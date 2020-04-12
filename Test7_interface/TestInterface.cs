/* 接口
 * 2020/4/11
 * 接口封装了一些功能，只提供功能的模板（名称，参数列表，返回类型），不做实现。继承接口的类负责实现。
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Test7_interface
{
    interface ISame<T1>
    {
        bool IsSame(T1 t);
    }


    class TestInterface
    {
        static void Main(string[] args)
        {
            TestCustomer();
        }

        static void TestCustomer()
        {
            SampleCustomer c = new SampleCustomer("customer one", new DateTime(2010, 5, 31)) 
            { 
                Reminders = 
                { 
                    { new DateTime(2010, 08, 12), "childs's birthday" }, 
                    { new DateTime(1012, 11, 15), "anniversary" } 
                } 
            };

            SampleOrder o = new SampleOrder(new DateTime(2002, 6, 1), 5m);
            c.AddOrder(o);
            //o = new SampleOrder(new DateTime(2103, 7, 4), 25m);
            //c.AddOrder(o);
            // Check the discount: 
            ICustomer theCustomer = c; 
            Console.WriteLine($"Current discount: {theCustomer.ComputeLoyaltyDiscount()}");
        }
        static void TestCar()
        {
            Car c4l = new Car();
            c4l.Make = "xuetielong";
            Console.WriteLine(c4l.Make);

            Car c5 = new Car();
            c5.Make = "xuetielong";

            if (c4l.IsSame(c5))
            {
                Console.WriteLine("They are the same car.");
            }
        }

    
    }
    public class Car: ISame<Car>
    {
        public string Make { set; get; } 

        public bool IsSame(Car thatcar)
        {
            return this.Make == thatcar.Make;
        }
    }
}
