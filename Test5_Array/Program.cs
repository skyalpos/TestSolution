/*数组相关的学习
 * 2020.4.10
 * 
 * 1.在 C# 中，数组实际上是对象，而不只是如在 C 和 C++ 中的连续内存的可寻址区域。 
 * Array 是所有数组类型的抽象基类型。 可以使用 Array 具有的属性和其他类成员。
 * 
 * 2.数组元素可以是任何类型，其中包括数组类型。如果希望数组 存储任意类型的元素，
 * 可将其类型指定为 object 。 在 C# 的统一类型系统中，所有类型（预定义类型、用户
 * 定义 类型、引用类型和值类型）都是直接或间接从 Object 继承的。
 * 
 *3.数值数组元素的默认值设置为零，而引用元素设置为 null。 
 * 
 *4.数组可以是一维、多维或交错的。
 * 
 *5.数组从零开始编制索引：包含 n 元素的数组从 0 索引到 n-1 。
 * 
 *6.数组类型是从抽象的基类型派生的引用类型Array。 由于此类型实现 IEnumerable 和 
 * IEnumerable<T>，因此 可以在 C# 中的所有数组上使用 foreach 迭代。
 * 
 *7.数组可以作为实参传递给方法形参。 由于数组是引用类型，因此方法可以更改元素的
 * 值。
 * 
 * 
 * 
 * 
 * 
 */

using System;

namespace Test5_Array
{
    class ArrayExample
    {
        static void Main(string[] args)
        {
            // Declare and initialize an array.
            string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            DisplayArray(weekDays);

            ChangeArray(weekDays);
            //Array.Reverse(weekDays);
            DisplayArray(weekDays);

            ChangeArrayElements(weekDays);
            DisplayArray(weekDays);

            //显示二维数组
            Print2DArray(new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } });

            //显示交错数组
            PrintJaggedArray(new int[][] { new int[]{ 1, 2, 3 }, new int[]{4,5,6,7,8 } });
            Console.WriteLine("".PadRight(40, '='));
            //数组作为返回值
            float[] studentScores = GetStudentScore();
            foreach (var score in studentScores)
            {
                Console.WriteLine(score);
            }
            Console.WriteLine("学生最高成绩是{0}", GetMax(studentScores));

            Console.WriteLine("".PadRight(40, '='));

            double[] arrayf = new double[] { 50, 27.3, 89, 96.5 };
            DisplayArray(arrayf);
            Console.WriteLine("最大数是{0}", GetMax(arrayf));

            Console.WriteLine("".PadRight(40, '='));
            Console.WriteLine(GetDayOfYear(2020, 2, 29));
            //Console.Write("Press <Enter> to exit... ");
            //while (Console.ReadKey().Key != ConsoleKey.Enter) { }

            //DateTime dt = new DateTime(2020,4,50);
        }

        static void DisplayArray(string[] arr) => Console.WriteLine(string.Join(" ", arr));

        static void DisplayArray(double[] arr)
        {
            if (arr.Length == 0)
                return;
            
            foreach (var item in arr)
            {
                Console.Write("{0} ", item);                
            }
            Console.WriteLine();

        }

        static void ChangeArray(string[] arr) => Array.Reverse(arr); //将字符串数组反序

        static void ChangeArrayElements(string[] arr)
        { // Change the value of the first three array elements.
            arr[0] = "Mon";
            arr[1] = "Wed";
            arr[2] = "Fri";
        }

        static void Print2DArray(int[,] arr)
        {//显示二维数组
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write("Elementa[{0},{1}]={2}\t", i, j, arr[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void PrintJaggedArray(int[][] jArr)
        {//显示交错数组
            for (int i = 0; i < jArr.Length; i++)
            {
                for (int j = 0; j < jArr[i].Length; j++)
                {
                    Console.Write("Elementa[{0}][{1}]={2}\t", i, j, jArr[i][j]);
                }
                Console.WriteLine();
            }

        }

        static float[] GetStudentScore()
        {//演示数组作为方法的返回值
            Console.WriteLine("欢迎使用学生成绩录入系统");
            Console.Write("请输入学生数量：");
            int n_students = int.Parse(Console.ReadLine());
            float[] scores = new float[n_students];
            for (int i = 0; i < n_students; i++)
            {
                Console.Write("请输入第{0}学生成绩：", i+1);
                scores[i] = float.Parse(Console.ReadLine());
                if (scores[i] > 100 || scores[i] < 0) 
                {
                    Console.WriteLine("成绩有误，请重新输入。");
                    i--;
                }
            }
            return scores;
        }

        static float GetMax(float[] arr)
        {//返回数组中最大的数。如果数组为空，返回0。
            if (arr.Length == 0)
            {
                return 0;
            }

            float max = arr[0];
            foreach (var item in arr)
            {
                if (item > max)
                {
                    max = item;
                }
            }

            return max;
        }

        static double GetMax(double[] arr)
        {//返回数组中最大的数。如果数组为空，返回0。
            if (arr.Length == 0)
            {
                return 0;
            }

            double max = arr[0];
            foreach (var item in arr)
            {
                if (item > max)
                {
                    max = item;
                }
            }

            return max;
        }

        static int GetDayOfYear(int year,int month,int day)
        {//已知年月日，返回当天是当年的第几天
            try
            {
                DateTime dt = new DateTime(year, month, day);                
                return dt.DayOfYear;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("非法日期");
                return 0;
            }


            /*
            int[] daysOfMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            //判断是否闰年 
            bool isLeap = false;
            int y = year;
            if (y % 100 == 0)
                y /= 100;
            if (y % 4 == 0)
                isLeap = true;
            
            //处理非法年月
            if (year < 0 || month < 0 || month > 12)
            {
                Console.WriteLine("非法日期");
                return 0;
            }
            //处理非法日 
            if (month == 1)
            {
                if (day > 29)
                {
                    Console.WriteLine("非法日期");
                    return 0;
                }
                else if (day == 29 && !isLeap)
                {
                    Console.WriteLine("非法日期");
                    return 0;
                }
            }
            else if (day > daysOfMonth[month - 1])
            {
                Console.WriteLine("非法日期");
                return 0;
            }
            

            //计算当天是第几天
            int dayOfYear = day;
            for (int i = 0; i < month-1; i++)
            {
                dayOfYear += daysOfMonth[i];
            }

            //月份大于2时，判断是否闰年，如果是则要加1
            if (month > 2 && isLeap)
            {
                dayOfYear++;
            }            

            return dayOfYear;
            */
        }
    }
        
}
