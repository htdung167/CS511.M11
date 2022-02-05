using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace PhienDich
{
    public partial class AddFolder : Form
    {
        
        public AddFolder()
        {
            InitializeComponent();
        }

        public string  name_folder
        {
            get
            {
                return tb_name_folder.Text;
            }
            private set
            {
                tb_name_folder.Text = value;
            }
        }
        public string label_folder
        {
            get
            {
                return label_foldername.Text;
            }
            set
            {
                label_foldername.Text = value;
            }
        }

        public string label_image
        {
            get
            {
                return label_img.Text;
            }
            set
            {
                label_img.Text = value;
            }
        }
        public string button_add
        {
            get
            {
                return btn_close.Text;
            }
            set
            {
                btn_close.Text = value;
            }
        }


        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string path = "";

        public string img_path
        {
            get
            {
                return path;
            }
        }
        private void icon_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = @"C:\";
            open.Title = "Please select an image.";
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                icon.BackgroundImage = Image.FromFile(open.FileName);
                path = open.FileName;
            }
        }

        private void icon_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
