using Byte_BillsSolution.Collection.Linked;
using Byte_BillsSolution.Orders.Files;

namespace Byte_BillsSolution.Orders.Handler
{
    public class OrdersHandler
    {
        private LinkedPriorityQueue<Order> attOrders = new();
        OrdersFile file = new();
        private int attTotalOrders;

        /// <summary>
        /// Constructor of the Orders manager
        /// </summary>
        public OrdersHandler()
        {
            this.attTotalOrders = file.GetLastCounter();
        }

        /// <summary>
        /// Using a enum, tihs method verify and return the priority value of a string.
        /// </summary>
        /// <param name="prmType">Value to parsed to a priority. This can be "Restaurant", "Rappi", "Delivery".</param>
        /// <returns>Int value of priority</returns>
        public int GetPriority(string prmType)
        {
            TimeSpan peakStart1 = new(11, 30, 0); TimeSpan peakEnd1 = new(14, 0, 0);
            TimeSpan peakStart2 = new(18, 0, 0); TimeSpan peakEnd2 = new(20, 0, 0);
            var attNow = DateTime.Now.TimeOfDay;
            // DateTime currentTime = DateTime.Parse("6/19/2022 12:34:12 AM"); for test
            if ((attNow >= peakStart1 && attNow <= peakEnd1) || (attNow >= peakStart2 && attNow <= peakEnd2))
            {
                if (Enum.TryParse(prmType, true, out PeakHoursOrderTypes peakResult))
                {
                    return (int)peakResult;
                }
                return 1;
            }
            if (Enum.TryParse(prmType, true, out NormalHoursOrderTypes normalResult))
            {
                return (int)normalResult;
            }
            return 1;
        }

        /// <summary>
        /// Create a order
        /// </summary>
        /// <param name="prmType">String to search a priority</param>
        /// <returns></returns>
        public int Create(string prmType)
        {
            attTotalOrders++;
            Order attOrder = new(attTotalOrders, prmType);
            int attPriority = GetPriority(prmType);
            file.Write(Convert.ToString(attOrder.GetId()) + " - Date: " + Convert.ToString(attOrder.GetDate()) + " - Priority: " + Convert.ToString(attPriority) + " - Type: " + prmType);
            attOrders.Enqueue(attOrder, attPriority);
            return attTotalOrders;
        }

        /// <summary>
        /// Delete a order before processed.
        /// </summary>
        /// <returns>Check if process was sucess.</returns>
        public bool Delete()
        {
            if (!attOrders.IsEmpty())
            {
                Order attDeleted = default;
                attOrders.Dequeue(ref attDeleted);
                return true;
            }
            return false;
        }

        /// <summary>
        /// View of the first order in queue.
        /// </summary>
        /// <returns>Fisr order.</returns>
        public Order Peek()
        {
            Order order = default;
            attOrders.Peek(ref order);
            return order;
        }

        /// <summary>
        /// View of all the orders in the system memory.
        /// </summary>
        /// <returns>Array of the newest orders.</returns>
        public Order[] PeekOrders()
        {
            return this.attOrders.ToArray();
        }

        /// <summary>
        /// String of the values saved in the file "Orders.txt".
        /// </summary>
        /// <returns>String with all values</returns>
        public string ReadFile()
        {
            return file.Read();
        }

        public bool IsEmpty()
        {
            return attOrders.IsEmpty(); 
        }

        /// <summary>
        /// Converts the Collection in string.
        /// </summary>
        /// <returns>Complete string of the items in the collection.</returns>
        public override string ToString()
        {
            return attOrders.ToString();
        }
    }
}
