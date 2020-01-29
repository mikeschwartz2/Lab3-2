using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string rerun;
            string userItem;
            double cartTotal = 0;
            int itemsOrdered = 0;
            int i = 0;

            ArrayList orders = new ArrayList();
            ArrayList prices = new ArrayList();

            do
            {
                Dictionary<string, double> inventory = new Dictionary<string, double>();
                inventory["pizza"] = 6.99;
                inventory["burger"] = 4.99;
                inventory["taco"] = 1.99;
                inventory["cake"] = 8.99;
                inventory["steak"] = 15.99;
                inventory["ham"] = 10.99;
                inventory["ice Cream"] = 3.99;
                inventory["salad"] = 5.99;

                foreach (KeyValuePair<string, double> kvPair in inventory)
                {
                    i++;
                    Console.WriteLine($"{i}: {kvPair.Key,10}: ${kvPair.Value,6}");
                }
                               
                Console.Write("Please input an item you would like added to the cart: ");
                userItem = Console.ReadLine();

                if(inventory.ContainsKey(userItem))
                {
                    cartTotal = cartTotal + inventory[userItem];
                    Console.WriteLine($"You added {userItem} to the cart which is ${inventory[userItem]}.");
                    Console.WriteLine($"Your new cart total is: {cartTotal}");
                    
                    orders.Add(userItem);
                    prices.Add(inventory[userItem]);

                    itemsOrdered++;
                }
                else
                {
                    Console.WriteLine("This is not a valid item");
                }

                Console.WriteLine("Would you like to add something else to the cart? y/n ");
                rerun = Console.ReadLine();
                rerun = rerun.ToLower();

                while (rerun != "y" && rerun != "n")
                {
                    Console.WriteLine("This is not a valid input. Would you like to continue: y/n");
                    rerun = Console.ReadLine();
                    rerun = rerun.ToLower();
                }
            }
            while (rerun == "y");

            i = 0;
            if (itemsOrdered != 0)
            {
                Console.WriteLine("============================================");
                Console.WriteLine($"This will be everything ordered");
                while(i < orders.Count)
                {
                    Console.WriteLine($"{orders[i]}: ${prices[i]}");
                    i++;
                }

                Console.WriteLine($"Final cart total: ${cartTotal}");
                Console.WriteLine($"The average price per item is ${cartTotal/itemsOrdered}");

            }
            else
            {
                Console.WriteLine("Nothing was added to the cart. ");
            }
        }
    }
}
