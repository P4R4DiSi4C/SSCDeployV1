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
            this.spinForm1 = new SpinTheme.SpinForm();
            this.spinHorizontalTabControl1 = new SpinHorizontalTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.text_deploy_progress = new SpinTheme.SpinRichTextbox();
            this.spinButton1 = new SpinTheme.SpinButton();
            this.deploy_progressbar = new SpinTheme.SpinCircleProgressBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.spinButton2 = new SpinButton();
            this.spinButton3 = new SpinButton();
            this.spinButton4 = new SpinButton();
            this.spinButton5 = new SpinButton();
            this.exit_btn = new SpinButton();
            this.spinForm1.SuspendLayout();
            this.spinHorizontalTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // spinForm1
            // 
            this.spinForm1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.spinForm1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.spinForm1.Controls.Add(this.exit_btn);
            this.spinForm1.Controls.Add(this.spinHorizontalTabControl1);
            this.spinForm1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinForm1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.spinForm1.HeaderLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.spinForm1.HeaderSize = 50;
            this.spinForm1.HeaderTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.spinForm1.Location = new System.Drawing.Point(0, 0);
            this.spinForm1.Name = "spinForm1";
            this.spinForm1.Size = new System.Drawing.Size(452, 280);
            this.spinForm1.TabIndex = 0;
            this.spinForm1.Text = "SSCDeploy";
            this.spinForm1.TitleTextPostion = SpinTheme.SpinForm.TitlePostion.Left;
            // 
            // spinHorizontalTabControl1
            // 
            this.spinHorizontalTabControl1.BorderColor = System.Drawing.Color.Transparent;
            this.spinHorizontalTabControl1.Controls.Add(this.tabPage1);
            this.spinHorizontalTabControl1.Controls.Add(this.tabPage2);
            this.spinHorizontalTabControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.spinHorizontalTabControl1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.spinHorizontalTabControl1.ItemSize = new System.Drawing.Size(80, 40);
            this.spinHorizontalTabControl1.Location = new System.Drawing.Point(0, 51);
            this.spinHorizontalTabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.spinHorizontalTabControl1.Name = "spinHorizontalTabControl1";
            this.spinHorizontalTabControl1.RoundRadius = 1;
            this.spinHorizontalTabControl1.SelectedIndex = 0;
            this.spinHorizontalTabControl1.Size = new System.Drawing.Size(452, 229);
            this.spinHorizontalTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.spinHorizontalTabControl1.Speed = 40;
            this.spinHorizontalTabControl1.TabColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.spinHorizontalTabControl1.TabIndex = 3;
            this.spinHorizontalTabControl1.TabPageColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.spinHorizontalTabControl1.TabSelectedTextColor = System.Drawing.Color.White;
            this.spinHorizontalTabControl1.TabUnSlectedTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.spinHorizontalTabControl1.UseAnimation = true;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.tabPage1.Controls.Add(this.text_deploy_progress);
            this.tabPage1.Controls.Add(this.spinButton1);
            this.tabPage1.Controls.Add(this.deploy_progressbar);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(444, 181);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DEPLOY";
            // 
            // text_deploy_progress
            // 
            this.text_deploy_progress.AutoWordSelection = false;
            this.text_deploy_progress.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.text_deploy_progress.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.text_deploy_progress.ForeColor = System.Drawing.Color.Silver;
            this.text_deploy_progress.Lines = null;
            this.text_deploy_progress.Location = new System.Drawing.Point(0, 1);
            this.text_deploy_progress.Name = "text_deploy_progress";
            this.text_deploy_progress.ReadOnly = false;
            this.text_deploy_progress.Size = new System.Drawing.Size(276, 180);
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
            this.spinButton1.Location = new System.Drawing.Point(295, 137);
            this.spinButton1.Name = "spinButton1";
            this.spinButton1.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.spinButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinButton1.NormalTextColor = System.Drawing.Color.White;
            this.spinButton1.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton1.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.spinButton1.PushedTextColor = System.Drawing.Color.White;
            this.spinButton1.RoundRadius = 5;
            this.spinButton1.Size = new System.Drawing.Size(132, 39);
            this.spinButton1.TabIndex = 1;
            this.spinButton1.Text = "DEPLOYER";
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
            this.deploy_progressbar.Location = new System.Drawing.Point(295, 0);
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
            this.tabPage2.Controls.Add(this.spinButton5);
            this.tabPage2.Controls.Add(this.spinButton4);
            this.tabPage2.Controls.Add(this.spinButton3);
            this.tabPage2.Controls.Add(this.spinButton2);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(444, 181);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "EXTRA";
            // 
            // spinButton2
            // 
            this.spinButton2.BackColor = System.Drawing.Color.Transparent;
            this.spinButton2.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.spinButton2.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton2.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.spinButton2.HoverTextColor = System.Drawing.Color.White;
            this.spinButton2.IsEnabled = true;
            this.spinButton2.Location = new System.Drawing.Point(34, 34);
            this.spinButton2.Name = "spinButton2";
            this.spinButton2.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.spinButton2.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinButton2.NormalTextColor = System.Drawing.Color.White;
            this.spinButton2.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton2.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.spinButton2.PushedTextColor = System.Drawing.Color.White;
            this.spinButton2.RoundRadius = 1;
            this.spinButton2.Size = new System.Drawing.Size(141, 32);
            this.spinButton2.TabIndex = 0;
            this.spinButton2.Text = "ONEDRIVE";
            this.spinButton2.Click += new System.EventHandler(this.btn_onedrive_Click);
            // 
            // spinButton3
            // 
            this.spinButton3.BackColor = System.Drawing.Color.Transparent;
            this.spinButton3.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.spinButton3.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton3.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.spinButton3.HoverTextColor = System.Drawing.Color.White;
            this.spinButton3.IsEnabled = true;
            this.spinButton3.Location = new System.Drawing.Point(34, 119);
            this.spinButton3.Name = "spinButton3";
            this.spinButton3.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.spinButton3.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinButton3.NormalTextColor = System.Drawing.Color.White;
            this.spinButton3.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton3.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.spinButton3.PushedTextColor = System.Drawing.Color.White;
            this.spinButton3.RoundRadius = 1;
            this.spinButton3.Size = new System.Drawing.Size(141, 32);
            this.spinButton3.TabIndex = 1;
            this.spinButton3.Text = "IE";
            this.spinButton3.Click += new System.EventHandler(this.btn_ie_Click);
            // 
            // spinButton4
            // 
            this.spinButton4.BackColor = System.Drawing.Color.Transparent;
            this.spinButton4.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.spinButton4.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton4.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.spinButton4.HoverTextColor = System.Drawing.Color.White;
            this.spinButton4.IsEnabled = true;
            this.spinButton4.Location = new System.Drawing.Point(280, 34);
            this.spinButton4.Name = "spinButton4";
            this.spinButton4.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.spinButton4.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinButton4.NormalTextColor = System.Drawing.Color.White;
            this.spinButton4.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton4.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.spinButton4.PushedTextColor = System.Drawing.Color.White;
            this.spinButton4.RoundRadius = 1;
            this.spinButton4.Size = new System.Drawing.Size(141, 32);
            this.spinButton4.TabIndex = 2;
            this.spinButton4.Text = "DEFAULT APPS";
            this.spinButton4.Click += new System.EventHandler(this.btn_default_Click);
            // 
            // spinButton5
            // 
            this.spinButton5.BackColor = System.Drawing.Color.Transparent;
            this.spinButton5.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.spinButton5.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton5.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(212)))), ((int)(((byte)(46)))));
            this.spinButton5.HoverTextColor = System.Drawing.Color.White;
            this.spinButton5.IsEnabled = true;
            this.spinButton5.Location = new System.Drawing.Point(280, 119);
            this.spinButton5.Name = "spinButton5";
            this.spinButton5.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(144)))), ((int)(((byte)(210)))));
            this.spinButton5.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(151)))), ((int)(((byte)(222)))));
            this.spinButton5.NormalTextColor = System.Drawing.Color.White;
            this.spinButton5.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(174)))), ((int)(((byte)(72)))));
            this.spinButton5.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(135)))), ((int)(((byte)(16)))));
            this.spinButton5.PushedTextColor = System.Drawing.Color.White;
            this.spinButton5.RoundRadius = 1;
            this.spinButton5.Size = new System.Drawing.Size(141, 32);
            this.spinButton5.TabIndex = 3;
            this.spinButton5.Text = "PRIVACY";
            this.spinButton5.Click += new System.EventHandler(this.btn_privacy_Click);
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.Color.Transparent;
            this.exit_btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_btn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.exit_btn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.exit_btn.HoverTextColor = System.Drawing.Color.White;
            this.exit_btn.IsEnabled = true;
            this.exit_btn.Location = new System.Drawing.Point(431, 4);
            this.exit_btn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.NormalBorderColor = System.Drawing.Color.Transparent;
            this.exit_btn.NormalColor = System.Drawing.Color.Transparent;
            this.exit_btn.NormalTextColor = System.Drawing.Color.DarkRed;
            this.exit_btn.PushedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.exit_btn.PushedColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.exit_btn.PushedTextColor = System.Drawing.Color.White;
            this.exit_btn.RoundRadius = 1;
            this.exit_btn.Size = new System.Drawing.Size(18, 17);
            this.exit_btn.TabIndex = 4;
            this.exit_btn.Text = "X";
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 280);
            this.Controls.Add(this.spinForm1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSCDeploy";
            this.spinForm1.ResumeLayout(false);
            this.spinHorizontalTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SpinTheme.SpinForm spinForm1;
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
    }
}

