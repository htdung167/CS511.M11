
namespace PhienDich
{
    partial class AddFolder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFolder));
            this.btn_close = new Guna.UI2.WinForms.Guna2Button();
            this.tb_name_folder = new System.Windows.Forms.TextBox();
            this.label_foldername = new System.Windows.Forms.Label();
            this.label_img = new System.Windows.Forms.Label();
            this.icon = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.CheckedState.Parent = this.btn_close;
            this.btn_close.CustomImages.Parent = this.btn_close;
            this.btn_close.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_close.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_close.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_close.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_close.DisabledState.Parent = this.btn_close;
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.HoverState.Parent = this.btn_close;
            this.btn_close.Location = new System.Drawing.Point(12, 338);
            this.btn_close.Name = "btn_close";
            this.btn_close.ShadowDecoration.Parent = this.btn_close;
            this.btn_close.Size = new System.Drawing.Size(159, 40);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "Add folder";
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // tb_name_folder
            // 
            this.tb_name_folder.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_name_folder.Location = new System.Drawing.Point(12, 48);
            this.tb_name_folder.Name = "tb_name_folder";
            this.tb_name_folder.Size = new System.Drawing.Size(335, 43);
            this.tb_name_folder.TabIndex = 2;
            // 
            // label_foldername
            // 
            this.label_foldername.AutoSize = true;
            this.label_foldername.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_foldername.Location = new System.Drawing.Point(16, 13);
            this.label_foldername.Name = "label_foldername";
            this.label_foldername.Size = new System.Drawing.Size(128, 18);
            this.label_foldername.TabIndex = 3;
            this.label_foldername.Text = "Folder name:";
            // 
            // label_img
            // 
            this.label_img.AutoSize = true;
            this.label_img.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_img.Location = new System.Drawing.Point(16, 123);
            this.label_img.Name = "label_img";
            this.label_img.Size = new System.Drawing.Size(188, 18);
            this.label_img.TabIndex = 5;
            this.label_img.Text = "Image (optional) :";
            // 
            // icon
            // 
            this.icon.BackgroundImage = global::PhienDich.Properties.Resources.upload_img_256;
            this.icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.icon.FillColor = System.Drawing.Color.Transparent;
            this.icon.ImageRotate = 0F;
            this.icon.Location = new System.Drawing.Point(226, 111);
            this.icon.Name = "icon";
            this.icon.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.icon.ShadowDecoration.Parent = this.icon;
            this.icon.Size = new System.Drawing.Size(128, 128);
            this.icon.TabIndex = 4;
            this.icon.TabStop = false;
            this.icon.Click += new System.EventHandler(this.icon_Click);
            this.icon.DoubleClick += new System.EventHandler(this.icon_DoubleClick);
            // 
            // AddFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 386);
            this.Controls.Add(this.label_img);
            this.Controls.Add(this.icon);
            this.Controls.Add(this.label_foldername);
            this.Controls.Add(this.tb_name_folder);
            this.Controls.Add(this.btn_close);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddFolder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AddFolder";
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btn_close;
        public System.Windows.Forms.TextBox tb_name_folder;
        private System.Windows.Forms.Label label_foldername;
        private Guna.UI2.WinForms.Guna2CirclePictureBox icon;
        private System.Windows.Forms.Label label_img;
    }
}