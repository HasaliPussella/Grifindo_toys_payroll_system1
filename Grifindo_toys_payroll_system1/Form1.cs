using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Grifindo_toys_payroll_system1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-U2F6VMH\SQLEXPRESS;Initial Catalog=Grifindo;Integrated Security=True");

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string employee_name;
            int employee_id;

           // employee_name = emp_name.Text;
            //employee_id = Convert.ToInt32(emp_id.Text);

            try
            {
                string querry = "SELECT * FROM Login_new WHERE employee_name = '"+ guna2TextBox1.Text+ "' AND employee_id = '"+ guna2TextBox2.Text + "' ";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if(dtable.Rows.Count > 0)
                {
                    employee_name = guna2TextBox1.Text;
                    employee_id = Convert.ToInt32(guna2TextBox2.Text);

                    Loginform Form2 = new Loginform();
                    Form2.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Invalid login details","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    emp_name.ClearSelection();
                    emp_id.ClearSelection();

                    emp_name.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error"+ ex);
            }
            finally
            {
                conn.Close();
            }
        }

        private void signin_buttoon_Click(object sender, EventArgs e)
        {
            signinform form3 = new signinform();
            form3.Show();
            this.Hide();
        }
    }
}
