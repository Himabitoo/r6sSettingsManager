using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace r6sSettingsManager
{
    public partial class FormMain : Form
    {
        //フィールド変数
        private Form activeForm;

        public FormMain()
        {
            InitializeComponent();
        }



        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
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
            OpenChildForm(new FormHome(), sender);
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
            //ダイアログを表示して選択されたファイルのpath(複数可)
            string[] selectedFiles = IniFileDialog.ShowDialog();

            if (selectedFiles != null)
            {
                foreach (string file in selectedFiles)
                {   

                    // iniファイル
                    IniFile iniFile = new IniFile(file);
                    iniFile.LoadSensValue();

                    UserControlIni userControlIni = new UserControlIni();
                    userControlIni.FILE_PATH = file;
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
                        formHome.AddTabPage(tabPage,Path.GetFileName(file));
                    }
                }
            }
        }
    }
}
