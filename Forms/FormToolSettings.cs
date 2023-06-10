using System;
using System.IO;
using System.Windows.Forms;

namespace r6sSettingsManager
{
    public partial class FormToolSettings : Form
    {

        private string saveMsg= "設定の保存が完了しました。";
        private string settingsFilePath;

        public FormToolSettings()
        {
            InitializeComponent();

            // exeファイルのパスを取得
            string exeFilePath = Application.ExecutablePath;

            // exeファイルと同じディレクトリのパスを取得
            string exeDirectory = Path.GetDirectoryName(exeFilePath);

            // Settings.iniファイルのパスを作成
            this.settingsFilePath = Path.Combine(exeDirectory, "Settings.ini");

            // iniに書かれている設定を読み込む
            loadToolSettings();
        }

        private void loadToolSettings()
        {

        }


        private void btnBrowsFolder_Click(object sender, EventArgs e)
        {
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
            if (this.textBoxFolderPath.Text != null)
            {
                // save Tool Setting



                MessageBox.Show(string.Format(saveMsg), "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {


            
            }
        }

        private void btnResetSetting_Click(object sender, EventArgs e)
        {
            
        }
    }
}
