using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Guna.UI2.WinForms;
using FontAwesome.Sharp;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.Media;
using Tesseract;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Collections;

namespace PhienDich
{
    public partial class Form1 : Form
    {
        // install system.data.sqlite from nuget
        // install newtonsoft.json from nuget
        // add system.speech
        // install Tesseract
        // add file python vao bin/debug
        // add data tesseract vao bin/debug
        //http://api.microsofttranslator.com/V1/SOAP.svc -- TranslatorService
        int lang_from_to = 0; //0 - Anh Việt, 1 - Việt Anh
        int lang_from_to_2 = 2; //2 - Anh Việt API, 3- Việt Anh API
        int lang_important = 1; // 0 - Anh, 1 - Việt
        int lang_ocr = 0; //0 - AV, 1 - VA
        int lang_all = 0; //0 - Anh, 1 - Việt
        int voice_gender_vietnam = 0; // 0 - random, 1- nam, 2-nữ
        int voice_gender_english = 0; // 0 - random, 1- nam, 2-nữ
        int type_color = 0; // 0 - default, i-type i
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(1248, 688);
            lang_from_to = 0;
            lang_from_to_2 = 2;
            lang_important = 1;
            lang_ocr = 0;
            lang_all = 0;
            voice_gender_vietnam = 0;
            voice_gender_english = 0;
            type_color = 0;
            color_main = ColorTranslator.FromHtml("#082032");
            color_btn_noclick = ColorTranslator.FromHtml("#396EB0");
            color_btn_click = ColorTranslator.FromHtml("#FF4C29");
            color_txt_noclick = Color.White;
            color_txt_click = Color.Black;
            Visible(panel_dich);
            path = Directory.GetCurrentDirectory();
            cBox_color_set.SelectedIndex = 0;
        }

        private void Visible(Guna2Panel pn)
        {
            panel_dich.Visible = false;
            panel_dichnangcao.Visible = false;
            panel_his.Visible = false;
            pnl_save.Visible = false;
            panel_img.Visible = false;
            panel_setting.Visible = false;
            pn.Visible = true;
            pn.Location = new Point(0, 176);
            pn.Size = new Size(1245, 510);

        }

        Color color_main = ColorTranslator.FromHtml("#082032");
        Color color_btn_noclick = ColorTranslator.FromHtml("#396EB0");
        Color color_btn_click = ColorTranslator.FromHtml("#FF4C29");
        Color color_txt_noclick = Color.White;
        Color color_txt_click = Color.Black;
        private void Highlight_button_main(Guna2Button btn)
        {
            btn_main.FillColor = color_btn_noclick;
            btn_main.ForeColor = Color.White;
            btn_adv.FillColor = color_btn_noclick;
            btn_adv.ForeColor = Color.White;
            btn_his.FillColor = color_btn_noclick;
            btn_his.ForeColor = Color.White;
            btn_img.FillColor = color_btn_noclick;
            btn_img.ForeColor = Color.White;
            btn_important_word.FillColor = color_btn_noclick;
            btn_important_word.ForeColor = Color.White;
            btn_setting.FillColor = color_btn_noclick;
            btn_setting.ForeColor = Color.White;
            btn.FillColor = color_btn_click;
            btn.ForeColor = Color.Black;
        }
        //PANEL_DICH//
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = color_main;
            btn_setting.FillColor = btn_add_folder.FillColor = btn_add_word.FillColor = btn_del_folder.FillColor = btn_tree_A.FillColor = btn_tree_V.FillColor =  btn_add_img.FillColor = btn_scan.FillColor = btn_AV_ocr.FillColor = btn_VA_ocr.FillColor = btn_trans_ocr.FillColor = btn_main.FillColor = btn_adv.FillColor = btn_his.FillColor = btn_important_word.FillColor = btnTrans.FillColor = btn_AV.FillColor = btn_VA.FillColor = btn_AV_api.FillColor = btn_VA_api.FillColor = btnTrans_2.FillColor = color_btn_noclick;
            btn_tree_A.FillColor = btn_tree_V.FillColor=btn_save.BackColor = color_btn_noclick;
            pnl_top.BackColor = ColorTranslator.FromHtml("#2C394B");
            tbox1.ScrollBars = ScrollBars.Vertical; ;
            tbox2.ScrollBars = ScrollBars.Vertical; ;
            btn_AV.FillColor = color_btn_click;
            btn_AV.ForeColor = Color.Black;
            btn_AV_api.FillColor = color_btn_click;
            btn_AV_api.ForeColor = Color.Black;
            btn_AV_ocr.FillColor = color_btn_click;
            btn_AV_ocr.ForeColor = Color.Black;
            click_btn_tree(btn_tree_V);
            //ShowTree(treeA);
            Highlight_button_main(btn_main);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void click_A_V(Guna2Button a, Guna2Button b)
        {
            a.FillColor = color_btn_click;
            a.ForeColor = Color.Black;
            b.FillColor = color_btn_noclick;
            b.ForeColor = Color.White;
        }
        private void btn_AV_Click(object sender, EventArgs e)
        {
            click_A_V(btn_AV, btn_VA);
            lang_from_to = 0;
        }

        private void btn_VA_Click(object sender, EventArgs e)
        {
            click_A_V(btn_VA, btn_AV);
            lang_from_to = 1;
        }

