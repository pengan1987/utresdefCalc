using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace utresdefCalc
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            try
            {
                double _pixelFreq = Convert.ToDouble(this.pixelFreq.Text);
                int _hVisible = Convert.ToInt32(this.hVisiable.Text);
                int _hSyncStart = Convert.ToInt32(this.hSyncStart.Text);
                int _hSyncEnd = Convert.ToInt32(this.hSyncEnd.Text);
                int _hTotal = Convert.ToInt32(this.hTotal.Text);
                int _hFrontPorch = _hSyncStart - _hVisible;
                int _hBackPorch = _hTotal - _hSyncEnd;
                int _hSyncWidth = _hSyncEnd - _hSyncStart;


                int _vVisible = Convert.ToInt32(this.vVisiable.Text);
                int _vSyncStart = Convert.ToInt32(this.vSyncStart.Text);
                int _vSyncEnd = Convert.ToInt32(this.vSyncEnd.Text);
                int _vTotal = Convert.ToInt32(this.vTotal.Text);

                int _vFrontPorch = _vSyncStart - _vVisible;
                int _vBackPorch = _vTotal - _vSyncEnd;
                int _vSyncWidth = _vSyncEnd - _vSyncStart;

                double _refreshRate = _pixelFreq * 1000000 / _vTotal / _hTotal;

                string utresdef = "";
                utresdef += ("htotal=" + _hTotal.ToString() + "\r\n");
                utresdef += ("hfp=" + _hFrontPorch.ToString() + "\r\n");
                utresdef += ("hsyncwidth=" + _hSyncWidth.ToString() + "\r\n");
                utresdef += ("vtotal=" + _vTotal.ToString() + "\r\n");
                utresdef += ("vfp=" + _vFrontPorch.ToString() + "\r\n");
                utresdef += ("vsyncwidth=" + _vSyncWidth.ToString() + "\r\n");
                utresdef += ("vcomposite=8" + "\r\n");
                utresdef += ("pixclock=" + (_pixelFreq * 100).ToString() + "\r\n");
                utresdef += ("xres=" + _hVisible.ToString() + "\r\n");
                utresdef += ("yres=" + _vVisible.ToString() + "\r\n");
                utresdef += ("hz=" + Math.Round(_refreshRate).ToString() + "\r\n");


                textBoxUT.Text = utresdef;
            }
            catch(Exception ex){
                Console.WriteLine(ex);
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }

    
    }
}
