using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Employee;
namespace ASM_4
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string empID = txtEmpID.Text.Trim();
            string empPass = txtPass.Text.Trim();
            EmployeeDAO dao = new EmployeeDAO();
            EmployeeDTO dto = dao.CheckLogin(empID, empPass);
            if (dto != null)
            {
                if (dto.EmpRole)
                {
                    frmManageBooks frm = new frmManageBooks();
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    frmChangeAccount frm = new frmChangeAccount(dto);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Employee ID or Password is invalid","Invalid" );
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEmpID.Clear();
            txtPass.Clear();
        }
    }
}
