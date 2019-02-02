using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;

namespace SSCDeploy.Actions
{
    public static class Docking
    {
        static List<string> WinAppsToUnpin = new List<string>
        {
            "Microsoft Edge",
            "Microsoft Store"
        };

        static Dictionary<string, string> AppsToPin = new Dictionary<string, string>()
        {
            //{ "IE", "aaaa" },
            //{ "FIREFOX", "aaaa" },
            { "OUTLOOK", @"C:\Program Files (x86)\Microsoft Office\root\Office16\OUTLOOK.EXE" },
            { "WORD", @"C:\Program Files (x86)\Microsoft Office\root\Office16\WINWORD.EXE" },
            { "EXCEL", @"C:\Program Files (x86)\Microsoft Office\root\Office16\EXCEL.EXE" },
            { "POWERPOINT", @"C:\Program Files (x86)\Microsoft Office\root\Office16\POWERPNT.EXE" },


        };

        public static void Pin()
        {
            Process p = new Process();
            ProcessStartInfo cmd = new ProcessStartInfo();
            cmd.FileName = "cmd.exe";
            cmd.RedirectStandardInput = true;
            cmd.UseShellExecute = false;
            cmd.CreateNoWindow = true;

            p.StartInfo = cmd;
            p.Start();

            using (StreamWriter sw = p.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    foreach (KeyValuePair <string,string> app in AppsToPin)
                    {
                        sw.WriteLine("syspin \"" + app.Value + "\" c:5386"); //unpin = c:5387
                    }
                }
            }

            p.WaitForExit();
            p.Close();
        }

        public static void Unpin()
        {
            using (PowerShell powershell_Inst = PowerShell.Create())
            {
                foreach (string appName in WinAppsToUnpin)
                {
                    powershell_Inst.AddScript("((New-Object -Com Shell.Application).NameSpace('shell:::{4234d49b-0245-4df3-b780-3893943456e1}').Items() | ?{$_.Name -eq '"+ appName +"'}).Verbs() | ?{$_.Name.replace('&','') -match 'Désépingler de la barre des tâches'} | %{$_.DoIt(); $exec = $true}");
                }

                Collection<PSObject> PSOutput = powershell_Inst.Invoke();
            }
        }
    }
}
