using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Newtonsoft.Json;
using DarrenLee.Translator;

namespace DoAn511
{
    public partial class Form1 : Form
    {
        // install system.data.sqlite from nuget
        // install newtonsoft.json from nuget
        // add DarrenLee.Translate to references
        // add bing api to references service
        public Form1()
        {
            InitializeComponent();
            lang_from_to = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#082032");
            btn1.FillColor = btn2.FillColor= btn3.FillColor= btn4.FillColor = btnTrans.FillColor = btn_AV.FillColor = btn_VA.FillColor = ColorTranslator.FromHtml("#396EB0");
            pnl_top.BackColor = ColorTranslator.FromHtml("#2C394B");
            tbox1.ScrollBars = ScrollBars.Vertical; 
            tbox2.ScrollBars = ScrollBars.Vertical; 
        }

        int lang_from_to = 0; //0 - Anh Việt, 1 - Việt Anh, 2 - Anh Việt API, 3- Việt Anh API
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_AV_Click(object sender, EventArgs e)
        {
            lang_from_to = 0;
        }

        private void btn_VA_Click(object sender, EventArgs e)
        {
            lang_from_to = 1;
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            //connect object
            SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\Hoang Tien Dung\Documents\Ky1_Nam3\LapTrinhC#\DoAn\CS511.M11\Data\TuDien.db");
            con.Open();
            //command object
            string query = "";
            if (lang_from_to==0)
            {
                if (tbox1.Text == "")
                {
                    tbox2.Text = "<Không được để trống>";
                }
                else
                {
                    query = "SELECT * FROM AnhViet WHERE word='" + tbox1.Text.Trim().ToLower() + "'";

                }    
            }   
            else if(lang_from_to==1)
            {
                if (tbox1.Text == "")
                {
                    tbox2.Text = "<Cannot be left blank>";
                }
                else
                {
                    query = "SELECT * FROM VietAnh WHERE word='" + tbox1.Text.Trim().ToLower() + "'";

                }
            }
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            try
            {
                if (lang_from_to == 0)
                    tbox2.Text = "Phát âm: " + ds.Rows[0][2].ToString() + "\n" + ds.Rows[0][1].ToString();
                else
                    tbox2.Text = ds.Rows[0][1].ToString();
            }
            catch
            {
                if(lang_from_to==0)
                {
                    tbox2.Text = "<Không có trong từ điển>";
                }    
                else
                {
                    tbox2.Text = "<Not in the dictionary>";
                }    
                
            }
            con.Close();
        }
    }
}
