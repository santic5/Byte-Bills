using Byte_BillsSolution.Orders.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byte_BillsSolution.Orders
{
    public class Order : IOrder, IComparable<Order>
    {
        DateTime attOrderedAt = DateTime.Now;
        string attType;
        int attId = 0;

        /// <summary>
        /// Create a order using the id as key.
        /// </summary>
        /// <param name="prmId">Id of the order.</param>
        public Order(int prmId, string attType) { this.attId = prmId; this.attType = attType; }

        /// <summary>
        /// Compare two orders.
        /// </summary>
        /// <param name="other">Order to compare.</param>
        /// <returns>Int (0/1) result of comparasion.</returns>
        public int CompareTo(Order? other)
        {
            if (other == null) return 1;
            return this.attId.CompareTo(other.attId);
        }

        /// <summary>
        /// Get the date of the order creation.
        /// </summary>
        /// <returns>Date of the order.</returns>
        public DateTime GetDate()
        {
            return attOrderedAt;
        }
        /// <summary>
        /// Get the id of the order.
        /// </summary>
        /// <returns>Id of the order.</returns>
        public int GetId()
        {
            return attId;
        }

        /// <summary>
        /// Get the origin of the order
        /// </summary>
        /// <returns>String of the type that ordered</returns>
        public string getType()
        {
            return attType;
        }

        /// <summary>
        /// Parse into a string the item info.
        /// </summary>
        /// <returns>String with the info of the item.</returns>
        public override string ToString()
        {
            return attId + " | " + this.GetDate().ToString() + " | " + this.getType();
        }
    }
}
