using System.Windows.Forms;

namespace r6sSettingsManager
{
    public class IniFileDialog
    {
        public static string ShowDialog()
        {
            // ダイアログ変数を宣言
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            // 初期フォルダを設定
            //dialog.SelectedPath = initialDirectory;

            if (dialog.ShowDialog() == DialogResult.OK)
            {

                // OKボタンを押されたときの選択されていたファイルのPATHを返す。
                // これ以降のコードは実行されない。
                return dialog.SelectedPath;
            }

            // OK以外のボタンが押されたらnullを返す。
            return null;
        }

    }
}
