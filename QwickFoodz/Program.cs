using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Threading;
using QwickFoodz;

class Program {

//  list for storing Customer details
    public static List<CustomerDetails> users = new List<CustomerDetails>();
    //  list for storing FoodDetails details
    public static List<FoodDetails> foods = new List<FoodDetails>();
    //  list for storing OrderDetails 
    public static List<OrderDetails> orders = new List<OrderDetails>();
    //  list for storing ItemDetails 
    public static List<ItemDetails> items = new List<ItemDetails>();
    public static void Main(string[] args)
    {
        // To initialize default data
        InitializeDefaultData();
        // To show the mainmenu
        ShowMainMenu();
    }

    private static void ShowMainMenu()
    {
        
        // Create an online application for Food Delivery Platform.
        // The application will show the following main menu.
        // 1.	Customer Registration
        // 2.	Customer Login
        // 3.	Exit

        // A flag to exit
        bool mainFlag = true;
        while(mainFlag) {
            System.Console.WriteLine("Welcome to QwickFoodz");
            System.Console.WriteLine("1. Customer Registration");
            System.Console.WriteLine("2. Customer Login");
            System.Console.WriteLine("3. Exit");
            System.Console.WriteLine("Enter your choice : ");
            int choice = int.Parse(Console.ReadLine());
            switch(choice) {
                case 1: {
                    // method for user registration
                    CustomerRegistration();
                    break;
                }

                case 2: {
                    // method for user login
                    CustomerLogin();
                    break;
                }
                case 3:{
                    mainFlag = false;
                    break;
                }
            }
                
            
        }



    }

    private static void CustomerLogin()
    {
        //         2.	Customer Login

        // a.	Get CustomerID from user and check whether his CustomerID exists. If not means show “Invalid user ID”.  If exists means Show following sub menu.

        // i.	Show Profile
        // ii.	Order Food
        // iii.	Cancel Order
        // iv.	Modify Order 
        // v.	Order History

        System.Console.WriteLine("enter customer id :");
        string enteredCustomerId = Console.ReadLine();
        // validating the enteredCustomerId
        CustomerDetails validatedEnteredUserId = users.Find(u => u.CustomerId == enteredCustomerId);
        if(validatedEnteredUserId != null) {
            ShowSubMenu(validatedEnteredUserId);
        } else {
            System.Console.WriteLine("Invalid User id.");
        }

    }

    private static void ShowSubMenu(CustomerDetails loggeduser)
    {
        // to exit from submenu
        bool subFlag = true;
        while(subFlag){
        System.Console.WriteLine("1. Show Profile");
        System.Console.WriteLine("2. Order Food");
        System.Console.WriteLine("3. Cancel Order");
        System.Console.WriteLine("4. Modify order");
        System.Console.WriteLine("5. Order History");
        System.Console.WriteLine("6.Recharge Wallet");
        System.Console.WriteLine("7. Show Wallet Balance");
        System.Console.WriteLine("8. Exit");
        System.Console.WriteLine();

        int userChoice = int.Parse(Console.ReadLine());
        switch(userChoice) {
            case 1: {
                // To show user details
                ShowProfile(loggeduser);
                break;
            }
            case 2:{
                // To order Food
                OrderFood(loggeduser);
                break;
            }
            case 3:{
                // To cancel the order
                CancelOrder(loggeduser);
                break;
            }
            case 4: {
                // To modigfy the order
                ModifyOrder(loggeduser);
                break;
            }
            case 5:{
                // To show order history
                OrderHistory(loggeduser);
                break;
            }
            case 6: {
                // To recharge wallet
                RechargeWallet(loggeduser);
                break;
                
            }
            case 7:{
                // To show wallet balance
                ShowWalletBalance(loggeduser);
                break;
            }
            case 8:{
                subFlag = false;
                break;
            }
        }
        }
    }

    // To show wallet balance
    private static void ShowWalletBalance(CustomerDetails loggedUser)
    {
        System.Console.WriteLine($"Your balance amount is : {loggedUser.WalletBalance}");
    }

    // To recharge the wallet

    private static void RechargeWallet(CustomerDetails loggeduser)
    {
        System.Console.WriteLine("Enter recharge amount : ");
        double amount = double.Parse(Console.ReadLine());
        loggeduser.WalletRecharge(amount);
        System.Console.WriteLine("Recharge successful");
    }

