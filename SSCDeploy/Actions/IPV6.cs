using System.Collections.ObjectModel;
using System.Management.Automation;

namespace SSCDeploy.Actions
{

    public static class IPV6
    {

        public static void Disable()
        {
            using (PowerShell powershell_Inst = PowerShell.Create())
            {

                powershell_Inst.AddScript("Get-NetAdapterBinding -ComponentID 'ms_tcpip6' | disable-NetAdapterBinding -ComponentID ms_tcpip6 -PassThru");
                Collection<PSObject> PSOutput = powershell_Inst.Invoke();
            }
        }

        public static void Enable()
        {
            using (PowerShell powershell_Inst = PowerShell.Create())
            {

                powershell_Inst.AddScript("Get-NetAdapterBinding -ComponentID 'ms_tcpip6' | enable-NetAdapterBinding -ComponentID ms_tcpip6 -PassThru");
                Collection<PSObject> PSOutput = powershell_Inst.Invoke();
            }
        }
    }
}
