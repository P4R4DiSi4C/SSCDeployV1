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
            this.btn_deploy = new MaterialSkin.Controls.MaterialFlatButton();
            this.deploy_progressbar = new MaterialSkin.Controls.MaterialProgressBar();
            this.btn_default = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_ie = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btn_privacy = new MaterialSkin.Controls.MaterialRaisedButton();
            this.text_deploy_progress = new System.Windows.Forms.RichTextBox();
            this.btn_onedrive = new MaterialSkin.Controls.MaterialRaisedButton();
            this.SuspendLayout();
            // 
            // btn_deploy
            // 
            this.btn_deploy.AutoSize = true;
            this.btn_deploy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_deploy.BackColor = System.Drawing.Color.Maroon;
            this.btn_deploy.Depth = 0;
            this.btn_deploy.Icon = null;
            this.btn_deploy.Location = new System.Drawing.Point(12, 68);
            this.btn_deploy.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btn_deploy.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_deploy.Name = "btn_deploy";
            this.btn_deploy.Primary = false;
            this.btn_deploy.Size = new System.Drawing.Size(206, 36);
            this.btn_deploy.TabIndex = 6;
            this.btn_deploy.Text = "DÉMARRER LE DÉPLOIEMENT";
            this.btn_deploy.UseVisualStyleBackColor = false;
            this.btn_deploy.Click += new System.EventHandler(this.btn_deploy_Click);
            // 
            // deploy_progressbar
            // 
            this.deploy_progressbar.Depth = 0;
            this.deploy_progressbar.Location = new System.Drawing.Point(12, 113);
            this.deploy_progressbar.MouseState = MaterialSkin.MouseState.HOVER;
            this.deploy_progressbar.Name = "deploy_progressbar";
            this.deploy_progressbar.Size = new System.Drawing.Size(206, 5);
            this.deploy_progressbar.TabIndex = 8;
            // 
            // btn_default
            // 
            this.btn_default.AutoSize = true;
            this.btn_default.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_default.Depth = 0;
            this.btn_default.Icon = null;
            this.btn_default.Location = new System.Drawing.Point(311, 238);
            this.btn_default.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_default.Name = "btn_default";
            this.btn_default.Primary = true;
            this.btn_default.Size = new System.Drawing.Size(193, 36);
            this.btn_default.TabIndex = 9;
            this.btn_default.Text = "Application par défaut";
            this.btn_default.UseVisualStyleBackColor = true;
            this.btn_default.Click += new System.EventHandler(this.btn_default_Click);
            // 
            // btn_ie
            // 
            this.btn_ie.AutoSize = true;
            this.btn_ie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_ie.Depth = 0;
            this.btn_ie.Icon = null;
            this.btn_ie.Location = new System.Drawing.Point(348, 186);
            this.btn_ie.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_ie.Name = "btn_ie";
            this.btn_ie.Primary = true;
            this.btn_ie.Size = new System.Drawing.Size(156, 36);
            this.btn_ie.TabIndex = 10;
            this.btn_ie.Text = "Internet Explorer";
            this.btn_ie.UseVisualStyleBackColor = true;
            this.btn_ie.Click += new System.EventHandler(this.btn_ie_Click);
            // 
            // btn_privacy
            // 
            this.btn_privacy.AutoSize = true;
            this.btn_privacy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_privacy.Depth = 0;
            this.btn_privacy.Icon = null;
            this.btn_privacy.Location = new System.Drawing.Point(368, 134);
            this.btn_privacy.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_privacy.Name = "btn_privacy";
            this.btn_privacy.Primary = true;
            this.btn_privacy.Size = new System.Drawing.Size(136, 36);
            this.btn_privacy.TabIndex = 11;
            this.btn_privacy.Text = "Confidentialité";
            this.btn_privacy.UseVisualStyleBackColor = true;
            this.btn_privacy.Click += new System.EventHandler(this.btn_privacy_Click);
            // 
            // text_deploy_progress
            // 
            this.text_deploy_progress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_deploy_progress.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_deploy_progress.Location = new System.Drawing.Point(12, 124);
            this.text_deploy_progress.Name = "text_deploy_progress";
            this.text_deploy_progress.Size = new System.Drawing.Size(293, 164);
            this.text_deploy_progress.TabIndex = 12;
            this.text_deploy_progress.Text = "";
            // 
            // btn_onedrive
            // 
            this.btn_onedrive.AutoSize = true;
            this.btn_onedrive.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_onedrive.Depth = 0;
            this.btn_onedrive.Icon = null;
            this.btn_onedrive.Location = new System.Drawing.Point(418, 82);
            this.btn_onedrive.MouseState = MaterialSkin.MouseState.HOVER;
            this.btn_onedrive.Name = "btn_onedrive";
            this.btn_onedrive.Primary = true;
            this.btn_onedrive.Size = new System.Drawing.Size(86, 36);
            this.btn_onedrive.TabIndex = 13;
            this.btn_onedrive.Text = "Onedrive";
            this.btn_onedrive.UseVisualStyleBackColor = true;
            this.btn_onedrive.Click += new System.EventHandler(this.btn_onedrive_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 300);
            this.Controls.Add(this.btn_onedrive);
            this.Controls.Add(this.text_deploy_progress);
            this.Controls.Add(this.btn_privacy);
            this.Controls.Add(this.btn_ie);
            this.Controls.Add(this.btn_default);
            this.Controls.Add(this.deploy_progressbar);
            this.Controls.Add(this.btn_deploy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSCDeploy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MaterialSkin.Controls.MaterialFlatButton btn_deploy;
        private MaterialSkin.Controls.MaterialProgressBar deploy_progressbar;
        private MaterialSkin.Controls.MaterialRaisedButton btn_default;
        private MaterialSkin.Controls.MaterialRaisedButton btn_ie;
        private MaterialSkin.Controls.MaterialRaisedButton btn_privacy;
        private System.Windows.Forms.RichTextBox text_deploy_progress;
        private MaterialSkin.Controls.MaterialRaisedButton btn_onedrive;
    }
}

