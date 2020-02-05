using System;
using System.Collections.Generic;
using System.Text;

namespace StoreDLL
{
    public class Store
    {
        private List<Product> _productList = new List<Product>();

        public void AddProduct(Product product)
        {
            _productList.Add(product);            
        }

        public void ShowProducts()
        {
            for (var i = 0; i < _productList.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("ID: {0, -3} ", _productList[i].id);  
                //Console.Write($"ID: {_productList[i].id}; ");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Name: {0, -20} ", _productList[i].name);
                //Console.Write($"Name: {_productList[i].name}; \t");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Category: {0, -15} ", _productList[i].category);
                //Console.Write($"Category: {_productList[i].category}; \t");

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("Amount: {0, -10} ", _productList[i].amount);
                //Console.Write($"Count: {_productList[i].amount}; \t");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Price: {0, -5} \n", _productList[i].price);
                //Console.Write($"Price: {_productList[i].price}\n");

                Console.ResetColor();
            }

            Console.WriteLine();
        }

        public void ShowCategory()
        {
            Product product = new Product();
            List<Product> categoryList = new List<Product>();
            string productCategory = product.GetProductCategory();
            bool isCategory = false;

            for (var i = 0; i < _productList.Count; i++)
            {
                if (_productList[i].category == productCategory)
                {
                    categoryList.Add(_productList[i]);
                    isCategory = true;
                }
            }

            if (!isCategory)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error. Category isn't correct. If you dont know product's category see the list of products.\n");
                Console.ResetColor();
                return;
            }

            Console.WriteLine();

            foreach (var cat in categoryList)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"ID: {cat.id}; ");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Name: {cat.name}; ");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"Category: {cat.category}; ");

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"Count: {cat.amount}; ");

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write($"Price: {cat.price}\n");

                Console.ResetColor();
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        public void RemoveProduct()
        {
            bool isRemoved = false;
            Product product = new Product();
            string productName = product.GetProductName();
            int productId = GetProductId();

            for (var i = 0; i < _productList.Count; i++)
            {
                if (_productList[i].name == productName && _productList[i].id == productId)
                {
                    _productList.Remove(_productList[i]);
                    Console.WriteLine("Product remooved.\n");
                    isRemoved = true;
                }
            }

            if (!isRemoved)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error. Name or ID isn't correct. If you dont know product's NAME and ID see the list of products.\n");
                Console.ResetColor();
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        public void GetTotalPrice()
        {
            double totalPrice = 0;

            for (var i = 0; i < _productList.Count; i++)
            {
                totalPrice += (_productList[i].price * _productList[i].amount);
            }

            Console.WriteLine($"Total price: {totalPrice}$\n");
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        private int GetProductId()
        {
            bool flagId = true;
            int productId = 0;

            while (flagId)
            {
                Console.Write("Enter product ID: ");

                bool isId = Int32.TryParse(Console.ReadLine(), out productId);

                if (isId)
                {
                    flagId = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ID is integer. Try again!\n");
                    Console.ResetColor();
                }
            }

            return productId;
        }

        public void ChangeProductPrice()
        {
            bool flagChangePrice = true;
            int productId = GetProductId();
            double priceChange = 0;
            bool hasId = HasID(productId);

            if (hasId)
            {
                while (flagChangePrice)
                {
                    Console.Write("Enter new product price: ");

                    bool isChangePrice = double.TryParse(Console.ReadLine(), out priceChange);

                    if (isChangePrice && priceChange >= 0)
                    {
                        flagChangePrice = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Price has double format. Price cannot be negative. Try again!");
                        Console.ResetColor();
                        Console.WriteLine("\nPress any key to continue.");
                        Console.ReadKey();

                        return;
                    }
                }

                for (var i = 0; i < _productList.Count; i++)
                {
                    if (_productList[i].id == productId)
                    {
                        _productList[i].price = priceChange;
                        Console.WriteLine("Price changed!\n");
                    }
                }
            }
            else
            {
                return;
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        public void ChangeProductAmount()
        {
            int productId = GetProductId();
            bool flagChangeAmount = true;
            double amountChange = 0;
            bool hasId = HasID(productId);

            if (hasId)
            {
                while (flagChangeAmount)
                {
                    Console.Write("Enter product amount to change: ");

                    bool isChangeAmount = double.TryParse(Console.ReadLine(), out amountChange);

                    if (isChangeAmount)
                    {
                        flagChangeAmount = false;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Amount has double format. Try again!\n");
                        Console.ResetColor();
                    }
                }

                if (amountChange > 0)
                {
                    _productList[productId - 1].amount += amountChange;
                    Console.WriteLine("Amount changed.\n");
                }
                else if (amountChange < 0 && Math.Abs(amountChange) <= _productList[productId - 1].amount)
                {
                    _productList[productId - 1].amount += amountChange;
                    Console.WriteLine("Amount changed.\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input amount have to be less than current amount. Try again!\n");
                    Console.ResetColor();
                    Console.WriteLine("\nPress any key to continue.");
                    Console.ReadKey();

                    return;
                }
            }
            else
            {
                return;
            }

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        private bool HasID(int productId)
        {
            bool hasId = false;

            for (var i = 0; i < _productList.Count; i++)
            {
                if (_productList[i].id == productId)
                {
                    hasId = true;
                }
            }

            if (!hasId)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Uncorrect product ID. If you dont know product ID see the list of product. Try again!\n");
                Console.ResetColor();
                Console.WriteLine("\nPress any key to continue.");
                Console.ReadKey();
            }

            return hasId;
        }
    }
}
