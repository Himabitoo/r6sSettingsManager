using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace r6sSettingsManager
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
            this.tabControlIni.BackColor = Color.FromArgb(34, 39, 46);
        }

        public void AddTabPage(TabPage tabPage, String name)
        {
            // 同じ名前のTabPageがすでに存在する場合は追加せずに終了する
            if (tabControlIni.TabPages.ContainsKey(name))
            {
                return;
            }

            tabControlIni.TabPages.Add(tabPage);
            tabPage.Name = name;
            tabPage.Text = name;
        }

    }
}