    // To show the order History
    private static void OrderHistory(CustomerDetails loggeduser)
    {
        // a.	Show the order history of the current logged-in user.
        System.Console.WriteLine("Order id  |   Customer Id |   OrderStatus |   DateOfOrder     |   TotalPrice");
        foreach(var order in orders) {
            if(order.CustomerID == loggeduser.CustomerId) {
                System.Console.Write($"{order.OrderId}  |");
                System.Console.Write($"{order.CustomerID}   |");
                System.Console.Write($"{order.OrderStatus}  |");
                System.Console.Write($"{order.DateOfOrder}  |");
                System.Console.Write($"{order.TotalPrice}     |");
                System.Console.WriteLine();
            }
        }
    }

    // To modify the order
    private static void ModifyOrder(CustomerDetails loggeduser)
    {
        //         a.	Show the orders placed by current logged in user whose order status is booked.
        // b.	Ask OrderID to modify orders
        // c.	Check OrderID is valid, and it is of current user’s and its status is Ordered. Then fetch the item details of corresponding order and show it.
        // d.	Ask ItemID and check ItemID is valid. Then ask user to provide new item quantity.
        // e.	Based on new item quantity the item object needs to be updated its price.
        // f.	If item quantity increased, then item amount will be collected from current user if he has enough balance. If he has no balance, ask him to recharge with that amount and proceed. If the item quantity reduced, then balance amount should be returned to current user.
        // g.	Update the total amount of order and show “Order ID + (OID3001) + modified successfully”.

        ShowCurrentOrders(loggeduser);
        System.Console.WriteLine("Enter order id : ");
        string enteredOrderId = Console.ReadLine();
        OrderDetails validateEnteredOrderId = orders.Find(m => m.OrderId == enteredOrderId);
        ShowItemDetails(loggeduser,validateEnteredOrderId);
        System.Console.WriteLine("Enter Item id:");
        string enteredItemId = Console.ReadLine();
        ItemDetails validateItemId = items.Find(m => m.ItemId == enteredItemId);
        //  validating the enteredOrder id
        if(validateEnteredOrderId != null) {
            System.Console.WriteLine("Enter new quantity : ");
            int modifiedQuantity = int.Parse(Console.ReadLine());
            // To update the price
            UpdatePrice(loggeduser,modifiedQuantity,validateItemId,validateEnteredOrderId);
        } else {
            System.Console.WriteLine("Order id is inavlid .");
        }

        System.Console.WriteLine($"Order Id + {validateEnteredOrderId.OrderId}  + modified successfully");
        

    }

// To show Item details
    private static void ShowItemDetails(CustomerDetails loggeduser , OrderDetails order)
    {
        System.Console.WriteLine("List of available ids");
       foreach(var item in items) {
        if(item.OrderId == order.OrderId) {
            System.Console.Write($"{item.ItemId}    |");
            System.Console.Write($"{item.FoodId}    |");
            System.Console.Write($"{item.OrderId}   |");
            System.Console.Write($"{item.PriceOfOrder}     |");
            System.Console.Write($"{item.PurchaseCount}    |");
            System.Console.WriteLine();
            
        }
       }
    }

    // To update the price after modifying
    private static void UpdatePrice(CustomerDetails loggedUser, int quantity , ItemDetails validItems ,OrderDetails validOrder)
    {
         //         a.	Show the orders placed by current logged in user whose order status is booked.
        // b.	Ask OrderID to modify orders
        // c.	Check OrderID is valid, and it is of current user’s and its status is Ordered. Then fetch the item details of corresponding order and show it.
        // d.	Ask ItemID and check ItemID is valid. Then ask user to provide new item quantity.
        // e.	Based on new item quantity the item object needs to be updated its price.
        // f.	If item quantity increased, then item amount will be collected from current user if he has enough balance. If he has no balance, ask him to recharge with that amount and proceed. If the item quantity reduced, then balance amount should be returned to current user.
        // g.	Update the total amount of order and show “Order ID + (OID3001) + modified successfully”.


        // calculating the difference amount
        int diff = quantity - validItems.PurchaseCount;
        // getting the food details
        FoodDetails food = foods.Find(m => m.FoodId == validItems.FoodId);
        // Calculating the total amount
        double amount = Math.Abs(diff) * food.PricePerQuantity;
        if(diff > 0) {
            if(loggedUser.WalletBalance >= amount) {
                loggedUser.WalletBalance -= amount;
                validOrder.TotalPrice += amount;
            } else {
                System.Console.WriteLine("Insufficent balance.");
                System.Console.WriteLine($"Recharge with the amount {loggedUser.WalletBalance - amount}");
            }
        } else {
            double returnAmount = Math.Abs(diff) * food.PricePerQuantity;
            loggedUser.WalletBalance += returnAmount;
            validOrder.TotalPrice -= amount;
        }
        
    }

