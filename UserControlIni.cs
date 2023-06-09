﻿using System;
using IniParser;
using IniParser.Model;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace r6sSettingsManager
{
    public partial class UserControlIni : UserControl
    {

        private System.Windows.Forms.ProgressBar progressBar;
        private string filePath;

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
                writeSensValue(this.filePath);
            });

            // プログレスバーを非表示
            progressBar.Visible = false;

            // 緑の線（完了メッセージ）を表示
            MessageBox.Show(string.Format($"{filePath}への書き込みが完了しました。"), "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        // TextBoxにある値をiniファイルに書き込む
        public void writeSensValue(string filePath) {

            // iniFileに書き込み
            FileIniDataParser parser = new FileIniDataParser();
            IniData iniData = parser.ReadFile(filePath);

            // ini形式を用意する
            iniData["INPUT"]["ADSMouseSensitivity1x"] = Ads1x.ToString();
            iniData["INPUT"]["ADSMouseSensitivity1xHalf"] = Ads1xHalf.ToString();
            iniData["INPUT"]["ADSMouseSensitivity2x"] = Ads2x.ToString();
            iniData["INPUT"]["ADSMouseSensitivity2xHalf"] = Ads2xHalf.ToString();
            iniData["INPUT"]["ADSMouseSensitivity3x"] = Ads3x.ToString();
            iniData["INPUT"]["ADSMouseSensitivity4x"] = Ads4x.ToString();
            iniData["INPUT"]["ADSMouseSensitivity5x"] = Ads5x.ToString();
            iniData["INPUT"]["ADSMouseSensitivity12x"] = Ads12x.ToString();

            parser.WriteFile(filePath, iniData);
        }

        private void InitializeProgressBar()
        {
            progressBar = new System.Windows.Forms.ProgressBar();
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.Visible = false;

            // プログレスバーをフォームに追加
            Controls.Add(progressBar);
        }



        public string FILE_PATH
        {
            get { return this.filePath; }
            set { this.filePath = value.ToString(); }
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
