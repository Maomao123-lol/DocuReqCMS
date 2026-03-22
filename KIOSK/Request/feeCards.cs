using System;
using System.Windows.Forms;

namespace KIOSK.Request
{
    public partial class feeCards : UserControl
    {
        public Action OnCardClicked { get; set; }

        public feeCards()
        {
            InitializeComponent();
            panel1.Click += (s, e) => OnCardClicked?.Invoke();
            label1.Click += (s, e) => OnCardClicked?.Invoke();
        }

        public string FeeName
        {
            get => label1.Text;
            set => label1.Text = value;
        }


    }
}