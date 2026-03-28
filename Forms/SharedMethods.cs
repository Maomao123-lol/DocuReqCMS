using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocuFlow_Reg.Forms
{
    internal class SharedMethods
    {
        public void LoadUserControl(UserControl uc, Panel panel)
        {
            uc.Dock = DockStyle.Fill;
            panel.Controls.Clear();
            panel.Controls.Add(uc);
        }
    }
}
