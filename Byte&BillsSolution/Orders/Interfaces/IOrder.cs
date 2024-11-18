using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_BillsSolution.Orders.Interfaces
{
    internal interface IOrder
    {
        int GetId();
        DateTime GetDate();
    }
}
