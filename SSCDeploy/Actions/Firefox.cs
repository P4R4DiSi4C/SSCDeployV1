using System;
using System.IO.Compression;
using System.IO;
using System.Windows.Forms;

namespace SSCDeploy.Actions
{
    public class Firefox
    {
        private static string[] mozillaPaths = { Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Mozilla", "Firefox"};
        private static DirectoryInfo mozillaDir = new DirectoryInfo(Path.Combine(mozillaPaths));

        private static void DeleteProfiles()
        {
            foreach (DirectoryInfo dir in mozillaDir.GetDirectories())
            {
                dir.Delete(true);
            }

            foreach (FileInfo file in mozillaDir.GetFiles())
            {
                file.Delete();
            }
        }
        
        private static void ExtractProfile()
        {
            ZipFile.ExtractToDirectory("Files\\FirefoxProfile.zip", mozillaDir.FullName);
        }

        public static void Profilize()
        {
            try
            {
                if (!Directory.Exists(mozillaDir.FullName))
                {
                    try
                    {
                        DirectoryInfo di = Directory.CreateDirectory(mozillaDir.FullName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la création du dossier Mozilla: " + ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        DeleteProfiles();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("La suppression du profil Firefox existant s'est mal déroulée: " + ex.ToString());
                    }
                }

                try
                {
                    ExtractProfile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("L'extraction du profil Firefox s'est mal déroulée: " + ex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'application du profil Firefox: " + ex.ToString());
            }
        }
    }
}
