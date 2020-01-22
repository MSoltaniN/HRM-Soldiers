using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace sarbaz
{
    class PersianDate
    {
       

        public static string GetPersianDate()
        {

            PersianCalendar pcalender = new PersianCalendar();
            string d = pcalender.GetDayOfMonth(DateTime.Now).ToString();
            string m = pcalender.GetMonth(DateTime.Now).ToString();
            string y = pcalender.GetYear(DateTime.Now).ToString();

            return y + "/" + m + "/" + d;
        }


        public void  increasePersianMonth(ref int year, ref int month, int number)
        {
            month += number;
            if (month > 12&& month<=24)
            {
                month = month-12;
                year++;
            }
            else if(month>24 )
            {
                month = month - 24;
                year++;
                year++;
            }
        }
        public void  decreasePersianMonth(ref int year,ref  int month, int number)
        {
            month -= number;
            if (month < 1)
            {
                month = 12;
                year--;
            }
        }
       public void increasePersianDay(ref int year,ref int month,ref int day, int number)
        {
            PersianCalendar pcalender = new PersianCalendar();
            int tempDay = day;
            tempDay += number;
            //شش ماه اول سال
            if (month <= 6 && tempDay > 31)
            {
                day = number;
                increasePersianMonth(ref year,ref  month, 1);
            }
            //5 ماه دوم سال 
            else if (month > 6 && month < 12 && tempDay > 30)
            {
                day = number;
                increasePersianMonth(ref year,ref  month, 1);
            }
            //اسفند در سال کبیسه
            else if (month == 12 && pcalender.IsLeapYear(year) && tempDay > 30)
            {
                day = number;
                increasePersianMonth(ref year,ref  month, 1);
            }
            //اسفند در سال غیر کبیسه
            else if (month == 12 && !pcalender.IsLeapYear(year) && tempDay > 29)
            {
                day = number;
                increasePersianMonth(ref year,ref  month, 1);
            }
            else
                day += number;
        }
      public  void decreasePersianDay(ref int year,ref int month,ref  int day, int number)
        {
            PersianCalendar pcalender = new PersianCalendar();
            int tempDay = day;
            tempDay -= number;
            //شش ماه اول سال
            if (month == 1 && tempDay < 1)
            {
                if (pcalender.IsLeapYear(year - 1))
                    day = 30 - number + 1;//+1 رو باید اضافه کرد در غیر این صورت محاسبات اشتباه میشوند ، تجربی
                else
                    day = 29 - number + 1;
                decreasePersianMonth(ref year,ref  month, 1);
            }
            else if (month <= 7 && month > 1 && tempDay < 1)
            {
                day = 31 - number + 1;
                month--;
            }
            //6 ماه دوم سال 
            else if (month > 7 && month <= 12 && tempDay < 1)
            {
                day = 30 - number + 1;
                decreasePersianMonth(ref year,ref  month, 1);
            }
            else
                day -= number;

        }
        public static int GetNumberDayInMonth()
        {
            int Res;
            try
            {
                PersianCalendar DateFme = new PersianCalendar();
                Res = DateFme.GetDayOfMonth(DateTime.Now);
            }
            catch
            {
                Res = 0;
            }
            return Res;
        }
        /// <summary>
        /// بدست اوردن نام روز شمسی
        /// </summary>
        /// <returns></returns>      
        public static string GetNameDayInMonth()
        {

            string Resme = "";
            string Res;
            PersianCalendar DateFme = new PersianCalendar();
            Res = DateFme.GetDayOfWeek(DateTime.Now).ToString();
            switch (Res)
            {
                case "Saturday":
                    {
                        Resme = "شنبه";
                        break;
                    }
                case "Sunday":
                    {
                        Resme = "یکشنبه";
                        break;
                    }
                case "Monday":
                    {
                        Resme = "دو شنبه";
                        break;
                    }
                case "Tuesday":
                    {
                        Resme = "سه شنبه";
                        break;
                    }
                case "Wednesday":
                    {
                        Resme = "چهار شنبه";
                        break;
                    }
                case "Thursday":
                    {
                        Resme = "پنج شنبه";
                        break;
                    }
                case "Friday":
                    {
                        Resme = "جمعه";
                        break;
                    }
            }
            return Resme;
        }





        /// <summary>
        /// بدست اوردن نام ماه شمسی
        /// </summary>
        /// <returns></returns>      
        public string GetNameMonth()
        {

            string Resme = "";
            string Res;
            PersianCalendar DateFme = new PersianCalendar();
            Res = DateFme.GetMonth(DateTime.Now).ToString();
            switch (Res)
            {
                case "1":
                    {
                        Resme = "فروردین";
                        break;
                    }
                case "2":
                    {
                        Resme = "اردیبهشت";
                        break;
                    }
                case "3":
                    {
                        Resme = "خرداد";
                        break;
                    }
                case "4":
                    {
                        Resme = "تیر";
                        break;
                    }
                case "5":
                    {
                        Resme = "مرداد";
                        break;
                    }
                case "6":
                    {
                        Resme = "شهریور";
                        break;
                    }

                case "7":
                    {
                        Resme = "مهر";
                        break;
                    }
                case "8":
                    {
                        Resme = "آبان";
                        break;
                    }
                case "9":
                    {
                        Resme = "آذر";
                        break;
                    }


                case "10":
                    {
                        Resme = "دی";
                        break;
                    }
                case "11":
                    {
                        Resme = "بهمن";
                        break;
                    }
                case "12":
                    {
                        Resme = "اسفند";
                        break;
                    }



            }




            return Resme;


        }
        /// <summary>
        /// بدست اوردن ماه شمسی
        /// </summary>
        /// <returns></returns>         



        /// <summary>
        /// بدست اوردن سال شمسی
        /// </summary>
        /// <returns></returns>
        public int GetNumberYear()
        {
            string Res;
            PersianCalendar DateFme = new PersianCalendar();
            Res = DateFme.GetYear(DateTime.Now).ToString();
            return Convert.ToInt32(Res);
        }

        public static string TimerDigitalPersian()
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            String Time = p.GetHour(DateTime.Now) + ":" + p.GetMinute(DateTime.Now) + ":" + p.GetSecond(DateTime.Now);
            return Time;


        }

        public enum dataConvertMode
        {
            toGregorian = 0,
            toPersian = 1
        }


        public static string ConvertPersianDate(string strDate, dataConvertMode convertMode, float addDay = 0)
        {
            PersianCalendar cal = new PersianCalendar();
            if (convertMode == dataConvertMode.toGregorian)
            {
                DateTime dt = cal.ToDateTime(Convert.ToInt32(strDate.Substring(0, 4)), Convert.ToInt32(strDate.Substring(5, 2)),
                                                Convert.ToInt32(strDate.Substring(8, 2)), 0, 0, 0, 0, 0);
                return dt.AddDays(addDay).ToShortDateString();
            }
            else
            {
                DateTime myDate = Convert.ToDateTime(strDate).AddDays(addDay);
                string Year, Day, Month;
                Year = cal.GetYear(myDate).ToString();
                Month = cal.GetMonth(myDate).ToString();
                Day = cal.GetDayOfMonth(myDate).ToString();
                Day = (Day.Length == 1) ? "0" + Day : Day;
                Month = (Month.Length == 1) ? "0" + Month : Month;
                return (Year + '/' + Month + '/' + Day);
            }




        }
        public static string PersianDateBackup(string strDate, dataConvertMode convertMode, float addDay = 0)
        {
            PersianCalendar cal = new PersianCalendar();
            if (convertMode == dataConvertMode.toGregorian)
            {
                DateTime dt = cal.ToDateTime(Convert.ToInt32(strDate.Substring(0, 4)), Convert.ToInt32(strDate.Substring(5, 2)),
                                                Convert.ToInt32(strDate.Substring(8, 2)), 0, 0, 0, 0, 0);
                return dt.AddDays(addDay).ToShortDateString();
            }
            else
            {
                DateTime myDate = Convert.ToDateTime(strDate).AddDays(addDay);
                string Year, Day, Month;
                Year = cal.GetYear(myDate).ToString();
                Month = cal.GetMonth(myDate).ToString();
                Day = cal.GetDayOfMonth(myDate).ToString();
                Day = (Day.Length == 1) ? "0" + Day : Day;
                Month = (Month.Length == 1) ? "0" + Month : Month;
                return (Year + '.' + Month + '.' + Day);
            }
        }


    }
}
