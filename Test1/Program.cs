using System;
using System.Collections.Generic;
using System.Runtime.InteropServices; //引入外部部件

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestNumbers();
            TestList();
        }
        static void TestList()
        {
            var names = new List<string> { "Rose", "Lina", "Tom", "Jack" };
            foreach (var name in names)
            {
                Console.WriteLine($"Hello,{name.ToUpper()}!");
            }

            Console.WriteLine("\nChange the name list");
            names.Add("Black");
            names.Remove("Tom");
            foreach (var name in names)
            {
                Console.WriteLine($"Hello,{name.ToUpper()}!");
            }

            Console.WriteLine($"I've added {names[3]} to the list");

            Console.WriteLine($"The list has {names.Count} people in it");

            if (-1 == names.IndexOf("Filipe")) 
            {
                Console.WriteLine("{0} is not in my list ,please add.", "Filipe");
                names.Add("Filipe");
            }

            names.Sort();
            foreach (var name in names)
            {
                Console.WriteLine($"Hello,{name.ToUpper()}!");
            }

            var fibonacciNumbers = new List<int> { 1, 1 };
            for (int i = 0; i < 18; i++)
            {
                var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
                var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
                fibonacciNumbers.Add(previous + previous2);
            }            
            foreach (var item in fibonacciNumbers)
                Console.Write($"{item},");

        }



        static void TestNumbers()
        {
            double maxdouble = double.MaxValue;
            double mindouble = double.MinValue;
            Console.WriteLine($"The range of double is {mindouble} to {maxdouble}");

            decimal mindecimal = decimal.MinValue;
            decimal maxdecimal = decimal.MaxValue;
            Console.WriteLine($"The range of the decimal type is {mindecimal} to {maxdecimal}");

            double a = 1.0;
            double b = 3.0;
            Console.WriteLine(a / b);
            decimal c = 1.0M; decimal d = 3.0M; Console.WriteLine(c / d);

            Console.WriteLine($"PI is {Math.PI}");
        }

        static void TestMessageBox()
        {//引入外部组件user32.dll中的MessageBox
            MessageBox(IntPtr.Zero, "Command-line message box", "Attention!", 0); 
        }

        static void TestString()
        {
            //字符串相关测试
            //复合格式参考链接：
            //https://docs.microsoft.com/zh-cn/dotnet/standard/base-types/composite-formatting?view=netframework-4.8
            string gunName = "AK47";
            string ammoCapacity = "30";
            //使用占位符｛｝
            string str = String.Format("枪的型号为{0}，容量为{1}。", gunName, ammoCapacity);
            Console.WriteLine(str);
            //数字格式化
            Console.WriteLine("金额：{0:c} {0:C}", 10);//货币￥10.00
            Console.WriteLine("现在时间是：{0:d2}:{1:d2}:{2:d2}", 5, 3, 29);//标准格式显示时间
            //显示账单
            Console.WriteLine(("").PadRight(24, '-'));
            double tipRate = 0.18;
            double billTotal = 52.23;
            double tip = billTotal * tipRate;
            Console.WriteLine();
            Console.WriteLine($"Bill total:\t{billTotal,8:c}");//billTotal占8个字段宽度，显示为货币
            Console.WriteLine($"Tip total/rate:\t{tip,8:c} ({tipRate:p1})");
            Console.WriteLine(("").PadRight(24, '-'));
            Console.WriteLine($"Grand total:\t{billTotal + tip,8:c}");
            Console.WriteLine(("").PadRight(24, '-'));
        }
        static void TestPlusPlus()
        {
            //++
            int a = 1;
            Console.WriteLine(a++);//先用后加，输出1；
            int b = 1;
            Console.WriteLine(++b);//先加后用，输出2；
            // int c = ++b++   //报错

            Console.WriteLine(("").PadRight(24, '-'));
        }        
        static void TestInputNumbers()
        {
            //parse转换：把string类型转换成数字。前提是string格式必须是数字。
            string n1 = "18.4";  //不能是"18.4f"
            float f1 = float.Parse(n1);
            Console.WriteLine(n1);
            //toString:把任意类型转换成字符串。
            float f2 = 520.25f;
            Console.WriteLine(f2.ToString());
            //练习：输入一个4位整数，输出各位数字的和
            #region//思路一：将输入转换成数字，再取出各位数字相加
            Console.WriteLine("输入一个4位整数：");
            int i1 = int.Parse(Console.ReadLine());
            if (i1 >= 1000 && i1 < 10000)
            {
                int sum = i1 % 10 + i1 / 10 % 10 + i1 / 100 % 10 + i1 / 1000;
                Console.WriteLine("{0}四位数字之和为{1}", i1, sum);
            }
            #endregion
            #region//思路二：从字符串中取出每一个数字字符，转换成数字相加
            Console.WriteLine("输入一个4位整数：");
            string s1 = Console.ReadLine();
            if (s1.Length == 4)
            {
                int sum = int.Parse(s1[0].ToString()) + int.Parse(s1[1].ToString()) +
                    int.Parse(s1[2].ToString()) + int.Parse(s1[3].ToString());
                Console.WriteLine(s1 + "四位数字之和为{0}", sum);
            }
            #endregion

            Console.WriteLine(("").PadRight(24, '-'));

            //练习：让用户输入两个数字和一个运算符，输出运算结果
            Console.WriteLine("输入两个数字和一个运算符");
            Console.Write("输入第一个数字：");
            int a1 = int.Parse(Console.ReadLine());
            Console.Write("输入第二个数字：");
            int a2 = int.Parse(Console.ReadLine());
            Console.Write("输入运算符：");
            string cal = Console.ReadLine();
            switch (cal)
            {
                case "+":
                    Console.WriteLine("{0} + {1} = {2}", a1, a2, a1 + a2);
                    break;
                case "-":
                    Console.WriteLine("{0} - {1} = {2}", a1, a2, a1 - a2);
                    break;
                case "*":
                    Console.WriteLine("{0} * {1} = {2}", a1, a2, a1 * a2);
                    break;
                case "/":
                    Console.WriteLine("{0} / {1} = {2}", a1, a2, a1 / a2);
                    break;
                default:
                    Console.WriteLine("输入有误。");
                    break;//这个break不能省
            }
            Console.WriteLine(("").PadRight(24, '-'));
        }
        static void TestLogic()
        {
            //短路逻辑
            int d1 = 1;
            int d2 = 2;
            bool bool1 = d1 > 2 && d2++ < 3;
            Console.WriteLine(d2);    //d2没有变化
            bool1 = d1 < 2 || d2++ < 3;
            Console.WriteLine(d2); //d2没有变化
            Console.WriteLine(("").PadRight(24, '-'));
        }
        static void TestFor()
        {
            //for循环。循环次数固定时使用
            float f1 = 0.001f;
            for (int i = 0; i < 30; i++)
            {
                f1 *= 2;
            }
            Console.WriteLine(f1); //f1=0.001*(2^30)
            Console.WriteLine(("").PadRight(24, '-'));
        }

        //引入外部组件user32.dll中的MessageBox
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);
    }
}
