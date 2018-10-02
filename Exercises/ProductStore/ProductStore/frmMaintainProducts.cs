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
    public partial class frmMaintainProducts : Form
    {
        ProductDB bm = new ProductDB();
        DataTable dtProduct;
        public frmMaintainProducts()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            int ID = 1;
            string Name = string.Empty;
            float Price = 0;
            int Quantity = 0;
            if (dtProduct.Rows.Count > 0)
            {
                ID = int.Parse(dtProduct.Compute("MAX(ProductID)", "").ToString()) + 1;
            }
            Product pro = new Product
            {
                ProductID = ID,
                ProductName = Name,
                UnitPrice = Price,
                Quantity = Quantity
            };

            frmProductDetails ProductDetail = new frmProductDetails(true, pro);
            DialogResult r = ProductDetail.ShowDialog();
            if (r == DialogResult.OK)
            {
                pro = ProductDetail.ProductAddOrEdit;
                dtProduct.Rows.Add(pro.ProductID, pro.ProductName, pro.UnitPrice, pro.Quantity);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtProductID.Text);
            string Name = txtProductName.Text;
            float Price = float.Parse(txtProductPrice.Text);
            int Quantity = int.Parse(txtQuantity.Text);

            Product pro = new Product
            {
                ProductID = ID,
                ProductName = Name,
                UnitPrice = Price,
                Quantity = Quantity
            };

            frmProductDetails ProductDetail = new frmProductDetails(false, pro);
            DialogResult r = ProductDetail.ShowDialog();
            if (r == DialogResult.OK)
            {
                DataRow row = dtProduct.Rows.Find(pro.ProductID);
                row["ProductName"] = pro.ProductName;
                row["UnitPrice"] = pro.UnitPrice;
                row["Quantity"] = pro.Quantity;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtProductID.Text);
            if (bm.RemoveProduct(ID))
            {
                DataRow row = dtProduct.Rows.Find(ID);
                dtProduct.Rows.Remove(row);
                MessageBox.Show("Successfull.");
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void frmMaintainProducts_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dtProduct = bm.GetAllProducts();
            //khai bao cot ProductID la khoa chinh
            dtProduct.PrimaryKey = new DataColumn[] { dtProduct.Columns["ProductID"] };
            //them cot subtotal
            dtProduct.Columns.Add("SubTotal", typeof(float), "Quantity*UnitPrice");

            bsProducts.DataSource = dtProduct;

            //xoa rang buoc du lieu
            txtProductID.DataBindings.Clear();
            txtProductName.DataBindings.Clear();
            txtProductPrice.DataBindings.Clear();
            txtQuantity.DataBindings.Clear();

            txtProductID.DataBindings.Add("Text", bsProducts, "ProductID");
            txtProductName.DataBindings.Add("Text", bsProducts, "ProductName");
            txtProductPrice.DataBindings.Add("Text", bsProducts, "UnitPrice");
            txtQuantity.DataBindings.Add("Text", bsProducts, "Quantity");

            dgvProductList.DataSource = bsProducts;
            bsProducts.Sort = "ProductID DESC";
            bnProductList.BindingSource = bsProducts;
        }
    }
}
