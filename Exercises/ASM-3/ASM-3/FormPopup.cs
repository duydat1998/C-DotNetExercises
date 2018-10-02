using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductLibrary;
namespace ASM_3
{
    public partial class FormPopup : Form
    {
        public FormPopup()
        {
            InitializeComponent();
        }

        public FormPopup(Product p)
        {
            InitializeComponent();
            txtID.Text = p.ProductID+"";
            txtName.Text = p.ProductName;
            txtPrice.Text = p.UnitPrice + "";
            txtQuantity.Text = p.Quantity + "";
            txtTotal.Text = p.SubTotal + "";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
