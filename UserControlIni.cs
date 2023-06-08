using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace r6sSettingsManager
{
    public partial class UserControlIni : UserControl
    {
        public UserControlIni()
        {
            InitializeComponent();
        }

    
        public int Ads1x { set { this.textBoxAds1x.Text = value.ToString(); } }
        public int Ads1xHalf { set { this.textBoxAds1xHalf.Text = value.ToString(); } }
        public int Ads2x { set { this.textBoxAds2x.Text = value.ToString(); } }
        public int Ads2xHalf { set { this.textBoxAds2xHalf.Text = value.ToString(); } }
        public int Ads3x { set { this.textBoxAds3x.Text = value.ToString(); } }
        public int Ads4x { set { this.textBoxAds4x.Text = value.ToString(); } }
        public int Ads5x { set { this.textBoxAds5x.Text = value.ToString(); } }
        public int Ads12x { set { this.textBoxAds12x.Text = value.ToString(); } }

    }
}
