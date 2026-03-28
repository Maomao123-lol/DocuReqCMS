using System;
using System.Linq;
using System.Windows.Forms;

namespace KIOSK
{
    public partial class keyboardUI : UserControl
    {
        private TextBox _targetTextBox;

        public keyboardUI()
        {
            InitializeComponent();
            WireButtons();
        }

        public void SetTarget(TextBox target)
        {
            _targetTextBox = target;
        }

        private void WireButtons()
        {
            foreach (TableLayoutPanel tlp in panel1.Controls.OfType<TableLayoutPanel>())
            {
                foreach (Button btn in tlp.Controls.OfType<Button>())
                {
                    btn.Click += Btn_Click;
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (_targetTextBox == null) return;

            var btn = (Button)sender;

            switch (btn.Name)
            {
                case "button41":
                    _targetTextBox.Text = "";
                    break;

                case "button42":
                    if (_targetTextBox.Text.Length > 0)
                        _targetTextBox.Text = _targetTextBox.Text
                            .Substring(0, _targetTextBox.Text.Length - 1);
                    break;

                case "button38":
                    _targetTextBox.Text += " ";
                    break;

                default:
                    _targetTextBox.Text += btn.Text;
                    break;
            }

            _targetTextBox.SelectionStart = _targetTextBox.Text.Length;
        }
    }
}