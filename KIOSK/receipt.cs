using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace KIOSK
{
    public partial class receipt : Form
    {
        private readonly Form1 _parent;
        private string _queueNo;

        public receipt(Form1 parent, string queueNo, string serviceType)
        {
            InitializeComponent();
            _parent = parent;
            _queueNo = queueNo;

            label6.Text = "University of Caloocan City Registrar";
            label1.Text = serviceType.ToUpper();
            label2.Text = queueNo;
            label4.Text = DateTime.Now.ToString("MM-dd-yyyy");
            label5.Text = DateTime.Now.ToString("hh:mmtt");

            // Auto print then go back after 5 seconds
            var timer = new Timer { Interval = 5000 };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                _parent.LoadChild(new preChoice(_parent));
            };
            timer.Start();

            PrintReceipt();
        }

        private void PrintReceipt()
        {
            var pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("Receipt", 350, 300);
            pd.PrintPage += (s, e) =>
            {
                e.Graphics.DrawString(
                    $"University of Caloocan City Registrar\n\n" +
                    $"{label1.Text}\n\n" +
                    $"{_queueNo}\n\n" +
                    $"Please wait for your number\nto be called. Thank you!\n\n" +
                    $"{label4.Text}  {label5.Text}",
                    new Font("MS PGothic", 12),
                    Brushes.Black,
                    new RectangleF(10, 10, 330, 280)
                );
            };
            pd.Print();
        }
    }
}