    // To cancel the order

    private static void CancelOrder(CustomerDetails loggeduser)
    {
        //         iii.	Cancel Order:
        // a.	Show the list of orders placed by current logged in user whose status is “Ordered”.
        // b.	Ask the user to pick an order to be cancelled by OrderID.
        // c.	If OrderID is present, then change the order status to “Cancelled”. Refund the total price amount of current order to user’s WalletBalance then return the food items of the current order to FoodList. 

        // To show the current orders of logged in user
        ShowCurrentOrders(loggeduser);
        System.Console.WriteLine("Pick an order to cancel : ");
        string selectedOrderId = Console.ReadLine();
        // validating the selected order id
        OrderDetails validatedSelectedOrderId = orders.Find(o => o.OrderId == selectedOrderId && o.OrderStatus == OrderStatus.Ordered);
        if(validatedSelectedOrderId != null) {
            validatedSelectedOrderId.OrderStatus = OrderStatus.Cancelled;
            loggeduser.WalletBalance += validatedSelectedOrderId.TotalPrice;
            List<ItemDetails> currentItems = items.FindAll(m => m.OrderId == validatedSelectedOrderId.OrderId);

            RevertBackToFoodDetails(loggeduser,currentItems);
            System.Console.WriteLine("Order cancelled successfully.");
        }

    }

// To show the current orders
    private static void ShowCurrentOrders(CustomerDetails loggeduser)
    {
        // Fetching all the orders with same customer id and order status as booked.
        List<OrderDetails> currentOrders = orders.FindAll(o => o.CustomerID == loggeduser.CustomerId && o.OrderStatus == OrderStatus.Ordered);
        System.Console.WriteLine("OrderId   |   CutomerId   |   OrderStatus |   DateOfOrder |   TotalPrice");
        foreach(var order in currentOrders) {
            System.Console.Write($"{order.OrderId}   |");
            System.Console.Write($"{order.CustomerID}   |");
            System.Console.Write($"{order.OrderStatus}  |");
            System.Console.Write($"{order.DateOfOrder}  |");
            System.Console.Write($"{order.TotalPrice}   |");
            System.Console.WriteLine();
           
        }
    }

// To order food
    private static void OrderFood(CustomerDetails loggeduser)
    {
        
        // ii.	Order Food:
        // a.	Create OrderDetails object with CustomerID, TotalPrice = 0, DateOfOrder as today and OrderStatus = Initiated.
        // b.	Create localItemList for adding your wishlist.
        // c.	Show all the list of food items available in store for processing the order.
        // d.	Ask the FoodID, order quantity from user and check whether it is available. If not show FoodID Invalid or FoodQuantity unavailable based on the scenario. 
        // e.	If it is available then, create ItemDetails object with created OrderID, FoodID, Quantity and Price of this order, deduct the available quantity and store the ItemDetails object in localItemList. Calculate total price of this order by summing it with current item’s price. 
        // f.	Ask the user whether he want to order more. If “Yes” means again show food details and repeat from step “c” to create new ItemDetails object. Repeat this process until he says “No”.
        // g.	If user select “No” then show “Do you want to confirm purchase.” If he says “No” return the localItemList of items count back to FoodDetails list.

        bool orderPlaced = false;
        while(!orderPlaced) {
            // creating temporary order
            OrderDetails tempOrder = new OrderDetails(loggeduser.CustomerId,0,DateTime.Now,OrderStatus.Initiated);
            // creating temporary cart
            List<ItemDetails> tempCart = new List<ItemDetails>();

            bool ordAgain = true;
            while(ordAgain) {
            ShowAvailableFoodItems(loggeduser);
            System.Console.WriteLine("Enter Food Id : ");
            string selectedFoodId = Console.ReadLine();
            // validating selected food id
            FoodDetails validatedSelectedFoodId = foods.Find(f => f.FoodId == selectedFoodId);
            if(validatedSelectedFoodId != null) {
                System.Console.WriteLine("Enter required qyuantity");
                int enteredQuantity = int.Parse(Console.ReadLine());
                // checking whether quantity is available or not
                if(validatedSelectedFoodId.QuantityAvailable >= enteredQuantity) {
                    double purchasePrice = validatedSelectedFoodId.PricePerQuantity * enteredQuantity;
                    ItemDetails newItem = new ItemDetails(tempOrder.OrderId,validatedSelectedFoodId.FoodId,enteredQuantity,purchasePrice);
                    validatedSelectedFoodId.QuantityAvailable -= enteredQuantity;
                    tempCart.Add(newItem);
                    System.Console.WriteLine("Added to cart successfully.");
                } else {
                    System.Console.WriteLine("selected Quantity is not available.");
                }
                // calling order again method to ask user whether he would buy again
                if(OrderAgain(loggeduser) == false) {
                    System.Console.WriteLine("Do you want to confirm purchase : yes/no");
                    string purchaseConfirmation = Console.ReadLine().ToLower();
                    if(purchaseConfirmation == "no") {

                                                // h.	If he says “Yes”. 
                        // i.	Check whether the customer wallet has sufficient balance.
                        // j.	 If he has balance then, modify OrderDetails object which was created at beginning with TotalPrice and OrderStatus to “Ordered”. Deduct the total amount from user’s wallet balance. Add the localItemList to ItemList. 
                        // k.	If the balance is insufficient, inform the customer that the wallet has insufficient balance and whether wish to recharge /not.
                        // l.	If he says “No” return the localItemList item’s count to FoodList.
                        // m.	If “Yes” ask for the amount to be recharged. Show the balance after recharge and goto step “i” to proceed purchase again.

                        
                        // Reverting the quantity to the food details
                        RevertBackToFoodDetails(loggeduser,tempCart);
                        System.Console.WriteLine("Order cancelled successfully.");
                        ordAgain = false;
                        orderPlaced = true;
                    } else {
                        // Placing the order
                        PurchaseOrder(loggeduser,tempCart,tempOrder);
                        orderPlaced = true;
                        ordAgain = false;
                    }
                } 
            } else {
                System.Console.WriteLine("Invalid Food Id.");
            }
            }
        }


    }

// to purchase the order
    private static void PurchaseOrder(CustomerDetails loggeduser, List<ItemDetails> tempCart, OrderDetails tempOrder)
    {
        // i.	Check whether the customer wallet has sufficient balance.
                        // j.	 If he has balance then, modify OrderDetails object which was created at beginning with TotalPrice and OrderStatus to “Ordered”. Deduct the total amount from user’s wallet balance. Add the localItemList to ItemList. 
                        // k.	If the balance is insufficient, inform the customer that the wallet has insufficient balance and whether wish to recharge /not.

                        // calculating the order price.
                        double totalPrice = tempCart.Sum(m => m.PriceOfOrder);
                        if(loggeduser.WalletBalance >= totalPrice) {
                            tempOrder.TotalPrice = totalPrice;
                            tempOrder.OrderStatus = OrderStatus.Ordered;
                            loggeduser.WalletBalance -= totalPrice;
                            items.AddRange(tempCart);
                            orders.Add(tempOrder);
                            System.Console.WriteLine("Order placed successfully.");
                            
                        } else {
                            System.Console.WriteLine("Insuffient funds . Please Recharge");
                            RechargeAgain(loggeduser,tempCart,tempOrder);
                        }
    }


// To rechare if the user has insufficient funds
    private static void RechargeAgain(CustomerDetails loggeduser,List<ItemDetails> tempCart, OrderDetails tempOrder)
    {
            //         k.	If the balance is insufficient, inform the customer that the wallet has insufficient balance and whether wish to recharge /not.
            // l.	If he says “No” return the localItemList item’s count to FoodList.
            // m.	If “Yes” ask for the amount to be recharged. Show the balance after recharge and goto step “i” to proceed purchase again.
            System.Console.WriteLine("Do you want to recharge , yes/no");
            string rechargeOption = Console.ReadLine().ToLower();
            if(rechargeOption == "yes"){
                System.Console.WriteLine("enter amount to recharge :");
                double enteredAmount = double.Parse(Console.ReadLine());
                loggeduser.WalletBalance += enteredAmount;
                System.Console.WriteLine($"Your balance amount is : {loggeduser.WalletBalance}");
                PurchaseOrder(loggeduser,tempCart,tempOrder);
            }

    }


// reveting back to the previous state of food details
    private static void RevertBackToFoodDetails(CustomerDetails loggeduser, List<ItemDetails> tempCart)
    {
        foreach(var item in tempCart) {
            FoodDetails revertQuantity = foods.Find(m => m.FoodId == item.FoodId);
            revertQuantity.QuantityAvailable += item.PurchaseCount;
        }
    }

