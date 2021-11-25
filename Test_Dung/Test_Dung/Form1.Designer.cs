
namespace Test_Dung
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.rtxt_nguon = new System.Windows.Forms.RichTextBox();
            this.lb_nguon = new System.Windows.Forms.Label();
            this.lb_dich = new System.Windows.Forms.Label();
            this.rtxt_dich = new System.Windows.Forms.RichTextBox();
            this.but_dich = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Translate";
            // 
            // rtxt_nguon
            // 
            this.rtxt_nguon.Location = new System.Drawing.Point(12, 150);
            this.rtxt_nguon.Name = "rtxt_nguon";
            this.rtxt_nguon.Size = new System.Drawing.Size(278, 380);
            this.rtxt_nguon.TabIndex = 1;
            this.rtxt_nguon.Text = "";
            // 
            // lb_nguon
            // 
            this.lb_nguon.AutoSize = true;
            this.lb_nguon.Location = new System.Drawing.Point(23, 111);
            this.lb_nguon.Name = "lb_nguon";
            this.lb_nguon.Size = new System.Drawing.Size(32, 17);
            this.lb_nguon.TabIndex = 2;
            this.lb_nguon.Text = "Việt";
            // 
            // lb_dich
            // 
            this.lb_dich.AutoSize = true;
            this.lb_dich.Location = new System.Drawing.Point(566, 111);
            this.lb_dich.Name = "lb_dich";
            this.lb_dich.Size = new System.Drawing.Size(33, 17);
            this.lb_dich.TabIndex = 3;
            this.lb_dich.Text = "Anh";
            // 
            // rtxt_dich
            // 
            this.rtxt_dich.Location = new System.Drawing.Point(504, 150);
            this.rtxt_dich.Name = "rtxt_dich";
            this.rtxt_dich.Size = new System.Drawing.Size(284, 380);
            this.rtxt_dich.TabIndex = 5;
            this.rtxt_dich.Text = "";
            // 
            // but_dich
            // 
            this.but_dich.Location = new System.Drawing.Point(344, 150);
            this.but_dich.Name = "but_dich";
            this.but_dich.Size = new System.Drawing.Size(75, 23);
            this.but_dich.TabIndex = 6;
            this.but_dich.Text = "Dịch";
            this.but_dich.UseVisualStyleBackColor = true;
            this.but_dich.Click += new System.EventHandler(this.but_dich_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Anh - Viêt",
            "Việt - Anh",
            "Anh - Việt - API",
            "Việt - Anh - API"});
            this.comboBox1.Location = new System.Drawing.Point(306, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(167, 24);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(875, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(298, 380);
            this.dataGridView1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(536, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 542);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.but_dich);
            this.Controls.Add(this.rtxt_dich);
            this.Controls.Add(this.lb_dich);
            this.Controls.Add(this.lb_nguon);
            this.Controls.Add(this.rtxt_nguon);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtxt_nguon;
        private System.Windows.Forms.Label lb_nguon;
        private System.Windows.Forms.Label lb_dich;
        private System.Windows.Forms.RichTextBox rtxt_dich;
        private System.Windows.Forms.Button but_dich;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
    }
}

