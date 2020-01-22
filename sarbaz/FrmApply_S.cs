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
    public partial class FrmApply_S : Form
    {
        public FrmApply_S()
        {
            InitializeComponent();
          
        }

        private void FrmApply_S_Load(object sender, EventArgs e)
        {
            txt_JazbDate.Text = PersianDate.GetPersianDate();



            var bank = new LinqDataContext();
            var query = (from p in bank.Gradetbls
                         orderby p.Id_Grade
                         select new {p.Id_Grade, p.Grade }).Distinct();

            comboBox_Grade.DataSource = query;
            comboBox_Grade.DisplayMember = "Grade";
            comboBox_Grade.ValueMember = "Id_Grade";

            var query1 = (from p in bank.Darajes
                         orderby p.ID
                         select new {p.ID, p.NameDaraje }).Distinct();

            comboBox_Darajeh.DataSource = query1;
            comboBox_Darajeh.DisplayMember = "NameDaraje";
            comboBox_Darajeh.ValueMember = "ID";


        }



        private void btnApply_Click(object sender, EventArgs e)
        {
            
            
            try
            {
               
                

                //int counter=1;
                if (this.txtIDSarbaz.Text == "" || this.txtName.Text == "" || this.txtLastName.Text == "" || this.txtFatherName.Text == "")
                    MessageBox.Show("لطفا موارد خواسته شده را پر نمایید");
                else
                {

                    var db = new LinqDataContext();
                    var query_Id = from p in db.sarbazs
                                   select p.شماره_ملی;
                    var x = txtID.Text;
                    foreach (var items in query_Id)
                    {

                        if (x == items) { MessageBox.Show("شماره ملی موجود است!");return; }
                    }

                    var S = new sarbaz();

                    S.شماره_ملی = txtID.Text;
                    S.نام = txtName.Text;
                    S.نام_خانوادگی = txtLastName.Text;
                    S.نام_پدر = txtFatherName.Text;

                    S.تاریخ_تولد = txt_BirthYear.Text;
                    S.آدرس = txt_Address.Text;
                    S.تلفن = txt_mobile.Text;
                    S.تحصیلات = comboBox_Grade.Text.ToString();
                    S.کد_تحصیلات = Convert.ToInt32(comboBox_Grade.SelectedValue);
                    S.رشته = txt_Reshteh.Text;


                    S.معرف = txt_Moaref.Text;
                    S.سابقه_بسیج_فعال = txt_Basij.Text;
                    S.حوزه_خدمت = txt_Hozeh.Text;
                   

                    S.تاهل = chBox_Taahol.Checked;
                    S.تکمیلی = chBox_Takmili.Checked;
                    S.سی_روزه = chBox_ThirthDay.Checked;
                    S.معاف_از_رزم = chBox_Moaf.Checked;
                    S.کمیته_امداد = chBox_Komiteh.Checked;
                    S.سازمان_بهزیستی = chBox_Behzisti.Checked;
                    S.بومی = chBox_Boomi.Checked;
                    S.فرمانده_دسته = chBox_FarmandeD.Checked;
                    S.فراری = chBox_Farari.Checked;
                    S.کمیسیون = chBox_Komision.Checked;



                    S.توضیحات = txt_Explain.Text;

                    S.تاریخ_اعزام = txt_EzamDate.Text;
                    S.درجه = comboBox_Darajeh.Text;
                    S.کد_درجه = Convert.ToInt32(comboBox_Darajeh.SelectedValue);
                    S.تاریخ_معرفی = txt_JazbDate.Text;


                    S.مدت_اضافه_خدمت_روز =txt_Ezaf.Text;
                    S.خدمت_قبلی_روز = txt_LastKhedmat.Text;
                    S.مدت_كسر_خدمت_به_روز = txt_kasri_day.Text;
                    // S.استحقاقی =Convert.ToInt32( txt_Estehghaghi.Text);
                    // S.تاریخ_ترخیص = Convert.ToDateTime(txt_FreeDate.Text);
                    S.مامور = chBox_MissionFlag.Checked;
                    S.مدت_ماموریت_ماه_ = txt_MissionDate.Text;
                    S.محل_ماموریت = txt_MissionLocation.Text;

                    db.sarbazs.InsertOnSubmit(S);
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