    // Asking user whether he will buy again

    private static bool OrderAgain(CustomerDetails loggeduser)
    {
        // f.	Ask the user whether he want to order more. If “Yes” means again show food details and repeat from step “c” to create new ItemDetails object. Repeat this process until he says “No”.
        // g.	If user select “No” then show “Do you want to confirm purchase.” If he says “No” return the localItemList of items count back to FoodDetails list.
        System.Console.WriteLine("Do you want to order again , yes/no");
        string orderChoice = Console.ReadLine().ToLower();
        return orderChoice == "yes";
    }

    // showing available food items

    private static void ShowAvailableFoodItems(CustomerDetails loggeduser)
    {
        System.Console.WriteLine("FoodId    |   FoodName    |   PricePerQuantity    |   QuantityAvailable");
        foreach(var food in foods) {
            System.Console.Write($"{food.FoodId}    |");
            System.Console.Write($"{food.FoodName}  |");
            System.Console.Write($"{food.PricePerQuantity}  |");
            System.Console.Write($"{food.QuantityAvailable}   |");
            System.Console.WriteLine();
        }
    }

    // showing the profile of current logged in user

    private static void ShowProfile(CustomerDetails loggedUser)
    {
        System.Console.WriteLine("Customer Id   |   Name    |   FatherName  |   MobileNumber    |   DateOfBirth |   WalletBalance   |   Gender  |   Location    |   MailId");
        System.Console.Write($"{loggedUser.CustomerId}  |");
        System.Console.Write($"{loggedUser.Name}    |");
        System.Console.Write($"{loggedUser.FatherName}  |");
        System.Console.Write($"{loggedUser.MobileNumber}    |");
        System.Console.Write($"{loggedUser.DateOfBirth} |");
        System.Console.Write($"{loggedUser.WalletBalance}   |");
        System.Console.Write($"{loggedUser.Gender}  |");
        System.Console.Write($"{loggedUser.Location}    |");
        System.Console.Write($"{loggedUser.MailId}  |");

    }