        private void btnTrans_Click(object sender, EventArgs e)
        {
            if(tbox1.Text.Split('\n').Length <= 200)
            {
                ItemSearch item = new ItemSearch();
                if (lang_from_to == 0 || lang_from_to == 1)
                {
                    SQLiteConnection con = new SQLiteConnection(@"Data Source=..\..\..\Data\TuDien.db");
                    con.Open();
                    //command object
                    string query = "";
                    if (lang_from_to == 0)
                    {
                        item.Title = lang["English - Vietnamese"][lang_all];
                        if (tbox1.Text == "")
                        {
                            tbox2.Text = "<Không được để trống>";
                        }
                        else
                        {
                            item.Search = tbox1.Text;
                            query = "SELECT * FROM AnhViet WHERE word='" + tbox1.Text.Trim().ToLower() + "'";

                        }
                    }
                    else if (lang_from_to == 1)
                    {
                        item.Title = lang["Vietnamese - English"][lang_all];
                        if (tbox1.Text == "")
                        {
                            tbox2.Text = "<Cannot be left blank>";
                        }
                        else
                        {
                            item.Search = tbox1.Text;
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
                        {
                            tbox2.Text = ("Phát âm: " + ds.Rows[0][2].ToString() + "\n" + ds.Rows[0][1].ToString()).Replace("\n", "\r\n");
                            var sr = new StringReader((ds.Rows[0][1].ToString()).Replace("\n", "\r\n"));

                            string line1 = sr.ReadLine();

                            string line2 = sr.ReadLine();
                            string first_two_lines = line1 + Environment.NewLine + line2;
                            item.Meaning = first_two_lines;
                        }
                        else
                        {
                            tbox2.Text = ds.Rows[0][1].ToString().Replace("\n", "\r\n");

                            var sr = new StringReader((ds.Rows[0][1].ToString()).Replace("\n", "\r\n"));

                            string line1 = sr.ReadLine();

                            string line2 = sr.ReadLine();
                            string first_two_lines = line1 + Environment.NewLine + line2;
                            item.Meaning = first_two_lines;
                        }
                    }
                    catch
                    {
                        if (lang_from_to == 0)
                        {
                            tbox2.Text = "<Không có trong từ điển>";
                            item.Meaning = "<Không có trong từ điển>";
                        }
                        else
                        {
                            tbox2.Text = "<Not in the dictionary>";
                            item.Meaning = "<Not in the dictionary>";
                        }

                    }
                    con.Close();
                }

                flow_his.Controls.Add(item);
            }    
            else
            {
                if (lang_from_to == 0)
                {
                    tbox2.Text = "<Vượt quá giới hạn 200 từ cho phép>";
                }
                else if (lang_from_to == 1)
                {
                    tbox2.Text = "<Exceeded the limit of 200 words allowed>";
                }
            }    
             
        }

        //PANEL_DICHNANGCAO
         
        private void btn_AV_api_Click(object sender, EventArgs e)
        {
            click_A_V(btn_AV_api, btn_VA_api);
            lang_from_to_2 = 2;
        }

        private void btn_VA_api_Click(object sender, EventArgs e)
        {
            click_A_V(btn_VA_api, btn_AV_api);
            lang_from_to_2 = 3;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            Highlight_button_main(btn_main);
            Visible(panel_dich);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            Highlight_button_main(btn_adv);
            Visible(panel_dichnangcao);
        }

         

        private void btnTrans_2_Click(object sender, EventArgs e)
        {
            if(tbox3.Text.Split('\n').Length <= 200)
            {
                if (lang_from_to_2 == 2)
                {
                    try
                    {
                        System.Threading.Thread.Sleep(300);
                        tbox4.Text = TranslateText(tbox3.Text, "en", "vi");

                    }
                    catch
                    {

                        tbox4.Text = "<Mất kết nối Internet>";
                    }

                }
                else if (lang_from_to_2 == 3)
                {
                    try
                    {
                        System.Threading.Thread.Sleep(300);
                        tbox4.Text = TranslateText(tbox3.Text, "vi", "en");
                    }
                    catch
                    {
                        tbox4.Text = "<Lost internet connection>";
                    }

                }
            }   
            else
            {
                if (lang_from_to_2 == 2)
                {

                    tbox4.Text = "<Vượt quá giới hạn 200 từ cho phép>";
                }
                else if (lang_from_to_2 == 3)
                {
                    tbox4.Text = "<Exceeded the limit of 200 words allowed>";

                }
            }
        }    
             
        

        private void btn_his_Click(object sender, EventArgs e)
        {
            Highlight_button_main(btn_his);
            Visible(panel_his);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            btn_save.BackColor = color_btn_click;
            btn_save.IconFont = IconFont.Solid;

            Highlight_button_main(btn_important_word);
            Visible(pnl_save);
            
        }

        private void btn_important_word_Click(object sender, EventArgs e)
        {
            Highlight_button_main(btn_important_word);
            Visible(pnl_save);
        }


        private bool NodeExists(TreeNode node, string key)
        {
            foreach (TreeNode subNode in node.Nodes)
            {
                if (subNode.Text == key)
                {
                    return true;
                }
                if (node.Nodes.Count > 0)
                {
                    NodeExists(node, key);
                }
            }
            return false;
        }
        private void btn_add_folder_Click(object sender, EventArgs e)
        {
             
            string txt = "";
            string path = "";
            using (var form = new AddFolder())
            {
                form.label_folder = lang["Folder name"][lang_all];
                form.label_image = lang["Image optional"][lang_all];
                form.button_add = lang["Add folder"][lang_all];
                if (DialogResult.Cancel == form.ShowDialog(this))
                {
                    //OK was clicked, do something with the form's properties 
                    // or textboxes if public
                    
                    txt = form.name_folder;
                    path = form.img_path;

                }
            }
            if (txt!="")
            {
                TreeNode root = new TreeNode();
                root.Name = txt;
                root.Text = txt;
                root.ImageKey = txt;
                root.SelectedImageKey = txt;
                if (treeA.Visible)
                {
                    if (path != "")
                    {
                        if (!treeA.Nodes.ContainsKey(txt))
                        {
                            imgLst_A.Images.Add(txt, Image.FromFile(path));
                            treeA.Nodes.Add(root);
                        }
                        else
                            MessageBox.Show(lang["Folder already exist"][lang_all], lang["Warning"][lang_all], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (!treeA.Nodes.ContainsKey(txt))
                        {
                            imgLst_A.Images.Add(txt, Properties.Resources.icon1);
                            treeA.Nodes.Add(root);
                        }
                        else
                            MessageBox.Show(lang["Folder already exist"][lang_all], lang["Warning"][lang_all], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (treeV.Visible)
                {
                    if (path != "")
                    {
                        if (!treeV.Nodes.ContainsKey(txt))
                        {
                            imgLst_V.Images.Add(txt, Image.FromFile(path));
                            treeV.Nodes.Add(root);
                        }
                        else
                            MessageBox.Show(lang["Folder already exist"][lang_all], lang["Warning"][lang_all], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (!treeV.Nodes.ContainsKey(txt))
                        {
                            imgLst_V.Images.Add(txt, Properties.Resources.icon1);
                            treeV.Nodes.Add(root);
                        }
                        else
                            MessageBox.Show(lang["Folder already exist"][lang_all], lang["Warning"][lang_all], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } 
             
             }    
             
             
        }

        private void btn_add_word_Click(object sender, EventArgs e)
        {
            if(tbox1.Text.Trim() != "")
            {
                string txt = "";
                if (treeV.Visible)
                {
                    if (treeV.Nodes.Count == 0)
                    {
                        
                        using (var form = new AddFolder())
                        {
                            form.label_folder = lang["Folder name"][lang_all];
                            form.label_image = lang["Image optional"][lang_all];
                            form.button_add = lang["Add folder"][lang_all];
                            if (DialogResult.Cancel == form.ShowDialog(this))
                            {
                                //OK was clicked, do something with the form's properties 
                                // or textboxes if public

                                txt = form.name_folder;
                                path = form.img_path;
                            }
                        }
                        if (txt != "")
                        {
                            TreeNode root = new TreeNode();
                            root.Name = txt;
                            root.Text = txt;
                            root.ImageKey = txt;
                            root.SelectedImageKey = txt;
                            if (path != "")
                            {
                                  imgLst_V.Images.Add(txt, Image.FromFile(path));
                                  treeV.Nodes.Add(root);
                                  TreeNode node = new TreeNode() { Name = tbox1.Text, Text = tbox1.Text, ImageKey = txt, SelectedImageKey = txt };
                                  root.Nodes.Add(node);
                                    
                            }
                            else
                            {     imgLst_V.Images.Add(txt, Properties.Resources.icon1);
                                  treeV.Nodes.Add(root);
                                  TreeNode node = new TreeNode() { Name = tbox1.Text, Text = tbox1.Text, ImageKey = txt, SelectedImageKey = txt };
                                  root.Nodes.Add(node);
                                      
                            }
                            
                        }
                        
                    }
                    else if (treeV.Nodes.Count != 0)
                    {
                        if (!treeV.SelectedNode.Nodes.ContainsKey(tbox1.Text))
                        {
                            TreeNode node = new TreeNode() { Name = tbox1.Text, Text = tbox1.Text, ImageKey = treeV.SelectedNode.ImageKey, SelectedImageKey = treeV.SelectedNode.SelectedImageKey };

                            treeV.SelectedNode.Nodes.Add(node);
                        }
                        else 
                            MessageBox.Show(lang["Word already exist"][lang_all], lang["Warning"][lang_all], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (treeA.Visible)
                {
                    if (treeA.Nodes.Count == 0)
                    {

                        using (var form = new AddFolder())
                        {
                            form.label_folder = lang["Folder name"][lang_all];
                            form.label_image = lang["Image optional"][lang_all];
                            form.button_add = lang["Add folder"][lang_all];
                            if (DialogResult.Cancel == form.ShowDialog(this))
                            {
                                //OK was clicked, do something with the form's properties 
                                // or textboxes if public

                                txt = form.name_folder;
                                path = form.img_path;
                            }
                        }
                        if (txt != "")
                        {
                            TreeNode root = new TreeNode();
                            root.Name = txt;
                            root.Text = txt;
                            root.ImageKey = txt;
                            root.SelectedImageKey = txt;
                            if (path != "")
                            {
                                imgLst_A.Images.Add(txt, Image.FromFile(path));
                                treeA.Nodes.Add(root);
                                TreeNode node = new TreeNode() { Name = tbox1.Text, Text = tbox1.Text, ImageKey = txt, SelectedImageKey = txt };
                                root.Nodes.Add(node);

                            }
                            else
                            {
                                imgLst_A.Images.Add(txt, Properties.Resources.icon1);
                                treeA.Nodes.Add(root);
                                TreeNode node = new TreeNode() { Name = tbox1.Text, Text = tbox1.Text, ImageKey = txt, SelectedImageKey = txt };
                                root.Nodes.Add(node);

                            }

                        }

                    }
                    else if (treeA.Nodes.Count != 0)
                    {
                        if (!treeA.SelectedNode.Nodes.ContainsKey(tbox1.Text))
                        {
                            TreeNode node = new TreeNode() { Name = tbox1.Text, Text = tbox1.Text, ImageKey = treeA.SelectedNode.ImageKey, SelectedImageKey = treeA.SelectedNode.SelectedImageKey };

                            treeA.SelectedNode.Nodes.Add(node);
                        }
                        else
                            MessageBox.Show(lang["Word already exist"][lang_all], lang["Warning"][lang_all], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }     
        }

        private void btn_del_folder_Click(object sender, EventArgs e)
        {
            if (treeV.Visible)
                treeV.SelectedNode.Remove();
            else if (treeA.Visible)
                treeA.SelectedNode.Remove();

        }

        private void treeA_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {   if (e.Node.Parent != null)
            {
                string txt = e.Node.Text;
                SQLiteConnection con = new SQLiteConnection(@"Data Source=..\..\..\Data\TuDien.db");
                con.Open();
                string query = "SELECT * FROM AnhViet WHERE word='" + txt.Trim().ToLower() + "'";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                DataTable ds = new DataTable();
                adapter.Fill(ds);
                try
                {


                    tb_meaning.Text = ("Phát âm: " + ds.Rows[0][2].ToString() + "\n" + ds.Rows[0][1].ToString()).Replace("\n", "\r\n");


                }
                catch
                {


                    tb_meaning.Text = "<Không có trong từ điển>";


                }
            }
        }
        private void treeV_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                string txt = e.Node.Text;
                SQLiteConnection con = new SQLiteConnection(@"Data Source=..\..\..\Data\TuDien.db");
                con.Open();
                string query = "SELECT * FROM VietAnh WHERE word='" + txt.Trim().ToLower() + "'";
                SQLiteCommand cmd = new SQLiteCommand(query, con);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                DataTable ds = new DataTable();
                adapter.Fill(ds);
                try
                {


                    tb_meaning.Text = ds.Rows[0][1].ToString().Replace("\n", "\r\n");

                }
                catch
                {

                    tb_meaning.Text = "<Not in the dictionary>";

                }
            }
        }
        void ShowTree(TreeView tv)
        {
            treeV.Visible = false;
            treeA.Visible = false;
            tv.Visible = true;
        }
        void click_btn_tree(Guna2Button a)
        {
            btn_tree_A.FillColor = color_btn_noclick;
            btn_tree_V.FillColor = color_btn_noclick;
            btn_tree_A.ForeColor = color_txt_noclick;
            btn_tree_V.ForeColor = color_txt_noclick;
            a.FillColor = color_btn_click;
            a.ForeColor = color_txt_click;
        }
        private void btn_tree_A_Click(object sender, EventArgs e)
        {
            click_btn_tree(btn_tree_A);
            ShowTree(treeA);
            lang_important = 0; 
        }

        private void btn_tree_V_Click(object sender, EventArgs e)
        {
            click_btn_tree(btn_tree_V);
            ShowTree(treeV);
            lang_important = 1;
        }


        //PHÁT ÂM
        SpeechSynthesizer speak = new SpeechSynthesizer();
        void speak_eng(string txt) // 0-random, 1-male, 2-female
        {
            // Setting chọn giọng đọc
            VoiceGender voice_gender;
            if (voice_gender_english == 0)
            {
                List<VoiceGender> lst_voice_gender = new List<VoiceGender> { VoiceGender.Female, VoiceGender.Male, VoiceGender.Neutral };
                Random rnd = new Random();
                int gender = rnd.Next(lst_voice_gender.Count);
                voice_gender = lst_voice_gender[gender];
            }
            else if (voice_gender_english == 1)
            {
                voice_gender = VoiceGender.Male;
            }
            else
            {
                voice_gender = VoiceGender.Female;
            }

            speak.SelectVoiceByHints(voice_gender);
            //if (lang_from_to == 0 || lang_from_to_2 == 2)
            //{
                
            //}
            speak.Volume = 100;
            speak.Rate = 0;
            speak.SpeakAsync(txt);
        }
        static string path = "";
        SoundPlayer my_sound = new SoundPlayer();
        void speak_vi(string txt)
        {
            Random rnd = new Random();
            string type_voice;
            if (voice_gender_vietnam == 0)
            {
                List<string> lst_voice = new List<string> { "hn-quynhanh", "hn-phuongtrang", "hn-thanhtung", "phamtienquan" };
                type_voice = lst_voice[rnd.Next(lst_voice.Count)];
            }
            else if (voice_gender_vietnam == 1)
            {
                List<string> lst_voice_male = new List<string> { "hn-thanhtung", "phamtienquan" };
                type_voice = lst_voice_male[rnd.Next(lst_voice_male.Count)];
            }
            else
            {
                List<string> lst_voice_female = new List<string> { "hn-quynhanh", "hn-phuongtrang" };
                type_voice = lst_voice_female[rnd.Next(lst_voice_female.Count)];
            }
            File.WriteAllText("./viettel_tts/text.txt", txt);
            File.WriteAllText("./viettel_tts/voice.txt", type_voice);

            Process process = new Process();
            process.StartInfo.FileName = path + "\\viettel_tts\\viettel_tts.exe";
            //process.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "\\viettel_tts\\viettel_tts.exe");
            process.StartInfo.Arguments = "-silent";
            process.StartInfo.ErrorDialog = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.WorkingDirectory = path + "\\viettel_tts";
            process.Start();
            process.WaitForExit(1000 * 10);

            //play wav file
            my_sound.SoundLocation = path + "\\viettel_tts\\output.wav";
            my_sound.Play();
        }

        private void pic_speak_translation_Click(object sender, EventArgs e)
        {
            try
            {
                if (lang_from_to == 0)
                {
                    speak_eng(tbox1.Text);
                }
                else
                {
                    speak_vi(tbox1.Text);

                }
            }
            catch { };
             
        }

        private void pic_mute_translation_Click(object sender, EventArgs e)
        {
            try
            {
                if (lang_from_to == 0)
                {
                    speak.Volume = 0;
                    speak.SpeakAsyncCancelAll();
                }
                else
                {
                    my_sound.Stop();
                }
            }
            catch { };
             
        }

        private void pic_speak1_adv_Click(object sender, EventArgs e)
        {
            try
            {
                if (lang_from_to_2 == 2)
                {
                    speak_eng(tbox3.Text);
                }
                else
                {
                    speak_vi(tbox3.Text);

                }
            }
            catch { };
             
        }

        private void pic_mute1_adv_Click(object sender, EventArgs e)
        {
            try
            {
                if (lang_from_to_2 == 2)
                {
                    speak.Volume = 0;
                    speak.SpeakAsyncCancelAll();
                }
                else
                {
                    my_sound.Stop();
                }
            }
            catch { };
             
        }

        private void pic_speak2_adv_Click(object sender, EventArgs e)
        {
            try
            {
                if (lang_from_to_2 == 2)
                {
                    speak_vi(tbox4.Text);
                }
                else if (lang_from_to_2 == 3)
                {
                    speak_eng(tbox4.Text);

                }
            }
            catch { };
            //if (lang_from_to_2 == 2)
            //{
            //    speak_vi(tbox4.Text);
            //}
            //else if (lang_from_to_2 == 3)
            //{
            //    speak_eng(tbox4.Text);

            //}

        }

        private void pic_mute2_adv_Click(object sender, EventArgs e)
        {
            try
            {
                if (lang_from_to_2 == 2)
                {
                    my_sound.Stop();
                }
                else
                {
                    speak.Volume = 0;
                    speak.SpeakAsyncCancelAll();
                }
            }
            catch { };
        }

        private void pic_speak_imp_Click(object sender, EventArgs e)
        {
            try
            {
                if (lang_important == 0)
                {
                    string txt = "";
                    if(txt!= null)
                    {
                        txt = treeA.SelectedNode.Text;
                    }    
                    speak_eng(txt);
                }
                else
                {
                    string txt = "";
                    if (txt != null)
                    {
                        txt = treeV.SelectedNode.Text;
                    }
                    speak_vi(txt);
                }
            }
            catch { };
                 
        }

        private void pic_mute_imp_Click(object sender, EventArgs e)
        {
            try
            {
                if (lang_important == 0)
                {
                    speak.Volume = 0;
                    speak.SpeakAsyncCancelAll();
                }
                else
                {
                    my_sound.Stop();
                }
            }
            catch { };
        }
        // DỊCH TỪ HÌNH ẢNH
        private void btn_add_img_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pic_img.ImageLocation = openFileDialog1.FileName;
                img_scan = Image.FromFile(openFileDialog1.FileName);
            }
        }

        Image img_scan;
        private void btn_scan_Click(object sender, EventArgs e)
        {
            FormWindowState old_state = this.WindowState;
            this.Hide();
            System.Threading.Thread.Sleep(500);
            var bmp = SnippingTool.Snip();
            if (bmp != null)
            {
                pic_img.Image = bmp;
                img_scan = bmp;
            }
            this.Show();
        }

        private void btn_AV_ocr_Click(object sender, EventArgs e)
        {
            click_A_V(btn_AV_ocr, btn_VA_ocr);
            lang_ocr = 0;
        }

        private void btn_VA_ocr_Click(object sender, EventArgs e)
        {
            click_A_V(btn_VA_ocr, btn_AV_ocr);
            lang_ocr = 1;
        }

        private string ocr_image(Image img)
        {
            string txt = "";
            if(img!= null)
            {

                Bitmap bmm_img = new Bitmap(img);
                //pic_img.Image = SetGrayscale(RemoveNoise(bmm_img));
                Bitmap bm_img = SetGrayscale(RemoveNoise(bmm_img));
                //Bitmap bm_img = Resize(bmm_img, 1, 1);
                if (lang_ocr == 0)
                {

                    var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.LstmOnly);
                    var page = ocr.Process(bm_img);
                    txt = page.GetText();
                }
                else if (lang_ocr == 1)
                {
                    var ocr = new TesseractEngine("./tessdata", "vie", EngineMode.LstmOnly);
                    var page = ocr.Process(bm_img);
                    txt = page.GetText();
                }
            }
            else
            {
                if(lang_ocr==0)
                {
                    txt = "<Error>";
                }    
                else
                {
                    txt = "<Lỗi>";
                }    
            }    
            return txt;
        }

        private void btn_trans_ocr_Click(object sender, EventArgs e)
        {
            string txt = ocr_image(img_scan);
            tbox5.Text = txt;
            if(txt.Split('\n').Length <= 200)
            {
                if (lang_ocr == 0)
                {

                    try
                    {
                        tbox6.Text = TranslateText(tbox5.Text, "en", "vi");
                    }
                    catch
                    {
                        tbox6.Text = "<Mất kết nối Internet>";
                    }
                }
                else if (lang_ocr == 1)
                {
                    try
                    {
                        tbox6.Text = TranslateText(tbox5.Text, "vi", "en");
                    }
                    catch
                    {
                        tbox6.Text = "<Lost internet connection>";
                    }
                }
            } 
            else
            {
                if(lang_ocr == 0)
                {
                    tbox6.Text = "<Vượt quá giới hạn 200 từ cho phép>";

                }
                else if (lang_ocr == 1)
                {
                    tbox6.Text = "<Exceeded the limit of 200 words allowed>";
                }
            }    
             
        }
        private void btn_img_Click(object sender, EventArgs e)
        {
            Highlight_button_main(btn_img);
            Visible(panel_img);
        }

        private void pic_speak1_ocr_Click(object sender, EventArgs e)
        {
            try
            {
                if (lang_ocr == 0)
                {
                    speak_eng(tbox5.Text);
                }
                else
                {
                    speak_vi(tbox5.Text);

                }
            }
            catch { };

        }

        private void pic_mute1_ocr_Click(object sender, EventArgs e)
        {
            try
            {
                if (lang_ocr == 0)
                {
                    speak.Volume = 0;
                    speak.SpeakAsyncCancelAll();
                }
                else
                {
                    my_sound.Stop();
                }
            }
            catch { };
        }

        private void pic_speak2_ocr_Click(object sender, EventArgs e)
        {
            try
            {
                if (lang_ocr == 0)
                {
                    speak_vi(tbox6.Text);
                }
                else
                {
                    speak_eng(tbox6.Text);

                }
            }
            catch { };
        }

        private void pic_mute2_ocr_Click(object sender, EventArgs e)
        {
            try
            {
                if (lang_ocr == 0)
                {
                    my_sound.Stop();

                }
                else
                {
                    speak.Volume = 0;
                    speak.SpeakAsyncCancelAll();
                }
            }
            catch { };
        }

        //Snipping tool
        public partial class SnippingTool : Form
        {
            public static System.Drawing.Image Snip()
            {
                var rc = Screen.PrimaryScreen.Bounds;
                using (Bitmap bmp = new Bitmap(rc.Width, rc.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb))
                {
                    using (Graphics gr = Graphics.FromImage(bmp))
                        gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);
                    using (var snipper = new SnippingTool(bmp))
                    {
                        if (snipper.ShowDialog() == DialogResult.OK)
                        {
                            return snipper.Image;
                        }
                    }
                    return null;
                }
            }

            public SnippingTool(System.Drawing.Image screenShot)
            {
                this.BackgroundImage = screenShot;
                this.ShowInTaskbar = false;
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
                this.DoubleBuffered = true;
            }
            public System.Drawing.Image Image { get; set; }

            private System.Drawing.Rectangle rcSelect = new System.Drawing.Rectangle();
            private System.Drawing.Point pntStart;

            protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left) return;
                pntStart = e.Location;
                rcSelect = new System.Drawing.Rectangle(e.Location, new System.Drawing.Size(0, 0));
                this.Invalidate();
            }
            protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left) return;

                int x1 = Math.Min(e.X, pntStart.X);
                int y1 = Math.Min(e.Y, pntStart.Y);
                int x2 = Math.Max(e.X, pntStart.X);
                int y2 = Math.Max(e.Y, pntStart.Y);
                rcSelect = new System.Drawing.Rectangle(x1, y1, x2 - x1, y2 - y1);
                this.Invalidate();
            }
            protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
            {
                if (rcSelect.Width <= 0 || rcSelect.Height <= 0) return;
                Image = new Bitmap(rcSelect.Width, rcSelect.Height);
                using (Graphics gr = Graphics.FromImage(Image))
                {
                    gr.DrawImage(this.BackgroundImage, new System.Drawing.Rectangle(0, 0, Image.Width, Image.Height),
                        rcSelect, GraphicsUnit.Pixel);
                }
                DialogResult = DialogResult.OK;
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                using (System.Drawing.Brush br = new SolidBrush(System.Drawing.Color.FromArgb(120, System.Drawing.Color.Black)))
                {
                    int x1 = rcSelect.X; int x2 = rcSelect.X + rcSelect.Width;
                    int y1 = rcSelect.Y; int y2 = rcSelect.Y + rcSelect.Height;
                    e.Graphics.FillRectangle(br, new System.Drawing.Rectangle(0, 0, x1, this.Height));
                    e.Graphics.FillRectangle(br, new System.Drawing.Rectangle(x2, 0, this.Width - x2, this.Height));
                    e.Graphics.FillRectangle(br, new System.Drawing.Rectangle(x1, 0, x2 - x1, y1));
                    e.Graphics.FillRectangle(br, new System.Drawing.Rectangle(x1, y2, x2 - x1, this.Height - y2));
                }
                using (System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.White, 1))
                {
                    e.Graphics.DrawRectangle(pen, rcSelect);
                }
            }
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                if (keyData == Keys.Escape) this.DialogResult = DialogResult.Cancel;
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }


        //Tăng chất lượng ảnh
        public Bitmap SetGrayscale(Bitmap img)
        {

            Bitmap temp = (Bitmap)img;
            Bitmap bmap = (Bitmap)temp.Clone();
            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);

                    bmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            return (Bitmap)bmap.Clone();

        }
        public Bitmap RemoveNoise(Bitmap bmap)
        {

            for (var x = 0; x < bmap.Width; x++)
            {
                for (var y = 0; y < bmap.Height; y++)
                {
                    var pixel = bmap.GetPixel(x, y);
                    if (pixel.R < 162 && pixel.G < 162 && pixel.B < 162)
                        bmap.SetPixel(x, y, Color.Black);
                    else if (pixel.R > 162 && pixel.G > 162 && pixel.B > 162)
                        bmap.SetPixel(x, y, Color.White);
                }
            }

            return bmap;
        }

        // Google translate APÍ
        public string TranslateText(string input, string lang_from, string lang_to)
        {
            string url = String.Format
            ("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
             lang_from, lang_to, Uri.EscapeUriString(input));
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetStringAsync(url).Result;
            var jsonData = new JavaScriptSerializer().Deserialize<List<dynamic>>(result);
            var translationItems = jsonData[0];
            string translation = "";
            try
            {
                foreach (object item in translationItems)
                {
                    IEnumerable translationLineObject = item as IEnumerable;
                    IEnumerator translationLineString = translationLineObject.GetEnumerator();
                    translationLineString.MoveNext();
                    translation += string.Format(" {0}", Convert.ToString(translationLineString.Current));
                }
                if (translation.Length > 1) { translation = translation.Substring(1); };
            }
            catch { };
             
            return translation;
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            Visible(panel_setting);
            Highlight_button_main(btn_setting);

        }


        //Thay đổi ngôn ngữ
        Dictionary<string, List<string>> lang = new Dictionary<string, List<string>>()
            {
                {"Translation", new List<string> { "Translation", "Dịch từ"} },
                {"Advanced translation", new List<string> { "Advanced translation", "Dịch nâng cao"} },
                {"Search history", new List<string> { "Search history", "Lịch sử tìm kiếm"} },
                {"Important words", new List<string> { "Important words", "Từ quan trọng"} },
                {"OCR and Translate", new List<string> { "OCR and Translate", "Dịch câu trong ảnh"} },
                {"Setting", new List<string> {"Setting", "Cài đặt"} },
                {"English - Vietnamese", new List<string> { "English - Vietnamese", "Anh - Việt"} },
                {"Vietnamese - English", new List<string> { "Vietnamese - English", "Việt - Anh"} },
                {"Translate", new List<string> {"Translate", "Dịch"} },
                {"Language", new List<string> {"Language:", "Ngôn ngữ:"} },
                {"Voice Gender", new List<string> { "Voice Gender:", "Giọng đọc:"} },
                {"Vietnamese", new List<string> {"Vietnamese", "Tiếng Việt"} },
                {"English", new List<string> {"English", "Tiếng Anh"} },
                {"Male", new List<string> {"Male", "Nam"} },
                {"Female", new List<string> {"Female", "Nữ"} },
                {"Random", new List<string> {"Random", "Ngẫu nhiên"} },
                {"Color", new List<string> {"Color:", "Màu sắc:"} },
                {"Add Folder", new List<string> {"Add Folder", "Thêm mục"} },
                {"Delete Folder", new List<string> {"Delete Folder/Word", "Xóa mục/từ"} },
                {"Delete Word", new List<string> {"Delete Word", "Xóa từ"} },
                {"Add Word", new List<string> {"Add Word", "Thêm từ"} },
                {"Add Image", new List<string> {"Add Image", "Thêm ảnh"} },
                {"Scan", new List<string> {"Scan", "Chụp màn hình"} },
                {"About", new List<string> {"About", ""} },
                {"Warning", new List<string> {"Warning", "Cảnh báo"} },
                {"Folder already exist", new List<string> { "Folder already exist", "Thư mục đã tồn tại"} },
                {"Word already exist", new List<string> { "Word already exist", "Từ đã tồn tại"} },
                {"Folder name", new List<string> { "Folder name:", "Tên mục:" } },
                {"Image optional", new List<string> { "Image (optional):", "Ảnh (tùy chọn):"} },
                {"Add folder", new List<string> { "Add folder", "Thêm mục"} }

            };

        List<string> eng_combo = new List<string>() { "Default", "Type 1", "Type 2", "Type 3" };
        List<string> vi_combo = new List<string>() { "Mặc định", "Loại 1", "Loại 2", "Loại 3" };
        void Change_Language(int lang_all)
        {
            //Setting
            lb_language_set.Text = lang["Language"][lang_all];
            lb_voicegender_set.Text = lang["Voice Gender"][lang_all];
            lb_vietnamese_set.Text = lang["Vietnamese"][lang_all];
            lb_english_set.Text = lang["English"][lang_all];
            rad_male_vn_set.Text = rad_male_eng_set.Text = lang["Male"][lang_all];
            rad_female_vn_set.Text = rad_female_eng_set.Text = lang["Female"][lang_all];
            rad_random_eng_set.Text = rad_random_vn_set.Text = lang["Random"][lang_all];
            lb_color_set.Text = lang["Color"][lang_all];
            if(lang_all==0)
            {
                cBox_color_set.DataSource = eng_combo;
            }    
            else
            {
                cBox_color_set.DataSource = vi_combo;
            }    
             
            //Important word
            btn_tree_A.Text = lang["English"][lang_all];
            btn_tree_V.Text = lang["Vietnamese"][lang_all];
            btn_add_folder.Text = lang["Add Folder"][lang_all];
            btn_del_folder.Text = lang["Delete Folder"][lang_all];
            btn_add_word.Text = lang["Add Word"][lang_all];

            //Advanced translation
            btnTrans_2.Text = lang["Translate"][lang_all];
            btn_VA_api.Text = lang["Vietnamese - English"][lang_all];
            btn_AV_api.Text = lang["English - Vietnamese"][lang_all];
            
            //OCR
            btn_trans_ocr.Text = btnTrans.Text = lang["Translate"][lang_all];
            btn_scan.Text = lang["Scan"][lang_all];
            btn_add_img.Text = lang["Add Image"][lang_all];
            btn_AV_ocr.Text = lang["English - Vietnamese"][lang_all];
            btn_VA_ocr.Text = lang["Vietnamese - English"][lang_all];

            //Translation
            btn_AV.Text = lang["English - Vietnamese"][lang_all];
            btn_VA.Text = lang["Vietnamese - English"][lang_all];
            btnTrans.Text = lang["Translate"][lang_all];

            //Main
            btn_setting.Text = lang["Setting"][lang_all];
            btn_img.Text = lang["OCR and Translate"][lang_all];
            btn_important_word.Text = lang["Important words"][lang_all];
            btn_his.Text = lang["Search history"][lang_all];
            btn_main.Text = lang["Translate"][lang_all];
            btn_adv.Text = lang["Advanced translation"][lang_all];

            //His
            foreach (ItemSearch item in flow_his.Controls)
            {
                if(item.Title == "English - Vietnamese" || item.Title == "Anh - Việt")
                {
                    item.Title = lang["English - Vietnamese"][lang_all];
                }    
                else
                {
                    item.Title = lang["Vietnamese - English"][lang_all];
                }    
            }

        }

        void Color_General()
        {
            this.BackColor = color_main;
            panel_dich.BackColor = color_main;
            panel_dichnangcao.BackColor = color_main;
            panel_his.BackColor = color_main;
            panel_setting.BackColor = color_main;
            pnl_save.BackColor = color_main;
        }    

        void Change_Color(int type)
        {
            if(type==0)
            {
                color_main = ColorTranslator.FromHtml("#082032");
                pnl_top.BackColor = ColorTranslator.FromHtml("#2C394B");
            }    
            else if(type == 1)
            {
                color_main = ColorTranslator.FromHtml("#1B2021");
                pnl_top.BackColor = ColorTranslator.FromHtml("#EAC8AF");
            }   
            else if(type == 2)
            {
                color_main = ColorTranslator.FromHtml("#194350");
                pnl_top.BackColor = ColorTranslator.FromHtml("#FF8882");
            }   
            else
            {
                color_main = ColorTranslator.FromHtml("#4A3933");
                pnl_top.BackColor = ColorTranslator.FromHtml("#F0A500");
            }
            Color_General();
        }    

        private void btn_ok_setting_Click(object sender, EventArgs e)
        {
            if(rad_tiengviet_set.Checked)
            {
                lang_all = 1;
            }    
            else if(rad_english_set.Checked)
            {
                lang_all = 0;
            }    

            if(rad_random_vn_set.Checked)
            {
                voice_gender_vietnam = 0;
            }    
            else if(rad_male_vn_set.Checked)
            {
                voice_gender_vietnam = 1;
            }    
            else if(rad_female_vn_set.Checked)
            {
                voice_gender_vietnam = 2;
            }   
            if(rad_random_eng_set.Checked)
            {
                voice_gender_english = 0;
            }   
            else if(rad_male_eng_set.Checked)
            {
                voice_gender_english = 1;
            }   
            else if(rad_female_eng_set.Checked)
            {
                voice_gender_english = 2;
            }
            type_color = cBox_color_set.SelectedIndex;

            Change_Language(lang_all);

            Change_Color(type_color);
            cBox_color_set.SelectedIndex = type_color;
        }

        private void btn_hide_app_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            //this.Hide();
        }
    }

}
