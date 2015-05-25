using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mandelbrot
{
    static class Entry
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Adding high resolution support (e.g. Retina MacBook).
            if (Environment.OSVersion.Version.Major >= 6)
                SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MandelbrotWindow());
        }

        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
    }
}