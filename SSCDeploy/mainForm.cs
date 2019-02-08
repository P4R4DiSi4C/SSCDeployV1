﻿using SSCDeploy.Actions;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSCDeploy
{
    public partial class mainForm : Form
    {
        private const int MAX_STEPS = 10;

        public mainForm()
        {
            InitializeComponent();
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

            progress.Report(new DeployProgressReport { CurrentProgressAmount = 9 * 100 / MAX_STEPS, CurrentProgressMessage = "Désinstallation de Onedrive..." });
            Onedrive.Uninstall();

            progress.Report(new DeployProgressReport { CurrentProgressAmount = 10 * 100 / MAX_STEPS, CurrentProgressMessage = "Adobe par défaut S.V.P ..." });
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

        private void exit_btn_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }
    }
}
