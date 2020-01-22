using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sarbaz
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void LoginFrm_Load(object sender, EventArgs e)
        {
            this.label3.Text = "";

        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == "")
                {
                    MessageBox.Show("نام کاربر را وارد کنید", "اخطار در فرمت داده ها");
                    txtUserName.Select();
                    txtUserName.SelectAll();
                }
                else if (txtPassword.Text == "")
                {
                    MessageBox.Show("پسورد را وارد کنید", "اخطار در فرمت داده ها");
                    txtPassword.Select();
                    txtPassword.SelectAll();
                }
                else
                {
                    SqlConnection con = new SqlConnection(Properties.Settings.Default.sarbaz_DB_ConnectionString);
                    SqlCommand com = new SqlCommand();
                    com.Connection = con;
                    SqlDataReader Data_reader;
                    com.CommandType = CommandType.Text;
                    com.CommandText = "SELECT * FROM authenticatetbl  where users=@users and password=@password";
                    com.Parameters.AddWithValue("@users", txtUserName.Text);
                    com.Parameters.AddWithValue("@password", txtPassword.Text);
                    con.Open();
                    Data_reader = com.ExecuteReader();
                    
                    if (Data_reader.Read())
                    {
                         this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        var FrmMainObj = new FrmMain();
                        FrmMainObj.Show();
                      
                    }
                    else
                          this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                    con.Close();
                    this.Visible = false;

                 
                }
            }
            catch
            {
                MessageBox.Show("داده ها را در فرمت صحیح وارد کنید", "اخطار در فرمت داده ها");
                txtUserName.Select();
                txtUserName.SelectAll();
            }
           
        }

        
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            this.label3.Text = "";
        }

      
      
       
    }
}
