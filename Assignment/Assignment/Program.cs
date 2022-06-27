// Add libraries here
using System;
using System.Collections.Generic;

namespace Lab1
{
    class Product
    {
        // data members for the product class
        public string Name;
        public double Price;
        public string Code;

        // getters
        public string GetName()
        {
            return Name;
        }
        public double GetPrice()
        {
            return Price;
        }
        public string GetCode()
        {
            return Code;
        }

        // setters
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetPrice(double price)
        {
            Price = price;
        }
        public void SetCode(string code)
        {
            Code = code;
        }

        // constructor
        public Product(string name, double price, string code)
        {
            Name = name;
            Price = price;
            Code = code;
        }
    }

    class vendingMachine
    {
        // data members for the vending machine class
        public int SerialNumber;
        public Dictionary<int, int> MoneyFloat;
        public Dictionary<Product, int> Inventory;

        // add constructor with one parameter
        public vendingMachine(int serialNumber)
        {
            SerialNumber = serialNumber;
            MoneyFloat = new Dictionary<int, int>();
            Inventory = new Dictionary<Product, int>();
        }
        // getters
        public int GetSerialNumber()
        {
            return SerialNumber;
        }

        public Dictionary<int, int> GetMoneyFloat()
        {
            return MoneyFloat;
        }

        public Dictionary<Product, int> GetInventory()
        {
            return Inventory;
        }

        // setters
        public void SetSerialNumber(int serialNumber)
        {
            SerialNumber = serialNumber;
        }

        public void SetMoneyFloat(Dictionary<int, int> moneyFloat)
        {
            MoneyFloat = moneyFloat;
        }

        public void SetInventory(Dictionary<Product, int> inventory)
        {
            Inventory = inventory;
        }

        // add StockItem method but with different logic
        public string StockItem(Product product, int quantity)
        {
            // check if the product is already in the inventory
            if (Inventory.ContainsKey(product))
            {
                Inventory[product] += quantity;
            }
            else
            {
                Inventory.Add(product, quantity);
            }
            return "Product " + product.GetName() + " " + product.GetCode() + " " + product.GetPrice() + " " + quantity;
        }

        // method for stocking float with different logic
        public string StockFloat(int moneyDenomination, int quantity)
        {
            // check if the money denomination is valid
            if (MoneyFloat.ContainsKey(moneyDenomination))
            {
                MoneyFloat[moneyDenomination] += quantity;
            }
            else
            {
                MoneyFloat.Add(moneyDenomination, quantity);
            }
            return "Money " + moneyDenomination + " " + quantity;
        }

        // add method for vent item with different logic
        public string VentItem(Product product, int quantity)
        {
            // check if the product is in the inventory
            if (Inventory.ContainsKey(product))
            {
                // check if the quantity is valid
                if (Inventory[product] >= quantity)
                {
                    Inventory[product] -= quantity;
                    return "Product " + product.GetName() + " " + product.GetCode() + " " + product.GetPrice() + " " + quantity;
                }
                else
                {
                    return "Not enough product " + product.GetName() + " " + product.GetCode() + " " + product.GetPrice() + " " + quantity;
                }
            }
            else
            {
                return "Product " + product.GetName() + " " + product.GetCode() + " " + product.GetPrice() + " " + quantity + " is not in the inventory";
            }
        }

        // add main method here
        public static void Main(string[] args)
        {
            vendingMachine vm = new vendingMachine(12345);
            Product p1 = new Product("Coffee", 1.50, "C002");
            Product p2 = new Product("Tea", 1.50, "T001");
            Product p3 = new Product("Milk", 1.50, "M001");
            Product p4 = new Product("Water", 1.50, "W001");
            Product p5 = new Product("Coffee", 1.50, "C003");

            vm.StockItem(p1, 10);
            vm.StockItem(p2, 10);
            vm.StockItem(p3, 10);
            vm.StockItem(p4, 10);
            vm.StockItem(p5, 10);

            vm.StockFloat(1, 10);
            vm.StockFloat(5, 10);
            vm.StockFloat(10, 10);
            vm.StockFloat(20, 10);
            vm.StockFloat(50, 10);

            Console.WriteLine(vm.VentItem(p1, 1));
            Console.WriteLine(vm.VentItem(p2, 1));
            Console.WriteLine(vm.VentItem(p3, 1));
            Console.WriteLine(vm.VentItem(p4, 1));
            Console.WriteLine(vm.VentItem(p5, 1));
        }
    }
}