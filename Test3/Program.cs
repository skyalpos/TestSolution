/* 方法的参数有4种：值参数，引用参数，输出参数，数组参数
 * 
 * 字符串：
 * 内插字符串$：  在 C#6.0及更高版本中提供，内插字符串 由 $ 特殊字符标识，并在大括号中包含内插表达式。
 * 
 * 逐字字符串@：  当字符串文本包含反斜杠字符（例如在文件路径中）时，出于便捷性和更强的可读性的考虑，使用逐字字符
 * 串。由于逐字字符串将新的行字符作为字符串文本的一部分保留，因此可将其用于初始化多行字符串。 使用
 * 双引号在逐字字符串内部嵌入引号。
 * 
 * 空字符串:  如果字符串显式分配了空字符串（""）或 String.Empty，则该字符串为空。 空字符串的 Length 为0。
 * null字符串（无效字符串）: 如果未为字符串分配值，或者如果已显式为其分配了值 null，则为null 字符串。
 * 
 */

using System;

namespace Test3
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 23, y = 100;

            //值参数
            //Console.WriteLine("x={0}, y={1}", x, y);
            Console.WriteLine($"x={x}, y={y}"); 
            Swap(x, y);
            Console.WriteLine("调用值参数方法后：x={0}, y={1}", x, y);

            //引用参数
            Swap(ref x, ref y);
            Console.WriteLine("调用引用参数方法后：x={0}, y={1}", x, y);
            string s1 = "play";
            Ing(s1);
            Console.WriteLine(s1);
            Ing(ref s1);
            Console.WriteLine(s1);

            //输出参数
            Divide(10, 3, out int res, out int rem); 
            Console.WriteLine("{0} {1}", res, rem); // Outputs "3 1" 

            //参数数组
            Sum(out double sum, 3, 7, 9.5, 8);
            Console.WriteLine(sum);
            Sum(out sum, 3, 7, 9.5, 8, 20);
            Console.WriteLine(sum);

            
            //测试String类自带的几个方法
            string s2 = "珠穆朗玛峰";
            string s3 = s2.Insert(4, "很美");  //s3= “珠穆朗玛很美峰”
            Console.WriteLine(s3);  
            Console.WriteLine(s3.IndexOf("很"));//输出4
            Console.WriteLine(s3.Remove(4));//输出：珠穆朗玛
            Console.WriteLine(s3.Replace("很", "不"));//输出：珠穆朗玛不美峰
            Console.WriteLine(s3.StartsWith("珠穆"));//true
            Console.WriteLine(s3.Contains("很"));//true

            string nullString = null;
            string emptyString = string.Empty;
            try
            { //NullReferenceException
                Console.WriteLine($"nullString.Length is {nullString.Length}");
            }
            catch (NullReferenceException){
                Console.WriteLine(@"You can't get a nullstring's length.");
            }
            Console.WriteLine($"emptyString.Length is {emptyString.Length}");//0
            string emptyString1 = "";            
            Console.WriteLine($"\"\"\'s length is {emptyString1.Length}");//0


        }


        //值参数：方法体内对参数的修改无效。
        static void Swap(int x, int y)
        {
            int temp = x;
            x = y;
            y = temp;

            return;
        }

        //引用参数：方法体内对参数的修改有效
        static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;

            return;
        }

        static void Ing(string str)  //即使string是引用类型，如果没有ref标识，还是值参数，方法内部修改无效。
        {
            str = str + "ing";
        }

        static void Ing(ref string str)
        {
            str += "ing";
        }

        //输出参数
        static void Divide(int x, int y, out int result, out int remainder)
        { 
            result = x / y; 
            remainder = x % y; 
        }

        //参数数组：参数数组只能是方法的最后一个参数，且参数数组的类型必须是一维数组类型。 
        //计算任意个数的和
        static void Sum(out double res, params double[] nums)
        {
            res = 0;
            foreach (var item in nums)
            {
                res += item;
            }

        }



    }
}
