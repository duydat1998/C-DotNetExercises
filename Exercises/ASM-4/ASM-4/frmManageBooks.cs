using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Book;
namespace ASM_4
{
    public partial class frmManageBooks : Form
    {
        private DataTable dtBook;
        BookDAO dao;
        public frmManageBooks()
        {
            InitializeComponent();
            dao = new BookDAO();
        }

        private void frmManageBooks_Load(object sender, EventArgs e)
        {
            dtBook = dao.GetAllBook();
            dtBook.PrimaryKey = new DataColumn[] { dtBook.Columns["BookID"] };
            bsBook.DataSource = dtBook;

            txtBookID.DataBindings.Clear();
            txtBookName.DataBindings.Clear();
            txtBookPrice.DataBindings.Clear();

            txtBookID.DataBindings.Add("Text", bsBook, "BookID");
            txtBookName.DataBindings.Add("Text", bsBook, "BookName");
            txtBookPrice.DataBindings.Add("Text", bsBook, "BookPrice");

            dgvData.DataSource = bsBook;

            bnBook.BindingSource = bsBook;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmBookReport frmReport = new frmBookReport(bsBook);
            frmReport.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataView dv = dtBook.DefaultView;
            string filter = "BookName like '%" + txtSearch.Text + "%'";
            dv.RowFilter = filter;
            lbTotalPrice.Text = "Total Price : " + dtBook.Compute("SUM(BookPrice)", filter);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtBookID.Text = "";
            txtBookName.Text = "";
            txtBookPrice.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int bookID = int.Parse(txtBookID.Text.Trim());
                string bookName = txtBookName.Text;
                float price = float.Parse(txtBookPrice.Text);
                BookDTO dto = new BookDTO { BookID = bookID, BookName = bookName, BookPrice = price };
                bool result = dao.AddBook(dto);
                if (result)
                {
                    MessageBox.Show("Add Successfully", "Result");
                    frmManageBooks_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Add Fail", "Result");
                }
            }
            catch (Exception ecx)
            {
                MessageBox.Show(ecx.Message, "Error");
            }
            
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int bookID = int.Parse(txtBookID.Text.Trim());
                string bookName = txtBookName.Text;
                float price = float.Parse(txtBookPrice.Text);
                BookDTO dto = new BookDTO { BookID = bookID, BookName = bookName, BookPrice = price };
                bool result = dao.UpdateBook(dto);
                if (result)
                {
                    MessageBox.Show("Update Successfully", "Result");
                    frmManageBooks_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Update Fail", "Result");
                }
            }
            catch (Exception ecx)
            {
                MessageBox.Show(ecx.Message, "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int bookID = int.Parse(txtBookID.Text.Trim());
                if (!bookID.Equals(""))
                {
                    bool result = dao.DeleteBook(bookID);
                    if (result)
                    {
                        MessageBox.Show("Delete Successfully", "Result");
                        frmManageBooks_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Delete Fail", "Result");
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error");
            }
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog();
            this.Close();
        }
    }
}
