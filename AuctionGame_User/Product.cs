using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace AuctionGame_User
{ 
    public class Product : IEquatable<Product>
    {
        public int IdProduct;
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Points { get; set; }

        public Image ImageProduct { get; set; }

        public Product()
        {

        }
        public Product(int id, string n, decimal p, int po, Image im)
        {
            this.IdProduct = id;
            this.Name = n;
            this.Price = p;
            this.Points = po;
            this.ImageProduct = im;
        }
        public bool Equals(Product product)
        {
            if (ReferenceEquals(this, product)) return true;

            return product != null && (this.IdProduct.CompareTo(product.IdProduct) == 0 && this.Name.Equals(product.Name));
        }


        public static Product GetProductById(int idProduct)
        {
            var product = new Product();
            var query = $"SELECT * FROM products_view WHERE idProduct = {idProduct}";
            var productDataTable = DbConnection.consultar_datos(query);
            if (productDataTable == null) return product;
            foreach (DataRow row in productDataTable.Rows)
            {
                var image = DataControl.Base64StringToImage((string) row[4]);
                product = new Product((int)row[0], (string)row[1], (decimal)row[2], (int)row[3], image);
                    
            }
            return product;
        }
        public static List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            var query = "SELECT * FROM products_view";
            var consult = DbConnection.consultar_datos(query);
            if (consult == null) return products;
            for (var index = 0; index < consult.Rows.Count; index++)
            {
                var row = consult.Rows[index];
                var id = (int) row[0];
                var name = (string) row[1];
                var price = (decimal) row[2];
                var points = (int) row[3];
                var image = DataControl.Base64StringToImage((string) row[4]);

                var p = new Product(id, name, price, points, image);
                products.Add(p);
            }

            return products;
        }
    }
}
