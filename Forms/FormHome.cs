using System;
using System.Windows.Forms;

namespace r6sSettingsManager
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }


        public void AddTabPage(TabPage tabPage, String name)
        {
            //tabPage.Text = name;
            //tabControlIni.TabPages.Add(tabPage);

            tabControlIni.TabPages.Add(tabPage);
            tabPage.Text = name;
        }

    }
}
