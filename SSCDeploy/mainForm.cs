using SSCDeploy.Actions;
using System;
using System.Windows.Forms;

namespace SSCDeploy
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void magicBtn_Click(object sender, EventArgs e)
        {
            //SelectiveUSB.Disable();
            //Sleep.Disable();
            //IPV6.Disable();
            //Docking.Unpin();
            bool success = true;
            try
            {
                PTTB10.ChangeImagePathName("explorer.exe");
                success = PTTB10.PinUnpinTaskbar(@"C:\Program Files (x86)\Microsoft Office\Office16\OUTLOOK.EXE", true);
            }
            finally
            {
                PTTB10.RestoreImagePathName();
            }
        }
    }
}
