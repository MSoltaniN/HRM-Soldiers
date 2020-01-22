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
    public partial class Frm_Login_DB : Form
    {
        public Frm_Login_DB()
        {
            InitializeComponent();
        }
        public static string serverName = string.Empty;
        public static string userName = string.Empty;
        public static string password = string.Empty;

        public static DataSet ds = new DataSet();
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            serverName = txt_ServerName.Text;
             userName = txt_UserName.Text;
             password = txt_Pass.Text;
            // string str = "Data Source=" + txt_ServerName.Text + ";User ID=" + txt_UserName.Text + ";Password=" + txt_Pass.Text + "";
            string str = "Data Source=.;Initial Catalog=sarbaz_DB;Integrated Security=True";

            SqlConnection con = new SqlConnection(str);
            try
            {
                con.Open();
                // MessageBox.Show("connection gets established");    
                SqlCommand cmd = new SqlCommand("SELECT  db.[name] as dbname FROM [master].[sys].[databases] db", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(ds, "DatabaseName");
                con.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Login_DB_Load(object sender, EventArgs e)
        {

        }
    }
}
