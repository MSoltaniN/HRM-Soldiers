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
    public partial class FrmEdit_S : Form
    {
        public FrmEdit_S()
        {
            InitializeComponent();
        }


        private void FrmEditSarbaz_Load(object sender, EventArgs e)
        {
            var LinqObj = new LinqDataContext();

            var query = (from tempTbl in LinqObj.sarbazs
                         where tempTbl.Id_Sarbaz == int.Parse(txtIDSarbaz.Text)
                         select tempTbl).Single();

            this.txtID.Text = query.شماره_ملی;
            this.txtName.Text = query.نام;
            this.txtLastName.Text = query.نام_خانوادگی;
            this.txtFatherName.Text = query.نام_پدر;

            txt_Address.Text= query.آدرس ;
             txt_mobile.Text=query.تلفن ;

            var bank = new LinqDataContext();
            var query1 = (from p in bank.Gradetbls
                          orderby p.Id_Grade
                          select new { p.Id_Grade, p.Grade }).Distinct();

            comboBox_Grade.DataSource = query1;
            comboBox_Grade.DisplayMember = "Grade";
            comboBox_Grade.ValueMember = "Id_Grade";
            comboBox_Grade.Text = query.تحصیلات;

            txt_Reshteh.Text= query.رشته ;
            txt_BirthYear.Text = query.تاریخ_تولد;
            txt_Explain.Text = query.توضیحات;

            txt_Moaref.Text= query.معرف ;
             txt_Basij.Text= query.سابقه_بسیج_فعال ;
             txt_Hozeh.Text = query.حوزه_خدمت;
          
            chBox_Taahol.Checked = Convert.ToBoolean(query.تاهل);
            chBox_Takmili.Checked =Convert.ToBoolean( query.تکمیلی );
            chBox_ThirthDay.Checked= Convert.ToBoolean(query.سی_روزه );
           chBox_Moaf.Checked = Convert.ToBoolean(query.معاف_از_رزم );
            chBox_Komiteh.Checked= Convert.ToBoolean(query.کمیته_امداد );
             chBox_Behzisti.Checked= Convert.ToBoolean(query.سازمان_بهزیستی );
             chBox_Boomi.Checked= Convert.ToBoolean(query.بومی );
            chBox_FarmandeD.Checked = Convert.ToBoolean(query.فرمانده_دسته );
            chBox_Farari.Checked = Convert.ToBoolean(query.فراری );
             chBox_Komision.Checked= Convert.ToBoolean(query.کمیسیون );

            query.توضیحات = txt_Explain.Text;


          
            



          
            var query2 = (from p in bank.Darajes
                          orderby p.ID
                          select new {p.ID, p.NameDaraje }).Distinct();

            comboBox_Darajeh.DataSource = query2;
            comboBox_Darajeh.DisplayMember = "NameDaraje";
            comboBox_Darajeh.ValueMember = "ID";
            comboBox_Darajeh.Text= query.درجه;

            txt_JazbDate.Text= query.تاریخ_معرفی ;
            txt_EzamDate.Text = query.تاریخ_اعزام;


            txt_Ezaf.Text = query.مدت_اضافه_خدمت_روز;
            txt_LastKhedmat.Text = query.خدمت_قبلی_روز;
            txt_kasri_day.Text = query.مدت_كسر_خدمت_به_روز;
            txt_Estehghaghi.Text = query.استحقاقی;
            txt_FreeDate.Text = query.تاریخ_ترخیص;

            chBox_MissionFlag.Checked = Convert.ToBoolean(query.مامور);
            txt_MissionDate.Text = query.مدت_ماموریت_ماه_;
            txt_MissionLocation.Text = query.محل_ماموریت;
            txt_EndMissionDate.Text = query.تاریخ_اتمام_ماموریت;

                
           
        }


      


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {



                var LinqObj = new LinqDataContext();

                var query = (from tempTbl in LinqObj.sarbazs
                             where tempTbl.Id_Sarbaz == int.Parse(txtIDSarbaz.Text)
                             select tempTbl).Single();



                query.شماره_ملی = this.txtID.Text;
                query.نام = this.txtName.Text;
                query.نام_خانوادگی = this.txtLastName.Text;
                query.نام_پدر = this.txtFatherName.Text;

                query.آدرس = txt_Address.Text;
                query.تلفن = txt_mobile.Text;
                query.تحصیلات =comboBox_Grade.Text;
                query.کد_تحصیلات = Convert.ToInt32(comboBox_Grade.SelectedValue);
                query.رشته = txt_Reshteh.Text;
                query.تلفن = txt_mobile.Text;
                query.تاریخ_تولد = txt_BirthYear.Text;

                query.حوزه_خدمت = txt_Hozeh.Text;
                query.معرف = txt_Moaref.Text;
                query.سابقه_بسیج_فعال = txt_Basij.Text;


                query.تاهل = chBox_Taahol.Checked;
                query.تکمیلی = chBox_Takmili.Checked;
                query.سی_روزه = chBox_ThirthDay.Checked;
                query.معاف_از_رزم = chBox_Moaf.Checked;
                query.کمیته_امداد = chBox_Komiteh.Checked;
                query.سازمان_بهزیستی = chBox_Behzisti.Checked;
                query.بومی = chBox_Boomi.Checked;
                query.فرمانده_دسته = chBox_FarmandeD.Checked;
                query.فراری = chBox_Farari.Checked;
                query.کمیسیون = chBox_Komision.Checked;

                query.توضیحات = txt_Explain.Text;


                query.تاریخ_اعزام = txt_EzamDate.Text;
                query.تاریخ_معرفی = txt_JazbDate.Text;
                query.درجه = comboBox_Darajeh.Text;
                query.کد_درجه = Convert.ToInt32(comboBox_Darajeh.SelectedValue);



                query.مدت_اضافه_خدمت_روز = txt_Ezaf.Text;
                query.خدمت_قبلی_روز = txt_LastKhedmat.Text;
                query.مدت_كسر_خدمت_به_روز = txt_kasri_day.Text;
                //  query.استحقاقی =Convert.ToInt32( txt_Estehghaghi.Text);
                //  query.تاریخ_ترخیص =Convert.ToDateTime( txt_FreeDate.Text);
                query.مامور = chBox_MissionFlag.Checked;
                query.مدت_ماموریت_ماه_ = txt_MissionDate.Text;
                query.محل_ماموریت = txt_MissionLocation.Text;


                LinqObj.SubmitChanges();

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
