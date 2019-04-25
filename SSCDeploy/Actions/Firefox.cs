using System;
using System.IO.Compression;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace SSCDeploy.Actions
{
    public class Firefox
    {
        //        private static string[] mozillaPaths = { Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla", "Firefox"};
        //private static DirectoryInfo mozillaDir = new DirectoryInfo(Path.Combine(mozillaPaths));
        private static string JS_PATH = (Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)).ToString() + @"\Mozilla Firefox\defaults\pref\all-epflssc.js";
        private static string CFG_PATH = (Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)).ToString() + @"\Mozilla Firefox\firefoxssc.cfg";


        private static void CopyConfigFiles()
        {
            File.Copy("Files\\all-epflssc.js", JS_PATH, true);
            File.Copy("Files\\firefoxssc.cfg", CFG_PATH, true);
        }
        
        public static void Profilize()
        {
            try
            {
                foreach (var process in Process.GetProcessesByName("firefox"))
                {
                    process.Kill();
                }

                try
                {
                    CopyConfigFiles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("La copie des fichiers de configuration s'est mal déroulée: " + ex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'application du profil Firefox: " + ex.ToString());
            }
        }
    }
}
