using MaterialSkin;
using MaterialSkin.Controls;
using SSCDeploy.Actions;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SSCDeploy
{
    public partial class mainForm : MaterialForm
    {
        private const int MAX_STEPS = 9;

        public mainForm()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        /// <summary>
        /// Fonction de déploiement
        /// </summary>
        /// <param name="progress">Objet pour le suivi du progrès</param>
        private void Deploy(IProgress<DeployProgressReport> progress)
        {
            progress.Report(new DeployProgressReport { CurrentProgressAmount = 1 * 100 / MAX_STEPS, CurrentProgressMessage = "Désactivation suspension sélective USB..." });
            SelectiveUSB.Disable();

            progress.Report(new DeployProgressReport { CurrentProgressAmount = 2 * 100 / MAX_STEPS, CurrentProgressMessage = "Désactivation mise en veille sous secteur..." });
            Sleep.Disable();

            progress.Report(new DeployProgressReport { CurrentProgressAmount = 3 * 100 / MAX_STEPS, CurrentProgressMessage = "Désactivation de l'IPV6..." });
            IPV6.Disable();

            progress.Report(new DeployProgressReport { CurrentProgressAmount = 4 * 100 / MAX_STEPS, CurrentProgressMessage = "Désépinglage des applications Microsoft..." });
            Docking.Unpin();

            progress.Report(new DeployProgressReport { CurrentProgressAmount = 5 * 100 / MAX_STEPS, CurrentProgressMessage = "Épinglage des applications par défaut..." });
            Docking.Pin();

            progress.Report(new DeployProgressReport { CurrentProgressAmount = 6 * 100 / MAX_STEPS, CurrentProgressMessage = "Mise en place du profil Firefox..." });
            Firefox.Profilize();
            
            progress.Report(new DeployProgressReport { CurrentProgressAmount = 7 * 100 / MAX_STEPS, CurrentProgressMessage = "Désactivation mise en veille cartes réseau..." });
            NICPowerSave.Disable();

            progress.Report(new DeployProgressReport { CurrentProgressAmount = 8 * 100 / MAX_STEPS, CurrentProgressMessage = "Désactivation mise en veille USB..." });
            USBPowerSave.Disable();

            progress.Report(new DeployProgressReport { CurrentProgressAmount = 9 * 100 / MAX_STEPS, CurrentProgressMessage = "Adobe par défaut S.V.P ..." });
            FileProps.OpenPDFDetails();
        }

        /// <summary>
        /// Bouton de déploiement
        /// </summary>
        private async void btn_deploy_Click(object sender, EventArgs e)
        {
            text_deploy_progress.Text = "";

            var progress_report = new Progress<DeployProgressReport>(progress =>
            {
                deploy_progressbar.Value = progress.CurrentProgressAmount;
                text_deploy_progress.Text += progress.CurrentProgressMessage + "\n";
            });

            // Run operation in another thread
            await Task.Run(() => Deploy(progress_report));

            // TODO: Do something after all calculations
            text_deploy_progress.Text += "Déploiement terminé";
        }

        private void btn_privacy_Click(object sender, EventArgs e)
        {
            Process.Start("ms-settings:privacy-general");
        }

        private void btn_default_Click(object sender, EventArgs e)
        {
            Process.Start("ms-settings:defaultapps");
        }

        private void btn_ie_Click(object sender, EventArgs e)
        {
            Process.Start("iexplore");
        }

        private void btn_onedrive_Click(object sender, EventArgs e)
        {
            Process.Start("appwiz.cpl");
        }
    }
}
