using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_TMS_
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
                Console.WriteLine($"ID: {_productList[i].id}, Name: {_productList[i].name}, Category: {_productList[i].category}, Count: {_productList[i].amount}, Price: {_productList[i].price}$\n");
                Console.ResetColor();
            }
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

            foreach (var cat in categoryList)
            {
                Console.WriteLine($"ID: {cat.id}, Name: {cat.name}, Category: {cat.category}, Amount: {cat.amount}, Price: {cat.price}\n");
            }
        
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
        }

        public void GetTotalPrice()
        {
            double totalPrice = 0;

            for (var i = 0; i < _productList.Count; i++)
            {
                totalPrice += (_productList[i].price * _productList[i].amount);
            }

            Console.WriteLine($"Total price: {totalPrice}$\n");
        }

        public int GetProductId()
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
                        Console.WriteLine("Price has double format. Price cannot be negative and equls to 0. Try again!");
                        Console.ResetColor();
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
                else if (amountChange < 0 && Math.Abs(amountChange) < _productList[productId - 1].amount)
                {
                    _productList[productId - 1].amount += amountChange;
                    Console.WriteLine("Amount changed.\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input amount have to be less than curreent amount. Try again!\n");
                    Console.ResetColor();

                    return;
                }
            }
            else
            {
                return;
            }
        }

        public bool HasID(int productId)
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
            }

            return hasId;
        }
    }
}
