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
    public partial class frmChangeAccount : Form
    {
        public frmChangeAccount()
        {
            InitializeComponent();
        }

        public frmChangeAccount(EmployeeDTO dto)
        {
            InitializeComponent();
            txtEmpID.Text = dto.EmpID;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string empID = txtEmpID.Text;
            string pass = txtPass.Text;
            if(pass.Trim().Length== 0)
            {
                MessageBox.Show("Password musn't be blank!");
            }
            else
            {
                EmployeeDAO dao = new EmployeeDAO();
                bool result = dao.ChangePassword(empID, pass);
                if (result)
                {
                    MessageBox.Show( "Change Successfully", "Result");
                }
                else
                {
                    MessageBox.Show( "Change Fail", "Result");
                }
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
