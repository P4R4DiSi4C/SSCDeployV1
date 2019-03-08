using Microsoft.Win32;

namespace SSCDeploy.Actions
{
    public class Regional
    {
        static RegistryKey regional_key = Registry.CurrentUser.OpenSubKey("Control Panel\\International", true);

        public static void Set_Thousands_Separator()
        {
            regional_key.SetValue("sThousand", "'");
            regional_key.Close();
        }

        public static void Set_Decimal_Separator()
        {
            regional_key.SetValue("sDecimal", ".");
            regional_key.Close();
        }
    }
}
