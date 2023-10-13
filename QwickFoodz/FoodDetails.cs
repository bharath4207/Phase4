using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QwickFoodz
{
    /// <summary>
    /// Food details class to store food details
    /// </summary>
    public class FoodDetails
    {

        /// <summary>
        /// Food Details constructor
        /// </summary>
        /// <param name="foodName">Type string</param>
        /// <param name="pricePerQuantity">Type double</param>
        /// <param name="quantityAvailable">Type int</param>
        public FoodDetails(string foodName, double pricePerQuantity, int quantityAvailable)
        {
            FoodId = "FID" + s_id.ToString();
            s_id++;
            FoodName = foodName;
            PricePerQuantity = pricePerQuantity;
            QuantityAvailable = quantityAvailable;
        }

        //         FoodDetails Class:
        // Properties: FoodID, FoodName, PricePerQuantity, QuantityAvailable
        // Values of FoodDetails Object

        private static int s_id = 101;
        public string FoodId { get; set; }
        public string FoodName { get; set; }
        public double PricePerQuantity { get; set; }
        public int QuantityAvailable { get; set; }

    }
}