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
            this.check_region = new SpinCheckBox();
            this.check_Adobe = new SpinCheckBox();
            this.check_OneDrive = new SpinCheckBox();
            this.check_USBSleep = new SpinCheckBox();
            this.check_NICSleep = new SpinCheckBox();
            this.check_Firefox = new SpinCheckBox();
            this.check_pin = new SpinCheckBox();
            this.check_unpin = new SpinCheckBox();
            this.check_IPV6 = new SpinCheckBox();
            this.check_Sleep = new SpinCheckBox();
            this.check_SelectUSB = new SpinCheckBox();
            this.radio_group = new SpinGroupBox();
            this.spinRadioButton1 = new SpinRadioButton();
            this.radio_new = new SpinRadioButton();
            this.radio_update = new SpinRadioButton();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Restart = new SpinButton();
            this.text_deploy_progress = new SpinTheme.SpinRichTextbox();
            this.spinButton1 = new SpinTheme.SpinButton();
            this.deploy_progressbar = new SpinTheme.SpinCircleProgressBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.spinButton5 = new SpinButton();
            this.spinButton4 = new SpinButton();
            this.spinButton3 = new SpinButton();
            this.spinButton2 = new SpinButton();
            this.spinGroupBox1 = new SpinGroupBox();
            this.SSCDeploy_SpinForm.SuspendLayout();
            this.spinHorizontalTabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.radio_group.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.spinGroupBox1.SuspendLayout();
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
            this.SSCDeploy_SpinForm.Margin = new System.Windows.Forms.Padding(4);
            this.SSCDeploy_SpinForm.Name = "SSCDeploy_SpinForm";
            this.SSCDeploy_SpinForm.Size = new System.Drawing.Size(603, 503);
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
            this.exit_btn.Location = new System.Drawing.Point(575, 5);
            this.exit_btn.Margin = new System.Windows.Forms.Padding(0);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.NormalBorderColor = System.Drawing.Color.Transparent;
            this.exit_btn.NormalColor = System.Drawing.Color.Transparent;
            this.exit_btn.NormalTextColor = System.Drawing.Color.DarkRed;
            this.exit_btn.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.exit_btn.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.exit_btn.PushedTextColor = System.Drawing.Color.White;
            this.exit_btn.RoundRadius = 1;
            this.exit_btn.Size = new System.Drawing.Size(24, 21);
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
            this.spinHorizontalTabControl1.Location = new System.Drawing.Point(0, 52);
            this.spinHorizontalTabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.spinHorizontalTabControl1.Name = "spinHorizontalTabControl1";
            this.spinHorizontalTabControl1.RoundRadius = 1;
            this.spinHorizontalTabControl1.SelectedIndex = 0;
            this.spinHorizontalTabControl1.Size = new System.Drawing.Size(603, 442);
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
            this.tabPage3.Controls.Add(this.radio_group);
            this.tabPage3.Controls.Add(this.spinGroupBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 44);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(595, 394);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "ACTIONS";
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
            this.check_region.Location = new System.Drawing.Point(21, 258);
            this.check_region.Margin = new System.Windows.Forms.Padding(4);
            this.check_region.Name = "check_region";
            this.check_region.Size = new System.Drawing.Size(212, 17);
            this.check_region.TabIndex = 23;
            this.check_region.Text = "Options régionales";
            this.check_region.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_region.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_region.UnCheckColor = System.Drawing.Color.Gray;
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
            this.check_Adobe.Location = new System.Drawing.Point(405, 219);
            this.check_Adobe.Margin = new System.Windows.Forms.Padding(4);
            this.check_Adobe.Name = "check_Adobe";
            this.check_Adobe.Size = new System.Drawing.Size(160, 17);
            this.check_Adobe.TabIndex = 22;
            this.check_Adobe.Text = "Adobe par défaut";
            this.check_Adobe.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_Adobe.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_Adobe.UnCheckColor = System.Drawing.Color.Gray;
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
            this.check_OneDrive.Location = new System.Drawing.Point(405, 179);
            this.check_OneDrive.Margin = new System.Windows.Forms.Padding(4);
            this.check_OneDrive.Name = "check_OneDrive";
            this.check_OneDrive.Size = new System.Drawing.Size(160, 17);
            this.check_OneDrive.TabIndex = 21;
            this.check_OneDrive.Text = "Onedrive";
            this.check_OneDrive.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_OneDrive.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_OneDrive.UnCheckColor = System.Drawing.Color.Gray;
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
            this.check_USBSleep.Location = new System.Drawing.Point(405, 140);
            this.check_USBSleep.Margin = new System.Windows.Forms.Padding(4);
            this.check_USBSleep.Name = "check_USBSleep";
            this.check_USBSleep.Size = new System.Drawing.Size(160, 17);
            this.check_USBSleep.TabIndex = 20;
            this.check_USBSleep.Text = "Mise en veille USB";
            this.check_USBSleep.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_USBSleep.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_USBSleep.UnCheckColor = System.Drawing.Color.Gray;
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
            this.check_NICSleep.Location = new System.Drawing.Point(405, 101);
            this.check_NICSleep.Margin = new System.Windows.Forms.Padding(4);
            this.check_NICSleep.Name = "check_NICSleep";
            this.check_NICSleep.Size = new System.Drawing.Size(160, 17);
            this.check_NICSleep.TabIndex = 19;
            this.check_NICSleep.Text = "Mise en veille NIC";
            this.check_NICSleep.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_NICSleep.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_NICSleep.UnCheckColor = System.Drawing.Color.Gray;
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
            this.check_Firefox.Location = new System.Drawing.Point(405, 61);
            this.check_Firefox.Margin = new System.Windows.Forms.Padding(4);
            this.check_Firefox.Name = "check_Firefox";
            this.check_Firefox.Size = new System.Drawing.Size(160, 17);
            this.check_Firefox.TabIndex = 18;
            this.check_Firefox.Text = "Profil Firefox";
            this.check_Firefox.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_Firefox.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_Firefox.UnCheckColor = System.Drawing.Color.Gray;
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
            this.check_pin.Location = new System.Drawing.Point(21, 219);
            this.check_pin.Margin = new System.Windows.Forms.Padding(4);
            this.check_pin.Name = "check_pin";
            this.check_pin.Size = new System.Drawing.Size(275, 17);
            this.check_pin.TabIndex = 17;
            this.check_pin.Text = "Épingler apps par défaut";
            this.check_pin.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_pin.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_pin.UnCheckColor = System.Drawing.Color.Gray;
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
            this.check_unpin.Location = new System.Drawing.Point(21, 179);
            this.check_unpin.Margin = new System.Windows.Forms.Padding(4);
            this.check_unpin.Name = "check_unpin";
            this.check_unpin.Size = new System.Drawing.Size(275, 17);
            this.check_unpin.TabIndex = 16;
            this.check_unpin.Text = "Désépingler apps Microsoft";
            this.check_unpin.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_unpin.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_unpin.UnCheckColor = System.Drawing.Color.Gray;
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
            this.check_IPV6.Location = new System.Drawing.Point(21, 140);
            this.check_IPV6.Margin = new System.Windows.Forms.Padding(4);
            this.check_IPV6.Name = "check_IPV6";
            this.check_IPV6.Size = new System.Drawing.Size(212, 17);
            this.check_IPV6.TabIndex = 15;
            this.check_IPV6.Text = "IPV6";
            this.check_IPV6.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_IPV6.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_IPV6.UnCheckColor = System.Drawing.Color.Gray;
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
            this.check_Sleep.Location = new System.Drawing.Point(21, 101);
            this.check_Sleep.Margin = new System.Windows.Forms.Padding(4);
            this.check_Sleep.Name = "check_Sleep";
            this.check_Sleep.Size = new System.Drawing.Size(259, 17);
            this.check_Sleep.TabIndex = 14;
            this.check_Sleep.Text = "Mise en veille sous sécteur";
            this.check_Sleep.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_Sleep.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_Sleep.UnCheckColor = System.Drawing.Color.Gray;
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
            this.check_SelectUSB.Location = new System.Drawing.Point(21, 61);
            this.check_SelectUSB.Margin = new System.Windows.Forms.Padding(4);
            this.check_SelectUSB.Name = "check_SelectUSB";
            this.check_SelectUSB.Size = new System.Drawing.Size(245, 17);
            this.check_SelectUSB.TabIndex = 13;
            this.check_SelectUSB.Text = "Suspension USB sélective";
            this.check_SelectUSB.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.check_SelectUSB.UnCheckBorderColor = System.Drawing.Color.Black;
            this.check_SelectUSB.UnCheckColor = System.Drawing.Color.Gray;
            // 
            // radio_group
            // 
            this.radio_group.BackColor = System.Drawing.Color.Transparent;
            this.radio_group.BaseColor = System.Drawing.Color.Transparent;
            this.radio_group.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.radio_group.Controls.Add(this.spinRadioButton1);
            this.radio_group.Controls.Add(this.radio_new);
            this.radio_group.Controls.Add(this.radio_update);
            this.radio_group.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radio_group.HeaderColor = System.Drawing.Color.Transparent;
            this.radio_group.HeaderTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.radio_group.Location = new System.Drawing.Point(6, 3);
            this.radio_group.Name = "radio_group";
            this.radio_group.Size = new System.Drawing.Size(580, 93);
            this.radio_group.TabIndex = 29;
            this.radio_group.Text = "Presets";
            // 
            // spinRadioButton1
            // 
            this.spinRadioButton1.BackColor = System.Drawing.Color.Transparent;
            this.spinRadioButton1.CheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinRadioButton1.CheckBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(71)))), ((int)(((byte)(114)))));
            this.spinRadioButton1.CheckColor = System.Drawing.Color.White;
            this.spinRadioButton1.Checked = false;
            this.spinRadioButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spinRadioButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.spinRadioButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.spinRadioButton1.Group = 1;
            this.spinRadioButton1.Location = new System.Drawing.Point(433, 62);
            this.spinRadioButton1.Name = "spinRadioButton1";
            this.spinRadioButton1.Size = new System.Drawing.Size(128, 21);
            this.spinRadioButton1.TabIndex = 28;
            this.spinRadioButton1.Text = "Personnalisé";
            this.spinRadioButton1.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.spinRadioButton1.UnCheckBorderColor = System.Drawing.Color.Black;
            this.spinRadioButton1.UnCheckColor = System.Drawing.Color.Gray;
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
            this.radio_new.Location = new System.Drawing.Point(21, 62);
            this.radio_new.Name = "radio_new";
            this.radio_new.Size = new System.Drawing.Size(137, 21);
            this.radio_new.TabIndex = 26;
            this.radio_new.Text = "Nouveau poste";
            this.radio_new.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.radio_new.UnCheckBorderColor = System.Drawing.Color.Black;
            this.radio_new.UnCheckColor = System.Drawing.Color.Gray;
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
            this.radio_update.Location = new System.Drawing.Point(225, 62);
            this.radio_update.Name = "radio_update";
            this.radio_update.Size = new System.Drawing.Size(137, 21);
            this.radio_update.TabIndex = 27;
            this.radio_update.Text = "Mise à niveau";
            this.radio_update.UnCheckBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.radio_update.UnCheckBorderColor = System.Drawing.Color.Black;
            this.radio_update.UnCheckColor = System.Drawing.Color.Gray;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPage1.Controls.Add(this.btn_Restart);
            this.tabPage1.Controls.Add(this.text_deploy_progress);
            this.tabPage1.Controls.Add(this.spinButton1);
            this.tabPage1.Controls.Add(this.deploy_progressbar);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(595, 394);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DÉPLOYER";
            // 
            // btn_Restart
            // 
            this.btn_Restart.BackColor = System.Drawing.Color.Transparent;
            this.btn_Restart.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Restart.HoverBorderColor = System.Drawing.Color.Silver;
            this.btn_Restart.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Restart.HoverTextColor = System.Drawing.Color.White;
            this.btn_Restart.IsEnabled = true;
            this.btn_Restart.Location = new System.Drawing.Point(401, 176);
            this.btn_Restart.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Restart.Name = "btn_Restart";
            this.btn_Restart.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Restart.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Restart.NormalTextColor = System.Drawing.Color.White;
            this.btn_Restart.PushedBorderColor = System.Drawing.Color.Silver;
            this.btn_Restart.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btn_Restart.PushedTextColor = System.Drawing.Color.White;
            this.btn_Restart.RoundRadius = 5;
            this.btn_Restart.Size = new System.Drawing.Size(176, 28);
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
            this.text_deploy_progress.Location = new System.Drawing.Point(8, 7);
            this.text_deploy_progress.Margin = new System.Windows.Forms.Padding(4);
            this.text_deploy_progress.Name = "text_deploy_progress";
            this.text_deploy_progress.ReadOnly = false;
            this.text_deploy_progress.Size = new System.Drawing.Size(368, 262);
            this.text_deploy_progress.TabIndex = 1;
            this.text_deploy_progress.WordWrap = true;
            // 
            // spinButton1
            // 
            this.spinButton1.BackColor = System.Drawing.Color.Transparent;
            this.spinButton1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.spinButton1.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.spinButton1.HoverTextColor = System.Drawing.Color.White;
            this.spinButton1.IsEnabled = true;
            this.spinButton1.Location = new System.Drawing.Point(401, 222);
            this.spinButton1.Margin = new System.Windows.Forms.Padding(4);
            this.spinButton1.Name = "spinButton1";
            this.spinButton1.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.spinButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinButton1.NormalTextColor = System.Drawing.Color.White;
            this.spinButton1.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton1.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.spinButton1.PushedTextColor = System.Drawing.Color.White;
            this.spinButton1.RoundRadius = 5;
            this.spinButton1.Size = new System.Drawing.Size(176, 48);
            this.spinButton1.TabIndex = 1;
            this.spinButton1.Text = "DÉPLOYER";
            this.spinButton1.Click += new System.EventHandler(this.btn_deploy_Click);
            // 
            // deploy_progressbar
            // 
            this.deploy_progressbar.BackColor = System.Drawing.Color.Transparent;
            this.deploy_progressbar.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.deploy_progressbar.Cursor = System.Windows.Forms.Cursors.Default;
            this.deploy_progressbar.EndStyle = System.Drawing.Drawing2D.LineCap.Custom;
            this.deploy_progressbar.FillInside = false;
            this.deploy_progressbar.InsideColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.deploy_progressbar.Location = new System.Drawing.Point(401, 7);
            this.deploy_progressbar.Margin = new System.Windows.Forms.Padding(4);
            this.deploy_progressbar.Maximum = 100;
            this.deploy_progressbar.Name = "deploy_progressbar";
            this.deploy_progressbar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.deploy_progressbar.ProgressTextColor = System.Drawing.Color.White;
            this.deploy_progressbar.ShowBase = true;
            this.deploy_progressbar.ShowProgressValue = true;
            this.deploy_progressbar.Size = new System.Drawing.Size(176, 161);
            this.deploy_progressbar.StartStyle = System.Drawing.Drawing2D.LineCap.Custom;
            this.deploy_progressbar.TabIndex = 0;
            this.deploy_progressbar.Thickness = 12;
            this.deploy_progressbar.Value = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPage2.Controls.Add(this.spinButton5);
            this.tabPage2.Controls.Add(this.spinButton4);
            this.tabPage2.Controls.Add(this.spinButton3);
            this.tabPage2.Controls.Add(this.spinButton2);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(595, 394);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "EXTRA";
            // 
            // spinButton5
            // 
            this.spinButton5.BackColor = System.Drawing.Color.Transparent;
            this.spinButton5.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.spinButton5.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton5.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.spinButton5.HoverTextColor = System.Drawing.Color.White;
            this.spinButton5.IsEnabled = true;
            this.spinButton5.Location = new System.Drawing.Point(205, 122);
            this.spinButton5.Margin = new System.Windows.Forms.Padding(4);
            this.spinButton5.Name = "spinButton5";
            this.spinButton5.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.spinButton5.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinButton5.NormalTextColor = System.Drawing.Color.White;
            this.spinButton5.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton5.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.spinButton5.PushedTextColor = System.Drawing.Color.White;
            this.spinButton5.RoundRadius = 1;
            this.spinButton5.Size = new System.Drawing.Size(188, 39);
            this.spinButton5.TabIndex = 3;
            this.spinButton5.Text = "PRIVACITÉ";
            this.spinButton5.Click += new System.EventHandler(this.btn_privacy_Click);
            // 
            // spinButton4
            // 
            this.spinButton4.BackColor = System.Drawing.Color.Transparent;
            this.spinButton4.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.spinButton4.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton4.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.spinButton4.HoverTextColor = System.Drawing.Color.White;
            this.spinButton4.IsEnabled = true;
            this.spinButton4.Location = new System.Drawing.Point(205, 203);
            this.spinButton4.Margin = new System.Windows.Forms.Padding(4);
            this.spinButton4.Name = "spinButton4";
            this.spinButton4.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.spinButton4.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinButton4.NormalTextColor = System.Drawing.Color.White;
            this.spinButton4.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton4.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.spinButton4.PushedTextColor = System.Drawing.Color.White;
            this.spinButton4.RoundRadius = 1;
            this.spinButton4.Size = new System.Drawing.Size(188, 39);
            this.spinButton4.TabIndex = 2;
            this.spinButton4.Text = "PAR DÉFAUT";
            this.spinButton4.Click += new System.EventHandler(this.btn_default_Click);
            // 
            // spinButton3
            // 
            this.spinButton3.BackColor = System.Drawing.Color.Transparent;
            this.spinButton3.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.spinButton3.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton3.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.spinButton3.HoverTextColor = System.Drawing.Color.White;
            this.spinButton3.IsEnabled = true;
            this.spinButton3.Location = new System.Drawing.Point(205, 41);
            this.spinButton3.Margin = new System.Windows.Forms.Padding(4);
            this.spinButton3.Name = "spinButton3";
            this.spinButton3.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.spinButton3.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinButton3.NormalTextColor = System.Drawing.Color.White;
            this.spinButton3.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton3.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.spinButton3.PushedTextColor = System.Drawing.Color.White;
            this.spinButton3.RoundRadius = 1;
            this.spinButton3.Size = new System.Drawing.Size(188, 39);
            this.spinButton3.TabIndex = 1;
            this.spinButton3.Text = "IE";
            this.spinButton3.Click += new System.EventHandler(this.btn_ie_Click);
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
            this.spinButton2.Margin = new System.Windows.Forms.Padding(4);
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
            // spinGroupBox1
            // 
            this.spinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.spinGroupBox1.BaseColor = System.Drawing.Color.Transparent;
            this.spinGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinGroupBox1.Controls.Add(this.check_SelectUSB);
            this.spinGroupBox1.Controls.Add(this.check_Sleep);
            this.spinGroupBox1.Controls.Add(this.check_region);
            this.spinGroupBox1.Controls.Add(this.check_IPV6);
            this.spinGroupBox1.Controls.Add(this.check_Adobe);
            this.spinGroupBox1.Controls.Add(this.check_unpin);
            this.spinGroupBox1.Controls.Add(this.check_OneDrive);
            this.spinGroupBox1.Controls.Add(this.check_pin);
            this.spinGroupBox1.Controls.Add(this.check_USBSleep);
            this.spinGroupBox1.Controls.Add(this.check_Firefox);
            this.spinGroupBox1.Controls.Add(this.check_NICSleep);
            this.spinGroupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinGroupBox1.HeaderColor = System.Drawing.Color.Transparent;
            this.spinGroupBox1.HeaderTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(218)))), ((int)(((byte)(218)))));
            this.spinGroupBox1.Location = new System.Drawing.Point(6, 102);
            this.spinGroupBox1.Name = "spinGroupBox1";
            this.spinGroupBox1.Size = new System.Drawing.Size(580, 285);
            this.spinGroupBox1.TabIndex = 30;
            this.spinGroupBox1.Text = "Actions à effectuer";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 503);
            this.Controls.Add(this.SSCDeploy_SpinForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSCDeploy";
            this.SSCDeploy_SpinForm.ResumeLayout(false);
            this.spinHorizontalTabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.radio_group.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.spinGroupBox1.ResumeLayout(false);
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
        private SpinButton spinButton5;
        private SpinButton spinButton4;
        private SpinButton spinButton3;
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
        private SpinGroupBox radio_group;
        private SpinRadioButton spinRadioButton1;
        private SpinRadioButton radio_new;
        private SpinRadioButton radio_update;
        private SpinGroupBox spinGroupBox1;
    }
}

