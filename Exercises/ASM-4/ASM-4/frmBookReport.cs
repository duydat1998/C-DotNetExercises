using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM_4
{
    public partial class frmBookReport : Form
    {
        BindingSource bsBook;
        public frmBookReport()
        {
            InitializeComponent();
        }

        public frmBookReport(BindingSource bsBook1)
        {
            InitializeComponent();
            this.bsBook = bsBook1;
            this.bsBook.Sort = "BookPrice DESC";
            
        }

        private void frmBookReport_Load(object sender, EventArgs e)
        {
            dgvBook.DataSource = bsBook;
        }
    }
}
