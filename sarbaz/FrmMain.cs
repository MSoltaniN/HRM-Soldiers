using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;


using System.IO;
using FastReport;


using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;




namespace sarbaz
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        //////////////////////////////// /        Methods      //////////////////////////////////////////


        /// <summary>
        /// //////////////////////   Show  GVtables   ////////
        /// </summary>


        //public IQueryable Public_query_ShowGVtableJazb;
        //public DataTable Public_query_ShowGVtablePriority;
        //public DataTable Public_query_ShowGVtableSarbaz;

        private void ShowGVtableJazb()
        {
            if (chBox_EzamDate.Checked)
            {
                var bank = new LinqDataContext();
                var query = from p in bank.Mashmoolins
                            where (p.نام==null|| p.نام.Contains(txtSearchName_M.Text))
                            && (p.نام_خانوادگی == null || p.نام_خانوادگی.Contains(txtSearchLastName_M.Text))
                            && (p.نام_پدر == null || p.نام_پدر.Contains(txtSearchFatherName_M.Text))
                             && (p.شماره_ملی == null || p.شماره_ملی.Contains(txtSearchID_M.Text))
                             && (p.تاریخ_اعزام == null || p.تاریخ_اعزام.Contains(Convert.ToString(cbox_M_EzamDate.SelectedValue)))
                            select 
                                    new
                                    {
                                        //   جذب=p.جذب,
                                        شماره_پرونده = p.Id_Mashmoolin,
                                        کد_ملی = p.شماره_ملی,
                                        نام = p.نام,
                                        نام_خانوادگی = p.نام_خانوادگی
                                    ,
                                        نام_پدر = p.نام_پدر,
                                        تحصیلات = p.تحصیلات,
                                        رشته = p.رشته,
                                        تکمیلی = p.تکمیلی
                                    };

                // Public_query_ShowGVtableJazb= query.CopyToDataTable();
                GV_Mashmoolin.DataSource = query;

                this.toolStripLabel_J.Text =  "  تعداد مشمولین:   "+ Convert.ToString(query.Count());
            }
            else
            {
                var bank = new LinqDataContext();
                var query = from p in bank.Mashmoolins
                            where( p.نام==null||p.نام.Contains(txtSearchName_M.Text))
                            && (p.نام_خانوادگی == null || p.نام_خانوادگی.Contains(txtSearchLastName_M.Text))
                            && (p.نام_پدر == null || p.نام_پدر.Contains(txtSearchFatherName_M.Text))
                             && (p.شماره_ملی == null || p.شماره_ملی.Contains(txtSearchID_M.Text))
                            //  && p.تاریخ_اعزام.Contains(Convert.ToString(cboxEzamDate.SelectedValue))
                            select 
                                    new
                                    {
                                        // جذب = p.جذب,
                                        شماره_پرونده = p.Id_Mashmoolin,
                                        کد_ملی = p.شماره_ملی,
                                        نام = p.نام,
                                        نام_خانوادگی = p.نام_خانوادگی
                                    ,
                                        نام_پدر = p.نام_پدر,
                                        تحصیلات = p.تحصیلات,
                                        رشته = p.رشته,
                                        تکمیلی = p.تکمیلی
                                    };

                GV_Mashmoolin.DataSource = query;



                this.toolStripLabel_J.Text = "  تعداد مشمولین:   " + Convert.ToString(query.Count());
            }


        }


        private void ShowGVtablePriority()
        {
            var bank = new LinqDataContext();
            var query = from p in bank.Mashmoolins
                        where (p.نام==null ||p.نام.Contains(txtSearchName_P.Text))
                        && (p.نام_خانوادگی == null || p.نام_خانوادگی.Contains(txtSearchLastName_P.Text))
                        && (p.نام_پدر == null || p.نام_پدر.Contains(txtSearchFatherName_P.Text))
                         && (p.شماره_ملی == null || p.شماره_ملی.Contains(txtSearchID_P.Text))
                         && (p.جذب == null || p.جذب == false)
                         && (p.تاریخ_اعزام == null || p.تاریخ_اعزام.Contains(Convert.ToString(cbox_P_EzamDate.SelectedValue)))

                        orderby p.اولویت descending

                        select   new
                            {
                                شماره_پرونده = p.Id_Mashmoolin,
                                کد_ملی = p.شماره_ملی,
                                نام = p.نام,
                                نام_خانوادگی = p.نام_خانوادگی
                            ,
                                نام_پدر = p.نام_پدر,
                                تحصیلات = p.تحصیلات,
                                رشته = p.رشته,
                                تکمیلی = p.تکمیلی,
                                اولویت = p.اولویت
                            };
            GV_Priority.DataSource = query;


        }


        private void ShowGVtableSarbaz()
        {
            if (this.checkBox_ActiveCboxHozeh.Checked)
            {
                var bank = new LinqDataContext();
                var query = from p in bank.sarbazs
                            where (p.نام == null || p.نام.Contains(txtSearchName.Text))
                            && (p.نام_خانوادگی == null || p.نام_خانوادگی.Contains(txtSearchLastName.Text))
                            && (p.نام_پدر == null || p.نام_پدر.Contains(txtSearchFatherName.Text))
                             && (p.شماره_ملی == null || p.شماره_ملی.Contains(txtSearchID.Text))
                             && (p.حوزه_خدمت == null || p.حوزه_خدمت.Contains(Convert.ToString(cboxNavahi.SelectedValue)))
                            select
                                    new
                                    {
                                        
                                        شماره_پرونده = p.Id_Sarbaz,
                                        کد_ملی = p.شماره_ملی,
                                        نام = p.نام,
                                        نام_خانوادگی = p.نام_خانوادگی,
                                        نام_پدر = p.نام_پدر,
                                        حوزه_خدمت = p.حوزه_خدمت,
                                        درجه = p.درجه,
                                        تحصیلات = p.تحصیلات,
                                        p.استحقاقی,
                                        p.تاریخ_ترخیص,
                                        p.تاریخ_اتمام_ماموریت
                                    };
                GVTable.DataSource = query;


                toolStripLabel_S.Text = "تعداد سربازان  :   " + Convert.ToString(query.Count());
            }
            else {
                var bank = new LinqDataContext();
                var query = from p in bank.sarbazs
                            where (p.نام == null || p.نام.Contains(txtSearchName.Text))
                            && (p.نام_خانوادگی == null || p.نام_خانوادگی.Contains(txtSearchLastName.Text))
                            && (p.نام_پدر == null || p.نام_پدر.Contains(txtSearchFatherName.Text))
                             && (p.شماره_ملی == null || p.شماره_ملی.Contains(txtSearchID.Text))
                            //  && p.KhedmatHozeh.Contains(Convert.ToString(cboxNavahi.SelectedValue))
                            select 
                                    new
                                    {
                                        شماره_پرونده = p.Id_Sarbaz,
                                        کد_ملی = p.شماره_ملی,
                                        نام = p.نام,
                                        نام_خانوادگی = p.نام_خانوادگی,
                                        نام_پدر = p.نام_پدر,
                                        حوزه_خدمت = p.حوزه_خدمت,
                                        درجه = p.درجه,
                                        تحصیلات = p.تحصیلات,
                                        p.استحقاقی,
                                        p.تاریخ_ترخیص,
                                        p.تاریخ_اتمام_ماموریت
                                    };
                GVTable.DataSource = query;

                toolStripLabel_S.Text = "  تعداد سربازان:   " + Convert.ToString(query.Count());

            }

        }

        private void ShowGVtableRaked()
        {
            var bank = new LinqDataContext();
            var query = from p in bank.Rakedin_Main_Tables
                        where (p.نام == null || p.نام.Contains(txtSearchFatherName_Rakedin.Text))
                        &&(p.نام_خانوادگی==null|| p.نام_خانوادگی.Contains(txtSearchLastName_Rakedin.Text))
                        && (p.نام_پدر == null || p.نام_پدر.Contains(txtSearchFatherName_Rakedin.Text))
                         &&(p.شماره_شناسنامه==null || p.شماره_شناسنامه.Contains(txtSearchIdentifierNum_Rakedin.Text))
                         && (p.شماره_ملی == null || p.شماره_ملی.Contains(txtSearchIdentifierNum_Rakedin.Text))
                        // && p.حوزه_اعزام_کننده.Contains(cboxNavahi.SelectedValue))
                        select 
                                new
                                {
                                    شماره_پرونده = p.Id_Rakedin_Main_Table,
                                    شماره_شناسنامه = p.شماره_شناسنامه,
                                    p.شماره_ملی,
                                    نام = p.نام,
                                    نام_خانوادگی = p.نام_خانوادگی,
                                    نام_پدر = p.نام_پدر,
                                    p.حوزه_اعزام_کننده,
                                    درجه = p.درجه,
                                    تحصیلات = p.مدرک_پایان
                                };

            GV_Rakedin.DataSource = query;
        }


        /// ////////////////////////////   Show  ComboBoxs    /////////////////////////

        private void Show_Cboxes_EzamDate()
        {

            var bank = new LinqDataContext();
            var query = (from p in bank.Mashmoolins
                                       orderby p.تاریخ_اعزام
                                       select new { p.تاریخ_اعزام }).Distinct();

            cbox_M_EzamDate.DataSource = query;
            cbox_M_EzamDate.DisplayMember = "تاریخ_اعزام";
            cbox_M_EzamDate.ValueMember = "تاریخ_اعزام";

            cbox_P_EzamDate.DataSource = query;
            cbox_P_EzamDate.DisplayMember = "تاریخ_اعزام";
            cbox_P_EzamDate.ValueMember = "تاریخ_اعزام";

            cbox_M_InsertTo_S_EzamDate.DataSource = query;
            cbox_M_InsertTo_S_EzamDate.DisplayMember = "تاریخ_اعزام";
            cbox_M_InsertTo_S_EzamDate.ValueMember = "تاریخ_اعزام";

        }
        
        private void Show_Cbox_Navahi()
        {

            var bank = new LinqDataContext();
            cboxNavahi.DataSource = (from p in bank.sarbazs
                                     orderby p.حوزه_خدمت
                                     select new { p.حوزه_خدمت }).Distinct();
            cboxNavahi.DisplayMember = "حوزه_خدمت";
            cboxNavahi.ValueMember = "حوزه_خدمت";
            // cboxNavahi.Items.Add("تمام موارد");


        }

        ///////////////////////// set Defoalt TextBox Value ///////////

            private void Set_defoultTextBoxValues()
        {
            txt_P_30day.Text = "1";
            txt_P_Distance.Text = "1";
            txt_P_Grade.Text = "1";
            txt_P_Reshteh.Text = "1";
            txt_P_Takmini.Text = "1";

            toolStripLabel_J.Text = "";
            toolStripLabel_P.Text = "";
            toolStripLabel_S.Text = "";
            toolStripLabel_SJ.Text = "";
            toolStripLabel_R.Text = "";
            toolStripLabel_B.Text = "";


        }

        /// <summary>
        /// /////////////////////////   Main Form Load   ////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            ///// set connection string
            //var bank = new LinqDataContext();
            //var query = from p in bank.ServerName_tbls
            //            select p.ConnectionString;
            

            /////// initialize objects //////////////
            Set_defoultTextBoxValues();

            Show_Cboxes_EzamDate();
            Show_Cbox_Navahi(); /// should be first of all (because next method read from it)

            ///////////////////////////////////////////
            //pictureBox_SJ_Referesh_Click(sender, e);

            Refresh_Commponent(null, null);


        }

        /// <summary>
        /// ///////////////////////    Referesh_Commponent     /////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Refresh_Commponent(object sender, EventArgs e)
        {
            try
            {
                ShowGVtableJazb();
                ShowGVtablePriority();

                
                ShowGVtableSarbaz();

                ShowGVtableRaked();

                this.FormBorderStyle = FormBorderStyle.FixedDialog;




            

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// //////////////////////////////////////tab    click ///////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void tabPage_Jazb_Click(object sender, EventArgs e)
        {
            ShowGVtableJazb();
        }

        private void tabPage_Priority_Click(object sender, EventArgs e)
        {
            ShowGVtablePriority();
        }

        private void tabPage_Sarbaz_Click(object sender, EventArgs e)
        {
            ShowGVtableSarbaz();
        }

        /////////////////////////////      جذب   tab    /////////////////////////////////////////////////////



        private void btnShow_ChboxJazb_Click_1(object sender, EventArgs e)
        {


            ShowGVtableJazb();
            ////////////////////////// update field جذب  in grideview  //////////////
            var bank = new LinqDataContext();
            var query2 = from p in bank.Mashmoolins
                         select p;
            foreach (DataGridViewRow myrow in GV_Mashmoolin.Rows)
            {
                myrow.Cells["jazb"].Value = (query2.Where(tempTbl => tempTbl.Id_Mashmoolin == Convert.ToInt32(myrow.Cells["شماره_پرونده"].Value))).Single().جذب;
            }
            ////////////////////////////////////////////////////////////////////////
        }




        private void chBox_EzamDate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ShowGVtableJazb();

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void cboxEzamDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ShowGVtableJazb();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }



        private void txtSearchID_M_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (txtSearchName.Text == "")
                {
                    ShowGVtableJazb();
                }
                else
                {


                    ShowGVtableJazb();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }


        private void txtSearchName_M_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (txtSearchName.Text == "")
                {
                    ShowGVtableJazb();
                }
                else
                {


                    ShowGVtableJazb();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchLastName_M_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (txtSearchName.Text == "")
                {
                    ShowGVtableJazb();
                }
                else
                {


                    ShowGVtableJazb();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void txtSearchFatherName_M_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (txtSearchName.Text == "")
                {
                    ShowGVtableJazb();
                }
                else
                {


                    ShowGVtableJazb();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }





        private void btnAdd_M_Click(object sender, EventArgs e)
        {


            var db = new LinqDataContext();

            var FrmObj = new FrmApply_M();
            var query = from p in db.Mashmoolins
                        select new { c1 = p.Id_Mashmoolin };

            FrmObj.txtID_M.Text = (Convert.ToString(query.Max(p => p.c1 + 1)));


            FrmObj.ShowDialog();
            Refresh_Commponent(null, null);
        }





        private void btnEdit_M_Click(object sender, EventArgs e)
        {
            var FrmEdite_M_Obj = new FrmEdit_M();

            FrmEdite_M_Obj.txtID_M.Text = Convert.ToString(GV_Mashmoolin.CurrentRow.Cells[1].Value);



            FrmEdite_M_Obj.ShowDialog();
            Refresh_Commponent(null, null);
        }









        private void btnApplyMashmoolin_for_Jazb_Click(object sender, EventArgs e)
        {



            var LinqObj = new LinqDataContext();
            var query = from tempTbl in LinqObj.Mashmoolins
                        select tempTbl;

            foreach (DataGridViewRow myrow in GV_Mashmoolin.Rows)
            {


                // CheckBox ChkSelect = (CheckBox)myrow.Cells[1];
                if (Convert.ToBoolean(myrow.Cells["jazb"].Value))
                {
                    (query.Where(tempTbl => tempTbl.Id_Mashmoolin == Convert.ToInt32(myrow.Cells["شماره_پرونده"].Value))).Single().جذب = true;
                  //  LinqObj.SubmitChanges();
                }
                else if (!Convert.ToBoolean(myrow.Cells["jazb"].Value))
                {
                    (query.Where(tempTbl => tempTbl.Id_Mashmoolin == Convert.ToInt32(myrow.Cells["شماره_پرونده"].Value))).Single().جذب = false;


                    //LinqObj.SubmitChanges();
                }

              
            }
           




            LinqObj.SubmitChanges();
            //  toolStripStatusLabel1.Text = "finish";
            ShowGVtablePriority();


        }


        private void btnDelete_M_Click(object sender, EventArgs e)
        {
            try
            {
                if (GVTable.RowCount == 0) return;
                if (MessageBox.Show("                    آیا می خواهید حذف کنید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {


                    if (GVTable.RowCount > 1)
                    {
                        // var ss = GVTable.CurrentRow.Cells[0].Value);
                        var db = new LinqDataContext();

                        var query = (from p in db.Mashmoolins
                                     where p.Id_Mashmoolin == Convert.ToInt32(GV_Mashmoolin.CurrentRow.Cells["شماره_پرونده"].Value)

                                     select p).Single();
                        db.Mashmoolins.DeleteOnSubmit(query);
                        db.SubmitChanges();

                    }
                    Refresh_Commponent(null, null);

                }

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        /////////////////////////////////////    tab  اولویت    /////////////////////////////////////////////
        private void cbox_P_EzamDate_SelectedIndexChanged(object sender, EventArgs e)
        {
          

            try
            {
                ShowGVtablePriority();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void txtSearchID_P_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (txtSearchName.Text == "")
                {
                    ShowGVtablePriority();
                }
                else
                {


                    ShowGVtablePriority();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchName_P_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (txtSearchName.Text == "")
                {
                    ShowGVtablePriority();
                }
                else
                {


                    ShowGVtablePriority();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchLastName_P_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (txtSearchName.Text == "")
                {
                    ShowGVtablePriority();
                }
                else
                {


                    ShowGVtablePriority();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchFatherName_P_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (txtSearchName.Text == "")
                {
                    ShowGVtablePriority();
                }
                else
                {


                    ShowGVtablePriority();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnFieldCapacity_Click(object sender, EventArgs e)
        {
            var db = new LinqDataContext();

            var LoadFrm = new FrmFieldCapacity();
            //   var query = from p in db.Mashmoolins
            //              select new { c1 = p.Id_Mashmoolin };
            //   LoadFrm.txtID.Text = (query.Max(p => p.c1 + 1)));


            LoadFrm.ShowDialog();
            Refresh_Commponent(null, null);

        }

        private void btnApplyPriority_Click(object sender, EventArgs e)
        {
            if (!(txtSearchID_P.Text == "") ||!( txtSearchName_P.Text == "") ||!( txtSearchLastName_P.Text == "") ||!( txtSearchFatherName_P.Text == ""))
                MessageBox.Show("لطفا فیلدهای جستجو را خالی بگذارید    ");
            else
            {


               
                var takmili = Convert.ToInt32(txt_P_Takmini.Text);
                var thirth_day = Convert.ToInt32(txt_P_30day.Text);
                var distance = Convert.ToInt32(txt_P_Distance.Text);
                var grade = Convert.ToInt32(txt_P_Grade.Text);

                var bank = new LinqDataContext();


                var query = from p in bank.Mashmoolins
                            where p.جذب == false
                            && p.تاریخ_اعزام.Contains(Convert.ToString(cbox_P_EzamDate.SelectedValue))
                            select p;
                var query_PriorityValue = from p in bank.Mashmoolins
                                          where p.جذب == false
                                          && p.تاریخ_اعزام== Convert.ToString(cbox_P_EzamDate.SelectedValue)
                                          select p.اولویت;

             
                foreach(var query_item in query)
                {
                    var query_City_Distance = (from p in bank.Cities
                                               where p.ID_City == Convert.ToInt32(query_item.کد_شهر_محل_سکونت)
                                               select p.Distance).SingleOrDefault()  ;
                   
                     var Is_takmili=0;
                    if (query_item.تکمیلی == true) {  Is_takmili = 1; } else { Is_takmili = 0; }
                    var Is_thirth_day = 0;
                    if (query_item.سی_روزه == true) { Is_thirth_day = 1; } else { Is_thirth_day = 0; }



                    if (query_item.کد_تحصیلات == null) query_item.کد_تحصیلات = 0;
                    if (query_City_Distance == null) query_City_Distance = 0;

                    query_item.اولویت = Convert.ToInt32(Is_takmili) * takmili
                                      + Convert.ToInt32(Is_thirth_day) * thirth_day
                                      + query_item.کد_تحصیلات * grade
                                      +Convert.ToInt32( query_City_Distance) * distance;
                   
                }


                bank.SubmitChanges();
            }
            ShowGVtablePriority();
        }




        private void btn_P_ApplyJazb_From_Priority_Click(object sender, EventArgs e)
        {
            try {
                var jazb_Num_From_Priority = Convert.ToInt32(txt_Jazb_Num_From_Priority.Text);

                var bank = new LinqDataContext();
                var query = (from temp in bank.Mashmoolins
                             where temp.جذب == false
                             && temp.تاریخ_اعزام.Contains(Convert.ToString(cbox_P_EzamDate.SelectedValue))
                             orderby temp.اولویت descending
                             select temp).Take(jazb_Num_From_Priority);


                foreach (var qeuryItem in query)
                {
                    qeuryItem.جذب = true;
                }
                bank.SubmitChanges();


            }

            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }



        /// <summary>
        /// ///////////////////////////سرباز tab //////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            try
            {


                if (txtSearchName.Text == "")
                {
                    ShowGVtableSarbaz();
                }
                else
                {


                    ShowGVtableSarbaz();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void txtSearchLastName_TextChanged(object sender, EventArgs e)
        {
            try
             {

                 if (txtSearchName.Text == "")
                 {
                     ShowGVtableSarbaz();
                 }
                 else
                 {


                     ShowGVtableSarbaz();
                 }
             }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchFatherName_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtSearchName.Text == "")
                {
                    ShowGVtableSarbaz();
                }
                else
                {
                    ShowGVtableSarbaz();

                }

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void txtSearchID_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtSearchName.Text == "")
                {
                    ShowGVtableSarbaz();
                }
                else
                {


                    ShowGVtableSarbaz();
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void checkBox_ActiveCboxHozeh_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ShowGVtableSarbaz();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void cboxNavahi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                ShowGVtableSarbaz();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }


        
        private void btnAdd_S_Click(object sender, EventArgs e)
        {
            var db = new LinqDataContext();

            var addSarbaz = new FrmApply_S();
            var query = from p in db.sarbazs
                        select new { c1 = p.Id_Sarbaz };
            addSarbaz.txtIDSarbaz.Text = (Convert.ToString(query.Max(p => p.c1 + 1)));


            addSarbaz.ShowDialog();
            Refresh_Commponent(null, null);
        }

        private void btnEdite_Click(object sender, EventArgs e)
        {
          
            var FrmEdit_SarbazObj = new FrmEdit_S();

            FrmEdit_SarbazObj.txtIDSarbaz.Text = Convert.ToString(GVTable.CurrentRow.Cells["شماره_پرونده"].Value);



            FrmEdit_SarbazObj.ShowDialog();
            Refresh_Commponent(null, null);

        }

      

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (GVTable.RowCount == 0) return;
                if (MessageBox.Show("                    آیا می خواهید حذف کنید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                     

                    if (GVTable.RowCount > 1)
                    {
                       // var ss = GVTable.CurrentRow.Cells[0].Value);
                        var db = new LinqDataContext();
                        
                        var query = (from p in db.sarbazs
                                     where p.Id_Sarbaz == Convert.ToInt32( GVTable.CurrentRow.Cells["شماره_پرونده"].Value)

                                     select p).Single();

                        db.sarbazs.DeleteOnSubmit(query);
                        db.SubmitChanges();

                    }
                    Refresh_Commponent(null, null);

                }

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

       

        private void btn_InsertSarbaz_Click(object sender, EventArgs e)
        {
            try
            { 
            
                var LinqObj = new LinqDataContext();
                
                var query_Jazb = from temp_Jazb in LinqObj.Mashmoolins
                                 where temp_Jazb.جذب == true
                                 && temp_Jazb.تاریخ_اعزام.Contains(Convert.ToString(cbox_M_InsertTo_S_EzamDate.SelectedValue))
                                 select temp_Jazb ;

                

                var FrmApply_s_Obj = new FrmApply_S();
            foreach (var query_Items in query_Jazb)
            {
                    var query_max = from temp in LinqObj.Mashmoolins
                                select temp;
                    var x = query_max.Max(temp => temp.Id_Mashmoolin);
                    FrmApply_s_Obj.txtIDSarbaz.Text = Convert.ToString(x+1);
                     
                FrmApply_s_Obj.txtID.Text = query_Items.شماره_ملی;
                FrmApply_s_Obj.txtName.Text = query_Items.نام;
                FrmApply_s_Obj.txtLastName.Text =query_Items.نام_خانوادگی;
                FrmApply_s_Obj.txtFatherName.Text =query_Items.نام_پدر;


                    FrmApply_s_Obj.txt_BirthYear.Text = query_Items.تاریخ_تولد;
                    FrmApply_s_Obj. txt_mobile.Text= query_Items.تلفن ;
                    FrmApply_s_Obj. comboBox_Grade.Text= query_Items.تحصیلات;
                     FrmApply_s_Obj.comboBox_Grade.SelectedValue= query_Items.کد_تحصیلات ;
                    FrmApply_s_Obj.txt_Reshteh.Text= query_Items.رشته ;
                    FrmApply_s_Obj.txt_Address.Text = query_Items.آدرس;

                    FrmApply_s_Obj. txt_Moaref.Text = query_Items.معرف;
                     FrmApply_s_Obj. txt_Basij.Text= query_Items.سابقه_بسیج_فعال ;
                     FrmApply_s_Obj.txt_Hozeh.Text = query_Items.حوزه_جذب;

                    FrmApply_s_Obj.chBox_Taahol.Checked = Convert.ToBoolean(query_Items.تاهل);
                     FrmApply_s_Obj. chBox_Takmili.Checked=Convert.ToBoolean( query_Items.تکمیلی );
                    FrmApply_s_Obj. chBox_ThirthDay.Checked= Convert.ToBoolean(query_Items.سی_روزه );
                     FrmApply_s_Obj.chBox_Moaf.Checked= Convert.ToBoolean(query_Items.معاف_از_رزم );
                    FrmApply_s_Obj. chBox_Komiteh.Checked= Convert.ToBoolean(query_Items.کمیته_امداد) ;
                    FrmApply_s_Obj.chBox_Behzisti.Checked= Convert.ToBoolean(query_Items.سازمان_بهزیستی );
                   
                    FrmApply_s_Obj. txt_Explain.Text= query_Items.توضیحات ;

                    FrmApply_s_Obj. txt_EzamDate.Text= query_Items.تاریخ_اعزام ;
                FrmApply_s_Obj.txt_JazbDate.Text = PersianDate.GetPersianDate();



                    var bank = new LinqDataContext();
                    var query1 = (from p in bank.Gradetbls
                                  orderby p.Id_Grade
                                  select new { p.Id_Grade, p.Grade }).Distinct();

                    FrmApply_s_Obj.comboBox_Grade.DataSource = query1;
                    FrmApply_s_Obj.comboBox_Grade.DisplayMember = "Grade";
                    FrmApply_s_Obj.comboBox_Grade.ValueMember = "Id_Grade";
                    FrmApply_s_Obj.comboBox_Grade.Text = query_Items.تحصیلات;
                   



                   
                    var query2 = (from p in bank.Darajes
                                  orderby p.ID
                                  select new { p.ID, p.NameDaraje }).Distinct();

                    FrmApply_s_Obj.comboBox_Darajeh.DataSource = query2;
                    FrmApply_s_Obj.comboBox_Darajeh.DisplayMember = "NameDaraje";
                    FrmApply_s_Obj.comboBox_Darajeh.ValueMember = "ID";

                   

                    
                    FrmApply_s_Obj.txt_Ezaf.Text = Convert.ToString(query_Items.اضاف);
                    
                    FrmApply_s_Obj.ShowDialog();
                  
            }

            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// /////////////////////////////////////// امور سرباز  ////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        /// 
        /// 
       

        private void pictureBox_SJ_Referesh_Click(object sender, EventArgs e)
        {
            toolStripLabel_SJ.Text = "در حال ثبت استحقاقی";
           
           Compute.Estehghaghi();
            toolStripLabel_SJ.Text = "در حال ثبت تاریخ ترخیص";
            Compute.FreeDate();
            toolStripLabel_SJ.Text = "در حال ثبت تاریخ اتمام ماموریت";
              Compute.EndMissionDate();
            toolStripLabel_SJ.Text = "";

            var bank = new LinqDataContext();

            
            
            var query_NotYetRaked = from p in bank.sarbazs
                         where  p.تاریخ_ترخیص.CompareTo(PersianDate.GetPersianDate())<=0
                                 select new {شماره_پرونده=p.Id_Sarbaz, p.نام,p.نام_خانوادگی,p.شماره_ملی,p.تاریخ_ترخیص} ;
            label_SJ_SumSarbazFreeDate.Text = Convert.ToString(query_NotYetRaked.Count());
            GV_SJ_NotYetRaked.DataSource = query_NotYetRaked;


            var query_EndMission = from p in bank.sarbazs
                                    where p.تاریخ_اتمام_ماموریت.CompareTo(PersianDate.GetPersianDate()) <= 0
                                   where p.مامور==true
                                    select new { شماره_پرونده = p.Id_Sarbaz, p.نام, p.نام_خانوادگی, p.شماره_ملی,p.تاریخ_اتمام_ماموریت };
            label_SJ_SumSarbazEndMission.Text = Convert.ToString(query_EndMission.Count());
            GV_SJ_EndMission.DataSource = query_EndMission;


        }

        private void btn_SJ_ChangeToRaked_Click(object sender, EventArgs e)
        {
            if (GVTable.RowCount == 0) return;

            if (MessageBox.Show("                    آیا می خواهید راکد کنید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {


                if (GV_SJ_NotYetRaked.RowCount > 1)
                {
                    // var ss = GVTable.CurrentRow.Cells[0].Value);
                    var db = new LinqDataContext();
                    var rakedinObj = new Rakedin_Main_Table();

                    var query = (from p in db.sarbazs
                                 where p.Id_Sarbaz == Convert.ToInt32(GVTable.CurrentRow.Cells["شماره_پرونده"].Value)

                                 select p).Single();

                    ///////  transmit to  Rakedin table

                    rakedinObj.نام = query.نام;
                    rakedinObj.نام_خانوادگی = query.نام_خانوادگی;
                    rakedinObj.نام_پدر = query.نام_پدر;
                    rakedinObj.شماره_ملی = query.شماره_ملی;
                  
                     rakedinObj.آدرس = query.آدرس;

                    //rakedinObj. = txt_mobile.Text;
                    rakedinObj.مدرک_پایان =query.تحصیلات;

                    //rakedinObj.کد_تحصیلات = Convert.ToInt32(comboBox_Grade.SelectedValue);
                    rakedinObj.رشته_پایان =query.رشته;

                    //rakedinObj.معرف = txt_Moaref.Text;
                    //rakedinObj.سابقه_بسیج_فعال = txt_Basij.Text;
                    //// S.حوزه_جذب = txt_HozehJazb.Text;
                  
                    //rakedinObj.تکمیلی = chBox_Takmili.Checked;
                    //rakedinObj.سی_روزه = chBox_ThirthDay.Checked;
                    //rakedinObj.معاف_از_رزم = chBox_Moaf.Checked;
                    //rakedinObj.کمیته_امداد = chBox_Komiteh.Checked;
                    //rakedinObj.سازمان_بهزیستی = chBox_Behzisti.Checked;
                    //rakedinObj.بومی = chBox_Boomi.Checked;
                    //rakedinObj.فرمانده_دسته = chBox_FarmandeD.Checked;
                    //rakedinObj.فراری = chBox_Farari.Checked;
                    //rakedinObj.کمیسیون = chBox_Komision.Checked;



                    //rakedinObj.توضیحات = txt_Explain.Text;

                    rakedinObj.تاریخ_اعزام_دفترچه = query.تاریخ_اعزام;
                    //rakedinObj.حوزه_خدمت = txt_Hozeh.Text;
                   
                    rakedinObj.درجه = query.درجه;

                    rakedinObj.کسری_روز_ = Convert.ToInt32(query.مدت_كسر_خدمت_به_روز);

                    rakedinObj.تاریخ_ترخیص = query.تاریخ_ترخیص;


                    db.Rakedin_Main_Tables.InsertOnSubmit(rakedinObj);

                    db.sarbazs.DeleteOnSubmit(query);

                    db.SubmitChanges();

                }
                Refresh_Commponent(null, null);

            }
        }

        private void btn_SJ_EndMision_ApplyHozeh_Click(object sender, EventArgs e)
        {
            if (GVTable.RowCount == 0) return;

            var Id_sarbaz=Convert.ToInt32( GV_SJ_EndMission.CurrentRow.Cells["شماره_پرونده"].Value);

            var bank = new LinqDataContext();
            var query =( from p in bank.sarbazs
                        where p.Id_Sarbaz == Id_sarbaz
                        select p).Single();

            query.حوزه_خدمت = txt_SJ_HozehKhedmat.Text;
            query.مامور = false;
            ////////////////  referesh GV  &  تعداد سربازان تقسیم نشده
            var query_EndMission = from p in bank.sarbazs
                                   where p.تاریخ_اتمام_ماموریت.CompareTo(PersianDate.GetPersianDate()) <= 0
                                   where p.مامور == true
                                   select new { شماره_پرونده = p.Id_Sarbaz, p.نام, p.نام_خانوادگی, p.شماره_ملی, p.تاریخ_اتمام_ماموریت };
            label_SJ_SumSarbazEndMission.Text = Convert.ToString(query_EndMission.Count());
            GV_SJ_EndMission.DataSource = query_EndMission;

        }

        //////////////////////////////     راکدین      /////////////////////////////////

        private void tabPage_Rakedin_Click(object sender, EventArgs e)
        {
            try
            {
                ShowGVtableRaked();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }


        private void txtSearchID_Rakedin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ShowGVtableRaked();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
               
            }
        }

        private void txtSearchID_Rakedin_TextChanged_1(object sender, EventArgs e)
        {

            try
            {
                ShowGVtableRaked();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
        }


        private void txtSearchName_Rakedin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ShowGVtableRaked();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchLastName_Rakedin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ShowGVtableRaked();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void txtSearchFatherName_Rakedin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ShowGVtableRaked();
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// ///////////////////////// Print /////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cbox_R_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] installs1 = new string[] { "مشمولین_جاری", "اولویت_جاری", "سرباز_جاری" };

            string[] installs2 = new string[] {"متاهلین","معاف از رزم","بومی","فرمانده دسته","فراری","کمیسیون","فوق لیسانس","لیسانس","فوق دیپلم","دیپلم","زیر دیپلم"};

            string[] installs3 = new string[] { "معرفی نامه"};

            string[] installs4 = new string[] { };

            cbox_R_Items.Text = "";

            if (Convert.ToString(cbox_R_Type.SelectedItem) == "جداول") { cbox_R_Items.Items.Clear(); cbox_R_Items.Items.AddRange(installs1); }
           // else if (cbox_R_Type.SelectedItem) == "مشمول") { cbox_R_Items.Items.Clear(); cbox_R_Items.Items.AddRange(installs2); }
            else if (Convert.ToString(cbox_R_Type.SelectedItem) == "سرباز") { cbox_R_Items.Items.Clear(); cbox_R_Items.Items.AddRange(installs2); }
          //  else if (Convert.ToString(cbox_R_Type.SelectedItem) == "مکاتبات") { cbox_R_Items.Items.Clear(); cbox_R_Items.Items.AddRange(installs3); }
            else { return; }
        }



        private void btn_R_Design_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(cbox_R_Items.SelectedItem) == "مشمولین_جاری")
            {
                var reportObj = new Report();

                reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Linq_mashmoolin.frx");
                reportObj.Preview = previewControl_R;
                reportObj.Design();
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            try {

                //////////////////////////////////////////////////////////////
                if (Convert.ToString(cbox_R_Items.SelectedItem) == "مشمولین_جاری")
                {
                    if (chBox_EzamDate.Checked)
                    {
                        var bank = new LinqDataContext();

                        var query = from p in bank.Mashmoolins
                                    where p.نام.Contains(txtSearchName_M.Text)
                                    && p.نام_خانوادگی.Contains(txtSearchLastName_M.Text)
                                    && p.نام_پدر.Contains(txtSearchFatherName_M.Text)
                                     && p.شماره_ملی.Contains(txtSearchID_M.Text)
                                     && p.تاریخ_اعزام.Contains(Convert.ToString(cbox_M_EzamDate.SelectedValue))
                                    select p;

                        var reportObj = new Report();

                        reportObj.RegisterData(query.ToList(), "MyQuery");
                        reportObj.GetDataSource("MyQuery").Enabled = true;
                        reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Linq_mashmoolin.frx");
                        reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                        reportObj.SetParameterValue("sum", query.Count());
                        reportObj.Preview = previewControl_R;
                        reportObj.Show();

                    }
                    else
                    {
                        var bank = new LinqDataContext();

                        var query = from p in bank.Mashmoolins
                                    where p.نام.Contains(txtSearchName_M.Text)
                                    && p.نام_خانوادگی.Contains(txtSearchLastName_M.Text)
                                    && p.نام_پدر.Contains(txtSearchFatherName_M.Text)
                                     && p.شماره_ملی.Contains(txtSearchID_M.Text)
                                    //   && p.تاریخ_اعزام.Contains(Convert.ToString(cbox_M_EzamDate.SelectedValue))
                                    select p;

                        var reportObj = new Report();

                        reportObj.RegisterData(query.ToList(), "MyQuery");
                        reportObj.GetDataSource("MyQuery").Enabled = true;
                        reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Linq_mashmoolin.frx");
                        reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                        reportObj.SetParameterValue("sum", query.Count());
                        reportObj.Preview = previewControl_R;
                        reportObj.Show();

                    }


                }

                else if (Convert.ToString(cbox_R_Items.SelectedItem) == "اولویت_جاری")
                {
                    var bank = new LinqDataContext();
                    var query = from p in bank.Mashmoolins
                                where p.نام.Contains(txtSearchName_P.Text)
                                && p.نام_خانوادگی.Contains(txtSearchLastName_P.Text)
                                && p.نام_پدر.Contains(txtSearchFatherName_P.Text)
                                 && p.شماره_ملی.Contains(txtSearchID_P.Text)
                                 && p.جذب == false
                                 && p.تاریخ_اعزام.Contains(Convert.ToString(cbox_P_EzamDate.SelectedValue))

                                orderby p.اولویت descending

                                select p;

                    var reportObj = new Report();

                    reportObj.RegisterData(query.ToList(), "MyQuery");
                    reportObj.GetDataSource("MyQuery").Enabled = true;
                    reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Linq_priority.frx");
                    reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                    reportObj.SetParameterValue("sum", query.Count());
                    reportObj.Preview = previewControl_R;
                    reportObj.Show();



                }
                else if (Convert.ToString(cbox_R_Items.SelectedItem) == "سرباز_جاری")
                {
                    if (this.checkBox_ActiveCboxHozeh.Checked)
                    {
                        var bank = new LinqDataContext();
                        var query = from p in bank.sarbazs
                                    where p.نام.Contains(txtSearchName.Text)
                                    && p.نام_خانوادگی.Contains(txtSearchLastName.Text)
                                    && p.نام_پدر.Contains(txtSearchFatherName.Text)
                                     && p.شماره_ملی.Contains(txtSearchID.Text)
                                     && p.حوزه_خدمت.Contains(Convert.ToString(cboxNavahi.SelectedValue))
                                    select p;

                        var reportObj = new Report();
                        reportObj.RegisterData(query.ToList(), "MyQuery");
                        reportObj.GetDataSource("MyQuery").Enabled = true;
                        reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Linq_sarbaz.frx");
                        reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                        reportObj.SetParameterValue("sum", query.Count());
                        reportObj.Preview = previewControl_R;
                        reportObj.Show();

                    }
                    else
                    {
                        var bank = new LinqDataContext();
                        var query = from p in bank.sarbazs
                                    where p.نام.Contains(txtSearchName.Text)
                                    && p.نام_خانوادگی.Contains(txtSearchLastName.Text)
                                    && p.نام_پدر.Contains(txtSearchFatherName.Text)
                                     && p.شماره_ملی.Contains(txtSearchID.Text)
                                    //  && p.KhedmatHozeh.Contains(Convert.ToString(cboxNavahi.SelectedValue))
                                    select p;

                        var reportObj = new Report();
                        reportObj.RegisterData(query.ToList(), "MyQuery");
                        reportObj.GetDataSource("MyQuery").Enabled = true;
                        reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Linq_sarbaz.frx");
                        reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                        reportObj.SetParameterValue("sum", query.Count());
                        reportObj.Preview = previewControl_R;
                        reportObj.Show();


                    }

                }



                else if (Convert.ToString(cbox_R_Items.SelectedItem) == "متاهلین")
                {
                    var reportObj = new Report();
                    var bank = new LinqDataContext();
                    var query = from p in bank.sarbazs
                                where p.تاهل == true
                                select p;
                    reportObj.RegisterData(query.ToList(), "MyQuery");
                    reportObj.GetDataSource("MyQuery").Enabled = true;


                    reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Motaahelin.frx");
                    reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                    reportObj.SetParameterValue("sum", query.Count());
                    reportObj.Preview = previewControl_R;
                    reportObj.Show();
                }
                else if (Convert.ToString(cbox_R_Items.SelectedItem) == "معاف از رزم")
                {
                    var reportObj = new Report();
                    var bank = new LinqDataContext();
                    var query = from p in bank.sarbazs
                                where p.معاف_از_رزم == true
                                select p;
                    reportObj.RegisterData(query.ToList(), "MyQuery");
                    reportObj.GetDataSource("MyQuery").Enabled = true;
                    reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Moaf.frx");
                    reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                    reportObj.SetParameterValue("sum", query.Count());
                    reportObj.Preview = previewControl_R;
                    reportObj.Show();
                }

                else if (Convert.ToString(cbox_R_Items.SelectedItem) == "بومی")
                {
                    var reportObj = new Report();
                    var bank = new LinqDataContext();
                    var query = from p in bank.sarbazs
                                where p.بومی == true
                                select p;
                    reportObj.RegisterData(query.ToList(), "MyQuery");
                    reportObj.GetDataSource("MyQuery").Enabled = true;
                    reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Boomi.frx");
                    reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                    reportObj.SetParameterValue("sum", query.Count());
                    reportObj.Preview = previewControl_R;
                    reportObj.Show();
                }
                else if (Convert.ToString(cbox_R_Items.SelectedItem) == "فرمانده دسته")
                {
                    var reportObj = new Report();
                    var bank = new LinqDataContext();
                    var query = from p in bank.sarbazs
                                where p.فرمانده_دسته == true
                                select p;
                    reportObj.RegisterData(query.ToList(), "MyQuery");
                    reportObj.GetDataSource("MyQuery").Enabled = true;
                    reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\FarmandeD.frx");
                    reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                    reportObj.SetParameterValue("sum", query.Count());
                    reportObj.Preview = previewControl_R;
                    reportObj.Show();
                }
                else if (Convert.ToString(cbox_R_Items.SelectedItem) == "فراری")
                {
                    var reportObj = new Report();
                    var bank = new LinqDataContext();
                    var query = from p in bank.sarbazs
                                where p.فراری == true
                                select p;
                    reportObj.RegisterData(query.ToList(), "MyQuery");
                    reportObj.GetDataSource("MyQuery").Enabled = true;
                    reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Farari.frx");
                    reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                    reportObj.SetParameterValue("sum", query.Count());
                    reportObj.Preview = previewControl_R;
                    reportObj.Show();
                }
                else if (Convert.ToString(cbox_R_Items.SelectedItem) == "کمیسیون")
                {
                    var reportObj = new Report();
                    var bank = new LinqDataContext();
                    var query = from p in bank.sarbazs
                                where p.کمیسیون == true
                                select p;
                    reportObj.RegisterData(query.ToList(), "MyQuery");
                    reportObj.GetDataSource("MyQuery").Enabled = true;
                    reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Komision.frx");
                    reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                    reportObj.SetParameterValue("sum", query.Count());
                    reportObj.Preview = previewControl_R;
                    reportObj.Show();
                }
                else if (Convert.ToString(cbox_R_Items.SelectedItem) == "فوق لیسانس")
                {
                    var reportObj = new Report();
                    var bank = new LinqDataContext();
                    var query = from p in bank.sarbazs
                                where p.تحصیلات == "فوق لیسانس"
                                select p;
                    reportObj.RegisterData(query.ToList(), "MyQuery");
                    reportObj.GetDataSource("MyQuery").Enabled = true;
                    reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Grade_FL.frx");
                    reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                    reportObj.SetParameterValue("sum", query.Count());
                    reportObj.Preview = previewControl_R;
                    reportObj.Show();
                }
                else if (Convert.ToString(cbox_R_Items.SelectedItem) == "لیسانس")
                {
                    var reportObj = new Report();
                    var bank = new LinqDataContext();
                    var query = from p in bank.sarbazs
                                where p.تحصیلات == "لیسانس"
                                select p;
                    reportObj.RegisterData(query.ToList(), "MyQuery");
                    reportObj.GetDataSource("MyQuery").Enabled = true;
                    reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Grade_L.frx");
                    reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                    reportObj.SetParameterValue("sum", query.Count());
                    reportObj.Preview = previewControl_R;
                    reportObj.Show();
                }
                else if (Convert.ToString(cbox_R_Items.SelectedItem) == "فوق دیپلم")
                {
                    var reportObj = new Report();
                    var bank = new LinqDataContext();
                    var query = from p in bank.sarbazs
                                where p.تحصیلات == "فوق دیپلم"
                                select p;
                    reportObj.RegisterData(query.ToList(), "MyQuery");
                    reportObj.GetDataSource("MyQuery").Enabled = true;
                    reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Grade_FD.frx");
                    reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                    reportObj.SetParameterValue("sum", query.Count());
                    reportObj.Preview = previewControl_R;
                    reportObj.Show();
                }
                else if (Convert.ToString(cbox_R_Items.SelectedItem) == "دیپلم")
                {
                    var reportObj = new Report();
                    var bank = new LinqDataContext();
                    var query = from p in bank.sarbazs
                                where p.تحصیلات == "دیپلم"
                                select p;
                    var c = query.Count();
                    reportObj.RegisterData(query.ToList(), "MyQuery");
                    reportObj.GetDataSource("MyQuery").Enabled = true;
                    reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Grade_D.frx");
                    reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                    reportObj.SetParameterValue("sum", query.Count());
                    reportObj.Preview = previewControl_R;
                    reportObj.Show();
                }


                else if (Convert.ToString(cbox_R_Items.SelectedItem) == "زیر دیپلم")
                {
                    var reportObj = new Report();
                    var bank = new LinqDataContext();
                    var query = from p in bank.sarbazs
                                where p.تحصیلات == "زیر دیپلم"
                                select p;
                    reportObj.RegisterData(query.ToList(), "MyQuery");
                    reportObj.GetDataSource("MyQuery").Enabled = true;
                    reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\Grade_ZD.frx");
                    reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                    reportObj.SetParameterValue("sum", query.Count());
                    reportObj.Preview = previewControl_R;
                    reportObj.Show();
                }
                else if (Convert.ToString(cbox_R_Items.SelectedItem) == "معرفی نامه")
                {
                    var reportObj = new Report();

                    var bank = new LinqDataContext();
                    var query = from p in bank.sarbazs
                                select p;
                    reportObj.RegisterData(query.ToList(), "MyQuery");
                    reportObj.GetDataSource("MyQuery").Enabled = true;

                    reportObj.Load(System.IO.Directory.GetCurrentDirectory() + @"\reports\1GovahiRaked.frx");
                    reportObj.SetParameterValue("date", PersianDate.GetPersianDate());

                    reportObj.Preview = previewControl_R;
                    reportObj.Show();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void btn_R_Mokatebat_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            try
            {
                if (result == DialogResult.OK)
                {
                    var reportObj = new Report();
                    //  string[] files = Directory.GetDirectories(folderBrowserDialog1.SelectedPath);
                    // string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);

                    //  listBox2.DataSource = files;


                    //var bank = new LinqDataContext();
                    //var query = from p in bank.sarbazs
                    //            where p.Id_Sarbaz== Convert.ToInt32( GVTable.CurrentRow.Cells["شماره_پرونده"].Value)
                    //            select p;
                    //reportObj.RegisterData(query.ToList(), "MyQuery");
                    //reportObj.GetDataSource("MyQuery").Enabled = true;

                    reportObj.Load(openFileDialog1.FileName);
                    reportObj.SetParameterValue("date", PersianDate.GetPersianDate());
                    reportObj.SetParameterValue("ID", GVTable.CurrentRow.Cells["شماره_پرونده"].Value);
                    reportObj.Preview = previewControl_R;
                    reportObj.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// ///////////////////////////////////  tab   پشتیبان گیری   /////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        string DbName = string.Empty;
        string DestPath = string.Empty;
        string SourcePath = string.Empty;

        DataSet dsDatabse = new DataSet();


        private void btn_B_ConnectToServer_Click(object sender, EventArgs e)
        {
            var Frm_LoginDBObj = new Frm_Login_DB();


            Frm_LoginDBObj.ShowDialog();

            ///////////////// extract data to List ////////////
            try
            {
                dsDatabse = Frm_Login_DB.ds;
              
                foreach (DataRow row in dsDatabse.Tables[0].Rows)
                {
                    ListViewItem item = new ListViewItem(Convert.ToString(row[0]));
                    for (int i = 1; i < dsDatabse.Tables[0].Columns.Count; i++)
                    {
                        item.SubItems.Add(Convert.ToString(row[i]));
                    }
                    //listBox1.Items.Add(item);
                    listBox1.Items.Add(item.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            /////////////////////////////////////////////
        }
        
        private void btn_B_BackupSaveLocation_Click(object sender, EventArgs e)
        {

            DialogResult result = folderBrowserDialog1.ShowDialog();
            try
            {
                if (result == DialogResult.OK)
                {
                  //  string[] files = Directory.GetDirectories(folderBrowserDialog1.SelectedPath);
                    // string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                    listBox2.Items.Add(folderBrowserDialog1.SelectedPath);
                  //  listBox2.DataSource = files;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DbName = listBox1.GetItemText(listBox1.SelectedItem);
            //MessageBox.Show(text);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DestPath = listBox2.GetItemText(listBox2.SelectedItem);
            //MessageBox.Show(text);
        }
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SourcePath = listBox3.GetItemText(listBox3.SelectedItem);
        }


        private void btn_B_BackupDB_Click(object sender, EventArgs e)
        {
            try {

                if (DestPath == "" || DbName == "")
                {
                    MessageBox.Show("برای انتخاب پایگاه داده و پوشه مقصد تلاش کنید");
                }
                else
                {
                    toolStripLabel_B.Text = "شروع پشتیبان گیری";
                    string databaseName = DbName;//dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue);

                    //Define a Backup object variable.
                    Backup sqlBackup = new Backup();

                    ////Specify the type of backup, the description, the name, and the database to be backed up.
                    sqlBackup.Action = BackupActionType.Database;
                    sqlBackup.BackupSetDescription = "BackUp of:" + databaseName + "on" + DateTime.Now.ToShortDateString();
                    sqlBackup.BackupSetName = "FullBackUp";
                    sqlBackup.Database = databaseName;

                    ////Declare a BackupDeviceItem
                    string destinationPath = DestPath;
                    string backupfileName = DbName + PersianDate.GetPersianDate() + ".bak";
                    BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath + "\\" + backupfileName, DeviceType.File);
                    ////Define Server connection
                   
                    //ServerConnection connection = new ServerConnection(frm.serverName, frm.userName, frm.password);   /////////   تغییر داده شده
                    ServerConnection connection = new ServerConnection(@"SARBAZ-PC\SQL_SERVER2014");
                    ////    --->  SARBAZ-PC\SQL_SERVER2014
                    ////To Avoid TimeOut Exception
                    connection.LoginSecure = true;
                    Server sqlServer = new Server(connection);
                    sqlServer.ConnectionContext.StatementTimeout = 60 * 60;
                    Microsoft.SqlServer.Management.Smo.Database db = sqlServer.Databases[databaseName];

                   
                    sqlBackup.Initialize = true;
                    sqlBackup.Checksum = true;
                    sqlBackup.ContinueAfterError = true;

                    ////Add the device to the Backup object.
                    sqlBackup.Devices.Add(deviceItem);
                    ////Set the Incremental property to False to specify that this is a full database backup.
                    sqlBackup.Incremental = false;

                    sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
                    ////Specify that the log must be truncated after the backup is complete.
                    sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

                    sqlBackup.FormatMedia = false;
                    ////Run SqlBackup to perform the full database backup on the instance of SQL Server.
                    sqlBackup.SqlBackup(sqlServer);
                    ////Remove the backup device from the Backup object.
                    sqlBackup.Devices.Remove(deviceItem);
                    toolStripLabel_B.Text = "";
                    toolStripLabel_B.Text = "نسخه پشتیبان با موفقیت انجام شد";
                }
            }
            catch (SmoException ex)
            {
                toolStripLabel_B.Text = "";
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                toolStripLabel_B.Text = "";
                MessageBox.Show(ex.Message);
            }


            catch (Exception ex)
            {
                toolStripLabel_B.Text = "";
                MessageBox.Show(ex.Message);
            } 
           
        }

        private void btn_B_FileRecoveryLocation_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                listBox3.Items.Add(openFileDialog1.FileName);
            }

        }
        private void btn_B_UpdateDB_Click(object sender, EventArgs e)
        {
            var connection = new ServerConnection();
            connection.ServerInstance = @"SARBAZ-PC\SQL_SERVER2014";
           
            var srv = new Server(connection);


            try
            {

                if (SourcePath == "" || DbName == "")
                {
                    MessageBox.Show("برای انتخاب پایگاه داده و پوشه مقصد تلاش کنید");
                }
                else
                {
                    //Restore res = new Restore();

                    //res.Devices.AddDevice(SourcePath, DeviceType.File);

                    //RelocateFile DataFile = new RelocateFile();
                    //string MDF = res.ReadFileList(srv).Rows[0][1].ToString();
                    //DataFile.LogicalFileName = res.ReadFileList(srv).Rows[0][0].ToString();
                    //DataFile.PhysicalFileName = srv.Databases[DbName].FileGroups[0].Files[0].FileName;

                    //RelocateFile LogFile = new RelocateFile();
                    //string LDF = res.ReadFileList(srv).Rows[1][1].ToString();
                    //LogFile.LogicalFileName = res.ReadFileList(srv).Rows[1][0].ToString();
                    //LogFile.PhysicalFileName = srv.Databases[DbName].LogFiles[0].FileName;

                    //res.RelocateFiles.Add(DataFile);
                    //res.RelocateFiles.Add(LogFile);

                    toolStripLabel_B.Text="شروع بازیابی";
                    Restore restore = new Restore();
                    //Set type of backup to be performed to database
                    restore.Database = DbName;
                    restore.Action = RestoreActionType.Database;
                    //Set up the backup device to use filesystem.         
                    restore.Devices.AddDevice(SourcePath, DeviceType.File);
                    //set ReplaceDatabase = true to create new database
                    //regardless of the existence of specified database
                    restore.ReplaceDatabase = true;
                    //If you have a differential or log restore to be followed,
                    //you would specify NoRecovery = true
                    restore.NoRecovery = false;
                    //if you want to restore to a different location, specify
                    //the logical and physical file names
                    //restore.RelocateFiles.Add(new RelocateFile("sarbaz_DB", @"C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\sarbaz_DB.mdf"));
                    //restore.RelocateFiles.Add(new RelocateFile("sarbaz_DB_Log", @"C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\sarbaz_DB.ldf"));
                    //my SQL user doesnt have sufficient permissions,
                    //so i am using my windows account
                    connection.LoginSecure = true;
                    //connection.LoginSecure = false;
                    //connection.Login = "testuser";
                    //connection.Password = "testuser";
                    restore.Database = DbName;
                    //SqlRestore method starts to restore database       
                    restore.SqlRestore(srv);
                    connection.Disconnect();
                    toolStripLabel_B.Text = "";
                    MessageBox.Show("بازیابی با موفقیت انجام شد");
                }
            }
            catch (SmoException ex)
            {
                toolStripLabel_B.Text = "";
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                toolStripLabel_B.Text = "";
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                toolStripLabel_B.Text = "";
                MessageBox.Show(ex.Message);
            }

            //try
            //{
            //    ServerConnection connection = new ServerConnection(@".");
            //    ////    --->  SARBAZ-PC\SQL_SERVER2014
            //    Server sqlServer = new Server(connection);
            //    Restore rstDatabase = new Restore();
            //    rstDatabase.Action = RestoreActionType.Database;
            //    rstDatabase.Database = DbName;
            //    BackupDeviceItem bkpDevice = new BackupDeviceItem(DbName, DeviceType.File);
            //    rstDatabase.Devices.Add(bkpDevice);
            //    rstDatabase.ReplaceDatabase = true;
            //    rstDatabase.SqlRestore(sqlServer);

            //}



        }

       
    }
}
