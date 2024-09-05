using System;
using System.Collections.Generic;

namespace CoffeeShopApp
{
    public class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public MenuItem(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} - ${Price:F2}";
        }
    }

    public class Menu
    {
        public List<MenuItem> Items { get; private set; }

        public Menu()
        {
            Items = new List<MenuItem>();
        }

        public void AddItem(string name, double price)
        {
            Items.Add(new MenuItem(name, price));
            Console.WriteLine("Item added to menu successfully!");
        }

        public void ViewMenu()
        {
            if (Items.Count == 0)
            {
                Console.WriteLine("Menu is empty.");
                return;
            }

            Console.WriteLine("Menu:");
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Items[i]}");
            }
        }
    }

    public class Order
    {
        public List<MenuItem> OrderedItems { get; private set; }

        public Order()
        {
            OrderedItems = new List<MenuItem>();
        }

        public void AddToOrder(MenuItem item)
        {
            OrderedItems.Add(item);
            Console.WriteLine("Item added to order successfully!");
        }

        public void ViewOrder()
        {
            if (OrderedItems.Count == 0)
            {
                Console.WriteLine("Your order is empty.");
                return;
            }

            Console.WriteLine("Your Order:");
            foreach (var item in OrderedItems)
            {
                Console.WriteLine(item);
            }
        }

        public double CalculateTotal()
        {
            double total = 0;
            foreach (var item in OrderedItems)
            {
                total += item.Price;
            }
            return total;
        }
    }

    public class CoffeeShop
    {
        private Menu menu;
        private Order order;

        public CoffeeShop()
        {
            menu = new Menu();
            order = new Order();
        }

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Coffee Shop!");
                Console.WriteLine("1. Add Menu Item");
                Console.WriteLine("2. View Menu");
                Console.WriteLine("3. Place Order");
                Console.WriteLine("4. View Order");
                Console.WriteLine("5. Calculate Total");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        menu.ViewMenu();
                        break;
                    case "3":
                        PlaceOrder();
                        break;
                    case "4":
                        order.ViewOrder();
                        break;
                    case "5":
                        CalculateTotal();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private void AddMenuItem()
        {
            Console.Write("Enter item name: ");
            string itemName = Console.ReadLine();

            Console.Write("Enter item price: ");
            if (double.TryParse(Console.ReadLine(), out double itemPrice))
            {
                menu.AddItem(itemName, itemPrice);
            }
            else
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
            }
        }

        private void PlaceOrder()
        {
            menu.ViewMenu();
            if (menu.Items.Count == 0) return;

            Console.Write("Enter the item number to order: ");
            if (int.TryParse(Console.ReadLine(), out int itemNumber) && itemNumber > 0 && itemNumber <= menu.Items.Count)
            {
                order.AddToOrder(menu.Items[itemNumber - 1]);
            }
            else
            {
                Console.WriteLine("Invalid item number.");
            }
        }

        private void CalculateTotal()
        {
            double total = order.CalculateTotal();
            if (total == 0)
            {
                Console.WriteLine("No items in the order to calculate.");
            }
            else
            {
                Console.WriteLine($"Total Amount Payable: ${total:F2}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CoffeeShop shop = new CoffeeShop();
            shop.Run();
        }
    }
}
