using System.Windows.Forms;

namespace Mandelbrot
{
    partial class MandelbrotWindow : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MandelbrotWindow));
      this.labelMiddenX = new System.Windows.Forms.Label();
      this.labelMiddenY = new System.Windows.Forms.Label();
      this.labelSchaal = new System.Windows.Forms.Label();
      this.labelMax = new System.Windows.Forms.Label();
      this.labelPlaces = new System.Windows.Forms.Label();
      this.textBoxCenterX = new System.Windows.Forms.TextBox();
      this.textBoxCenterY = new System.Windows.Forms.TextBox();
      this.textBoxScale = new System.Windows.Forms.TextBox();
      this.comboBoxPreset = new System.Windows.Forms.ComboBox();
      this.groupBoxSettings = new System.Windows.Forms.GroupBox();
      this.numericUpDownRenderChunks = new System.Windows.Forms.NumericUpDown();
      this.labelrenderChunks = new System.Windows.Forms.Label();
      this.labelLineSaveImage = new System.Windows.Forms.Label();
      this.buttonSaveImage = new System.Windows.Forms.Button();
      this.labelLine = new System.Windows.Forms.Label();
      this.labelRed = new System.Windows.Forms.Label();
      this.labelGreen = new System.Windows.Forms.Label();
      this.labelBlue = new System.Windows.Forms.Label();
      this.trackBarBlue = new System.Windows.Forms.TrackBar();
      this.trackBarGreen = new System.Windows.Forms.TrackBar();
      this.trackBarRed = new System.Windows.Forms.TrackBar();
      this.labelRenderTime = new System.Windows.Forms.Label();
      this.labelRenderPixels = new System.Windows.Forms.Label();
      this.labelRenderInfo = new System.Windows.Forms.Label();
      this.numericUpDownIterations = new System.Windows.Forms.NumericUpDown();
      this.numericUpDownAntialiasing = new System.Windows.Forms.NumericUpDown();
      this.progressBarMandel = new System.Windows.Forms.ProgressBar();
      this.labelAntiAliasing = new System.Windows.Forms.Label();
      this.buttonRender = new System.Windows.Forms.Button();
      this.buttonReset = new System.Windows.Forms.Button();
      this.pictureBoxMandel = new System.Windows.Forms.PictureBox();
      this.groupBoxSettings.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRenderChunks)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarBlue)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarGreen)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarRed)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIterations)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAntialiasing)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMandel)).BeginInit();
      this.SuspendLayout();
      // 
      // labelMiddenX
      // 
      this.labelMiddenX.AutoSize = true;
      this.labelMiddenX.Location = new System.Drawing.Point(10, 56);
      this.labelMiddenX.Name = "labelMiddenX";
      this.labelMiddenX.Size = new System.Drawing.Size(46, 13);
      this.labelMiddenX.TabIndex = 6;
      this.labelMiddenX.Text = "Center x";
      // 
      // labelMiddenY
      // 
      this.labelMiddenY.AutoSize = true;
      this.labelMiddenY.Location = new System.Drawing.Point(10, 82);
      this.labelMiddenY.Name = "labelMiddenY";
      this.labelMiddenY.Size = new System.Drawing.Size(46, 13);
      this.labelMiddenY.TabIndex = 7;
      this.labelMiddenY.Text = "Center y";
      // 
      // labelSchaal
      // 
      this.labelSchaal.AutoSize = true;
      this.labelSchaal.Location = new System.Drawing.Point(10, 108);
      this.labelSchaal.Name = "labelSchaal";
      this.labelSchaal.Size = new System.Drawing.Size(34, 13);
      this.labelSchaal.TabIndex = 8;
      this.labelSchaal.Text = "Scale";
      // 
      // labelMax
      // 
      this.labelMax.AutoSize = true;
      this.labelMax.Location = new System.Drawing.Point(10, 134);
      this.labelMax.Name = "labelMax";
      this.labelMax.Size = new System.Drawing.Size(50, 13);
      this.labelMax.TabIndex = 9;
      this.labelMax.Text = "Iterations";
      // 
      // labelPlaces
      // 
      this.labelPlaces.AutoSize = true;
      this.labelPlaces.Location = new System.Drawing.Point(10, 30);
      this.labelPlaces.Name = "labelPlaces";
      this.labelPlaces.Size = new System.Drawing.Size(63, 13);
      this.labelPlaces.TabIndex = 10;
      this.labelPlaces.Text = "Load preset";
      // 
      // textBoxCenterX
      // 
      this.textBoxCenterX.Location = new System.Drawing.Point(83, 53);
      this.textBoxCenterX.Name = "textBoxCenterX";
      this.textBoxCenterX.Size = new System.Drawing.Size(119, 20);
      this.textBoxCenterX.TabIndex = 1;
      this.textBoxCenterX.Text = "-0,5";
      this.textBoxCenterX.Leave += new System.EventHandler(this.textBoxMiddenX_Leave);
      // 
      // textBoxCenterY
      // 
      this.textBoxCenterY.Location = new System.Drawing.Point(83, 79);
      this.textBoxCenterY.Name = "textBoxCenterY";
      this.textBoxCenterY.Size = new System.Drawing.Size(119, 20);
      this.textBoxCenterY.TabIndex = 2;
      this.textBoxCenterY.Text = "0";
      this.textBoxCenterY.Leave += new System.EventHandler(this.textBoxMiddenY_Leave);
      // 
      // textBoxScale
      // 
      this.textBoxScale.Location = new System.Drawing.Point(83, 105);
      this.textBoxScale.Name = "textBoxScale";
      this.textBoxScale.Size = new System.Drawing.Size(119, 20);
      this.textBoxScale.TabIndex = 3;
      this.textBoxScale.Text = "0,0025";
      this.textBoxScale.Leave += new System.EventHandler(this.textBoxSchaal_Leave);
      // 
      // comboBoxPreset
      // 
      this.comboBoxPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboBoxPreset.FormattingEnabled = true;
      this.comboBoxPreset.Items.AddRange(new object[] {
            "Default"});
      this.comboBoxPreset.Location = new System.Drawing.Point(83, 27);
      this.comboBoxPreset.Name = "comboBoxPreset";
      this.comboBoxPreset.Size = new System.Drawing.Size(119, 21);
      this.comboBoxPreset.TabIndex = 0;
      this.comboBoxPreset.TextChanged += new System.EventHandler(this.comboBoxPreset_TextChanged);
      // 
      // groupBoxSettings
      // 
      this.groupBoxSettings.Controls.Add(this.numericUpDownRenderChunks);
      this.groupBoxSettings.Controls.Add(this.labelrenderChunks);
      this.groupBoxSettings.Controls.Add(this.labelLineSaveImage);
      this.groupBoxSettings.Controls.Add(this.buttonSaveImage);
      this.groupBoxSettings.Controls.Add(this.labelLine);
      this.groupBoxSettings.Controls.Add(this.labelRed);
      this.groupBoxSettings.Controls.Add(this.labelGreen);
      this.groupBoxSettings.Controls.Add(this.labelBlue);
      this.groupBoxSettings.Controls.Add(this.trackBarBlue);
      this.groupBoxSettings.Controls.Add(this.trackBarGreen);
      this.groupBoxSettings.Controls.Add(this.trackBarRed);
      this.groupBoxSettings.Controls.Add(this.labelRenderTime);
      this.groupBoxSettings.Controls.Add(this.labelRenderPixels);
      this.groupBoxSettings.Controls.Add(this.labelRenderInfo);
      this.groupBoxSettings.Controls.Add(this.numericUpDownIterations);
      this.groupBoxSettings.Controls.Add(this.numericUpDownAntialiasing);
      this.groupBoxSettings.Controls.Add(this.progressBarMandel);
      this.groupBoxSettings.Controls.Add(this.labelAntiAliasing);
      this.groupBoxSettings.Controls.Add(this.buttonRender);
      this.groupBoxSettings.Controls.Add(this.comboBoxPreset);
      this.groupBoxSettings.Controls.Add(this.buttonReset);
      this.groupBoxSettings.Controls.Add(this.labelPlaces);
      this.groupBoxSettings.Controls.Add(this.labelMiddenX);
      this.groupBoxSettings.Controls.Add(this.labelSchaal);
      this.groupBoxSettings.Controls.Add(this.textBoxCenterX);
      this.groupBoxSettings.Controls.Add(this.labelMiddenY);
      this.groupBoxSettings.Controls.Add(this.textBoxScale);
      this.groupBoxSettings.Controls.Add(this.textBoxCenterY);
      this.groupBoxSettings.Controls.Add(this.labelMax);
      this.groupBoxSettings.Location = new System.Drawing.Point(620, 10);
      this.groupBoxSettings.Name = "groupBoxSettings";
      this.groupBoxSettings.Size = new System.Drawing.Size(214, 600);
      this.groupBoxSettings.TabIndex = 12;
      this.groupBoxSettings.TabStop = false;
      this.groupBoxSettings.Text = "Settings";
      // 
      // numericUpDownRenderChunks
      // 
      this.numericUpDownRenderChunks.Location = new System.Drawing.Point(83, 184);
      this.numericUpDownRenderChunks.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.numericUpDownRenderChunks.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDownRenderChunks.Name = "numericUpDownRenderChunks";
      this.numericUpDownRenderChunks.Size = new System.Drawing.Size(119, 20);
      this.numericUpDownRenderChunks.TabIndex = 26;
      this.numericUpDownRenderChunks.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numericUpDownRenderChunks.ValueChanged += new System.EventHandler(this.numericUpDownRenderChunks_ValueChanged);
      // 
      // labelrenderChunks
      // 
      this.labelrenderChunks.AutoSize = true;
      this.labelrenderChunks.Location = new System.Drawing.Point(10, 186);
      this.labelrenderChunks.Name = "labelrenderChunks";
      this.labelrenderChunks.Size = new System.Drawing.Size(43, 13);
      this.labelrenderChunks.TabIndex = 27;
      this.labelrenderChunks.Text = "Chunks";
      // 
      // labelLineSaveImage
      // 
      this.labelLineSaveImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labelLineSaveImage.Location = new System.Drawing.Point(11, 406);
      this.labelLineSaveImage.Name = "labelLineSaveImage";
      this.labelLineSaveImage.Size = new System.Drawing.Size(191, 2);
      this.labelLineSaveImage.TabIndex = 25;
      this.labelLineSaveImage.Visible = false;
      // 
      // buttonSaveImage
      // 
      this.buttonSaveImage.Location = new System.Drawing.Point(11, 423);
      this.buttonSaveImage.Name = "buttonSaveImage";
      this.buttonSaveImage.Size = new System.Drawing.Size(90, 23);
      this.buttonSaveImage.TabIndex = 24;
      this.buttonSaveImage.Text = "Save as image";
      this.buttonSaveImage.UseVisualStyleBackColor = true;
      this.buttonSaveImage.Visible = false;
      this.buttonSaveImage.Click += new System.EventHandler(this.buttonSaveImage_Click);
      // 
      // labelLine
      // 
      this.labelLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.labelLine.Location = new System.Drawing.Point(11, 319);
      this.labelLine.Name = "labelLine";
      this.labelLine.Size = new System.Drawing.Size(191, 2);
      this.labelLine.TabIndex = 17;
      this.labelLine.Visible = false;
      // 
      // labelRed
      // 
      this.labelRed.AutoSize = true;
      this.labelRed.Location = new System.Drawing.Point(10, 215);
      this.labelRed.Name = "labelRed";
      this.labelRed.Size = new System.Drawing.Size(27, 13);
      this.labelRed.TabIndex = 23;
      this.labelRed.Text = "Red";
      // 
      // labelGreen
      // 
      this.labelGreen.AutoSize = true;
      this.labelGreen.Location = new System.Drawing.Point(10, 246);
      this.labelGreen.Name = "labelGreen";
      this.labelGreen.Size = new System.Drawing.Size(36, 13);
      this.labelGreen.TabIndex = 22;
      this.labelGreen.Text = "Green";
      // 
      // labelBlue
      // 
      this.labelBlue.AutoSize = true;
      this.labelBlue.Location = new System.Drawing.Point(10, 279);
      this.labelBlue.Name = "labelBlue";
      this.labelBlue.Size = new System.Drawing.Size(28, 13);
      this.labelBlue.TabIndex = 21;
      this.labelBlue.Text = "Blue";
      // 
      // trackBarBlue
      // 
      this.trackBarBlue.Location = new System.Drawing.Point(75, 277);
      this.trackBarBlue.Minimum = 1;
      this.trackBarBlue.Name = "trackBarBlue";
      this.trackBarBlue.Size = new System.Drawing.Size(133, 45);
      this.trackBarBlue.TabIndex = 8;
      this.trackBarBlue.Value = 5;
      this.trackBarBlue.ValueChanged += new System.EventHandler(this.trackBarBlue_ValueChanged);
      // 
      // trackBarGreen
      // 
      this.trackBarGreen.Location = new System.Drawing.Point(75, 244);
      this.trackBarGreen.Minimum = 1;
      this.trackBarGreen.Name = "trackBarGreen";
      this.trackBarGreen.Size = new System.Drawing.Size(133, 45);
      this.trackBarGreen.TabIndex = 7;
      this.trackBarGreen.Value = 3;
      this.trackBarGreen.ValueChanged += new System.EventHandler(this.trackBarGreen_ValueChanged);
      // 
      // trackBarRed
      // 
      this.trackBarRed.Location = new System.Drawing.Point(75, 213);
      this.trackBarRed.Minimum = 1;
      this.trackBarRed.Name = "trackBarRed";
      this.trackBarRed.Size = new System.Drawing.Size(133, 45);
      this.trackBarRed.TabIndex = 6;
      this.trackBarRed.Value = 2;
      this.trackBarRed.ValueChanged += new System.EventHandler(this.trackBarRed_ValueChanged);
      // 
      // labelRenderTime
      // 
      this.labelRenderTime.AutoSize = true;
      this.labelRenderTime.Location = new System.Drawing.Point(10, 375);
      this.labelRenderTime.Name = "labelRenderTime";
      this.labelRenderTime.Size = new System.Drawing.Size(0, 13);
      this.labelRenderTime.TabIndex = 19;
      this.labelRenderTime.Visible = false;
      // 
      // labelRenderPixels
      // 
      this.labelRenderPixels.AutoSize = true;
      this.labelRenderPixels.Location = new System.Drawing.Point(10, 354);
      this.labelRenderPixels.Name = "labelRenderPixels";
      this.labelRenderPixels.Size = new System.Drawing.Size(0, 13);
      this.labelRenderPixels.TabIndex = 18;
      this.labelRenderPixels.Visible = false;
      // 
      // labelRenderInfo
      // 
      this.labelRenderInfo.AutoSize = true;
      this.labelRenderInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelRenderInfo.Location = new System.Drawing.Point(10, 333);
      this.labelRenderInfo.Name = "labelRenderInfo";
      this.labelRenderInfo.Size = new System.Drawing.Size(73, 13);
      this.labelRenderInfo.TabIndex = 16;
      this.labelRenderInfo.Text = "Render info";
      this.labelRenderInfo.Visible = false;
      // 
      // numericUpDownIterations
      // 
      this.numericUpDownIterations.Location = new System.Drawing.Point(83, 132);
      this.numericUpDownIterations.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
      this.numericUpDownIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDownIterations.Name = "numericUpDownIterations";
      this.numericUpDownIterations.Size = new System.Drawing.Size(119, 20);
      this.numericUpDownIterations.TabIndex = 4;
      this.numericUpDownIterations.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
      this.numericUpDownIterations.ValueChanged += new System.EventHandler(this.numericUpDownMax_ValueChanged);
      // 
      // numericUpDownAntialiasing
      // 
      this.numericUpDownAntialiasing.Location = new System.Drawing.Point(83, 158);
      this.numericUpDownAntialiasing.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
      this.numericUpDownAntialiasing.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDownAntialiasing.Name = "numericUpDownAntialiasing";
      this.numericUpDownAntialiasing.Size = new System.Drawing.Size(119, 20);
      this.numericUpDownAntialiasing.TabIndex = 5;
      this.numericUpDownAntialiasing.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      this.numericUpDownAntialiasing.ValueChanged += new System.EventHandler(this.numericUpDownAntialiasing_ValueChanged);
      // 
      // progressBarMandel
      // 
      this.progressBarMandel.Location = new System.Drawing.Point(13, 526);
      this.progressBarMandel.Name = "progressBarMandel";
      this.progressBarMandel.Size = new System.Drawing.Size(188, 23);
      this.progressBarMandel.TabIndex = 14;
      this.progressBarMandel.Value = 100;
      this.progressBarMandel.Visible = false;
      // 
      // labelAntiAliasing
      // 
      this.labelAntiAliasing.AutoSize = true;
      this.labelAntiAliasing.Location = new System.Drawing.Point(10, 160);
      this.labelAntiAliasing.Name = "labelAntiAliasing";
      this.labelAntiAliasing.Size = new System.Drawing.Size(63, 13);
      this.labelAntiAliasing.TabIndex = 15;
      this.labelAntiAliasing.Text = "Anti-aliasing";
      // 
      // buttonRender
      // 
      this.buttonRender.Location = new System.Drawing.Point(112, 564);
      this.buttonRender.Name = "buttonRender";
      this.buttonRender.Size = new System.Drawing.Size(90, 23);
      this.buttonRender.TabIndex = 10;
      this.buttonRender.Text = "Render";
      this.buttonRender.UseVisualStyleBackColor = true;
      this.buttonRender.Click += new System.EventHandler(this.buttonRender_Click);
      // 
      // buttonReset
      // 
      this.buttonReset.Location = new System.Drawing.Point(12, 564);
      this.buttonReset.Name = "buttonReset";
      this.buttonReset.Size = new System.Drawing.Size(94, 23);
      this.buttonReset.TabIndex = 9;
      this.buttonReset.Text = "Reset";
      this.buttonReset.UseVisualStyleBackColor = true;
      this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
      // 
      // pictureBoxMandel
      // 
      this.pictureBoxMandel.BackColor = System.Drawing.SystemColors.ControlLight;
      this.pictureBoxMandel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.pictureBoxMandel.Location = new System.Drawing.Point(10, 10);
      this.pictureBoxMandel.Name = "pictureBoxMandel";
      this.pictureBoxMandel.Size = new System.Drawing.Size(600, 600);
      this.pictureBoxMandel.TabIndex = 13;
      this.pictureBoxMandel.TabStop = false;
      this.pictureBoxMandel.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMandel_Paint);
      this.pictureBoxMandel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMandel_MouseDoubleClick);
      this.pictureBoxMandel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMandel_MouseDown);
      this.pictureBoxMandel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMandel_MouseMove);
      this.pictureBoxMandel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMandel_MouseUp);
      // 
      // MandelbrotWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(845, 620);
      this.Controls.Add(this.pictureBoxMandel);
      this.Controls.Add(this.groupBoxSettings);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimumSize = new System.Drawing.Size(856, 558);
      this.Name = "MandelbrotWindow";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Mandelbrot";
      this.groupBoxSettings.ResumeLayout(false);
      this.groupBoxSettings.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRenderChunks)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarBlue)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarGreen)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.trackBarRed)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIterations)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAntialiasing)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMandel)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxPreset;
        private System.Windows.Forms.Label labelMiddenX;
        private System.Windows.Forms.Label labelMiddenY;
        private System.Windows.Forms.Label labelSchaal;
        private System.Windows.Forms.Label labelMax;
        private System.Windows.Forms.Label labelPlaces;
        private System.Windows.Forms.TextBox textBoxCenterX;
        private System.Windows.Forms.TextBox textBoxCenterY;
        private System.Windows.Forms.TextBox textBoxScale;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.PictureBox pictureBoxMandel;
        private System.Windows.Forms.ProgressBar progressBarMandel;
        private System.Windows.Forms.Button buttonRender;
        private System.Windows.Forms.Label labelAntiAliasing;
        private System.Windows.Forms.NumericUpDown numericUpDownAntialiasing;
        private System.Windows.Forms.NumericUpDown numericUpDownIterations;
        private Label labelLine;
        private Label labelRenderInfo;
        private Label labelRenderTime;
        private Label labelRenderPixels;
        private TrackBar trackBarGreen;
        private TrackBar trackBarBlue;
        private TrackBar trackBarRed;
        private Label labelRed;
        private Label labelGreen;
        private Label labelBlue;
        private Label labelLineSaveImage;
        private Button buttonSaveImage;
        private NumericUpDown numericUpDownRenderChunks;
        private Label labelrenderChunks;
    }
}