using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Mandelbrot
{
    /// <summary>
    /// Behold. Mandelbrot fractal. Source of infinite joy.
    /// </summary>
    partial class MandelbrotWindow
    {
        Bitmap _mandelbrotBitmap; // Cache for the current visible part of the Mandelbrot plane.
        private double _centerX, _centerY, _scaling, _drawX, _drawY;
        private ushort _iterations, _mousePosX, _mousePosY, _antiAliasing, _colorRed, _colorGreen, _colorBlue, _toProcess, _bitmapSize = 600, _renderChunks = 10;
        private bool _mandelMoving, _parametersChanged, _isCalculating;
        private DateTime _start;
        private IList<MandelbrotPlace> _mandelbrotPlaces;

        public MandelbrotWindow()
        {
            InitializeComponent();

            // Hardcoded Mandelbrot presets, interesting images can be seen at these coordinates.
            _mandelbrotPlaces = new Collection<MandelbrotPlace>(new[] {
                new MandelbrotPlace("Default", -0.5, 0, 0.0025, 400, 2, 2, 3, 5),
                new MandelbrotPlace("Waves", -0.59836573600769, -0.664236764907637, 1.9073486328125E-08, 2400, 2, 2, 3, 5),
                new MandelbrotPlace("Weird DNA", 0.384192199707031, -0.0985696411132812, 0.762939453125E-07, 800, 2, 10, 1, 5),
                new MandelbrotPlace("Dinosaur", -0.531610422134399, -0.668436431884766, 4.76837158203125E-09, 2200, 2, 6, 8, 1),
                new MandelbrotPlace("Bat", -0.53160898680031, -0.668437485636351, 1.818989403545855E-14, 2200, 2, 4, 7, 3),
                new MandelbrotPlace("Paint splash", -1.94141374199284, -0.00502002773871919, 0.90949470177293E-14, 400, 2, 1, 3, 5),
                new MandelbrotPlace("Hypnotic", -0.7464555, 0.1151315, 1.875E-06, 3000, 2, 5, 8, 10),
                new MandelbrotPlace("Back2Black", -1.27832725032806, 0.0724904097795486, 4.053115844726565E-11, 850, 2, 1, 1, 1)
            });

            // If the screen is not highres then adjust scaling.
            if (CreateGraphics().DpiX == 96)
                foreach (var place in _mandelbrotPlaces)
                    place.Scaling *= 2;
            
            // Add all MandelbrotPlaces to the dropdown.
            for (var i = 1; i < _mandelbrotPlaces.Count; i++)
                comboBoxPreset.Items.Add(_mandelbrotPlaces[i].Name);
            
            // Set and load default Mandelbrot place.
            SetDefaults();
        }

        /// <summary>
        /// Load defaults settings.
        /// </summary>
        private void SetDefaults()
        {
            _parametersChanged = true;
            comboBoxPreset.Text = _mandelbrotPlaces.ElementAt(0).Name;
        }

        /// <summary>
        /// Load MandelbrotPlace presest.
        /// </summary>
        /// <param name="place">The MandelbrotPlace to set.</param>
        private void SetPreset(MandelbrotPlace place)
        {
            _centerX = place.CenterX;
            textBoxCenterX.Text = place.CenterX.ToString();
            _centerY = place.CenterY;
            textBoxCenterY.Text = place.CenterY.ToString();
            _scaling = place.Scaling;
            textBoxScale.Text = place.Scaling.ToString();
            _iterations = place.Iterations;
            numericUpDownIterations.Value = place.Iterations;
            _antiAliasing = place.AntiAliasing;
            numericUpDownAntialiasing.Value = place.AntiAliasing;
            _colorRed = place.ColorRed;
            trackBarRed.Value = place.ColorRed;
            _colorGreen = place.ColorGreen;
            trackBarGreen.Value = place.ColorGreen;
            _colorBlue = place.ColorBlue;
            trackBarBlue.Value = place.ColorBlue;
            _toProcess = (ushort)(_renderChunks * _renderChunks);
        }

        /// <summary>
        /// Main paint event.
        /// </summary>
        private void pictureBoxMandel_Paint(object sender, PaintEventArgs e)
        {
            // Finish current calculation first before new repaint requests are handled (e.g. minimizing the window and restoring it fires new paint request).
            if (_isCalculating)
                return;

            // If no settings were changed there is no need to start a calculation.
            if (_parametersChanged)
            {
                PrepareFormElements();
                _isCalculating = true;
                var bw = new BackgroundWorker
                {
                    WorkerReportsProgress = true
                };
                bw.DoWork += BwDoWork;
                bw.ProgressChanged += BwProgressChanged;
                bw.RunWorkerCompleted += BwOperationCompleted;
                bw.RunWorkerAsync();
                return;
            }

            // If none of the settings has changed and there is already a bitmap in memory, just show this cached one.
            if (_mandelbrotBitmap != null)
                e.Graphics.DrawImage(_mandelbrotBitmap, 0, 0, pictureBoxMandel.Width, pictureBoxMandel.Height);
        }

      /// <summary>
      /// The required calculations to generate a new Mandelbrot bitmap.
      /// </summary>
        private void BwDoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            _start = DateTime.Now;
            _drawX = _centerX - (_bitmapSize * _scaling) / (2 * _antiAliasing);
            _drawY = _centerY - (_bitmapSize * _scaling) / (2 * _antiAliasing);
            _mandelbrotBitmap = new Bitmap(_bitmapSize, _bitmapSize, PixelFormat.Format24bppRgb);
            var rect = new Rectangle(0, 0, _mandelbrotBitmap.Width, _mandelbrotBitmap.Height);
            var data = _mandelbrotBitmap.LockBits(rect, ImageLockMode.WriteOnly, _mandelbrotBitmap.PixelFormat);
            const int depth = 3; // 3 bytes per pixel (RGB)
            var buffer = new byte[data.Width * data.Height * depth];
            var renderChunkWidth = data.Width / _renderChunks;
            var resetEvent = new ManualResetEvent(false);
            var progress = (int)_toProcess;

            // Divide the bitmap into parts and add each chunk to the ThreadPool for optimal parallel CPU usage.
            for (var x = 0; x < _renderChunks; x++)
                for (var y = 0; y < _renderChunks; y++)
                {
                    var startX = renderChunkWidth * x;
                    var startY = renderChunkWidth * y;
                    ThreadPool.QueueUserWorkItem(
                            delegate
                            {
                                for (var i = startX; i < startX + renderChunkWidth; i++)
                                    for (var j = startY; j < startY + renderChunkWidth; j++)
                                    {
                                        var mandelGetal = GiveMandelNumber(_drawX + _scaling * i / _antiAliasing, _drawY + _scaling * j / _antiAliasing);
                                        
                                        // The maximum number of iterations is set to prevent infinite calculations. When this number of iterations is reached to pixel is black.
                                        if (mandelGetal == _iterations)
                                            continue;

                                        // Colouring of the pixel.
                                        var offset = ((j * data.Height) + i) * depth;
                                        buffer[offset + 0] = Convert.ToByte(mandelGetal * _colorBlue % 255);
                                        buffer[offset + 1] = Convert.ToByte(mandelGetal * _colorGreen % 255);
                                        buffer[offset + 2] = Convert.ToByte(mandelGetal * _colorRed % 255);
                                    }

                                // Keep the user informed about the progress.
                                worker.ReportProgress(_toProcess - progress);
                                
                                // When all chunks are done we can say to the ThreadPool: "Thank you and goodbye!"
                                if (Interlocked.Decrement(ref progress) == 0)
                                    resetEvent.Set();
                            }, null);
                }

            resetEvent.WaitOne();
            Marshal.Copy(buffer, 0, data.Scan0, buffer.Length);
            _mandelbrotBitmap.UnlockBits(data);
        }

        /// <summary>
        /// Update the progressbar to inform the user about the progress.
        /// </summary>
        public void BwProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarMandel.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// When the backgroundworker has finished calculating a new bitmap we can update the picturebox.
        /// </summary>
        public void BwOperationCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBoxMandel.CreateGraphics().DrawImage(_mandelbrotBitmap, 0, 0, pictureBoxMandel.Width, pictureBoxMandel.Height);
            WrapUpFormElements(_start);
            UpdateFormFields();
            _isCalculating = false;
            pictureBoxMandel.Invalidate();
        }

        /// <summary>
        /// This is the core function where the fractal magic happens. It calculates for the given coordinates in the complex plane the mandel number which is used for colouring.
        /// </summary>
        /// <param name="x">Real number.</param>
        /// <param name="y">Imaginairy number.</param>
        /// <returns>Complex number.</returns>
        private int GiveMandelNumber(double x, double y)
        {
            var mandelNumber = 0;
            double a = 0, aOld = 0, b = 0, c = 0;
            while (c <= 4 && mandelNumber < _iterations)
            {
                a = a * a - b * b + x;
                b = 2 * aOld * b + y;
                aOld = a;
                c = a * a + b * b;
                mandelNumber++;
            }
            return mandelNumber;
        }

        /// <summary>
        /// Prepare UI for rendering.
        /// </summary>
        private void PrepareFormElements()
        {
            _bitmapSize = (ushort)(pictureBoxMandel.Width * _antiAliasing);
            progressBarMandel.Value = 0;
            progressBarMandel.Maximum = _toProcess;
            progressBarMandel.Visible = true;
            buttonReset.Enabled = buttonRender.Enabled = trackBarRed.Enabled = trackBarGreen.Enabled = trackBarBlue.Enabled = numericUpDownAntialiasing.Enabled = numericUpDownIterations.Enabled = textBoxScale.Enabled = textBoxCenterY.Enabled = textBoxCenterX.Enabled = comboBoxPreset.Enabled = buttonSaveImage.Enabled = numericUpDownRenderChunks.Enabled = false;
        }

        /// <summary>
        /// Finish rendering and show elapsed time.
        /// </summary>
        /// <param name="start"></param>
        private void WrapUpFormElements(DateTime start)
        {
            var end = DateTime.Now - start;
            labelRenderPixels.Text = string.Format("{0} x {0} = {1} pixels (rgb)", _bitmapSize.ToString("#,###,###"), (_bitmapSize * _bitmapSize).ToString("#,###,###"));
            labelRenderTime.Text = string.Format("{0} mm:ss:ffff", end.ToString(@"mm\:ss\:ffff"));
            buttonReset.Enabled = buttonRender.Enabled = labelLine.Visible = labelRenderInfo.Visible = labelRenderPixels.Visible = labelRenderTime.Visible = labelLineSaveImage.Visible = buttonSaveImage.Visible = trackBarRed.Enabled = trackBarGreen.Enabled = trackBarBlue.Enabled = numericUpDownAntialiasing.Enabled = numericUpDownIterations.Enabled = textBoxScale.Enabled = textBoxCenterY.Enabled = textBoxCenterX.Enabled = comboBoxPreset.Enabled = buttonSaveImage.Enabled = numericUpDownRenderChunks.Enabled = true;
            progressBarMandel.Visible = _parametersChanged = false;
        }

        private void UpdateFormFields()
        {
            textBoxCenterX.Text = _centerX.ToString();
            textBoxCenterY.Text = _centerY.ToString();
            textBoxScale.Text = _scaling.ToString();
            numericUpDownIterations.Value = _iterations;
            numericUpDownAntialiasing.Value = _antiAliasing;
            trackBarRed.Value = _colorRed;
            trackBarGreen.Value = _colorGreen;
            trackBarBlue.Value = _colorBlue;
        }

        /// <summary>
        /// Read number or restore old value.
        /// </summary>
        private void textBoxMiddenX_Leave(object sender, EventArgs e)
        {
            try
            {
                _centerX = double.Parse(textBoxCenterX.Text.Replace(".", ","));
                _parametersChanged = true;
            }
            catch {
                textBoxCenterX.Text = _centerX.ToString();
            }
        }

        /// <summary>
        /// Read number or restore old value.
        /// </summary>
        private void textBoxMiddenY_Leave(object sender, EventArgs e)
        {
            try
            {
                _centerY = double.Parse(textBoxCenterY.Text.Replace(".", ","));
                _parametersChanged = true;
            }
            catch
            {
                textBoxCenterY.Text = _centerY.ToString();
            }
        }

        /// <summary>
        /// Read number or restore old value.
        /// </summary>
        private void textBoxSchaal_Leave(object sender, EventArgs e)
        {
            try
            {
                _scaling = double.Parse(textBoxScale.Text.Replace(".", ","));
                _parametersChanged = true;
            }
            catch
            {
                textBoxScale.Text = _scaling.ToString();
            }
        }

        private void numericUpDownMax_ValueChanged(object sender, EventArgs e)
        {
            _parametersChanged = true;
            _iterations = (ushort)numericUpDownIterations.Value;
        }

        /// <summary>
        /// Load preset settings and render image.
        /// </summary>
        private void comboBoxPreset_TextChanged(object sender, EventArgs e)
        {
            _parametersChanged = true;
            SetPreset(_mandelbrotPlaces.First(m => m.Name == comboBoxPreset.Text));
            UpdateFormFields();
            pictureBoxMandel.Invalidate();
       }

        private void numericUpDownAntialiasing_ValueChanged(object sender, EventArgs e)
        {
            _parametersChanged = true;
            _antiAliasing = (ushort)numericUpDownAntialiasing.Value;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }

        private void buttonRender_Click(object sender, EventArgs e)
        {
            if (_parametersChanged)
                pictureBoxMandel.Invalidate();
        }

        /// <summary>
        /// Store the current position of the mouse.
        /// </summary>
        private void pictureBoxMandel_MouseDown(object sender, MouseEventArgs e)
        {
            _mousePosX = (ushort)e.X;
            _mousePosY = (ushort)e.Y;
            _mandelMoving = true;
        }

        private void pictureBoxMandel_MouseUp(object sender, MouseEventArgs e)
        {
            _mandelMoving = false;
            if (_mousePosX == e.X || _mousePosY == e.Y)
                return;
            _parametersChanged = true;
            _centerX -= (e.X - _mousePosX) * _scaling;
            _centerY -= (e.Y - _mousePosY) * _scaling;
            pictureBoxMandel.Invalidate();
        }

        private void pictureBoxMandel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _parametersChanged = true;
            var center = pictureBoxMandel.Width / 2;
            _centerX += (e.X - center) * _scaling;
            _centerY += (e.Y - center) * _scaling;
            if (e.Button == MouseButtons.Left)
                _scaling /= 2;
            else
                _scaling *= 2;
            pictureBoxMandel.Invalidate();
        }

        /// <summary>
        /// Show mouse move cursor if mouse is moving and mouse is clicked.
        /// </summary>
        private void pictureBoxMandel_MouseMove(object sender, MouseEventArgs e)
        {
            pictureBoxMandel.Cursor = _mandelMoving ? Cursors.SizeAll : Cursors.Default;
            this.Text = string.Format("Mandelbrot ({0}, {1})", e.X, e.Y);
        }

        private void trackBarRed_ValueChanged(object sender, EventArgs e)
        {
            _parametersChanged = true;
            _colorRed = (ushort)trackBarRed.Value;
        }

        private void trackBarGreen_ValueChanged(object sender, EventArgs e)
        {
            _parametersChanged = true;
            _colorGreen = (ushort)trackBarGreen.Value;
        }

        private void trackBarBlue_ValueChanged(object sender, EventArgs e)
        {
            _parametersChanged = true;
            _colorBlue = (ushort)trackBarBlue.Value;
        }

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
            sfd.Title = "Save Mandelbrot Image";
            var format = ImageFormat.Png;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                var ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                _mandelbrotBitmap.Save(sfd.FileName, format);
            }
        }

        private void numericUpDownRenderChunks_ValueChanged(object sender, EventArgs e)
        {
            _parametersChanged = true;
            _renderChunks = (ushort)numericUpDownRenderChunks.Value;
            _toProcess = (ushort)(_renderChunks * _renderChunks);
        }
    }

    /// <summary>
    /// Class for defining the presets.
    /// </summary>
    public class MandelbrotPlace {
        private readonly string _name;
        private readonly double _centerX;
        private readonly double _centerY;
        private double _scaling;
        private readonly ushort _iterations;
        private readonly ushort _antiAliasing;
        private readonly ushort _colorRed;
        private readonly ushort _colorGreen;
        private readonly ushort _colorBlue;

        public MandelbrotPlace(string name, double centerX, double centerY, double scaling, ushort iterations, ushort antiAliasing, ushort colorRed, ushort colorGreen, ushort colorBlue) {
            _name = name;
            _centerX = centerX;
            _centerY = centerY;
            _scaling = scaling;
            _iterations = iterations;
            _antiAliasing = antiAliasing;
            _colorRed = colorRed;
            _colorGreen = colorGreen;
            _colorBlue = colorBlue;
        }

        public string Name { get { return _name; } }
        public double CenterX { get { return _centerX; } }
        public double CenterY { get { return _centerY; } }
        public double Scaling { get { return _scaling; } set { _scaling = value; } }
        public ushort Iterations { get { return _iterations; } }
        public ushort AntiAliasing { get { return _antiAliasing; } }
        public ushort ColorRed { get { return _colorRed; } }
        public ushort ColorGreen { get { return _colorGreen; } }
        public ushort ColorBlue { get { return _colorBlue; } }
    }
}