    // method for registering the customer

    private static void CustomerRegistration()
    {
        //         1.	Customer Registration:
        // a.	Collect all the details of user. 
        // i.	Name,
        // ii.	FatherName, 
        // iii.	Gender- {Select, Male, Female, Transgender}, 
        // iv.	Mobile, 
        // v.	DOB, 
        // vi.	MailID, 
        // b.	Location and register him as a customer and show: “Customer registration successful Your Customer ID: CID1001.”


        // collecting the details

        System.Console.WriteLine("Welcome to registration process.");
        System.Console.WriteLine("Enter name : ");
        string name = Console.ReadLine();
        System.Console.WriteLine("enter father name : ");
        string fatherName = Console.ReadLine();
        
        Gender gender;
       
        System.Console.WriteLine("Enter gender - Male/Female/Transgender");
        bool validGender = Enum.TryParse(Console.ReadLine(),out gender);
        
        System.Console.WriteLine("enter mobile : ");
        long mobileNumber = long.Parse(Console.ReadLine());
        System.Console.WriteLine("Enter your date of birth : ");
        DateTime dateOfBirth;
        DateTime.TryParseExact(Console.ReadLine(),"dd/MM/yyy",null,System.Globalization.DateTimeStyles.None,out dateOfBirth);
        System.Console.WriteLine("Enter MailId : ");
        string mailId = Console.ReadLine();
        System.Console.WriteLine("enter Location: ");
        string location = Console.ReadLine();
        System.Console.WriteLine("Enter Initial Walletbalance : ");
        double walletBalance = double.Parse(Console.ReadLine());
        
        // creating new customer object
        CustomerDetails newCustomer = new CustomerDetails(walletBalance,name,fatherName,gender,mobileNumber,dateOfBirth,mailId,location);
        // adding user to users list
        users.Add(newCustomer);
        System.Console.WriteLine("Thankyou for registering with us.");
        System.Console.WriteLine($"Customer registration successful Your Customer ID: {newCustomer.CustomerId}");


    }

