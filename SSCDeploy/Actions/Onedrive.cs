using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SSCDeploy.Actions
{
    public static class Onedrive
    {
        public static void Uninstall()
        {
            try
            {
                foreach (var process in Process.GetProcessesByName("OneDrive"))
                {
                    process.Kill();
                }

                Process p = new Process();
                ProcessStartInfo cmd = new ProcessStartInfo();
                cmd.FileName = "cmd.exe";
                cmd.RedirectStandardInput = true;
                cmd.UseShellExecute = false;
                cmd.CreateNoWindow = true;
                cmd.Arguments = "/C " + @"%SystemRoot%\SysWOW64\OneDriveSetup.exe" + " /uninstall";

                p.StartInfo = cmd;
                p.Start();
                p.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("La désinstallation de Onedrive s'est mal déroulée: " + ex.ToString());
            }
        }
    }
}
