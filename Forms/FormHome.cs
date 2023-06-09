using System;
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
            tabControlIni.TabPages.Add(tabPage);
            tabPage.Text = name;
        }

    }
}
