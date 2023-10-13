using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{

    /// <summary>
    /// Enum order status , to know the state of order
    /// </summary>

    public enum OrderStatus {
        Default,
        Initiated,
        Ordered,
        Cancelled
    }

    /// <summary>
    /// A class to store order details
    /// </summary>
    public class OrderDetails
    {

        /// <summary>
        /// A Order details constructor to initialize Values
        /// </summary>
        /// <param name="customerID">type string</param>
        /// <param name="totalPrice">type totalPrice</param>
        /// <param name="dateOfOrder">type dateTime</param>
        /// <param name="orderStatus">Enum OrderStatus</param>
        public OrderDetails(string customerID, double totalPrice, DateTime dateOfOrder, OrderStatus orderStatus)
        {
            OrderId = "OID" + s_id.ToString();
            s_id++;
            CustomerID = customerID;
            TotalPrice = totalPrice;
            DateOfOrder = dateOfOrder;
            OrderStatus = orderStatus;
        }

        //         OrderDetails Class:
        // Properties: OrderID, CustomerID, TotalPrice, DateOfOrder, OrderStatus – {Default, Initiated, Ordered, Cancelled}.

        private static int s_id = 3001;
        public string OrderId { get; set; }
        public string CustomerID { get; set; }
        public double TotalPrice { get; set; }
        public DateTime DateOfOrder { get; set; }   
        public OrderStatus OrderStatus { get; set; }
        

    }
}