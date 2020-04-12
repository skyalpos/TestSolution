using System;
using System.Collections.Generic;
using System.Text;

namespace Test7_interface
{
    public interface IOrder
    {
        DateTime Purchased { get; }
        decimal Cost { get; }
    }
}
