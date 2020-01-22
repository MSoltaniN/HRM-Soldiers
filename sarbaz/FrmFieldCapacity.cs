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
    public partial class FrmFieldCapacity : Form
    {
        public FrmFieldCapacity()
        {
            InitializeComponent();
        }


        private void FrmFieldCapacity_Load(object sender, EventArgs e)
        {
            try
            {

                var bank = new LinqDataContext();
                var query = from temp in bank.Grade_Reshtehs
                            join tempjoin in bank.Reshtehas on temp.Id_CodeReshteh equals tempjoin.Id
                            join tempjoin2 in bank.Gradetbls on temp.Id_Grade equals tempjoin2.Id_Grade
                            select new { temp.Id_Grade_Reshteh, tempjoin2.Grade, tempjoin.Reshteh, tempjoin.CodeReshteh, temp.Capacity };

                GVFeildCapacity.DataSource = query;


                var query2 = from temp1 in bank.Gradetbls
                             orderby temp1.Id_Grade
                             select temp1.Grade;

                cboxGrade.DataSource = query2;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                var LinqObj = new LinqDataContext();
                var GradeReshtehObj = new Grade_Reshteh();

                var c = LinqObj.Grade_Reshtehs.Count();
                if (GVFeildCapacity.RowCount >= 1)
                {

                    for (int i = 1; i <= c; i++)
                    {

                        if(GVFeildCapacity.Rows[i].Cells[4].Value.ToString()=="")

                        GradeReshtehObj.Capacity = int.Parse(GVFeildCapacity.Rows[i].Cells[4].Value.ToString());

                        LinqObj.Grade_Reshtehs.InsertOnSubmit(GradeReshtehObj);


                    }
                    LinqObj.SubmitChanges();

                    /////////////////  referesh GVtable  /////////////
                    var bank = new LinqDataContext();
                    var query = from temp in bank.Grade_Reshtehs
                                join tempjoin in bank.Reshtehas on temp.Id_CodeReshteh equals tempjoin.Id
                                join tempjoin2 in bank.Gradetbls on temp.Id_Grade equals tempjoin2.Id_Grade
                                select new { temp.Id_Grade_Reshteh, tempjoin2.Grade, tempjoin.Reshteh, tempjoin.CodeReshteh, temp.Capacity };

                    GVFeildCapacity.DataSource = query;

                    //////////////////////////////////////////////////
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
