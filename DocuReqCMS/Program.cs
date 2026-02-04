using System;
using System.Windows.Forms;
using UCCRegistrarCMS;

namespace DocuReqCMS
{
    static class Program
    {
        public static TestingForm TestingForm { get; set; }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TestingForm = new TestingForm();
            TestingForm.Show();

            Application.Run(new LoginForm());
           
        }
    }
}
