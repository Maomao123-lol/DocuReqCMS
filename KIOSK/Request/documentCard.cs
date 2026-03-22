using System;
using System.Drawing;
using System.Windows.Forms;

namespace KIOSK.Request
{
    public partial class documentCard : UserControl
    {
        public Action OnCardClicked { get; set; }

        public documentCard()
        {
            InitializeComponent();
            panel1.Click += (s, e) => OnCardClicked?.Invoke();
            label1.Click += (s, e) => OnCardClicked?.Invoke();
        }

        public string DocumentName
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(91, 208, 102);
        }
    }
}