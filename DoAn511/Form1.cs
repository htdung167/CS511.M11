using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn511
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#082032");
            btn1.FillColor = btn2.FillColor= btn3.FillColor= btn4.FillColor = btnTrans.FillColor = btn_AV.FillColor = btn_VA.FillColor = ColorTranslator.FromHtml("#396EB0");
            pnl_top.BackColor = ColorTranslator.FromHtml("#2C394B");
            tbox1.ScrollBars = ScrollBars.Vertical; ;
            tbox2.ScrollBars = ScrollBars.Vertical; ;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
