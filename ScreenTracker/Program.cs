using System;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace ScreenTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    Assembly.GetExecutingAssembly().GetName().Name);
                Directory.CreateDirectory(path);
                while (true)
                {

                    var nameStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
                    Console.WriteLine($"Capturing {nameStamp}");
                    var fileName = System.IO.Path.Combine(path, nameStamp + ".jpg");
                    ScreenCapture.CaptureScreenToFile(fileName, ImageFormat.Jpeg);
                    Task.Delay(new TimeSpan(0, 5, 0)).Wait();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
