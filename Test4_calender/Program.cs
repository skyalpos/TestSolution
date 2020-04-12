
//在控制台打印日历
//2020.4.10
/*功能模块划分：
 * 1在控制台打印多个月的日历 void PrintMonthsCalender(int year,int month_start,int n_months)
 *  11在控制台打印每个月的日历 void PrintAMonthCalender(int year,int month)
 *      打印年月信息
 *      打印表头（日 一 二。。。）
 *      打印空格（需要知道本月1日是星期几）
 *      --111 得到本月1日是星期几 int WeekOfFirstDay(int year, int month)
 *      打印日期（从1日到本月最后一天，需要知道本月有多少天）
 *      --112 得到本月的天数 int DaysOftheMonth(int year, int month) 
 */

using System;

namespace Test4_calender
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMonthsCalender(2020,12,14);
            //PrintAMonthCalender(2020, 4);
            //Console.WriteLine(DaysOftheMonth(2020, 3));
        }



        //====================================================
        //1在控制台打印多个月的日历 void PrintMonthsCalender(int year, int month_start, int n_months)
        /// <summary>
        /// 格式化输出多个月的日历，可以跨年
        /// </summary>        
        static void PrintMonthsCalender(int year, int month_start, int n_months)
        {
            //在控制台打印每个月的日历           
            //月份示意10，11，12，1，2，3....
            /*思路:
             * 年份：月份为12时，年份要加1
             * 月份：用公式 month = (month_start + n)%12 == 0 ? 12 : (month_start + n)%12
             * --其中：n从0开始，到n_months-1，表示正在打印的第几个月。
             
            */
            int thisyear = year;
            int thismonth;   
            
            for (int n = 0; n < n_months; n++)
            {
                thismonth = (month_start + n) % 12 == 0 ? 12 : (month_start + n) % 12;
                PrintAMonthCalender(thisyear, thismonth);
                Console.WriteLine("\n");

                //月份为12时，年份要加1
                if (12 == thismonth)
                {
                    thisyear++;
                }
            }
                       
        }

        //====================================================
        //11在控制台打印每个月的日历 void PrintAMonthCalender(int year,int month)
        /// <summary>
        /// 格式化输出某年某月的日历。
        /// </summary>        
        static void PrintAMonthCalender(int year, int month)
        {
            //定义一个控制对齐的变量
            //int align = 4;

            //打印年月信息
            Console.WriteLine("{0}年{1}月", year, month);

            // 打印表头（日 一 二。。。）
            string week = "日一二三四五六";
            for (int i = 0; i < 7; i++)
            {
                Console.Write("{0,4}", week[i]);
                //Console.Write("{0,{1}}", week[i], align);  //会报异常
            }
            Console.WriteLine();

            // 打印空格（需要知道本月1日是星期几）
            int blank = WeekOfFirstDay(year, month);    //blank表示空格的数量
            for (int i = 0; i < blank; i++)
            {
                Console.Write("{0,5}", " ");
            }            

            //打印日期（从1日到本月最后一天，需要知道本月有多少天）
            int days = DaysOftheMonth(year, month);
            for (int day = 1; day <= days; day++)
            {
                if ((day + blank) % 7 == 0)
                {
                    Console.WriteLine("{0,5}", day);
                }
                else
                {
                    Console.Write("{0,5}", day);
                }
            }
        }


        //====================================================   
        //111 得到本月1日是星期几 int WeekOfFirstDay(int year, int month)
        /// <summary>
        /// 给出年和月，返回本月1日是星期几（0表示星期日，1表示星期一，...）
        /// </summary>       
        static int WeekOfFirstDay(int year, int month)
        {
            DateTime dt = new DateTime(year, month, 1);            
            return (int)dt.DayOfWeek;
        }

        //==================================================== 
        //112 得到本月的天数 int DaysOftheMonth(int year, int month)
        /// <summary>
        /// 给出年和月，返回该月的天数
        /// </summary>        
        static int DaysOftheMonth(int year, int month)
        {
            if (month < 1 || month > 12) 
            {
                return 0;
            }

            //二月，闰年29天，平年28天
            if (month == 2)
            {
                int y = year;                
                
                if (y % 100 == 0)
                {
                    y /= 100;
                }

                if (y % 4 == 0)
                {
                    return 29;
                }

                return 28;
            }

            switch (month)
            {                
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default:
                    return 31;
            }
        }


        
     }
}
