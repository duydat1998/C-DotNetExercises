using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Winform
{
    public partial class frmMain : Form
    {
        ProductData data = new ProductData();
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                int proID = int.Parse(txtProductID.Text);
                string proName = txtProductName.Text;
                float price = float.Parse(txtUnitPrice.Text);
                int quantity = int.Parse(txtQuantity.Text);
                Product p = new Product { ProductID = proID, ProductName = proName, UnitPrice = price, Quantity = quantity };
                data.AddNew(p);
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = data.GetProductList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int proID = int.Parse(txtProductID.Text);
                data.Remove(proID);
                dgvProducts.DataSource = null;
                dgvProducts.DataSource = data.GetProductList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int proID = int.Parse(txtProductID.Text);
            Product p = data.Find(proID);
            if (p == null)
            {
                MessageBox.Show("Product not found");
            }
            else
            {
                txtProductName.Text = p.ProductName;
                txtUnitPrice.Text = p.UnitPrice.ToString();
                txtQuantity.Text = p.Quantity.ToString();
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductName.Text = "";
            txtUnitPrice.Text = "";
            txtQuantity.Text = "";
            txtProductID.Text = "";
        }
    }
}
