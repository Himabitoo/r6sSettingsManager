using IniParser.Model;
using IniParser;
using System;
using System.IO;
using System.Windows.Forms;

namespace r6sSettingsManager
{
    public partial class FormToolSettings : Form
    {   
        private string settingsFilePath;
        private string textBoxClickMsg = "ここには入力できません。\n参照ボタンを使ってください。";
        private string saveMsg= "設定の保存が完了しました。";
        private string resetMsg= "設定の初期化が完了しました。";
        private string restartMsg = "設定が変わったため再起動を行います。";
        private string warningMsg = "Rainbow Six Siege フォルダのパスの入力欄が空です。";

        public FormToolSettings()
        {
            InitializeComponent();

            // exeファイルのパスを取得
            string exeFilePath = Application.ExecutablePath;

            // exeファイルと同じディレクトリのパスを取得
            string exeDirectory = Path.GetDirectoryName(exeFilePath);

            // Settings.iniファイルのパスを作成
            SettingsFilePath = Path.Combine(exeDirectory, "Settings.ini");

            // iniに書かれている設定を読み込む
            loadToolSettings(SettingsFilePath);
        }

        // 読み込む
        private void loadToolSettings(string filePath)
        {
            // Ini読み込み
            var parser = new FileIniDataParser();
            IniData iniData = parser.ReadFile(filePath);

            this.textBoxFolderPath.Text = iniData["PATH"]["r6sSettingsFolder"];
        }


        private void btnBrowsFolder_Click(object sender, EventArgs e)
        {
            // ヒント
            MessageBox.Show(string.Format("My Gamesフォルダ内の「Rainbow Six Siege」フォルダを選択してください。"), "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //ダイアログを表示して選択されたファイルのpath(複数可)
            string selectedFolder = IniFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(selectedFolder))
            {
                this.textBoxFolderPath.Text = selectedFolder;
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            // テキストボックスが空じゃなかったら
            if (this.textBoxFolderPath.Text != "")
            {
                // iniFileに書き込み
                FileIniDataParser parser = new FileIniDataParser();
                IniData iniData = parser.ReadFile(SettingsFilePath);

                // ini形式を用意する
                // MultiUnit
                iniData["PATH"]["r6sSettingsFolder"] = this.textBoxFolderPath.Text;

                // 書き込み
                parser.WriteFile(SettingsFilePath, iniData);

                // ヒント
                MessageBox.Show(string.Format("設定が保存されました。"), "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show(string.Format(restartMsg), "再起動", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // 再起動
                Application.Restart();

            }
            else
            {

                MessageBox.Show(string.Format(warningMsg), "処理を止めました", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnResetSetting_Click(object sender, EventArgs e)
        {
            // テキストボックスの中身を空にする
            this.textBoxFolderPath.Text = "";

            // iniFileに書き込み
            FileIniDataParser parser = new FileIniDataParser();
            IniData iniData = parser.ReadFile(SettingsFilePath);

            // ini形式を用意する
            // MultiUnit
            iniData["PATH"]["r6sSettingsFolder"] = this.textBoxFolderPath.Text;

            // 書き込み
            parser.WriteFile(SettingsFilePath, iniData);

            MessageBox.Show(string.Format(resetMsg), "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show(string.Format(restartMsg), "再起動", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            // 再起動
            Application.Restart();
        }


        private void textBoxFolderPath_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format(textBoxClickMsg), "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        // getter setter
        public string SettingsFilePath { get { return this.settingsFilePath; } set {  this.settingsFilePath = value; } }


    }
}
