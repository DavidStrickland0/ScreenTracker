using System.Windows.Forms;

namespace ScreenTracker
{
    using System;
    using System.Runtime.InteropServices;
    using System.Drawing;
    using System.Drawing.Imaging;

        /// <summary>
        /// Provides functions to capture the entire screen, or a particular window, and save it to a file.
        /// </summary>
        public class ScreenCapture
        {

            /// <summary>
            /// Captures a screen shot of the entire desktop, and saves it to a file
            /// </summary>
            /// <param name="filename"></param>
            /// <param name="format"></param>
            public static void CaptureScreenToFile(string filename, ImageFormat format)
            {
                
                using var bitmap = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(SystemInformation.VirtualScreen.Location.X, SystemInformation.VirtualScreen.Location.Y, 0, 0,
                        bitmap.Size, CopyPixelOperation.SourceCopy);
                }
                bitmap.Save(filename,ImageFormat.Jpeg);
            }

        }
    
}
