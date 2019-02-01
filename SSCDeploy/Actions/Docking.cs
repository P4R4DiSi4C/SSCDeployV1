using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            { "IE", "aaaa" },
            { "FIREFOX", "aaaa" },
            { "OUTLOOK", "aaaa" },
            { "WORD", "aaaa" },
            { "EXCEL", "aaaa" },
            { "POWERPOINT", "aaaa" },


        };

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
