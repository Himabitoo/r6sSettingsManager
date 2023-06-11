using System;
using IniParser;
using IniParser.Model;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace r6sSettingsManager
{
    public partial class UserControlIni : UserControl
    {
        private string[] allFilePath;
        private string filePath;
        private ProgressBar progressBar;

        public UserControlIni()
        {
            InitializeComponent();
            InitializeProgressBar();
        }

        // 非同期処理
        private async void btnApply_Click(object sender, EventArgs e)
        {
            // プログレスバーを表示
            progressBar.Visible = true;

            // 非同期で処理を実行
            await Task.Run(() =>
            {
                // ファイルの保存処理を実行
                WriteSettingsToFile(this.filePath);

            });

            // プログレスバーを非表示
            progressBar.Visible = false;
        }

        // TextBoxにある値をiniファイルに書き込む
        private void WriteSettingsToFile(string filePath) {

            // チェックボックスにチェックが入っていたら
            if(checkBoxApplyAll.Checked) 
            {

                // 再確認
               DialogResult result = MessageBox.Show(string.Format("読み込まれている全GameSettings.iniファイルに現在のTabの値を設定しようとしています。よろしいでしょうか？"), "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // はいを押したら
                if (result == DialogResult.Yes)
                {
                    //ファイルの数だけ繰り返し
                    foreach (string afp in this.allFilePath)
                    {

                        Console.WriteLine(afp);

                        // iniFileに書き込み
                        FileIniDataParser parser = new FileIniDataParser();
                        IniData iniData = parser.ReadFile(afp);

                        // ini形式を用意する
                        // MultiUnit
                        iniData["INPUT"]["MouseSensitivityMultiplierUnit"] = MultiplierUnit.ToString();

                        // 水平、垂直
                        iniData["INPUT"]["MouseYawSensitivity"] = SensYaw.ToString();
                        iniData["INPUT"]["MousePitchSensitivity"] = SensPitch.ToString();

                        // ads感度
                        iniData["INPUT"]["ADSMouseSensitivity1x"] = Ads1x.ToString();
                        iniData["INPUT"]["ADSMouseSensitivity1xHalf"] = Ads1xHalf.ToString();
                        iniData["INPUT"]["ADSMouseSensitivity2x"] = Ads2x.ToString();
                        iniData["INPUT"]["ADSMouseSensitivity2xHalf"] = Ads2xHalf.ToString();
                        iniData["INPUT"]["ADSMouseSensitivity3x"] = Ads3x.ToString();
                        iniData["INPUT"]["ADSMouseSensitivity4x"] = Ads4x.ToString();
                        iniData["INPUT"]["ADSMouseSensitivity5x"] = Ads5x.ToString();
                        iniData["INPUT"]["ADSMouseSensitivity12x"] = Ads12x.ToString();

                        // 書き込み
                        parser.WriteFile(afp, iniData);

                    }

                    // 完了メッセージを表示
                    MessageBox.Show(string.Format("書き込みが完了しました。"), "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 再起動
                    Application.Restart();

                }// いいえ
                else{

                    //処理を終わる
                    return;

                }
            }
            else // チェックがない場合その設定をそのファイルだけに反映する
            {
                // iniFileに書き込み
                FileIniDataParser parser = new FileIniDataParser();
                IniData iniData = parser.ReadFile(filePath);

                // ini形式を用意する
                // MultiUnit
                iniData["INPUT"]["MouseSensitivityMultiplierUnit"] = MultiplierUnit.ToString();

                // 水平、垂直
                iniData["INPUT"]["MouseYawSensitivity"] = SensYaw.ToString();
                iniData["INPUT"]["MousePitchSensitivity"] = SensPitch.ToString();

                // ads感度
                iniData["INPUT"]["ADSMouseSensitivity1x"] = Ads1x.ToString();
                iniData["INPUT"]["ADSMouseSensitivity1xHalf"] = Ads1xHalf.ToString();
                iniData["INPUT"]["ADSMouseSensitivity2x"] = Ads2x.ToString();
                iniData["INPUT"]["ADSMouseSensitivity2xHalf"] = Ads2xHalf.ToString();
                iniData["INPUT"]["ADSMouseSensitivity3x"] = Ads3x.ToString();
                iniData["INPUT"]["ADSMouseSensitivity4x"] = Ads4x.ToString();
                iniData["INPUT"]["ADSMouseSensitivity5x"] = Ads5x.ToString();
                iniData["INPUT"]["ADSMouseSensitivity12x"] = Ads12x.ToString();

                // 書き込み
                parser.WriteFile(filePath, iniData);

                // 完了メッセージを表示
                MessageBox.Show(string.Format("書き込みが完了しました。"), "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        
        }

        private void InitializeProgressBar()
        {
            progressBar = new ProgressBar();
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Visible = false;

            // プログレスバーをフォームに追加
            Controls.Add(progressBar);
        }


        public string[] ALL_FILE_PATH
        {
            get { return this.allFilePath; }
            set { this.allFilePath = value; }
        }


        public string FILE_PATH
        {
            get { return this.filePath; }
            set { this.filePath = value.ToString(); }
        }


        public float MultiplierUnit
        {
            get { return float.Parse(this.textBoxMultiplierUnit.Text); }
            set { this.textBoxMultiplierUnit.Text = value.ToString(); }
        }

        public int SensYaw
        {
            get { return int.Parse(this.textBoxSensYaw.Text); }
            set { this.textBoxSensYaw.Text = value.ToString(); }
        }

        public int SensPitch
        {
            get { return int.Parse(this.textBoxSensPitch.Text); }
            set { this.textBoxSensPitch.Text = value.ToString(); }
        }

        public int Ads1x
        {
            get { return int.Parse(this.textBoxAds1x.Text); }
            set { this.textBoxAds1x.Text = value.ToString(); }
        }


        public int Ads1xHalf
        {
            get { return int.Parse(this.textBoxAds1xHalf.Text); }
            set { this.textBoxAds1xHalf.Text = value.ToString(); }
        }

        public int Ads2x
        {
            get { return int.Parse(this.textBoxAds2x.Text); }
            set { this.textBoxAds2x.Text = value.ToString(); }
        }

        public int Ads2xHalf
        {
            get { return int.Parse(this.textBoxAds2xHalf.Text); }
            set { this.textBoxAds2xHalf.Text = value.ToString(); }
        }

        public int Ads3x
        {
            get { return int.Parse(this.textBoxAds3x.Text); }
            set { this.textBoxAds3x.Text = value.ToString(); }
        }

        public int Ads4x
        {
            get { return int.Parse(this.textBoxAds4x.Text); }
            set { this.textBoxAds4x.Text = value.ToString(); }
        }

        public int Ads5x
        {
            get { return int.Parse(this.textBoxAds5x.Text); }
            set { this.textBoxAds5x.Text = value.ToString(); }
        }

        public int Ads12x
        {
            get { return int.Parse(this.textBoxAds12x.Text); }
            set { this.textBoxAds12x.Text = value.ToString(); }
        }

    }
}
