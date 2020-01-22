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
    public partial class FrmEdit_M : Form
    {
        public FrmEdit_M()
        {
            InitializeComponent();
        }

        private void FrmEdit_M_Load(object sender, EventArgs e)
        {
           




            var LinqObj = new LinqDataContext();

            var query = (from tempTbl in LinqObj.Mashmoolins
                         where tempTbl.Id_Mashmoolin == int.Parse(txtID_M.Text)
                         select tempTbl).Single();

            this.txtID.Text = query.شماره_ملی;
            this.txtName.Text = query.نام;
            this.txtLastName.Text = query.نام_خانوادگی;
            this.txtFatherName.Text = query.نام_پدر;
            this.txt_BirthYear.Text = query.تاریخ_تولد;

            var bank = new LinqDataContext();
            var query1 = (from p in bank.Gradetbls
                          orderby p.Id_Grade
                          select new { p.Id_Grade, p.Grade }).Distinct();

            comboBox_Grade.DataSource = query1;
            comboBox_Grade.DisplayMember = "Grade";
            comboBox_Grade.ValueMember = "Id_Grade";
            comboBox_Grade.Text = query.تحصیلات;

            txt_Address.Text = query.آدرس; 
            txt_mobile.Text=query.تلفن ;
            txt_Explain.Text = query.توضیحات;
           
           

            txt_Reshteh.Text= query.رشته ;
            txt_Moaref.Text= query.معرف ;
            txt_Basij.Text= query.سابقه_بسیج_فعال ;
            txt_HozehJazb.Text = query.حوزه_جذب ;
            txt_Ezaf.Text = query.اضاف;

            chBox_Takmili.Checked=Convert.ToBoolean( query.تکمیلی) ;
            chBox_ThirthDay.Checked=Convert.ToBoolean( query.سی_روزه) ;
            chBox_Moaf.Checked=Convert.ToBoolean( query.معاف_از_رزم) ;
            chBox_Komiteh.Checked=Convert.ToBoolean( query.کمیته_امداد );
             chBox_Behzisti.Checked=Convert.ToBoolean( query.سازمان_بهزیستی );
            chBox_Taahol.Checked = Convert.ToBoolean(query.تاهل);
          

            txt_EzamDate.Text = query.تاریخ_اعزام;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var LinqObj = new LinqDataContext();

            var query = (from tempTbl in LinqObj.Mashmoolins
                         where tempTbl.Id_Mashmoolin == int.Parse(txtID_M.Text)
                         select tempTbl).Single();

            query.شماره_ملی = this.txtID.Text;
            query.نام = this.txtName.Text;
            query.نام_خانوادگی = this.txtLastName.Text;
            query.نام_پدر = this.txtFatherName.Text;

            query.تاریخ_تولد = txt_BirthYear.Text;
            query.آدرس = txt_Address.Text;
            query.تلفن = txt_mobile.Text;
            query.تحصیلات = comboBox_Grade.Text.ToString();
            query.کد_تحصیلات =Convert.ToInt32( comboBox_Grade.SelectedValue);
            query.رشته = txt_Reshteh.Text;

            query.معرف = txt_Moaref.Text;
            query.سابقه_بسیج_فعال = txt_Basij.Text;
            query.حوزه_جذب = txt_HozehJazb.Text;
            query.اضاف = txt_Ezaf.Text;

            query.تکمیلی = chBox_Takmili.Checked;
            query.سی_روزه = chBox_ThirthDay.Checked;
            query.معاف_از_رزم = chBox_Moaf.Checked;
            query.کمیته_امداد = chBox_Komiteh.Checked;
            query.سازمان_بهزیستی = chBox_Behzisti.Checked;
            query.تاهل = chBox_Taahol.Checked;

            query.توضیحات = txt_Explain.Text;
            query.تاریخ_اعزام = txt_EzamDate.Text;

            LinqObj.SubmitChanges();

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
