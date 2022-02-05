
namespace PhienDich
{
    partial class ItemSearch
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lb_AV = new System.Windows.Forms.Label();
            this.lb_search = new System.Windows.Forms.Label();
            this.elip_item = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_meaning = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_AV
            // 
            this.lb_AV.AutoSize = true;
            this.lb_AV.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_AV.Location = new System.Drawing.Point(3, 5);
            this.lb_AV.Name = "lb_AV";
            this.lb_AV.Size = new System.Drawing.Size(265, 27);
            this.lb_AV.TabIndex = 0;
            this.lb_AV.Text = "English - Vietnamese";
            this.lb_AV.Click += new System.EventHandler(this.lb_AV_Click);
            // 
            // lb_search
            // 
            this.lb_search.AutoSize = true;
            this.lb_search.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_search.Location = new System.Drawing.Point(3, 51);
            this.lb_search.Name = "lb_search";
            this.lb_search.Size = new System.Drawing.Size(110, 31);
            this.lb_search.TabIndex = 1;
            this.lb_search.Text = "Search";
            // 
            // elip_item
            // 
            this.elip_item.BorderRadius = 20;
            this.elip_item.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1218, 3);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.lb_AV);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1220, 30);
            this.panel2.TabIndex = 5;
            // 
            // lb_meaning
            // 
            this.lb_meaning.AutoSize = true;
            this.lb_meaning.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_meaning.ForeColor = System.Drawing.Color.Gray;
            this.lb_meaning.Location = new System.Drawing.Point(4, 118);
            this.lb_meaning.Name = "lb_meaning";
            this.lb_meaning.Size = new System.Drawing.Size(96, 27);
            this.lb_meaning.TabIndex = 6;
            this.lb_meaning.Text = "Search";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 99);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1218, 3);
            this.panel3.TabIndex = 5;
            // 
            // ItemSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lb_meaning);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_search);
            this.Name = "ItemSearch";
            this.Size = new System.Drawing.Size(1195, 184);
            this.Load += new System.EventHandler(this.ItemSearch_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_AV;
        private System.Windows.Forms.Label lb_search;
        private Guna.UI2.WinForms.Guna2Elipse elip_item;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_meaning;
        private System.Windows.Forms.Panel panel3;
    }
}
