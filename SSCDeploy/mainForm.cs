using SSCDeploy.Actions;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace SSCDeploy
{
    public partial class mainForm : Form
    {
        private bool formLoaded;
        private bool ignore_radio_custom;
        private bool ignore_check;

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
            int max_steps = actions_groupbox.Controls.OfType<SpinCheckBox>().Count(c => c.Checked);
            int tasks_counter = 0;

            if (check_SelectUSB.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Désactivation suspension sélective USB..." });
                SelectiveUSB.Disable();
            }

            if (check_Sleep.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Désactivation mise en veille sous secteur..." });
                Sleep.Disable();
            }

            if (check_IPV6.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Désactivation de l'IPV6..." });
                IPV6.Disable();
            }

            if (check_unpin.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Désépinglage des applications Microsoft..." });
                Docking.Unpin();
            }

            if(check_pin.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Épinglage des applications par défaut..." });
                Docking.Pin();
            }

            if (check_Firefox.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Mise en place du profil Firefox..." });
                Firefox.Profilize();
            }

            if (check_NICSleep.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Désactivation mise en veille cartes réseau..." });
                NICPowerSave.Disable();
            }

            if (check_USBSleep.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Désactivation mise en veille USB..." });
                USBPowerSave.Disable();
            }

            if (check_OneDrive.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Désinstallation de Onedrive..." });
                Onedrive.Uninstall();
            }

            if (check_region.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Application options régionales..." });
                Regional.Set_Thousands_Separator();
                Regional.Set_Decimal_Separator();
            }

            if (check_Adobe.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Adobe par défaut S.V.P ..." });
                FileProps.OpenPDFDetails();
            }
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

        private void btn_Restart_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown.exe", "-r -t 00");
        }

        private void radiobuttons_checked_changed(object sender)
        {
            if (formLoaded)
            {
                int max_steps = presets_group.Controls.OfType<SpinRadioButton>().Count(c => c.Checked);
                ignore_check = true;
                SpinRadioButton clicked_radio = (SpinRadioButton)sender;

                foreach (SpinRadioButton radiobutton in presets_group.Controls.OfType<SpinRadioButton>())
                {
                    if(radiobutton == clicked_radio)
                    {
                        radiobutton.Enabled = false;
                    }
                    else
                    {
                        radiobutton.Enabled = true;
                    }
                }

                if (radio_new.Checked)
                {
                    foreach (SpinCheckBox action_checkbox in actions_groupbox.Controls.OfType<SpinCheckBox>())
                    {
                        action_checkbox.Checked = true;
                    }
                }
                else if (radio_update.Checked)
                {
                    foreach (SpinCheckBox action_checkbox in actions_groupbox.Controls.OfType<SpinCheckBox>())
                    {
                        action_checkbox.Checked = true;
                    }

                    check_Firefox.Checked = false;
                    check_unpin.Checked = false;
                    check_pin.Checked = false;
                }
                else if (radio_custom.Checked && !ignore_radio_custom)
                {
                    foreach (SpinCheckBox action_checkbox in actions_groupbox.Controls.OfType<SpinCheckBox>())
                    {
                        action_checkbox.Checked = false;
                    }
                }

                ignore_check = false;
            }
        }

        private void checkbox_actions_checked_changed(object sender)
        {
            if (formLoaded && !ignore_check)
            {
                ignore_radio_custom = true;
                radio_custom.Checked = true;
                ignore_radio_custom = false;
            }
        }

        private void mainForm_Shown(object sender, EventArgs e)
        {
            formLoaded = true;
        }
    }
}
