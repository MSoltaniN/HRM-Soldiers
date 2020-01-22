using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace sarbaz
{
   

    class Compute
    {
      
        
     
        public static  void Estehghaghi()
        {
            var bank = new LinqDataContext();

            var query = from p in bank.sarbazs
                       // where p.Id_Sarbaz==Id_sarbaz
                        select p;
            foreach (var items in query)
            {
                var x = items.مدت_كسر_خدمت_به_روز;
                var y = items.خدمت_قبلی_روز;
                var z = items.مدت_اضافه_خدمت_روز;
                if (x == "" || x == null) x = "0";
                if (y == "" || y == null) y = "0";
                if (z == "" || z == null) z = "0";
                int Day_variable = -Convert.ToInt32(x)
                                                   - Convert.ToInt32(y)
                                                   + Convert.ToInt32(z);

                double Mounth_Variable = Convert.ToInt32(Day_variable / 30);

                var Khedmat_Mounth = 21 + Mounth_Variable;

                int E;
                if (items.تاهل == true)
                 E=   Convert.ToInt32(Khedmat_Mounth * 2.5);
                else  E = Convert.ToInt32(Khedmat_Mounth * 1);

                items.استحقاقی =Convert.ToString( E);
            }
            bank.SubmitChanges();
          //  return E;
        }

        public static void FreeDate()
        {

            var bank = new LinqDataContext();

            var query = from p in bank.sarbazs
                      //   where p.Id_Sarbaz == Id_sarbaz
                         select p;
            foreach (var items in query)
            {
                var x = items.مدت_كسر_خدمت_به_روز;
                var y = items.خدمت_قبلی_روز;
                var z = items.مدت_اضافه_خدمت_روز;
                if (x== "" || x == null)x = "0";
                if (y== "" || y == null)y = "0";
                if (z== "" ||z== null)z= "0";
                int Day_variable = -Convert.ToInt32(x) 
                                                   - Convert.ToInt32(y)
                                                   +Convert.ToInt32(z);
 PersianCalendar pcalender = new PersianCalendar();
                PersianDate pDateObj = new PersianDate();
               
                int year=Convert.ToDateTime(items.تاریخ_اعزام).Year;
                int month = Convert.ToDateTime(items.تاریخ_اعزام).Month;
                int day =Convert.ToDateTime(items.تاریخ_اعزام).Day;

                pDateObj.increasePersianMonth(ref year,ref month, 21);

               

                DateTime date = pcalender.ToDateTime(year,
                                                      month,
                                                      day, 0, 0, 0, 0, 0
                 );
                //  DateTime date_FreeDate = date.AddMonths(21);
                  DateTime date_FreeDate1= date.AddDays( Day_variable);
                items.تاریخ_ترخیص = pcalender.GetYear(date_FreeDate1) + "/" +
                                    pcalender.GetMonth(date_FreeDate1) + "/" +
                                    pcalender.GetDayOfMonth(date_FreeDate1);
               
            }
            //return date_FreeDate;
            bank.SubmitChanges();
        }

         public static void EndMissionDate()
        {
            var bank = new LinqDataContext();

            var query = from p in bank.sarbazs
                         where p.مدت_ماموریت_ماه_!=null
                         select p;
            foreach (var items in query)
            {
                PersianCalendar pcalender = new PersianCalendar();
                
                DateTime date = pcalender.ToDateTime(Convert.ToDateTime(items.تاریخ_اعزام).Year,
                                                      Convert.ToDateTime(items.تاریخ_اعزام).Month,
                                                      Convert.ToDateTime(items.تاریخ_اعزام).Day, 0, 0, 0, 0, 0
                                            );
                var x = items.مدت_ماموریت_ماه_;
                if (x == "" || x== null) x = "0";
                DateTime date_EndMission = date.AddMonths(Convert.ToInt32(x));
                items.تاریخ_اتمام_ماموریت = pcalender.GetYear(date_EndMission) + "/" +
                                    pcalender.GetMonth(date_EndMission) + "/" +
                                    pcalender.GetDayOfMonth(date_EndMission);
            }
            //   return date_EndMission;
            bank.SubmitChanges();
        }
    }
}
