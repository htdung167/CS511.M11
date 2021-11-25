using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Data.SQLite;
using Newtonsoft.Json;
using DarrenLee.Translator;

namespace Test_Dung
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }


        private void but_dich_Click(object sender, EventArgs e)
        {   
            if(choosen==2)
            {
                rtxt_dich.Text = Translator.Translate(rtxt_nguon.Text, "en", "vi"); //(text, nguồn, đích)
            }
            if (choosen == 3)
            {
                rtxt_dich.Text=Translator.Translate(rtxt_nguon.Text, "vi", "en");
            }
            if (choosen==1 || choosen==0)
            {
                //connect object
                SQLiteConnection con = new SQLiteConnection(@"Data Source=C:\Users\Hoang Tien Dung\Documents\Ky1_Nam3\LapTrinhC#\DoAn\CS511.M11\Data\TuDien.db");
                con.Open();
                //command object
                if(rtxt_nguon.Text=="")
                {
                    rtxt_dich.Text = "<Không được để trống>";
                }
                else
                {
                    string query = "";
                    if (choosen == 0)
                        query = "SELECT * FROM AnhViet WHERE word='" + rtxt_nguon.Text.Trim().ToLower() +  "'";
                    else
                        query = "SELECT * FROM VietAnh WHERE word='" + rtxt_nguon.Text.Trim().ToLower() + "'";
                    SQLiteCommand cmd = new SQLiteCommand(query, con);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    DataTable ds = new DataTable();
                    adapter.Fill(ds);
                    try
                    {
                        if (choosen == 0)
                            rtxt_dich.Text = "Phát âm: " + ds.Rows[0][2].ToString() + "\n" + ds.Rows[0][1].ToString();
                        else
                            rtxt_dich.Text = ds.Rows[0][1].ToString();
                    }
                    catch
                    {
                        rtxt_dich.Text = "<không có>";
                    }
                    dataGridView1.DataSource = ds;
                }
                con.Close();
                //adapter
                 
                //get data
            }

        }

        int choosen = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            choosen = cb.SelectedIndex;
            label2.Text = choosen.ToString();
        }
    }
}
