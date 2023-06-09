﻿using IniParser.Model;
using IniParser;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace r6sSettingsManager
{
    public partial class FormMain : Form
    {
        //フィールド変数
        private string SettingsFilePath;
        private string settingsFolderPath;
        private Form activeForm;
        private FormHome formHome;
        private string urlProfile = "https://github.com/Himabitoo";
        private string urlRepository = "https://github.com/Himabitoo/r6sSettingsManager";

        public FormMain()
        {
            InitializeComponent();
            formHome = new FormHome();

            // exeファイルのパスを取得
            string exeFilePath = Application.ExecutablePath;

            // exeファイルと同じディレクトリのパスを取得
            string exeDirectory = Path.GetDirectoryName(exeFilePath);

            // Settings.iniファイルのパスを作成
            SettingsFilePath = Path.Combine(exeDirectory, "Settings.ini");

            // 読み込み作業
            // Ini読み込み
            var parser = new FileIniDataParser();
            IniData iniData = parser.ReadFile(SettingsFilePath);

            if (iniData["PATH"]["r6sSettingsFolder"] != "")
            {
                this.settingsFolderPath = iniData["PATH"]["r6sSettingsFolder"];
            }

        }

        private void OpenChildForm(Form childForm, object btnSender, string filePath = null)
        {
            if (activeForm != null && activeForm.GetType() == childForm.GetType())
            {
                // 既に同じ型の子フォームが表示されている場合は、再表示せずに終了する
                return;
            }

            activeForm = childForm;
            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            activeForm.BringToFront();
            activeForm.Show();

        }

        /// <summary>
        ///ホームフォーム
        /// </summary>
        private void btnHome_Click(object sender, EventArgs e)
        {   

            OpenChildForm(formHome, sender);

            if (settingsFolderPath != "")
            {
                openFolder(this.settingsFolderPath);
            }
            
        }

        /// <summary>
        /// ツール設定フォーム
        /// </summary>
        private void btnToolSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormToolSettings(), sender);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {   
            // ヒント
            MessageBox.Show(string.Format("My Gamesフォルダ内の「Rainbow Six Siege」フォルダを選択してください。"), "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //ダイアログを表示して選択されたファイルのpath(複数可)
            string selectedFolder = IniFileDialog.ShowDialog();

            openFolder(selectedFolder);
        }

        public void openFolder(string selectedFolder)
        {
            if (!string.IsNullOrEmpty(selectedFolder))
            {
                // 親ディレクトリからGameSettings.iniを全取得する
                string[] iniFiles = Directory.GetFiles(selectedFolder, "GameSettings.ini", SearchOption.AllDirectories);

                foreach (string file in iniFiles)
                {
                    // iniファイル
                    IniFile iniFile = new IniFile(file);
                    iniFile.LoadSensValue();

                    UserControlIni userControlIni = new UserControlIni();

                    userControlIni.ALL_FILE_PATH = iniFiles;
                    userControlIni.FILE_PATH = file;

                    // 非ADS時のMultiUnit
                    userControlIni.MultiplierUnit = iniFile.MultiplierUnit;

                    // 水平,垂直感度
                    userControlIni.SensYaw = iniFile.SensYaw;
                    userControlIni.SensPitch = iniFile.SensPitch;

                    // Ads感度
                    userControlIni.Ads1x = iniFile.Ads1x;
                    userControlIni.Ads1xHalf = iniFile.Ads1xHalf;
                    userControlIni.Ads2x = iniFile.Ads2x;
                    userControlIni.Ads2xHalf = iniFile.Ads2xHalf;
                    userControlIni.Ads3x = iniFile.Ads3x;
                    userControlIni.Ads4x = iniFile.Ads4x;
                    userControlIni.Ads5x = iniFile.Ads5x;
                    userControlIni.Ads12x = iniFile.Ads12x;

                    var tabPage = new TabPage();
                    tabPage.Controls.Add(userControlIni);

                    // FormHome のインスタンスを取得し、AddTabPage メソッドを呼び出してタブを追加する
                    FormHome formHome = Application.OpenForms.OfType<FormHome>().FirstOrDefault();

                    if (formHome != null)
                    {
                        formHome.AddTabPage(tabPage, Path.GetFileName(Path.GetDirectoryName(file)));
                    }
                }
            }
        }

        private void pictureBoxIcon_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.urlProfile);
        }

        private void pictureBoxGitHub_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(this.urlRepository);
        }
    }
}
