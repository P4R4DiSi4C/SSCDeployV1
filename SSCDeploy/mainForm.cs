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
        private bool form_loaded;
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
            int max_steps = actions_groupbox.Controls.OfType<SpinCheckBox>().Count(c => c.Checked) + 1;
            int tasks_counter = 0;

            
            if (check_select_usb.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Désactivation suspension sélective USB..." });
                SelectiveUSB.Disable();
            }

            if (check_sleep.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Désactivation mise en veille sous secteur..." });
                Sleep.Disable();
            }

            if (check_ipv6.Checked)
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

            if (check_firefox.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Mise en place de la config Firefox..." });
                Firefox.Profilize();
            }

            if (check_nic_sleep.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Désactivation mise en veille cartes réseau..." });
                NICPowerSave.Disable();
            }

            if (check_usb_sleep.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Désactivation mise en veille USB..." });
                USBPowerSave.Disable();
            }

            if (check_onedrive.Checked)
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

            if(check_edge_desk.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Supression îcone Edge du bureau..." });
                Desktop.Delete_Edge_Icon();
            }

            if (check_adobe.Checked)
            {
                tasks_counter++;
                progress.Report(new DeployProgressReport { CurrentProgressAmount = tasks_counter * 100 / max_steps, CurrentProgressMessage = "Adobe par défaut S.V.P..." });
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

            // Fait tourner l'opération sur un autre thread
            await Task.Run(() => Deploy(progress_report));

            // Défini les valeurs finales à la fin de toutes les étapes
            text_deploy_progress.Text += "Déploiement terminé";
            deploy_progressbar.Value = 100;
        }

        /// <summary>
        /// Ouvre les options de confidentialité Windows 10
        /// </summary>
        private void btn_privacy_Click(object sender, EventArgs e)
        {
            Process.Start("ms-settings:privacy-general");
        }

        /// <summary>
        /// Ouvre les options d'applications par défaut Windows 10
        /// </summary>
        private void btn_default_Click(object sender, EventArgs e)
        {
            Process.Start("ms-settings:defaultapps");
        }

        /// <summary>
        /// Ouvre IE
        /// </summary>
        private void btn_ie_Click(object sender, EventArgs e)
        {
            Process.Start("iexplore");
        }

        /// <summary>
        /// Bouton pour quitter l'application
        /// </summary>
        private void exit_btn_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        /// <summary>
        /// Bouton pour redémarrer le poste
        /// </summary>
        private void btn_Restart_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown.exe", "-r -t 00");
        }

        /// <summary>
        /// Événement lorsque l'un des radios boutons change d'état
        /// </summary>
        private void radiobuttons_checked_changed(object sender)
        {
            // Uniquement si l'application a déjà charger
            if (form_loaded)
            {
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

                    check_firefox.Checked = false;
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

        /// <summary>
        /// Événement lorsque l'un des checks boutons change d'état
        /// </summary>
        private void checkbox_actions_checked_changed(object sender)
        {
            // Uniquement lorsque l'application est chargée
            if (form_loaded && !ignore_check)
            {
                if (actions_groupbox.Controls.OfType<SpinCheckBox>().Count() == actions_groupbox.Controls.OfType<SpinCheckBox>().Count(c => c.Checked))
                {
                    radio_new.Checked = true;
                }
                else
                {
                    ignore_radio_custom = true;
                    radio_custom.Checked = true;
                    ignore_radio_custom = false;
                }
            }
        }
        /// <summary>
        /// Événement lorsque l'application a fini de charger
        /// </summary>
        private void mainForm_Shown(object sender, EventArgs e)
        {
            form_loaded = true;
        }
    }
}
