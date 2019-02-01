using System.Diagnostics;

namespace SSCDeploy.Actions
{
    public static class PowerCFG
    {
        private const string POWER_CFG = "powercfg";

        public static void Power_CFG(string args)
        {
            Process.Start(POWER_CFG, args);
        }
    }
}