    // To initialize the default data
    private static void InitializeDefaultData()
    {
        // CustomerID	WalletBalance	Name	FatherName	Gender	Mobile	DOB	MailID	Location
        // CID1001	10000	Ravi	Ettapparajan	Male	974774646	11/11/1999	ravi@gmail.com	Chennai
        // CID1002	15000	Baskaran	Sethurajan	Male	847575775	11/11/1999	baskaran@gmail.com	Chennai
        // User default data

        users.Add(new CustomerDetails(10000,"Ravi","Ettapparajan",Gender.Male,974774646,new DateTime(1999,11,11) , "ravi@gmail.com","Chennai"));
        users.Add(new CustomerDetails(15000,"Baskaran","Sethurajan",Gender.Male,847575775,new DateTime(1999,11,11) , "baskaran@gmail.com","Chennai"));

        // food default details

            // FoodID	FoodName	PricePerQuantity	QuantityAvailable
            // FID101	Chicken Briyani 1Kg	100	12
            // FID102	Mutton Briyani 1Kg	150	10
            // FID103	Veg Full Meals	80	30
            // FID104	Noodles	100	40
            // FID105	Dosa	40	40
            // FID106	Idly (2 pieces)	20	50
            // FID107	Pongal	40	20
            // FID108	Vegetable Briyani	80	15
            // FID109	Lemon Rice	50	30
            // FID110	Veg Pulav	120	30
            // FID111	Chicken 65 (200 Grams)	75	30


            foods.Add(new FoodDetails("Chicken Briyani" , 100 , 12));
            foods.Add(new FoodDetails("Mutton Briyani" , 150 , 10));
            foods.Add(new FoodDetails("Veg full meals" , 80 , 30));
            foods.Add(new FoodDetails("Noodles",100,40));
            foods.Add(new FoodDetails("Dosa",40,40));
            foods.Add(new FoodDetails("Idly",20,50));
            foods.Add(new FoodDetails("Pongal",40,20));
            foods.Add(new FoodDetails("Vegetable Briyani",80,15));
            foods.Add(new FoodDetails("Lemon Rice",120,30));
            foods.Add(new FoodDetails("Veg Pulav",40,20));
            foods.Add(new FoodDetails("Chicken 65",75,30));
            
            // Default order details

        //             OrderID	CustomerID	TotalPrice	DateOfOrder	OrderStatus
        // OID3001	CID1001	580	26/11/2022	Ordered
        // OID3002	CID1002	870	26/11/2022	Ordered
        // OID3003	CID1001	820	26/11/2022	Cancelled

            orders.Add(new OrderDetails("CID1001",580,new DateTime(2022,11,26) ,OrderStatus.Ordered));
            orders.Add(new OrderDetails("CID1002",870,new DateTime(2022,11,26) ,OrderStatus.Ordered));
            orders.Add(new OrderDetails("CID1001",820,new DateTime(2022,11,26) ,OrderStatus.Ordered));



            //             Default objects for ItemDetails class:
            // ItemID	OrderID	FoodID	PurchaseCount	PriceOfOrder
            // ITID101	OID3001	FID101	2	200
            // ITID102	OID3001	FID102	2	300
            // ITID103	OID3001	FID103	1	80
            // ITID104	OID3002	FID101	1	100
            // ITID105	OID3002	FID102	4	600
            // ITID106	OID3002	FID110	1	120
            // ITID107	OID3002	FID109	1	50
            // ITID108	OID3003	FID102	2	300
            // ITID109	OID3003	FID108	4	320
            // ITID110	OID3003	FID101	2	200

            items.Add(new ItemDetails("OID3001","FID101",2,200));
            items.Add(new ItemDetails("OID3001","FID102",2,300));
            items.Add(new ItemDetails("OID3001","FID103",1,80));
            items.Add(new ItemDetails("OID3002","FID101",1,100));
            items.Add(new ItemDetails("OID3001","FID102",4,600));
            items.Add(new ItemDetails("OID3001","FID110",1,120));
            items.Add(new ItemDetails("OID3001","FID109",1,50));
            items.Add(new ItemDetails("OID3003","FID102",2,300));
            items.Add(new ItemDetails("OID3003","FID108",4,320));
            items.Add(new ItemDetails("OID3003","FID101",2,200));



    }
}