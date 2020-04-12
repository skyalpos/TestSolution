using System;
using System.Collections.Generic;
using System.Text;

namespace Test7_interface
{
    public class SampleOrder : IOrder

    {
        public SampleOrder(DateTime purchase, decimal cost) =>

            (Purchased, Cost) = (purchase, cost);

        public DateTime Purchased { get; }

        public decimal Cost { get; }

    }
}
