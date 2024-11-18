using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_BillsSolution.Orders.Handler
{
    /// <summary>
    /// Peak hours means the hours when Byte&Bills restaurant have a extra demand of the persons in restaurant.
    /// Becouse that, the priority of the rest types will be minor than the persons. 
    /// </summary>
    enum PeakHoursOrderTypes
    {
        Restaurant = 3,
        Restaurante = 3,
        Rappi = 2,
        Delivery = 1
    }
    /// <summary>
    /// Normal hours means the hours when Byte&Bills restaurant have a normal deman of persons in restaurant.
    /// Becouse that, the priority of the rest types will be major than the persons.
    /// </summary>
    enum NormalHoursOrderTypes
    {
        Restaurant = 1,
        Restaurante = 1,
        Rappi = 2,
        Delivery = 3
    }
}
