using System;
using System.IO.Compression;
using System.IO;

namespace SSCDeploy.Actions
{
    public class Firefox
    {
        private static string[] mozillaPaths = { Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Mozilla", "Firefox"};
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
                        throw new ApplicationException("Erreur lors de la création du dossier Mozilla:", ex);
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
                        throw new ApplicationException("La suppression du profil Firefox existant s'est mal déroulée:", ex);
                    }
                }

                try
                {
                    ExtractProfile();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("L'extraction du profile Firefox s'est mal déroulée:", ex);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erreur lors de l'application du profile Firefox:", ex);
            }
        }
    }
}
