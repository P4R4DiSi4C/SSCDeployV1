using System.Collections.ObjectModel;
using System.Management.Automation;

namespace SSCDeploy.Actions
{

    public static class IPV6
    {

        public static void Disable()
        {
            try
            {
                using (PowerShell powershell_Inst = PowerShell.Create())
                {

                    powershell_Inst.AddScript("Get-NetAdapterBinding -ComponentID 'ms_tcpip6' | disable-NetAdapterBinding -ComponentID ms_tcpip6 -PassThru");
                    Collection<PSObject> PSOutput = powershell_Inst.Invoke();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.ApplicationException("La désactivation de l'IPV6 s'est mal déroulée:", ex);
            }
        }

        public static void Enable()
        {
            using (PowerShell ps = PowerShell.Create())
            {

                ps.AddScript("Get-NetAdapterBinding -ComponentID 'ms_tcpip6' | enable-NetAdapterBinding -ComponentID ms_tcpip6 -PassThru");
                Collection<PSObject> PSOutput = ps.Invoke();
            }
        }
    }
}
