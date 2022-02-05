using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhienDich
{
    public partial class ItemSearch : UserControl
    {
        public ItemSearch()
        {
            InitializeComponent();
        }
        private string _title;
        private string _search;
        private string _meaning;
        
        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value; lb_AV.Text = value; }
        }

        [Category("Custom Props")]
        public string Search
        {
            get { return _search; }
            set { _search = value; lb_search.Text = value; }
        }

        [Category("Custom Props")]
        public string Meaning
        {
            get { return _meaning; }
            set { _meaning = value; lb_meaning.Text = value; }
        }

        private void ItemSearch_Load(object sender, EventArgs e)
        {

        }

        private void lb_AV_Click(object sender, EventArgs e)
        {

        }
    }
}
