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
            this.check_edge_desk = new SpinCheckBox();
            this.check_select_usb = new SpinCheckBox();
            this.check_sleep = new SpinCheckBox();
            this.check_region = new SpinCheckBox();
            this.check_ipv6 = new SpinCheckBox();
            this.check_adobe = new SpinCheckBox();
            this.check_unpin = new SpinCheckBox();
            this.check_onedrive = new SpinCheckBox();
            this.check_pin = new SpinCheckBox();
            this.check_usb_sleep = new SpinCheckBox();
            this.check_firefox = new SpinCheckBox();
            this.check_nic_sleep = new SpinCheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.spinGroupBox2 = new SpinGroupBox();
            this.btn_deploy = new SpinTheme.SpinButton();
            this.btn_restart = new SpinButton();
            this.text_deploy_progress = new SpinTheme.SpinRichTextbox();
            this.deploy_progressbar = new SpinTheme.SpinCircleProgressBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.spinGroupBox3 = new SpinGroupBox();
            this.btn_ie = new SpinButton();
            this.btn_privacy = new SpinButton();
            this.btn_default = new SpinButton();
            this.spinButton2 = new SpinButton();
            this.lab_version = new SpinLabel();
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
            this.SSCDeploy_SpinForm.Controls.Add(this.lab_version);
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
            this.actions_groupbox.Controls.Add(this.check_edge_desk);
            this.actions_groupbox.Controls.Add(this.check_select_usb);
            this.actions_groupbox.Controls.Add(this.check_sleep);
            this.actions_groupbox.Controls.Add(this.check_region);
            this.actions_groupbox.Controls.Add(this.check_ipv6);
            this.actions_groupbox.Controls.Add(this.check_adobe);
            this.actions_groupbox.Controls.Add(this.check_unpin);
            this.actions_groupbox.Controls.Add(this.check_onedrive);
            this.actions_groupbox.Controls.Add(this.check_pin);
            this.actions_groupbox.Controls.Add(this.check_usb_sleep);
            this.actions_groupbox.Controls.Add(this.check_firefox);
            this.actions_groupbox.Controls.Add(this.check_nic_sleep);
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
            // check_edge_desk
            // 
            this.check_edge_desk.BackColor = System.Drawing.Color.Transparent;
            this.check_edge_desk.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_edge_desk.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_edge_desk.CheckColor = System.Drawing.Color.White;
            this.check_edge_desk.Checked = true;
            this.check_edge_desk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_edge_desk.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_edge_desk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_edge_desk.Location = new System.Drawing.Point(304, 191);
            this.check_edge_desk.Name = "check_edge_desk";
            this.check_edge_desk.Size = new System.Drawing.Size(120, 17);
            this.check_edge_desk.TabIndex = 24;
            this.check_edge_desk.Text = "Sup. Edge bureau";
            this.check_edge_desk.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_edge_desk.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_edge_desk.UnCheckColor = System.Drawing.Color.Gray;
            this.check_edge_desk.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_select_usb
            // 
            this.check_select_usb.BackColor = System.Drawing.Color.Transparent;
            this.check_select_usb.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_select_usb.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_select_usb.CheckColor = System.Drawing.Color.White;
            this.check_select_usb.Checked = true;
            this.check_select_usb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_select_usb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_select_usb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_select_usb.Location = new System.Drawing.Point(16, 63);
            this.check_select_usb.Name = "check_select_usb";
            this.check_select_usb.Size = new System.Drawing.Size(184, 17);
            this.check_select_usb.TabIndex = 13;
            this.check_select_usb.Text = "Suspension USB sélective";
            this.check_select_usb.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_select_usb.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_select_usb.UnCheckColor = System.Drawing.Color.Gray;
            this.check_select_usb.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_sleep
            // 
            this.check_sleep.BackColor = System.Drawing.Color.Transparent;
            this.check_sleep.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_sleep.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_sleep.CheckColor = System.Drawing.Color.White;
            this.check_sleep.Checked = true;
            this.check_sleep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_sleep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_sleep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_sleep.Location = new System.Drawing.Point(16, 95);
            this.check_sleep.Name = "check_sleep";
            this.check_sleep.Size = new System.Drawing.Size(194, 17);
            this.check_sleep.TabIndex = 14;
            this.check_sleep.Text = "Mise en veille sous sécteur";
            this.check_sleep.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_sleep.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_sleep.UnCheckColor = System.Drawing.Color.Gray;
            this.check_sleep.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
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
            // check_ipv6
            // 
            this.check_ipv6.BackColor = System.Drawing.Color.Transparent;
            this.check_ipv6.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_ipv6.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_ipv6.CheckColor = System.Drawing.Color.White;
            this.check_ipv6.Checked = true;
            this.check_ipv6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_ipv6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_ipv6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_ipv6.Location = new System.Drawing.Point(16, 127);
            this.check_ipv6.Name = "check_ipv6";
            this.check_ipv6.Size = new System.Drawing.Size(159, 17);
            this.check_ipv6.TabIndex = 15;
            this.check_ipv6.Text = "IPV6";
            this.check_ipv6.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_ipv6.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_ipv6.UnCheckColor = System.Drawing.Color.Gray;
            this.check_ipv6.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_adobe
            // 
            this.check_adobe.BackColor = System.Drawing.Color.Transparent;
            this.check_adobe.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_adobe.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_adobe.CheckColor = System.Drawing.Color.White;
            this.check_adobe.Checked = true;
            this.check_adobe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_adobe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_adobe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_adobe.Location = new System.Drawing.Point(304, 223);
            this.check_adobe.Name = "check_adobe";
            this.check_adobe.Size = new System.Drawing.Size(120, 17);
            this.check_adobe.TabIndex = 22;
            this.check_adobe.Text = "Adobe par défaut";
            this.check_adobe.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_adobe.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_adobe.UnCheckColor = System.Drawing.Color.Gray;
            this.check_adobe.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
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
            // check_onedrive
            // 
            this.check_onedrive.BackColor = System.Drawing.Color.Transparent;
            this.check_onedrive.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_onedrive.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_onedrive.CheckColor = System.Drawing.Color.White;
            this.check_onedrive.Checked = true;
            this.check_onedrive.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_onedrive.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_onedrive.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_onedrive.Location = new System.Drawing.Point(304, 158);
            this.check_onedrive.Name = "check_onedrive";
            this.check_onedrive.Size = new System.Drawing.Size(120, 17);
            this.check_onedrive.TabIndex = 21;
            this.check_onedrive.Text = "Onedrive";
            this.check_onedrive.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_onedrive.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_onedrive.UnCheckColor = System.Drawing.Color.Gray;
            this.check_onedrive.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
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
            // check_usb_sleep
            // 
            this.check_usb_sleep.BackColor = System.Drawing.Color.Transparent;
            this.check_usb_sleep.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_usb_sleep.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_usb_sleep.CheckColor = System.Drawing.Color.White;
            this.check_usb_sleep.Checked = true;
            this.check_usb_sleep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_usb_sleep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_usb_sleep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_usb_sleep.Location = new System.Drawing.Point(304, 127);
            this.check_usb_sleep.Name = "check_usb_sleep";
            this.check_usb_sleep.Size = new System.Drawing.Size(120, 17);
            this.check_usb_sleep.TabIndex = 20;
            this.check_usb_sleep.Text = "Mise en veille USB";
            this.check_usb_sleep.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_usb_sleep.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_usb_sleep.UnCheckColor = System.Drawing.Color.Gray;
            this.check_usb_sleep.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_firefox
            // 
            this.check_firefox.BackColor = System.Drawing.Color.Transparent;
            this.check_firefox.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_firefox.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_firefox.CheckColor = System.Drawing.Color.White;
            this.check_firefox.Checked = true;
            this.check_firefox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_firefox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_firefox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_firefox.Location = new System.Drawing.Point(304, 63);
            this.check_firefox.Name = "check_firefox";
            this.check_firefox.Size = new System.Drawing.Size(120, 17);
            this.check_firefox.TabIndex = 18;
            this.check_firefox.Text = "Config Firefox";
            this.check_firefox.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_firefox.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_firefox.UnCheckColor = System.Drawing.Color.Gray;
            this.check_firefox.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
            // 
            // check_nic_sleep
            // 
            this.check_nic_sleep.BackColor = System.Drawing.Color.Transparent;
            this.check_nic_sleep.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.check_nic_sleep.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.check_nic_sleep.CheckColor = System.Drawing.Color.White;
            this.check_nic_sleep.Checked = true;
            this.check_nic_sleep.Cursor = System.Windows.Forms.Cursors.Hand;
            this.check_nic_sleep.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.check_nic_sleep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.check_nic_sleep.Location = new System.Drawing.Point(304, 95);
            this.check_nic_sleep.Name = "check_nic_sleep";
            this.check_nic_sleep.Size = new System.Drawing.Size(120, 17);
            this.check_nic_sleep.TabIndex = 19;
            this.check_nic_sleep.Text = "Mise en veille NIC";
            this.check_nic_sleep.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_nic_sleep.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_nic_sleep.UnCheckColor = System.Drawing.Color.Gray;
            this.check_nic_sleep.CheckedChanged += new SpinCheckBox.CheckedChangedEventHandler(this.checkbox_actions_checked_changed);
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
            this.spinGroupBox2.Controls.Add(this.btn_deploy);
            this.spinGroupBox2.Controls.Add(this.btn_restart);
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
            // btn_deploy
            // 
            this.btn_deploy.BackColor = System.Drawing.Color.Transparent;
            this.btn_deploy.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btn_deploy.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.btn_deploy.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.btn_deploy.HoverTextColor = System.Drawing.Color.White;
            this.btn_deploy.IsEnabled = true;
            this.btn_deploy.Location = new System.Drawing.Point(285, 242);
            this.btn_deploy.Name = "btn_deploy";
            this.btn_deploy.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.btn_deploy.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.btn_deploy.NormalTextColor = System.Drawing.Color.White;
            this.btn_deploy.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.btn_deploy.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.btn_deploy.PushedTextColor = System.Drawing.Color.White;
            this.btn_deploy.RoundRadius = 1;
            this.btn_deploy.Size = new System.Drawing.Size(143, 39);
            this.btn_deploy.TabIndex = 1;
            this.btn_deploy.Text = "DÉPLOYER";
            this.btn_deploy.Click += new System.EventHandler(this.btn_deploy_Click);
            // 
            // btn_restart
            // 
            this.btn_restart.BackColor = System.Drawing.Color.Transparent;
            this.btn_restart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_restart.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.btn_restart.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.btn_restart.HoverTextColor = System.Drawing.Color.White;
            this.btn_restart.IsEnabled = true;
            this.btn_restart.Location = new System.Drawing.Point(285, 310);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.btn_restart.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_restart.NormalTextColor = System.Drawing.Color.White;
            this.btn_restart.PushedBorderColor = System.Drawing.Color.Silver;
            this.btn_restart.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_restart.PushedTextColor = System.Drawing.Color.White;
            this.btn_restart.RoundRadius = 1;
            this.btn_restart.Size = new System.Drawing.Size(143, 23);
            this.btn_restart.TabIndex = 2;
            this.btn_restart.Text = "Redémarrer";
            this.btn_restart.Click += new System.EventHandler(this.btn_Restart_Click);
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
            // lab_version
            // 
            this.lab_version.BackColor = System.Drawing.Color.Transparent;
            this.lab_version.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lab_version.ForeColor = System.Drawing.Color.White;
            this.lab_version.Location = new System.Drawing.Point(420, 24);
            this.lab_version.Name = "lab_version";
            this.lab_version.Size = new System.Drawing.Size(32, 19);
            this.lab_version.TabIndex = 5;
            this.lab_version.Text = "V2.0";
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
        private SpinTheme.SpinButton btn_deploy;
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
        private SpinCheckBox check_adobe;
        private SpinCheckBox check_onedrive;
        private SpinCheckBox check_usb_sleep;
        private SpinCheckBox check_nic_sleep;
        private SpinCheckBox check_firefox;
        private SpinCheckBox check_pin;
        private SpinCheckBox check_unpin;
        private SpinCheckBox check_ipv6;
        private SpinCheckBox check_sleep;
        private SpinCheckBox check_select_usb;
        private SpinButton btn_restart;
        private SpinGroupBox presets_group;
        private SpinRadioButton radio_custom;
        private SpinRadioButton radio_new;
        private SpinRadioButton radio_update;
        private SpinGroupBox actions_groupbox;
        private SpinGroupBox spinGroupBox2;
        private SpinGroupBox spinGroupBox3;
        private SpinCheckBox check_edge_desk;
        private SpinLabel lab_version;
    }
}

