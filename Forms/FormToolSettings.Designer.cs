namespace r6sSettingsManager
{
    partial class FormToolSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSettingDefaultDirectory = new System.Windows.Forms.Label();
            this.textBoxFolderPath = new System.Windows.Forms.TextBox();
            this.btnBrowsFolder = new System.Windows.Forms.Button();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.btnResetSetting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSettingDefaultDirectory
            // 
            this.labelSettingDefaultDirectory.AutoSize = true;
            this.labelSettingDefaultDirectory.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 12F, System.Drawing.FontStyle.Bold);
            this.labelSettingDefaultDirectory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelSettingDefaultDirectory.Location = new System.Drawing.Point(235, 196);
            this.labelSettingDefaultDirectory.Name = "labelSettingDefaultDirectory";
            this.labelSettingDefaultDirectory.Size = new System.Drawing.Size(257, 18);
            this.labelSettingDefaultDirectory.TabIndex = 0;
            this.labelSettingDefaultDirectory.Text = "Rainbow Six Siegeフォルダのパス";
            // 
            // textBoxFolderPath
            // 
            this.textBoxFolderPath.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxFolderPath.Location = new System.Drawing.Point(499, 192);
            this.textBoxFolderPath.Name = "textBoxFolderPath";
            this.textBoxFolderPath.ReadOnly = true;
            this.textBoxFolderPath.Size = new System.Drawing.Size(298, 23);
            this.textBoxFolderPath.TabIndex = 1;
            this.textBoxFolderPath.Click += new System.EventHandler(this.textBoxFolderPath_Click);
            // 
            // btnBrowsFolder
            // 
            this.btnBrowsFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowsFolder.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 10F, System.Drawing.FontStyle.Bold);
            this.btnBrowsFolder.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnBrowsFolder.Location = new System.Drawing.Point(812, 188);
            this.btnBrowsFolder.Name = "btnBrowsFolder";
            this.btnBrowsFolder.Size = new System.Drawing.Size(65, 32);
            this.btnBrowsFolder.TabIndex = 18;
            this.btnBrowsFolder.Text = "参照";
            this.btnBrowsFolder.UseVisualStyleBackColor = true;
            this.btnBrowsFolder.Click += new System.EventHandler(this.btnBrowsFolder_Click);
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSaveSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSetting.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 13F, System.Drawing.FontStyle.Bold);
            this.btnSaveSetting.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSaveSetting.Location = new System.Drawing.Point(898, 480);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(152, 31);
            this.btnSaveSetting.TabIndex = 19;
            this.btnSaveSetting.Text = "保存";
            this.btnSaveSetting.UseVisualStyleBackColor = false;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // btnResetSetting
            // 
            this.btnResetSetting.BackColor = System.Drawing.Color.Salmon;
            this.btnResetSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetSetting.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 13F, System.Drawing.FontStyle.Bold);
            this.btnResetSetting.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnResetSetting.Location = new System.Drawing.Point(706, 480);
            this.btnResetSetting.Name = "btnResetSetting";
            this.btnResetSetting.Size = new System.Drawing.Size(152, 31);
            this.btnResetSetting.TabIndex = 20;
            this.btnResetSetting.Text = "初期化";
            this.btnResetSetting.UseVisualStyleBackColor = false;
            this.btnResetSetting.Click += new System.EventHandler(this.btnResetSetting_Click);
            // 
            // FormToolSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1204, 689);
            this.Controls.Add(this.btnResetSetting);
            this.Controls.Add(this.btnSaveSetting);
            this.Controls.Add(this.btnBrowsFolder);
            this.Controls.Add(this.textBoxFolderPath);
            this.Controls.Add(this.labelSettingDefaultDirectory);
            this.Name = "FormToolSettings";
            this.Text = "Tool Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSettingDefaultDirectory;
        private System.Windows.Forms.TextBox textBoxFolderPath;
        private System.Windows.Forms.Button btnBrowsFolder;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.Button btnResetSetting;
    }
}