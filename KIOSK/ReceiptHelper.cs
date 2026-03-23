using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KIOSK
{
    public static class ReceiptHelper
    {
        public static void Print(string queueNo, string serviceType)
        {
            int width = 350;
            int height = 300;

            using (var bmp = new Bitmap(width, height))
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                var fontHeader = new Font("MS PGothic", 9, FontStyle.Regular);
                var fontTitle = new Font("MS PGothic", 15, FontStyle.Bold);
                var fontQueue = new Font("MS Gothic", 50, FontStyle.Regular);
                var fontNormal = new Font("MS PGothic", 11, FontStyle.Regular);
                var fontSmall = new Font("MS PGothic", 11, FontStyle.Regular);
                var center = new StringFormat { Alignment = StringAlignment.Center };

                // Black border around receipt
                g.DrawRectangle(new Pen(Color.Black, 3), 5, 5, width - 10, height - 10);

                int y = 18;

                // University header
                g.DrawString("University of Caloocan City Registrar", fontHeader,
                    Brushes.Black, new RectangleF(0, y, width, 20), center);
                y += 25;

                // QUEUING NUMBER
                g.DrawString("QUEUING NUMBER", fontTitle, Brushes.Black,
                    new RectangleF(0, y, width, 30), center);
                y += 40;

                // Big queue number
                g.DrawString(queueNo, fontQueue, Brushes.Black,
                    new RectangleF(0, y, width, 90), center);
                y += 90;

                // Message
                g.DrawString("Please wait for your number", fontNormal, Brushes.Black,
                    new RectangleF(0, y, width, 25), center);
                y += 22;
                g.DrawString("to be called. Thank you!", fontNormal, Brushes.Black,
                    new RectangleF(0, y, width, 25), center);
                y += 35;

                // Date and time
                g.DrawString(DateTime.Now.ToString("MM-dd-yyyy"), fontSmall, Brushes.Black,
                    new RectangleF(20, y, width / 2 - 20, 20));
                g.DrawString(DateTime.Now.ToString("hh:mmtt"), fontSmall, Brushes.Black,
                    new RectangleF(width / 2, y, width / 2 - 20, 20));

                // Save and open
                string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Receipts");
                Directory.CreateDirectory(folder);
                string filePath = Path.Combine(folder,
                    $"Receipt_{queueNo}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
        }
    }
}