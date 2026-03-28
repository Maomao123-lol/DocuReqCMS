using KIOSK.Request;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace KIOSK
{
    public partial class Form1 : Form
    {
        private Form _activeChild;
        private Timer _idleTimer;
        private const int IdleSeconds = 20;

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
                Form previousPage = _activeChild;
                Func<Form> recreate = () =>
                {
                    if (previousPage is preChoice prev)
                        return new preChoice(this, prev.ClassPrefix, prev.Classification);
                    if (previousPage is studentClassification) return new studentClassification(this);
                    if (previousPage is startPage) return new startPage(this);
                    if (previousPage is thankPage) return new thankPage(this);
                    if (previousPage is requestForm prevReq) return new requestForm(this, prevReq.ClassPrefix, prevReq.Classification);
                    return new startPage(this);
                };
                LoadChild(new warning(this, recreate));
            };
        }
        public void LoadChild(Form form)
        {
            Form previousChild = _activeChild;
            _activeChild = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel3.Controls.Add(form);
            form.BringToFront();
            form.Show();
            if (previousChild != null && !previousChild.IsDisposed)
                previousChild.Close();
            if (_idleTimer != null && !(form is warning))
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