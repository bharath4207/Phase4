using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace CafetariaCardManagement
{
    public static class FileHandling
    {
        public static void Create() {
            if(!Directory.Exists("CafetariaCardManagement")) {
                Directory.CreateDirectory("CafetariaCardManagement");
                System.Console.WriteLine("Directory created.");
            } else {
                System.Console.WriteLine("Directory already exists ....");
            }

            if(!File.Exists("CafetariaCardManagement/FoodDetails.csv")) {
                File.Create("CafetariaCardManagement/FoodDetails.csv").Close();
                System.Console.WriteLine("file created.");
            } else {
                System.Console.WriteLine("File already exists ....");
            }

            if(!File.Exists("CafetariaCardManagement/UserDetails.csv")) {
                File.Create("CafetariaCardManagement/UserDetails.csv").Close();
                System.Console.WriteLine("file created.");
            } else {
                System.Console.WriteLine("File already exists ....");
            }

            if(!File.Exists("CafetariaCardManagement/OrderDetails.csv")) {
                File.Create("CafetariaCardManagement/OrderDetails.csv").Close();
                System.Console.WriteLine("file created.");
            } else {
                System.Console.WriteLine("File already exists ....");
            }

            if(!File.Exists("CafetariaCardManagement/CartItem.csv")) {
                File.Create("CafetariaCardManagement/CartItem.csv").Close();
                System.Console.WriteLine("file created.");
            } else {
                System.Console.WriteLine("File already exists ....");
            }
            



        }


    //     static CustomList<UserDetails> userList = new CustomList<UserDetails>();
    // static CustomList<FoodDetails> foodList = new CustomList<FoodDetails>();
    // static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
    // static CustomList<CartItems> cartlist = new CustomList<CartItems>();

        public static void WriteToCSV() {

            string[] user = new string[Operations.userList.Count];
            string[] food = new string[Operations.foodList.Count];
            string[] order = new string[Operations.orderList.Count];
            string[] cart = new string[Operations.cartlist.Count];


            // string name, string fatherName, long mobile, string mailId, Gender gender, string workStationNumber, double walletBalance)
        // : base(name, fatherName, gender, mobile, mailId

        // _userId = user[0];
        //     Name = user[1];
        //     FatherName = user[2];
        //     Gender = Enum.Parse<Gender>(user[3]);
        //     Mobile = long.Parse(user[4]);
        //     MailID = user[5];
        //     _balance = double.Parse(user[6]);
        //     WorkStationNumber = user[7];

            try
            {
                for(int i = 0 ; i < Operations.userList.Count ; i++) {
                user[i] = Operations.userList[i].UserID + "," + Operations.userList[i].Name + "," + Operations.userList[i].FatherName + "," + Operations.userList[i].Gender + "," + Operations.userList[i].Mobile + "," + Operations.userList[i].MailID + "," + Operations.userList[i].WalletBalance + "," + Operations.userList[i].WorkStationNumber;
            }
            }
            catch (System.NullReferenceException)
            {
                
                System.Console.WriteLine("Null reference");
            }

            File.WriteAllLines("CafetariaCardManagement/UserDetails.csv",user);


            // (string userId, DateTime orderDate, double totalPrice, Status status)

            for(int i = 0 ; i < Operations.orderList.Count ; i++) {
                order[i] = Operations.orderList[i].OrderID + "," + Operations.orderList[i].UserID + "," + Operations.orderList[i].OrderDate + "," + Operations.orderList[i].TotalPrice + "," + Operations.orderList[i].Status;
            }

            File.WriteAllLines("CafetariaCardManagement/OrderDetails.csv",order);

            // string foodName, double foodPrice, int availableQuantity

            for(int i = 0 ; i < Operations.foodList.Count ; i++) {
                food[i] = Operations.foodList[i].FoodID + "," + Operations.foodList[i].FoodName + "," + Operations.foodList[i].FoodPrice + "," + Operations.foodList[3].AvailableQuantity;
            }

            File.WriteAllLines("CafetariaCardManagement/FoodDetails.csv",food);

            //  s_id++;
            // _itemId = "ITID" + s_id;
            // OrderID = orderId;
            // FoodID = foodId;
            // OrderPrice = orderPrice;
            // OrderQuantity = orderQuantity;

            //    _itemId = cart[0];
            // OrderID = cart[1];
            // FoodID = cart[2];
            // OrderPrice = double.Parse(cart[2]);
            // OrderQuantity = int.Parse(cart[3]);

            // _itemId = cart[0];
            // OrderID = cart[1];
            // FoodID = cart[2];
            // OrderPrice = double.Parse(cart[2]);
            // OrderQuantity = int.Parse(cart[3]);

            for(int i = 0 ; i < Operations.cartlist.Count ; i++) {
                cart[i] = Operations.cartlist[i].OrderID + "," + Operations.cartlist[i].FoodID + "," + Operations.cartlist[i].OrderPrice + "," + Operations.cartlist[i].OrderQuantity;
            }

            File.WriteAllLines("CafetariaCardManagement/CartItem.csv",cart);
            




        }

        public static void ReadToCSV() {
            string[] readUser = File.ReadAllLines("CafetariaCardManagement/userDetails.csv");
            string[] readFood = File.ReadAllLines("CafetariaCardManagement/FoodDetails.csv");
            string[] readOrder = File.ReadAllLines("CafetariaCardManagement/OrderDetails.csv");
            string[] readCart = File.ReadAllLines("CafetariaCardManagement/CartItem.csv");

            foreach(var u in readUser) {
                UserDetails newUser = new UserDetails(u);
                Operations.userList.Add(newUser);
            }
            foreach(var u in readFood) {
                FoodDetails newFood = new FoodDetails(u);
                Operations.foodList.Add(newFood);
            }
            foreach(var u in readOrder) {
                OrderDetails newOrd = new OrderDetails(u);
                Operations.orderList.Add(newOrd);
            }
            foreach(var u in readCart) {
                CartItems newCart = new CartItems(u);
                Operations.cartlist.Add(newCart);
            }
        }


    }
}