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

namespace ProductStore
{
    public partial class frmProductDetails : Form
    {
        //variable ti update or create new
        private bool addOrEdit;

        public Product ProductAddOrEdit { get; set; }
        public frmProductDetails()
        {
            InitializeComponent();
        }

        public frmProductDetails(bool flag, Product p)
        {
            InitializeComponent();
            addOrEdit = flag;
            ProductAddOrEdit = p;
            InitData();
        }

        private void InitData()
        {
            txtProductID.Text = ProductAddOrEdit.ProductID + "";
            txtProductName.Text = ProductAddOrEdit.ProductName;
            txtProductPrice.Text = ProductAddOrEdit.UnitPrice+"";
            txtQuantity.Text = ProductAddOrEdit.Quantity + "";

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool flag;
            ProductAddOrEdit.ProductID = int.Parse(txtProductID.Text);
            ProductAddOrEdit.ProductName = txtProductName.Text;
            ProductAddOrEdit.UnitPrice = float.Parse(txtProductPrice.Text);
            ProductAddOrEdit.Quantity = int.Parse(txtQuantity.Text);
            ProductDB proDB = new ProductDB();
            if(addOrEdit == true)
            {
                flag = proDB.AddNewProduct(ProductAddOrEdit);
            }
            else
            {
                flag = proDB.UpdateProduct(ProductAddOrEdit);
            }
            if (flag == true)
                MessageBox.Show("Save successfull.");
            else
                MessageBox.Show("Save fail.");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
