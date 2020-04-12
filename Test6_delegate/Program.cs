/*演示delegate 
 * 2020/4/10
 * 委托本质上是方法，有趣的这个方法看上去与变量类似，可以形象的称为方法变量。
 * 委托使用时，先有类型，在从类型定义出实例。
 * 
 */

using System;

namespace Test6_delegate
{
    class Program
    {
        //声明名为Del的委托，该委托可以封装将string作为参数并返回void 的方法。Del作为一种类型使用。
        public delegate void Del(string str);

        static void Main(string[] args)
        {
            //委托实例（将Del作为一种类型使用）
            Del d1 = Circle;
            //调用委托实例
            d1("blue");

            Del d2 = Cube;
            d2("red");

            //委托实例可以相加
            MethodWithCallback("blue", d1+d2);


            /*任何 Lambda 表达式都可以转换为委托类型。 Lambda 表达式可以转换的委托类型由其参数和
             * 返回值的 类型定义。 如果 lambda 表达式不返回值，则可以将其转换为 Action 委托类型
             * 之一；否则，可将其转换 为 Func 委托类型之一。 例如，有 2 个参数且不返回值的
             * Lambda 表达式可转换为 Action<T1,T2> 委托。 有 1 个参数且不返回值的 Lambda 表达式
             * 可转换为 Func<T,TResult> 委托。 以下示例中，lambda 表达式 x => x * x （指定名为
             * x 的参数并返回 x 平方值）将分配给委托类型的变量：
             */
            Action<object> Print = s => Console.WriteLine(s);
            Action<Array> PrintA = arr =>
            {
                foreach (var item in arr)
                    Console.Write($"{item}  ");
                Console.WriteLine();
            };
            

            Func<int,int> Square = x => x * x;
            Print(Square(10));

            int[] a = { 1, 2, 3 };
            int[] b = (int[])a.Clone();
            if (!Object.ReferenceEquals(a, b))
            {
                Print("a,b are not referenceequale.");
            }
            PrintA(a);
            PrintA(b);
            a[0] = 100;
            PrintA(a);
            PrintA(b);
        }

        public static void Circle(string color)
        {
            Console.WriteLine("This is a {0} circle",color);
        }
        public static void Cube(string color)
        {
            Console.WriteLine("This is a {0} cube",color);
        }
        

        public static void MethodWithCallback(string str, Del callback)
        {
            callback(str);
        }



    }
}
