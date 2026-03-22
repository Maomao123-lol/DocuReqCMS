using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace KIOSK.Request
{
    public partial class studentNumber : Form
    {
        private readonly Form1 _mainParent;
        private readonly requestForm _requestParent;
        private KIOSK.keyboardUI _keyboard;

        public studentNumber(requestForm requestParent, Form1 mainParent, string documentName, string requirements)
        {
            InitializeComponent();
            _requestParent = requestParent;
            _mainParent = mainParent;

            label4.Text = documentName;
            label2.Text = string.IsNullOrWhiteSpace(requirements)
                ? "No requirements."
                : string.Join("\n", requirements.Split(',')
                    .Select(r => "• " + r.Trim()));

            LoadKeyboard();

            button2.Click += (s, e) => _mainParent.LoadChild(new requestForm(_mainParent));
            button1.Click += BtnEnter_Click;
        }

        private void BtnEnter_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();

            if (!IsValidStudentNumber(input))
            {
                label6.ForeColor = Color.Red;
                label6.Text = "Invalid format. Use: 00000000-X";
                return;
            }

 
            label6.ForeColor = Color.Black;
            label6.Text = "Format: 00000000-X";

        }

        private bool IsValidStudentNumber(string input)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d{8}-[A-Za-z]$");
        }   

        private void LoadKeyboard()
        {
            _keyboard = new KIOSK.keyboardUI();
            _keyboard.Dock = DockStyle.Fill;
            _keyboard.SetTarget(textBox1);
            panel4.Controls.Add(_keyboard);
        }

        private void label1_Click(object sender, EventArgs e) { }
    }
}