using System;
using System.Windows.Forms;

namespace KIOSK
{
    public partial class Form1 : Form
    {
        private Form _activeChild;
        private Timer _idleTimer;
        private const int IdleSeconds = 10;

        public Form1()
        {
            InitializeComponent();
            LoadChild(new startPage(this));
            SetupIdleTimer();
        }

        private void SetupIdleTimer()
        {
            _idleTimer = new Timer();
            _idleTimer.Interval = IdleSeconds * 1000;
            _idleTimer.Tick += (s, e) =>
            {
                _idleTimer.Stop();
                LoadChild(new startPage(this));
            };
            _idleTimer.Start();

            Application.AddMessageFilter(new IdleMessageFilter(_idleTimer));
        }

        public void LoadChild(Form form)
        {
            if (_activeChild != null)
                _activeChild.Close();

            _activeChild = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel3.Controls.Add(form);
            form.BringToFront();
            form.Show();

            if (_idleTimer != null)
            {
                _idleTimer.Stop();
                _idleTimer.Start();
            }
        }
    }

    public class IdleMessageFilter : IMessageFilter
    {
        private readonly Timer _timer;

        public IdleMessageFilter(Timer timer)
        {
            _timer = timer;
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x200 || m.Msg == 0x201 || m.Msg == 0x100)
            {
                _timer.Stop();
                _timer.Start();
            }
            return false;
        }
    }
}