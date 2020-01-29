using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_TMS_
{
    public class Store
    {
        private List<Product> productList = new List<Product>();

        public void AddProduct(Product product)
        {
            productList.Add(product);
        }

        public void ShowProducts()
        {
            for (var i = 0; i < productList.Count; i++)
            {
                Console.WriteLine($"Name: {productList[i].name}, ID: {productList[i].id}, Price: {productList[i].price}, Count: {productList[i].count}");
            }
        }
    }
}
