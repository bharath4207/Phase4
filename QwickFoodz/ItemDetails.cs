using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{

    /// <summary>
    /// Item details class To store item details
    /// </summary>
    public class ItemDetails
    {
        //         ItemDetails Class:
        // Properties: ItemID – (ITID100), OrderID, FoodID, PurchaseCount, PriceOfOrder

        private static int s_id = 100;

        /// <summary>
        /// A constructor to initialize values.
        /// </summary>
        /// <param name="orderId">Type string</param>
        /// <param name="foodId">Type string</param>
        /// <param name="purchaseCount">Type int</param>
        /// <param name="priceOfOrder">Type double</param>
        public ItemDetails(string orderId, string foodId, int purchaseCount, double priceOfOrder)
        {
            ItemId = "ITI" + s_id.ToString();
            s_id++;
            OrderId = orderId;
            FoodId = foodId;
            PurchaseCount = purchaseCount;
            PriceOfOrder = priceOfOrder;
        }

        public string ItemId { get; set; }
        public string OrderId { get; set; }

        public string FoodId { get; set; }
        public int PurchaseCount { get; set; }
        public double PriceOfOrder { get; set; }

    }
}