using System;
using System.Collections.Generic;
namespace CafetariaCardManagement;


public static class Operations
{
    public static CustomList<UserDetails> userList = new CustomList<UserDetails>();
    public static CustomList<FoodDetails> foodList = new CustomList<FoodDetails>();
    public static CustomList<OrderDetails> orderList = new CustomList<OrderDetails>();
    public static CustomList<CartItems> cartlist = new CustomList<CartItems>();
    static UserDetails currentLoggedInUser;
   
    public static void AddDefaultData()
    {
        userList.Add(new UserDetails("Ravichandran", "Ettaparajan", 8857777575, "ravi@gmail.com", Gender.Male, "WS101", 400));
        userList.Add(new UserDetails("Baskaran", "Sethurajan", 9577747744, "baskaran@gmail.com", Gender.Male, "WS105", 500));
        //System.Console.WriteLine($"Used added!");

        orderList.Add(new OrderDetails("SF1001", new DateTime(2022, 06, 15), 70, Status.Ordered));
        orderList.Add(new OrderDetails("SF1002", new DateTime(2022, 06, 15), 100, Status.Ordered));
        //System.Console.WriteLine("Order list added");

        cartlist.Add(new CartItems("OID1001", "FID101", 20, 1));
        cartlist.Add(new CartItems("OID1001", "FID103", 10, 1));
        cartlist.Add(new CartItems("OID1001", "FID105", 40, 1));
        cartlist.Add(new CartItems("OID1002", "FID103", 10, 1));
        cartlist.Add(new CartItems("OID1002", "FID104", 50, 1));
        cartlist.Add(new CartItems("OID1002", "FID105", 40, 1));
        //System.Console.WriteLine("Cart details added");

        foodList.Add(new FoodDetails("Coffee", 20, 100));
        foodList.Add(new FoodDetails("Tea", 15, 100));
        foodList.Add(new FoodDetails("Biscut", 10, 100));
        foodList.Add(new FoodDetails("Juice", 50, 100));
        foodList.Add(new FoodDetails("Puff", 40, 100));
        foodList.Add(new FoodDetails("Milk", 10, 100));
        foodList.Add(new FoodDetails("Popcorn", 20, 20));
        //System.Console.WriteLine("Food details added!");
    }
    public static void PrintDetails()
    {
        foreach (UserDetails user in userList)
        {
            System.Console.WriteLine($"{user.UserID}\t|{user.Name,-10}\t|{user.FatherName,-10}\t|{user.Mobile,-10}\t|{user.MailID,-15}\t|{user.Gender,-10}\t|{user.WorkStationNumber,-10}\t|{user.WalletBalance,-10}\t");
        }
        System.Console.WriteLine();
        foreach (OrderDetails order in orderList)
        {
            System.Console.WriteLine($"{order.OrderID}\t|{order.UserID}\t|{order.OrderDate.ToString("dd/MM/yyyy")}\t|{order.TotalPrice}\t|{order.Status}\t");
        }
        System.Console.WriteLine();
        foreach (CartItems cart in cartlist)
        {
            System.Console.WriteLine($"{cart.ItemID}\t|{cart.OrderID}\t|{cart.FoodID}\t|{cart.OrderPrice}\t|{cart.OrderQuantity}\t");
        }
        System.Console.WriteLine();
        foreach (FoodDetails food in foodList)
        {
            System.Console.WriteLine($"{food.FoodID,-10}\t|{food.FoodName,-10}\t|{food.FoodPrice,-10}\t|{food.AvailableQuantity}\t");
        }
    }
    public static void Register()
    {
        System.Console.WriteLine("You are inside Register method");
        //get user name, father name, mobile number, mail id, gender, workstation number, balance
        System.Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();

        System.Console.WriteLine("Enter Father Name:");
        string fatherName = Console.ReadLine();

        bool tempPhone;
        long mobile;
        do
        {
            System.Console.WriteLine("Enter mobile number:");
            tempPhone = long.TryParse(Console.ReadLine(), out mobile);
        } while (!tempPhone);

        System.Console.WriteLine("Enter Mail ID:");
        string mail = Console.ReadLine();

        bool tempGender;
        Gender gender;
        do
        {
            System.Console.WriteLine("Enter Gender : Male/ Female/ TransGender");
            tempGender = Gender.TryParse(Console.ReadLine(), true, out gender);
        } while (!tempGender);

        System.Console.WriteLine("Enter work Station number:");
        string workStation = Console.ReadLine();

        bool tempBalance;
        long balance;
        do
        {
            System.Console.WriteLine("Enter balance:");
            tempBalance = long.TryParse(Console.ReadLine(), out balance);
        } while (!tempBalance);
        //create an object for user details class
        UserDetails user = new UserDetails(name, fatherName, mobile, mail, gender, workStation, balance);
        //add the object in the user details class
        userList.Add(user);
        //show user ID to user
        System.Console.WriteLine($"You have registered Successfully.. Your user ID is {user.UserID}");
    }
    public static void Login()
    {
        System.Console.WriteLine("you are inside Login method");
        //ask for the user ID of the user
        System.Console.WriteLine("Enter the user ID:");
        string userId = Console.ReadLine().ToUpper();
        int count = 0;
        //check the user id in user list
        foreach (UserDetails user in userList)
        {
            if (userId == user.UserID)
            {
                count++;
                currentLoggedInUser = user;
                System.Console.WriteLine($"Welcome {user.Name}\n");
                SubMenu();
            }
        }
        //if not present, show invalid
        if (count == 0)
        {
            System.Console.WriteLine("Invalid User ID");
        }
    }
    public static void SubMenu()
    {
        bool check = true;
        do
        {
            System.Console.WriteLine("Choose the Options:\na.Show my profile\nb.food Order\nc.Cancel Order\nd.Order History\ne.Wallet Recharge\nf.Show Wallet Balance\ng.Exit\n");
            char option = char.Parse(Console.ReadLine());
            switch (option)
            {
                case 'a':
                    {
                        ShowMyProfile();
                        break;
                    }
                case 'b':
                    {
                        FoodOrder();
                        break;
                    }
                case 'c':
                    {
                        CancelOrder();
                        break;
                    }
                case 'd':
                    {
                        OrderHistory();
                        break;
                    }
                case 'e':
                    {
                        WalletRecharge();
                        break;
                    }
                case 'f':
                    {
                        ShowWalletBalance();
                        break;
                    }
                case 'g':
                    {
                        check = false;
                        System.Console.WriteLine("switching back to main menu");
                        break;
                    }
                default:
                    {
                        System.Console.WriteLine("Invalid Option!");
                        break;
                    }
            }
        } while (check);
    }
    public static void ShowMyProfile()
    {
        //show current logged in user
        System.Console.WriteLine($"User ID : {currentLoggedInUser.UserID,10}\nName : {currentLoggedInUser.Name,-10}\nFather's Name :{currentLoggedInUser.FatherName,-10}\nMobile Number : {currentLoggedInUser.Mobile,-10}\nMail ID: {currentLoggedInUser.MailID,-15}\ntGender: {currentLoggedInUser.Gender,-10}\nWork Station Number: {currentLoggedInUser.WorkStationNumber,-10}\n");
    }
    public static void FoodOrder()
    {
        //Create a temporary local carItemtList.
        CustomList<CartItems> tempCartList = new CustomList<CartItems>();

        //Create an Order object with current UserID, Order date as current DateTime, total price as 0, Order status as “Initiated”.
        OrderDetails order = new OrderDetails(currentLoggedInUser.UserID, DateTime.Now, 0, Status.Initiated);
        string choice = "";
        do
        {
            foreach (FoodDetails food in foodList)
            {
                System.Console.WriteLine($"{food.FoodID,-10}\t|{food.FoodName,-10}\t|{food.FoodPrice,-5}\t|{food.AvailableQuantity}\t");
            }
            //Ask the user to pick a product using FoodID
            System.Console.WriteLine("Enter the Food ID:");
            string foodId = Console.ReadLine().ToUpper();
            int count = 0;
            foreach (FoodDetails food in foodList)
            {
                if (foodId == food.FoodID)
                {
                    count++;
                    System.Console.WriteLine("Enter the quantity:");
                    int quantity = int.Parse(Console.ReadLine());
                    double price;

                    //If the food and quantity available, reduce the quantity from the food object’s “AvailableQuantity” 
                    if (quantity <= food.AvailableQuantity)
                    {
                        food.AvailableQuantity -= quantity;
                        price = food.FoodPrice * quantity;
                        //then create CartItems object using the available data.
                        CartItems cart = new CartItems(order.OrderID, food.FoodID, price, quantity);
                        tempCartList.Add(cart);
                        System.Console.WriteLine("\nAdded to cart!\n");
                    }
                    else
                    {
                        System.Console.WriteLine("\nQuantity not available!\n");
                    }
                }
            }
            if (count == 0)
            {
                
                System.Console.WriteLine("Invalid Input!");
                
            }
            //Ask the user whether he want to pick another product. 
            System.Console.WriteLine("Do you want to pick another product? type yes or no");
            choice = Console.ReadLine();
            
        } while (choice == "yes");

        //ask whether the user want to purchase the wish list
        string confirm = "";
        System.Console.WriteLine("Do you want to confirm? type yes or no");
        confirm = Console.ReadLine().ToLower();

        //If no, traverse the cart items list and return the quantity to the product available quantity
        if (confirm == "no")
        {
            foreach (CartItems items in tempCartList)
            {
                foreach (FoodDetails food in foodList)
                {
                    if (items.FoodID == food.FoodID)
                    {
                        food.AvailableQuantity += items.OrderQuantity;
                    }
                }
            }
        }
        //If he says “Yes” then, Calculate the total price of the food items selected using the local CartItemList information and 

        else if (confirm == "yes")
        {
            double totalPrice = 0;
            foreach (CartItems items in tempCartList)
            {
                totalPrice += items.OrderPrice;
            }
            //check the balance from the user details whether it has sufficient balance to purchase.
            if (currentLoggedInUser.WalletBalance >= totalPrice)
            {
                //If he has enough balance, then deduct the respective amount from the user’s balance. 
                currentLoggedInUser.DeductAmount(totalPrice);

                //Append the local CartItemList to global CartItemList.
                cartlist.AddRange(tempCartList);

                //Modify Order object created at step 1’s total price as total OrderPrice and OrderStatus as “Ordered”. 
                order.TotalPrice = totalPrice;
                order.Status = Status.Ordered;

                //15.	Then add the Order object to the Order list.
                orderList.Add(order);
                System.Console.WriteLine($"\nOrder palced successfully..Your order ID is {order.OrderID}\n");
            }
            else
            {
                System.Console.WriteLine("Insufficient balance... Are you willing to recharge? type yes / no : ");
                string willing = Console.ReadLine().ToLower();
                if (willing == "no")
                {
                    System.Console.WriteLine("\nExiting without Order due to insufficient balance\n");
                    foreach (CartItems items in tempCartList)
                    {
                        foreach (FoodDetails food in foodList)
                        {
                            if (items.FoodID == food.FoodID)
                            {
                                food.AvailableQuantity += items.OrderQuantity;
                            }
                        }
                    }
                }
                //If he says “Yes”. Then ask him to Recharge with the total price of Order. If he recharged with that amount means continue from step 12 to continue purchase. 
                else if (willing == "yes")
                {
                    double balanceAmount = totalPrice - currentLoggedInUser.WalletBalance;
                    double amount;
                    do
                    {
                        System.Console.WriteLine($"\nYour missing amount is {balanceAmount}. Kindly recharge the amount\nEnter the missed out amount to recharge\n");
                        amount = double.Parse(Console.ReadLine());
                    } while (amount < balanceAmount);
                    currentLoggedInUser.WalletRecharge(amount);

                    //If he has enough balance, then deduct the respective amount from the user’s balance. 
                    currentLoggedInUser.DeductAmount(totalPrice);

                    //Append the local CartItemList to global CartItemList.
                    cartlist.AddRange(tempCartList);

                    //Modify Order object created at step 1’s total price as total OrderPrice and OrderStatus as “Ordered”. 
                    order.TotalPrice = totalPrice;
                    order.Status = Status.Ordered;

                    //15.	Then add the Order object to the Order list.
                    orderList.Add(order);
                    System.Console.WriteLine($"\nOrder palced successfully..Your order ID is {order.OrderID}\n");
                }
            }
        }
    }
    public static void CancelOrder()
    {
        //Show the Order details of the current user who’s Order status is “Ordered”.
        bool checkCount = false;
        foreach (OrderDetails order in orderList)
        {
            if (currentLoggedInUser.UserID == order.UserID && order.Status == Status.Ordered)
            {
                checkCount = true; ;
                System.Console.WriteLine($"{order.OrderID}\t|{order.UserID}\t|{order.OrderDate.ToString("dd/MM/yyyy")}\t|{order.TotalPrice}\t|{order.Status}\t");
            }
        }
        if (checkCount)
        {
            //Ask the user to pick an OrderID to cancel. Check the OrderID is valid. If not, then show “Invalid OrderID”
            System.Console.WriteLine("Enter the order ID to cancel:");
            string orderId = Console.ReadLine().ToUpper();
            int count = 0;
            foreach (OrderDetails order in orderList)
            {
                if (orderId == order.OrderID)
                {
                    count++;
                    //•	If valid, then Return the Order total amount to current user. 
                    currentLoggedInUser.WalletRecharge(order.TotalPrice);

                    //traverse the cart items list and select the order ID
                    foreach (CartItems cart in cartlist)
                    {
                        //check whether the order id in cartlist is equal to order id in order list
                        if (cart.OrderID == order.OrderID)
                        {
                            foreach (FoodDetails food in foodList)
                            {
                                if (food.FoodID == cart.FoodID)
                                {
                                    //•	Return product orderQuantity to Foodtem list’s Food Quantity. 
                                    food.AvailableQuantity += cart.OrderQuantity;
                                }
                            }
                        }
                    }
                    order.Status = Status.Cancelled;
                    System.Console.WriteLine("\nYour order cancelled successfully\n");
                }
            }
            if (count == 0)
            {
                System.Console.WriteLine("Invalid Order ID!");
            }
        }
        else
        {
            System.Console.WriteLine("Nothing to cancel");
        }
    }
    public static void OrderHistory()
    {
        int count = 0;
        foreach (OrderDetails order in orderList)
        {
            if (currentLoggedInUser.UserID == order.UserID)
            {
                count++;       
                System.Console.WriteLine($"{order.OrderID}\t|{order.UserID}\t|{order.OrderDate.ToString("dd/MM/yyyy")}\t|{order.TotalPrice}\t|{order.Status}\t");
            }
        }
        if(count==0)
            Console.WriteLine("You have no orders yet");
    }
    public static void WalletRecharge()
    {

        bool temp;
        double amount;
        do
        {
            System.Console.WriteLine("Enter the amount to recharge");
            temp = double.TryParse(Console.ReadLine(), out amount);
        } while (!temp);
        currentLoggedInUser.WalletRecharge(amount);
        System.Console.WriteLine($"Your new wallet balance is {currentLoggedInUser.WalletBalance}");
    }
    public static void ShowWalletBalance()
    {
        System.Console.WriteLine($"Your wallet balance is {currentLoggedInUser.WalletBalance}");
    }
}

