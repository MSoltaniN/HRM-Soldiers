using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sarbaz
{
    public partial class FrmApply_M : Form
    {
        public FrmApply_M()
        {
            InitializeComponent();
        }


        private void FrmApply_M_Load(object sender, EventArgs e)
        {

            var bank = new LinqDataContext();
            var query = (from p in bank.Gradetbls
                         orderby p.Id_Grade
                         select new {p.Id_Grade, p.Grade }).Distinct();

            comboBox_Grade .DataSource = query;
            comboBox_Grade.DisplayMember = "Grade";
            comboBox_Grade.ValueMember = "Id_Grade";
        }


        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                //int counter=1;
                if (this.txtID_M.Text == "" || this.txtName.Text == "" || this.txtLastName.Text == "" || this.txtFatherName.Text == "")
                    MessageBox.Show("لطفا موارد خواسته شده را پر نمایید");
                else
                {

                    var db = new LinqDataContext();


                    var query_Id = from p in db.Mashmoolins
                                   select p.شماره_ملی;
                    var x = txtID.Text;
                    foreach (var items in query_Id)
                    {

                        if (x == items) { MessageBox.Show("شماره ملی موجود است!"); return; }
                    }

                    var M = new Mashmoolin();

                    
                    M.شماره_ملی = txtID.Text;
                    M.نام = txtName.Text;
                    M.نام_خانوادگی = txtLastName.Text;
                    M.نام_پدر = txtFatherName.Text;
                    M.تاریخ_تولد = txt_BirthYear.Text;

                  

                    M.آدرس = txt_Address.Text;
                    M.تلفن = txt_mobile.Text;
                    M.تحصیلات = comboBox_Grade.Text.ToString();
                    M.کد_تحصیلات =Convert.ToInt32( comboBox_Grade.SelectedValue);
                    M.رشته = txt_Reshteh.Text;
                    M.معرف = txt_Moaref.Text;
                    M.سابقه_بسیج_فعال = txt_Basij.Text;
                    M.حوزه_جذب = txt_HozehJazb.Text;
                    M.اضاف = txt_Ezaf.Text;

                    M.تکمیلی = chBox_Takmili.Checked;
                    M.سی_روزه = chBox_ThirthDay.Checked;
                    M.معاف_از_رزم = chBox_Moaf.Checked;
                    M.کمیته_امداد = chBox_Komiteh.Checked;
                    M.سازمان_بهزیستی = chBox_Behzisti.Checked;
                    M.تاهل = chBox_Taahol.Checked;
                    
                    M.توضیحات = txt_Explain.Text;

                    M.تاریخ_اعزام = txt_EzamDate.Text;

                    db.Mashmoolins.InsertOnSubmit(M);
                    db.SubmitChanges();

                   


                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
