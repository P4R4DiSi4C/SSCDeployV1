namespace SSCDeploy
{
    partial class mainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.SSCDeploy_SpinForm = new SpinTheme.SpinForm();
            this.exit_btn = new SpinButton();
            this.spinHorizontalTabControl1 = new SpinHorizontalTabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.presets_group = new SpinGroupBox();
            this.radio_custom = new SpinRadioButton();
            this.radio_new = new SpinRadioButton();
            this.radio_update = new SpinRadioButton();
            this.actions_groupbox = new SpinGroupBox();
            this.check_edgedesk = new SpinCheckBox();
            this.check_SelectUSB = new SpinCheckBox();
            this.check_Sleep = new SpinCheckBox();
            this.check_region = new SpinCheckBox();
            this.check_IPV6 = new SpinCheckBox();
            this.check_Adobe = new SpinCheckBox();
            this.check_unpin = new SpinCheckBox();
            this.check_OneDrive = new SpinCheckBox();
            this.check_pin = new SpinCheckBox();
            this.check_USBSleep = new SpinCheckBox();
            this.check_Firefox = new SpinCheckBox();
            this.check_NICSleep = new SpinCheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.spinGroupBox2 = new SpinGroupBox();
            this.spinButton1 = new SpinTheme.SpinButton();
            this.btn_Restart = new SpinButton();
            this.text_deploy_progress = new SpinTheme.SpinRichTextbox();
            this.deploy_progressbar = new SpinTheme.SpinCircleProgressBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.spinGroupBox3 = new SpinGroupBox();
            this.btn_ie = new SpinButton();
            this.btn_privacy = new SpinButton();
            this.btn_default = new SpinButton();
            this.spinButton2 = new SpinButton();
            this.SSCDeploy_SpinForm.SuspendLayout();
            this.spinHorizontalTabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.presets_group.SuspendLayout();
            this.actions_groupbox.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.spinGroupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.spinGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SSCDeploy_SpinForm
            // 
            this.SSCDeploy_SpinForm.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.SSCDeploy_SpinForm.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.SSCDeploy_SpinForm.Controls.Add(this.exit_btn);
            this.SSCDeploy_SpinForm.Controls.Add(this.spinHorizontalTabControl1);
            this.SSCDeploy_SpinForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SSCDeploy_SpinForm.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.SSCDeploy_SpinForm.HeaderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.SSCDeploy_SpinForm.HeaderSize = 50;
            this.SSCDeploy_SpinForm.HeaderTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.SSCDeploy_SpinForm.Location = new System.Drawing.Point(0, 0);
            this.SSCDeploy_SpinForm.Name = "SSCDeploy_SpinForm";
            this.SSCDeploy_SpinForm.Size = new System.Drawing.Size(452, 451);
            this.SSCDeploy_SpinForm.TabIndex = 0;
            this.SSCDeploy_SpinForm.Text = "SSCDeploy";
            this.SSCDeploy_SpinForm.TitleTextPostion = SpinTheme.SpinForm.TitlePostion.Left;
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.Color.Transparent;
            this.exit_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_btn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.exit_btn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.exit_btn.HoverTextColor = System.Drawing.Color.White;
            this.exit_btn.IsEnabled = true;
            this.exit_btn.Location = new System.Drawing.Point(430, 4);
            this.exit_btn.Margin = new System.Windows.Forms.Padding(0);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.NormalBorderColor = System.Drawing.Color.Transparent;
            this.exit_btn.NormalColor = System.Drawing.Color.Transparent;
            this.exit_btn.NormalTextColor = System.Drawing.Color.DarkRed;
            this.exit_btn.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.exit_btn.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.exit_btn.PushedTextColor = System.Drawing.Color.White;
            this.exit_btn.RoundRadius = 1;
            this.exit_btn.Size = new System.Drawing.Size(19, 17);
            this.exit_btn.TabIndex = 4;
            this.exit_btn.Text = "X";
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // spinHorizontalTabControl1
            // 
            this.spinHorizontalTabControl1.BorderColor = System.Drawing.Color.Transparent;
            this.spinHorizontalTabControl1.Controls.Add(this.tabPage3);
            this.spinHorizontalTabControl1.Controls.Add(this.tabPage1);
            this.spinHorizontalTabControl1.Controls.Add(this.tabPage2);
            this.spinHorizontalTabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spinHorizontalTabControl1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.spinHorizontalTabControl1.ItemSize = new System.Drawing.Size(80, 40);
            this.spinHorizontalTabControl1.Location = new System.Drawing.Point(0, 42);
            this.spinHorizontalTabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.spinHorizontalTabControl1.Name = "spinHorizontalTabControl1";
            this.spinHorizontalTabControl1.RoundRadius = 1;
            this.spinHorizontalTabControl1.SelectedIndex = 0;
            this.spinHorizontalTabControl1.Size = new System.Drawing.Size(452, 405);
            this.spinHorizontalTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.spinHorizontalTabControl1.Speed = 40;
            this.spinHorizontalTabControl1.TabColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.spinHorizontalTabControl1.TabIndex = 3;
            this.spinHorizontalTabControl1.TabPageColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.spinHorizontalTabControl1.TabSelectedTextColor = System.Drawing.Color.White;
            this.spinHorizontalTabControl1.TabUnSlectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.spinHorizontalTabControl1.UseAnimation = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPage3.Controls.Add(this.presets_group);
            this.tabPage3.Controls.Add(this.actions_groupbox);
            this.tabPage3.Location = new System.Drawing.Point(4, 44);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(444, 357);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ACTIONS";
            // 
            // presets_group
            // 
            this.presets_group.BackColor = System.Drawing.Color.Transparent;
            this.presets_group.BaseColor = System.Drawing.Color.Transparent;
            this.presets_group.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.presets_group.Controls.Add(this.radio_custom);
            this.presets_group.Controls.Add(this.radio_new);
            this.presets_group.Controls.Add(this.radio_update);
            this.presets_group.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.presets_group.HeaderColor = System.Drawing.Color.Transparent;
            this.presets_group.HeaderTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.presets_group.Location = new System.Drawing.Point(3, 2);
            this.presets_group.Margin = new System.Windows.Forms.Padding(2);
            this.presets_group.Name = "presets_group";
            this.presets_group.Size = new System.Drawing.Size(437, 97);
            this.presets_group.TabIndex = 29;
            this.presets_group.Text = "PRESETS";
            // 
            // radio_custom
            // 
            this.radio_custom.BackColor = System.Drawing.Color.Transparent;
            this.radio_custom.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.radio_custom.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.radio_custom.CheckColor = System.Drawing.Color.White;
            this.radio_custom.Checked = false;
            this.radio_custom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radio_custom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radio_custom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.radio_custom.Group = 1;
            this.radio_custom.Location = new System.Drawing.Point(328, 65);
            this.radio_custom.Margin = new System.Windows.Forms.Padding(2);
            this.radio_custom.Name = "radio_custom";
            this.radio_custom.Size = new System.Drawing.Size(96, 21);
            this.radio_custom.TabIndex = 28;
            this.radio_custom.Text = "Personnalisé";
            this.radio_custom.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.radio_custom.UnCheckBorderColor = System.Drawing.Color.Black;
            this.radio_custom.UnCheckColor = System.Drawing.Color.Gray;
            this.radio_custom.CheckedChanged += new SpinRadioButton.CheckedChangedEventHandler(this.radiobuttons_checked_changed);
            // 
            // radio_new
            // 
            this.radio_new.BackColor = System.Drawing.Color.Transparent;
            this.radio_new.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.radio_new.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.radio_new.CheckColor = System.Drawing.Color.White;
            this.radio_new.Checked = true;
            this.radio_new.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radio_new.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radio_new.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.radio_new.Group = 1;
            this.radio_new.Location = new System.Drawing.Point(16, 65);
            this.radio_new.Margin = new System.Windows.Forms.Padding(2);
            this.radio_new.Name = "radio_new";
            this.radio_new.Size = new System.Drawing.Size(103, 21);
            this.radio_new.TabIndex = 26;
            this.radio_new.Text = "Nouveau poste";
            this.radio_new.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.radio_new.UnCheckBorderColor = System.Drawing.Color.Black;
            this.radio_new.UnCheckColor = System.Drawing.Color.Gray;
            this.radio_new.CheckedChanged += new SpinRadioButton.CheckedChangedEventHandler(this.radiobuttons_checked_changed);
            // 
            // radio_update
            // 
            this.radio_update.BackColor = System.Drawing.Color.Transparent;
            this.radio_update.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.radio_update.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.radio_update.CheckColor = System.Drawing.Color.White;
            this.radio_update.Checked = false;
            this.radio_update.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radio_update.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.radio_update.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.radio_update.Group = 1;
            this.radio_update.Location = new System.Drawing.Point(174, 65);
            this.radio_update.Margin = new System.Windows.Forms.Padding(2);
            this.radio_update.Name = "radio_update";
            this.radio_update.Size = new System.Drawing.Size(103, 21);
            this.radio_update.TabIndex = 27;
            this.radio_update.Text = "Mise à niveau";
            this.radio_update.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.radio_update.UnCheckBorderColor = System.Drawing.Color.Black;
            this.radio_update.UnCheckColor = System.Drawing.Color.Gray;
            this.radio_update.CheckedChanged += new SpinRadioButton.CheckedChangedEventHandler(this.radiobuttons_checked_changed);
            // 
            // actions_groupbox
            // 
            this.actions_groupbox.BackColor = System.Drawing.Color.Transparent;
            this.actions_groupbox.BaseColor = System.Drawing.Color.Transparent;
            this.actions_groupbox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.actions_groupbox.Controls.Add(this.check_edgedesk);
            this.actions_groupbox.Controls.Add(this.check_SelectUSB);
            this.actions_groupbox.Controls.Add(this.check_Sleep);
            this.actions_groupbox.Controls.Add(this.check_region);
            this.actions_groupbox.Controls.Add(this.check_IPV6);
            this.actions_groupbox.Controls.Add(this.check_Adobe);
            this.actions_groupbox.Controls.Add(this.check_unpin);
            this.actions_groupbox.Controls.Add(this.check_OneDrive);
            this.actions_groupbox.Controls.Add(this.check_pin);
            this.actions_groupbox.Controls.Add(this.check_USBSleep);
            this.actions_groupbox.Controls.Add(this.check_Firefox);
            this.actions_groupbox.Controls.Add(this.check_NICSleep);
            this.actions_groupbox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.actions_groupbox.HeaderColor = System.Drawing.Color.Transparent;
            this.actions_groupbox.HeaderTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.actions_groupbox.Location = new System.Drawing.Point(3, 103);
            this.actions_groupbox.Margin = new System.Windows.Forms.Padding(2);
            this.actions_groupbox.Name = "actions_groupbox";
            this.actions_groupbox.Size = new System.Drawing.Size(437, 252);
            this.actions_groupbox.TabIndex = 30;
            this.actions_groupbox.Text = "ACTIONS À EFFECTUER";
            // 
            // check_edgedesk
            // 
            this.check_edgedesk.BackColor = System.Drawing.Color.Transparent;
            this.check_edgedesk.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_edgedesk.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_edgedesk.CheckColor = System.Drawing.Color.White;
            this.check_edgedesk.Checked = true;
            this.check_edgedesk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_edgedesk.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_edgedesk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_edgedesk.Location = new System.Drawing.Point(304, 191);
            this.check_edgedesk.Name = "check_edgedesk";
            this.check_edgedesk.Size = new System.Drawing.Size(120, 17);
            this.check_edgedesk.TabIndex = 24;
            this.check_edgedesk.Text = "Sup. Edge bureau";
            this.check_edgedesk.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_edgedesk.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_edgedesk.UnCheckColor = System.Drawing.Color.Gray;
            this.check_edgedesk.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_SelectUSB
            // 
            this.check_SelectUSB.BackColor = System.Drawing.Color.Transparent;
            this.check_SelectUSB.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_SelectUSB.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_SelectUSB.CheckColor = System.Drawing.Color.White;
            this.check_SelectUSB.Checked = true;
            this.check_SelectUSB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_SelectUSB.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_SelectUSB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_SelectUSB.Location = new System.Drawing.Point(16, 63);
            this.check_SelectUSB.Name = "check_SelectUSB";
            this.check_SelectUSB.Size = new System.Drawing.Size(184, 17);
            this.check_SelectUSB.TabIndex = 13;
            this.check_SelectUSB.Text = "Suspension USB sélective";
            this.check_SelectUSB.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_SelectUSB.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_SelectUSB.UnCheckColor = System.Drawing.Color.Gray;
            this.check_SelectUSB.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_Sleep
            // 
            this.check_Sleep.BackColor = System.Drawing.Color.Transparent;
            this.check_Sleep.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_Sleep.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_Sleep.CheckColor = System.Drawing.Color.White;
            this.check_Sleep.Checked = true;
            this.check_Sleep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_Sleep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_Sleep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_Sleep.Location = new System.Drawing.Point(16, 95);
            this.check_Sleep.Name = "check_Sleep";
            this.check_Sleep.Size = new System.Drawing.Size(194, 17);
            this.check_Sleep.TabIndex = 14;
            this.check_Sleep.Text = "Mise en veille sous sécteur";
            this.check_Sleep.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_Sleep.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_Sleep.UnCheckColor = System.Drawing.Color.Gray;
            this.check_Sleep.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_region
            // 
            this.check_region.BackColor = System.Drawing.Color.Transparent;
            this.check_region.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_region.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_region.CheckColor = System.Drawing.Color.White;
            this.check_region.Checked = true;
            this.check_region.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_region.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_region.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_region.Location = new System.Drawing.Point(16, 223);
            this.check_region.Name = "check_region";
            this.check_region.Size = new System.Drawing.Size(159, 17);
            this.check_region.TabIndex = 23;
            this.check_region.Text = "Options régionales";
            this.check_region.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_region.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_region.UnCheckColor = System.Drawing.Color.Gray;
            this.check_region.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_IPV6
            // 
            this.check_IPV6.BackColor = System.Drawing.Color.Transparent;
            this.check_IPV6.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_IPV6.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_IPV6.CheckColor = System.Drawing.Color.White;
            this.check_IPV6.Checked = true;
            this.check_IPV6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_IPV6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_IPV6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_IPV6.Location = new System.Drawing.Point(16, 127);
            this.check_IPV6.Name = "check_IPV6";
            this.check_IPV6.Size = new System.Drawing.Size(159, 17);
            this.check_IPV6.TabIndex = 15;
            this.check_IPV6.Text = "IPV6";
            this.check_IPV6.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_IPV6.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_IPV6.UnCheckColor = System.Drawing.Color.Gray;
            this.check_IPV6.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_Adobe
            // 
            this.check_Adobe.BackColor = System.Drawing.Color.Transparent;
            this.check_Adobe.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_Adobe.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_Adobe.CheckColor = System.Drawing.Color.White;
            this.check_Adobe.Checked = true;
            this.check_Adobe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_Adobe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_Adobe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_Adobe.Location = new System.Drawing.Point(304, 223);
            this.check_Adobe.Name = "check_Adobe";
            this.check_Adobe.Size = new System.Drawing.Size(120, 17);
            this.check_Adobe.TabIndex = 22;
            this.check_Adobe.Text = "Adobe par défaut";
            this.check_Adobe.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_Adobe.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_Adobe.UnCheckColor = System.Drawing.Color.Gray;
            this.check_Adobe.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_unpin
            // 
            this.check_unpin.BackColor = System.Drawing.Color.Transparent;
            this.check_unpin.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_unpin.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_unpin.CheckColor = System.Drawing.Color.White;
            this.check_unpin.Checked = true;
            this.check_unpin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_unpin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_unpin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_unpin.Location = new System.Drawing.Point(16, 158);
            this.check_unpin.Name = "check_unpin";
            this.check_unpin.Size = new System.Drawing.Size(206, 17);
            this.check_unpin.TabIndex = 16;
            this.check_unpin.Text = "Désépingler apps Microsoft";
            this.check_unpin.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_unpin.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_unpin.UnCheckColor = System.Drawing.Color.Gray;
            this.check_unpin.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_OneDrive
            // 
            this.check_OneDrive.BackColor = System.Drawing.Color.Transparent;
            this.check_OneDrive.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_OneDrive.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_OneDrive.CheckColor = System.Drawing.Color.White;
            this.check_OneDrive.Checked = true;
            this.check_OneDrive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_OneDrive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_OneDrive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_OneDrive.Location = new System.Drawing.Point(304, 158);
            this.check_OneDrive.Name = "check_OneDrive";
            this.check_OneDrive.Size = new System.Drawing.Size(120, 17);
            this.check_OneDrive.TabIndex = 21;
            this.check_OneDrive.Text = "Onedrive";
            this.check_OneDrive.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_OneDrive.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_OneDrive.UnCheckColor = System.Drawing.Color.Gray;
            this.check_OneDrive.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_pin
            // 
            this.check_pin.BackColor = System.Drawing.Color.Transparent;
            this.check_pin.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_pin.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_pin.CheckColor = System.Drawing.Color.White;
            this.check_pin.Checked = true;
            this.check_pin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_pin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_pin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_pin.Location = new System.Drawing.Point(16, 191);
            this.check_pin.Name = "check_pin";
            this.check_pin.Size = new System.Drawing.Size(206, 17);
            this.check_pin.TabIndex = 17;
            this.check_pin.Text = "Épingler apps par défaut";
            this.check_pin.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_pin.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_pin.UnCheckColor = System.Drawing.Color.Gray;
            this.check_pin.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_USBSleep
            // 
            this.check_USBSleep.BackColor = System.Drawing.Color.Transparent;
            this.check_USBSleep.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_USBSleep.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_USBSleep.CheckColor = System.Drawing.Color.White;
            this.check_USBSleep.Checked = true;
            this.check_USBSleep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_USBSleep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_USBSleep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_USBSleep.Location = new System.Drawing.Point(304, 127);
            this.check_USBSleep.Name = "check_USBSleep";
            this.check_USBSleep.Size = new System.Drawing.Size(120, 17);
            this.check_USBSleep.TabIndex = 20;
            this.check_USBSleep.Text = "Mise en veille USB";
            this.check_USBSleep.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_USBSleep.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_USBSleep.UnCheckColor = System.Drawing.Color.Gray;
            this.check_USBSleep.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_Firefox
            // 
            this.check_Firefox.BackColor = System.Drawing.Color.Transparent;
            this.check_Firefox.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_Firefox.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_Firefox.CheckColor = System.Drawing.Color.White;
            this.check_Firefox.Checked = true;
            this.check_Firefox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_Firefox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_Firefox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_Firefox.Location = new System.Drawing.Point(304, 63);
            this.check_Firefox.Name = "check_Firefox";
            this.check_Firefox.Size = new System.Drawing.Size(120, 17);
            this.check_Firefox.TabIndex = 18;
            this.check_Firefox.Text = "Profil Firefox";
            this.check_Firefox.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_Firefox.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_Firefox.UnCheckColor = System.Drawing.Color.Gray;
            this.check_Firefox.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_NICSleep
            // 
            this.check_NICSleep.BackColor = System.Drawing.Color.Transparent;
            this.check_NICSleep.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_NICSleep.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_NICSleep.CheckColor = System.Drawing.Color.White;
            this.check_NICSleep.Checked = true;
            this.check_NICSleep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_NICSleep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_NICSleep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_NICSleep.Location = new System.Drawing.Point(304, 95);
            this.check_NICSleep.Name = "check_NICSleep";
            this.check_NICSleep.Size = new System.Drawing.Size(120, 17);
            this.check_NICSleep.TabIndex = 19;
            this.check_NICSleep.Text = "Mise en veille NIC";
            this.check_NICSleep.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_NICSleep.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_NICSleep.UnCheckColor = System.Drawing.Color.Gray;
            this.check_NICSleep.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPage1.Controls.Add(this.spinGroupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(444, 357);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DÉPLOYER";
            // 
            // spinGroupBox2
            // 
            this.spinGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.spinGroupBox2.BaseColor = System.Drawing.Color.Transparent;
            this.spinGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinGroupBox2.Controls.Add(this.spinButton1);
            this.spinGroupBox2.Controls.Add(this.btn_Restart);
            this.spinGroupBox2.Controls.Add(this.text_deploy_progress);
            this.spinGroupBox2.Controls.Add(this.deploy_progressbar);
            this.spinGroupBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinGroupBox2.HeaderColor = System.Drawing.Color.Transparent;
            this.spinGroupBox2.HeaderTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.spinGroupBox2.Location = new System.Drawing.Point(3, 2);
            this.spinGroupBox2.Name = "spinGroupBox2";
            this.spinGroupBox2.Size = new System.Drawing.Size(437, 353);
            this.spinGroupBox2.TabIndex = 3;
            this.spinGroupBox2.Text = "DÉPLOIEMENT";
            // 
            // spinButton1
            // 
            this.spinButton1.BackColor = System.Drawing.Color.Transparent;
            this.spinButton1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.spinButton1.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.spinButton1.HoverTextColor = System.Drawing.Color.White;
            this.spinButton1.IsEnabled = true;
            this.spinButton1.Location = new System.Drawing.Point(285, 242);
            this.spinButton1.Name = "spinButton1";
            this.spinButton1.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.spinButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinButton1.NormalTextColor = System.Drawing.Color.White;
            this.spinButton1.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton1.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.spinButton1.PushedTextColor = System.Drawing.Color.White;
            this.spinButton1.RoundRadius = 1;
            this.spinButton1.Size = new System.Drawing.Size(143, 39);
            this.spinButton1.TabIndex = 1;
            this.spinButton1.Text = "DÉPLOYER";
            this.spinButton1.Click += new System.EventHandler(this.btn_deploy_Click);
            // 
            // btn_Restart
            // 
            this.btn_Restart.BackColor = System.Drawing.Color.Transparent;
            this.btn_Restart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Restart.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.btn_Restart.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.btn_Restart.HoverTextColor = System.Drawing.Color.White;
            this.btn_Restart.IsEnabled = true;
            this.btn_Restart.Location = new System.Drawing.Point(285, 310);
            this.btn_Restart.Name = "btn_Restart";
            this.btn_Restart.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.btn_Restart.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Restart.NormalTextColor = System.Drawing.Color.White;
            this.btn_Restart.PushedBorderColor = System.Drawing.Color.Silver;
            this.btn_Restart.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Restart.PushedTextColor = System.Drawing.Color.White;
            this.btn_Restart.RoundRadius = 1;
            this.btn_Restart.Size = new System.Drawing.Size(143, 23);
            this.btn_Restart.TabIndex = 2;
            this.btn_Restart.Text = "Redémarrer";
            this.btn_Restart.Click += new System.EventHandler(this.btn_Restart_Click);
            // 
            // text_deploy_progress
            // 
            this.text_deploy_progress.AutoWordSelection = false;
            this.text_deploy_progress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.text_deploy_progress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.text_deploy_progress.ForeColor = System.Drawing.Color.Silver;
            this.text_deploy_progress.Lines = null;
            this.text_deploy_progress.Location = new System.Drawing.Point(5, 64);
            this.text_deploy_progress.Name = "text_deploy_progress";
            this.text_deploy_progress.ReadOnly = false;
            this.text_deploy_progress.Size = new System.Drawing.Size(276, 269);
            this.text_deploy_progress.TabIndex = 1;
            this.text_deploy_progress.WordWrap = true;
            // 
            // deploy_progressbar
            // 
            this.deploy_progressbar.BackColor = System.Drawing.Color.Transparent;
            this.deploy_progressbar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.deploy_progressbar.Cursor = System.Windows.Forms.Cursors.Default;
            this.deploy_progressbar.EndStyle = System.Drawing.Drawing2D.LineCap.Custom;
            this.deploy_progressbar.FillInside = false;
            this.deploy_progressbar.InsideColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.deploy_progressbar.Location = new System.Drawing.Point(289, 62);
            this.deploy_progressbar.Maximum = 100;
            this.deploy_progressbar.Name = "deploy_progressbar";
            this.deploy_progressbar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.deploy_progressbar.ProgressTextColor = System.Drawing.Color.White;
            this.deploy_progressbar.ShowBase = true;
            this.deploy_progressbar.ShowProgressValue = true;
            this.deploy_progressbar.Size = new System.Drawing.Size(132, 131);
            this.deploy_progressbar.StartStyle = System.Drawing.Drawing2D.LineCap.Custom;
            this.deploy_progressbar.TabIndex = 0;
            this.deploy_progressbar.Thickness = 12;
            this.deploy_progressbar.Value = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPage2.Controls.Add(this.spinGroupBox3);
            this.tabPage2.Controls.Add(this.spinButton2);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(444, 357);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "EXTRA";
            // 
            // spinGroupBox3
            // 
            this.spinGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.spinGroupBox3.BaseColor = System.Drawing.Color.Transparent;
            this.spinGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinGroupBox3.Controls.Add(this.btn_ie);
            this.spinGroupBox3.Controls.Add(this.btn_privacy);
            this.spinGroupBox3.Controls.Add(this.btn_default);
            this.spinGroupBox3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinGroupBox3.HeaderColor = System.Drawing.Color.Transparent;
            this.spinGroupBox3.HeaderTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.spinGroupBox3.Location = new System.Drawing.Point(3, 2);
            this.spinGroupBox3.Name = "spinGroupBox3";
            this.spinGroupBox3.Size = new System.Drawing.Size(437, 353);
            this.spinGroupBox3.TabIndex = 5;
            this.spinGroupBox3.Text = "FONCTIONS SUPPLÉMENTAIRES";
            // 
            // btn_ie
            // 
            this.btn_ie.BackColor = System.Drawing.Color.Transparent;
            this.btn_ie.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_ie.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.btn_ie.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.btn_ie.HoverTextColor = System.Drawing.Color.White;
            this.btn_ie.IsEnabled = true;
            this.btn_ie.Location = new System.Drawing.Point(112, 115);
            this.btn_ie.Name = "btn_ie";
            this.btn_ie.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.btn_ie.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.btn_ie.NormalTextColor = System.Drawing.Color.White;
            this.btn_ie.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.btn_ie.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.btn_ie.PushedTextColor = System.Drawing.Color.White;
            this.btn_ie.RoundRadius = 1;
            this.btn_ie.Size = new System.Drawing.Size(214, 32);
            this.btn_ie.TabIndex = 1;
            this.btn_ie.Text = "Internet Explorer";
            this.btn_ie.Click += new System.EventHandler(this.btn_ie_Click);
            // 
            // btn_privacy
            // 
            this.btn_privacy.BackColor = System.Drawing.Color.Transparent;
            this.btn_privacy.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_privacy.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.btn_privacy.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.btn_privacy.HoverTextColor = System.Drawing.Color.White;
            this.btn_privacy.IsEnabled = true;
            this.btn_privacy.Location = new System.Drawing.Point(112, 184);
            this.btn_privacy.Name = "btn_privacy";
            this.btn_privacy.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.btn_privacy.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.btn_privacy.NormalTextColor = System.Drawing.Color.White;
            this.btn_privacy.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.btn_privacy.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.btn_privacy.PushedTextColor = System.Drawing.Color.White;
            this.btn_privacy.RoundRadius = 1;
            this.btn_privacy.Size = new System.Drawing.Size(214, 32);
            this.btn_privacy.TabIndex = 3;
            this.btn_privacy.Text = "Confidentialité";
            this.btn_privacy.Click += new System.EventHandler(this.btn_privacy_Click);
            // 
            // btn_default
            // 
            this.btn_default.BackColor = System.Drawing.Color.Transparent;
            this.btn_default.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_default.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.btn_default.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.btn_default.HoverTextColor = System.Drawing.Color.White;
            this.btn_default.IsEnabled = true;
            this.btn_default.Location = new System.Drawing.Point(112, 256);
            this.btn_default.Name = "btn_default";
            this.btn_default.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.btn_default.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.btn_default.NormalTextColor = System.Drawing.Color.White;
            this.btn_default.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.btn_default.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.btn_default.PushedTextColor = System.Drawing.Color.White;
            this.btn_default.RoundRadius = 1;
            this.btn_default.Size = new System.Drawing.Size(214, 29);
            this.btn_default.TabIndex = 2;
            this.btn_default.Text = "Apps par défaut";
            this.btn_default.Click += new System.EventHandler(this.btn_default_Click);
            // 
            // spinButton2
            // 
            this.spinButton2.BackColor = System.Drawing.Color.Transparent;
            this.spinButton2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.spinButton2.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton2.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.spinButton2.HoverTextColor = System.Drawing.Color.White;
            this.spinButton2.IsEnabled = true;
            this.spinButton2.Location = new System.Drawing.Point(0, 0);
            this.spinButton2.Name = "spinButton2";
            this.spinButton2.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.spinButton2.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinButton2.NormalTextColor = System.Drawing.Color.White;
            this.spinButton2.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton2.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.spinButton2.PushedTextColor = System.Drawing.Color.White;
            this.spinButton2.RoundRadius = 5;
            this.spinButton2.Size = new System.Drawing.Size(0, 0);
            this.spinButton2.TabIndex = 4;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 451);
            this.Controls.Add(this.SSCDeploy_SpinForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSCDeploy";
            this.Shown += new System.EventHandler(this.mainForm_Shown);
            this.SSCDeploy_SpinForm.ResumeLayout(false);
            this.spinHorizontalTabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.presets_group.ResumeLayout(false);
            this.actions_groupbox.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.spinGroupBox2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.spinGroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SpinTheme.SpinForm SSCDeploy_SpinForm;
        private SpinTheme.SpinCircleProgressBar deploy_progressbar;
        private SpinTheme.SpinRichTextbox text_deploy_progress;
        private SpinTheme.SpinButton spinButton1;
        private SpinHorizontalTabControl spinHorizontalTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private SpinButton spinButton2;
        private SpinButton btn_privacy;
        private SpinButton btn_default;
        private SpinButton btn_ie;
        private SpinButton exit_btn;
        private System.Windows.Forms.TabPage tabPage3;
        private SpinCheckBox check_region;
        private SpinCheckBox check_Adobe;
        private SpinCheckBox check_OneDrive;
        private SpinCheckBox check_USBSleep;
        private SpinCheckBox check_NICSleep;
        private SpinCheckBox check_Firefox;
        private SpinCheckBox check_pin;
        private SpinCheckBox check_unpin;
        private SpinCheckBox check_IPV6;
        private SpinCheckBox check_Sleep;
        private SpinCheckBox check_SelectUSB;
        private SpinButton btn_Restart;
        private SpinGroupBox presets_group;
        private SpinRadioButton radio_custom;
        private SpinRadioButton radio_new;
        private SpinRadioButton radio_update;
        private SpinGroupBox actions_groupbox;
        private SpinGroupBox spinGroupBox2;
        private SpinGroupBox spinGroupBox3;
        private SpinCheckBox check_edgedesk;
    }
}

