using Microsoft.Win32;
using System;

namespace SSCDeploy.Actions
{
    public class Regional
    {

        public static void Set_Thousands_Separator()
        {
            using (var regional_key = Registry.CurrentUser.OpenSubKey(@"Control Panel\International",true))
            {
                regional_key.SetValue("sThousand", "'");
            }
        }

        public static void Set_Decimal_Separator()
        {
            using (var regional_key = Registry.CurrentUser.OpenSubKey(@"Control Panel\International",true))
            {
                regional_key.SetValue("sDecimal", ".");
            }
        }
    }
}
