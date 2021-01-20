using EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            readProduct();
            deleteProduct();
            readProduct();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        static void readProduct()
        {

            using (var db = new EFContext())
            {
                List<Product> products = db.Products.ToList();
                foreach (Product p in products)
                {
                    Console.WriteLine("{0} {1}", p.Id, p.Name);
                }
            }
            return;
        }

        static void insertProduct()
        {
            using (var db = new EFContext())
            {
                Product product = new Product();
                product.Name = "Pen Drive";
                db.Add(product);

                product = new Product();
                product.Name = "Memory Card";
                db.Add(product);

                db.SaveChanges();
            }
            return;
        }

        static void updateProduct()
        {
            using (var db = new EFContext())
            {
                Product product = db.Products.Find(3);
                product.Name = "Better Pen Drive";
                db.SaveChanges();
            }
            return;
        }
        static void deleteProduct()
        {
            using (var db = new EFContext())
            {

                Product product = db.Products.Find(1);
                db.Products.Remove(product);
                db.SaveChanges();
            }
            return;
        }


    }
}