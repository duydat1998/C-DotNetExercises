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
    public partial class Form1 : Form
    {
        //List<Product> listOfProduct;
        DataTable dtProduct;
        ProductDB pd;
        public Form1()
        {
            InitializeComponent();
            pd = new ProductDB();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtProduct = pd.GetAllProducts();
            dtProduct.Columns.Add("SubTotal", typeof(float), "UnitPrice*Quantity");
            dgvData.DataSource = dtProduct;


            txtID.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtPrice.DataBindings.Clear();
            txtQuantity.DataBindings.Clear();
            txtTotal.DataBindings.Clear();

            txtID.DataBindings.Add("Text", dtProduct, "ProductID");
            txtName.DataBindings.Add("Text", dtProduct, "ProductName");
            txtPrice.DataBindings.Add("Text", dtProduct, "UnitPrice");
            txtQuantity.DataBindings.Add("Text", dtProduct, "Quantity");
            txtTotal.DataBindings.Add("Text", dtProduct, "SubTotal");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtTotal.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                string name = string.Empty;
                float price = 0;
                int quantity = 0;
                if(getAndCheckValues(ref id, ref name, ref price, ref quantity))
                {
                    Product p = new Product { ProductID = id, ProductName = name, Quantity = quantity, UnitPrice = price };
                    bool result = pd.AddNewProduct(p);
                    string message = (result ? "successfull" : "fail");
                    MessageBox.Show("Add " + message);
                    Form1_Load(sender, e);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private bool getAndCheckValues(ref int id, ref string name, ref float price, ref int quantity)
        {
            id = int.Parse(txtID.Text);
            if (id <= 0)
            {
                MessageBox.Show("ID must not be less than 0");
                return false;
            }
            name = txtName.Text.Trim();
            if (name == string.Empty || name.Equals(""))
            {
                MessageBox.Show("Name must not be empty");
                return false;
            }
            price = float.Parse(txtPrice.Text);
            if (price <= 0)
            {
                MessageBox.Show("Price must not be less than 0");
                return false;
            }
            quantity = int.Parse(txtQuantity.Text);
            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must not be less than 0");
                return false;
            }

            return true;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                string name = string.Empty;
                float price = 0;
                int quantity = 0;
                if(getAndCheckValues(ref id, ref name, ref price, ref quantity))
                {
                    Product p = new Product { ProductID = id, ProductName = name, Quantity = quantity, UnitPrice = price };
                    bool result = pd.UpdateProduct(p);
                    string message = (result ? "successfull" : "fail");
                    MessageBox.Show("Update " + message);
                    Form1_Load(sender, e);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtID.Text);
                bool result = pd.RemoveProduct(id);
                string message = (result ? "successfull" : "fail");
                MessageBox.Show("Remove " + message);
                Form1_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtSearch.Text);
                Product p = pd.FindProduct(id);
                if (p == null)
                {
                    MessageBox.Show("No result is matched!");
                }
                else
                {
                    FormPopup popUp = new FormPopup(p);
                    popUp.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
