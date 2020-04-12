/*内容有：random，格式化输出，while
 * 
 * 
 */

using System;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate and display 5 random integers between 5 and 100.
            var rand = new Random();
            Console.WriteLine("Five random integers between 5 and 100:");
            for (int ctr = 0; ctr <= 4; ctr++)
                Console.Write("{0,8:N0}", rand.Next(5, 101));  //[5,100]
            Console.WriteLine();
            Console.WriteLine(("").PadRight(24, '-'));

            //随机产生一个1~100的随机数，判断多少次后数值为50
            int count = 0;
            const int N1 = 50;
            while (true)//提示：输入while后按两下tab键，语法结构会自动出现
            {
                count++;
                int n = rand.Next(1, 101);
                Console.Write("{0,4}", n);                
                if (N1 == n)
                {
                    Console.WriteLine();
                    Console.WriteLine("第{0}次产生的数字为50", count);
                    break;
                }

            }

            Console.WriteLine(("").PadRight(24, '-'));

            //又一个格式输出的例子 { index[,alignment][:formatString] }
            string[] names = { "Adam", "Bridgette", "Carla", "Daniel",
                         "Ebenezer", "Francine", "George" };
            decimal[] hours = { 40, 6.667m, 40.39m, 82, 40.333m, 80,
                                 16.75m };

            Console.WriteLine("{0,-20} {1,5}\n", "Name", "Hours");//Name左对齐，Hours右对齐
            for (int ctr = 0; ctr < names.Length; ctr++)
                Console.WriteLine("{0,-20} {1,5:N1}", names[ctr], hours[ctr]);//hours带1位小数

            Console.WriteLine(("").PadRight(24, '-'));

            //练习，一个小球从1米高掉下，落地后反弹高度减半，问最多反弹多少次后高度不低于0.01m，小球行程是多少
            //循环次数未知，用while循环
            //1、定义清楚什么是一次循环；2、循环的条件；3、数据更新的时机，条件判断之前还是之后。
            double height = 1;
            count = 0;
            double distance = 0;
            do
            {
                //重复单位：从高点落下反弹到新的高度（一个行程）
                //一个行程后的变量更新：
                count++;
                height /= 2;   //第count次反弹后的高度
                distance += 3 * height;                
                Console.WriteLine("第{0}次反弹后小球高度{1}米。", count, height);
            } while (height/2 >= 0.01);//如果下次反弹的高度不低于0.01m，行程继续
            Console.WriteLine("共反弹{0}次，小球行程{1}米。", count, distance);

            Console.WriteLine(("").PadRight(24, '-'));


            //练习：猜数游戏。随机产生一个1到100之间的整数，不告诉用户，让用户猜。看多少次猜中。
            Console.WriteLine("欢迎来玩猜数字游戏，看看你最快多少次能猜中。加油！！！");
            int n1 = rand.Next(1, 101);
            count = 0;
            while (true) 
            {
                count++;               
                Console.Write("输入一个整数：");
                int m = int.Parse(Console.ReadLine());
                if (m > n1)
                {
                    Console.WriteLine("猜大了，继续努力\n");
                }
                if (m < n1)
                {
                    Console.WriteLine("猜小了，加油\n");
                }
                if (m == n1)
                {
                    Console.WriteLine("\n你真厉害，猜了{0}次，终于猜对了",count);
                    break;                       
                }
            }

           


        }
    }
}
