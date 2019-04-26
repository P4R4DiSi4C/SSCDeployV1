using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;

namespace SSCDeploy.Actions
{
    public class Firefox
    {
        private static string PROGRAM_FILES = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
        private static DirectoryInfo mozillaDir = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla", "Firefox"));
        private static string JS_PATH = PROGRAM_FILES + @"\Mozilla Firefox\defaults\pref\all-epflssc.js";
        private static string CFG_PATH = PROGRAM_FILES + @"\Mozilla Firefox\firefoxssc.cfg";
        private static string DISTRIB_PATH = PROGRAM_FILES + @"\Mozilla Firefox\distribution";
        private static string POLICIES_PATH = PROGRAM_FILES + @"\Mozilla Firefox\distribution\policies.json";


        private static void CopyConfigFiles()
        {
            Directory.CreateDirectory(DISTRIB_PATH);
            File.Copy("Files\\policies.json", POLICIES_PATH, true);
            File.Copy("Files\\all-epflssc.js", JS_PATH, true);
            File.Copy("Files\\firefoxssc.cfg", CFG_PATH, true);
        }

        private static void CopyHandlers()
        {
            DirectoryInfo profilesDir = new DirectoryInfo(Path.Combine(mozillaDir.FullName, "Profiles"));

            if (profilesDir.EnumerateDirectories().Any())
            {
                foreach (DirectoryInfo dir in profilesDir.GetDirectories())
                {
                    File.Copy("Files\\handlers.json", Path.Combine(dir.FullName, "handlers.json"), true);
                }
            }
        }

        private static void KillFirefox()
        {
            bool iskilled = false;

            foreach (var process in Process.GetProcessesByName("firefox"))
            {
                process.Kill();
                iskilled = true;
            }

            if(iskilled)
                System.Threading.Thread.Sleep(3000);
        }

        private static void OpenFirefox()
        {
            using (Process firefox_p = new Process())
            {
                // You can start any process, HelloWorld is a do-nothing example.
                firefox_p.StartInfo.FileName = "firefox.exe";
                firefox_p.Start();
                System.Threading.Thread.Sleep(10000);
                firefox_p.CloseMainWindow();
            };
        }

        private static void ClearProfiles()
        {
            foreach (FileInfo file in mozillaDir.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in mozillaDir.GetDirectories())
            {
                dir.Delete(true);
            }
        }
        
        public static void Profilize()
        {
            try
            {
                KillFirefox();
                ClearProfiles();
                CopyConfigFiles();
                OpenFirefox();
                CopyHandlers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'application du profil Firefox: " + ex.ToString());
            }
        }
    }
}
