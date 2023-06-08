using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace r6sSettingsManager
{
    public class IniFileDialog
    {
        public static string[] ShowDialog()
        {
            // Dialog変数を宣言
            OpenFileDialog dialog = new OpenFileDialog();

            // Dialogでフィルターするファイルを指定する
            dialog.Filter = "INI ファイル (*.ini)|*.ini";

            // 複数選択 True
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                // OKボタンを押されたときの選択されていたファイルのPATHを返す。
                // これ以降のコードは実行されない。
                return dialog.FileNames;
            }


            // OK以外のボタンが押されたらnullを返す。
            return null;
        }

    }
}
