using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionGame_User
{
    public class Routine
    {
        public int IdRoutine { get; set; }
        public string NameRoutine { get; set; }
        public string DescriptionRoutine { get; set; }
        public List<Family> Families { get; set; }
        public List<Product> SingleProducts { get; set; }
        public List<Product> ProductsByFamily { get; set; }
        public List<Product> AllProducts { get; set; }
        public List<VirtualBidder> VirtualBidders { get; set; }

        public static Routine GetRoutineById(int idRoutine)
        {
            var routine = new Routine();
            var query = $"SELECT nameRoutine, descriptionRoutine FROM routine WHERE idRoutine = {idRoutine}";
            var routineDt = DbConnection.consultar_datos(query);
            if (routine != null)
            {
                routine.NameRoutine = routineDt.Rows[0][0].ToString();
                routine.DescriptionRoutine = routineDt.Rows[0][1].ToString();
            }

            routine.IdRoutine = idRoutine;
            routine.Families = routine.GetFamilies();
            routine.SingleProducts = routine.GetSingleProducts();
            routine.ProductsByFamily = routine.GetProductsByFamily();
            routine.AllProducts = routine.GetAllProducts();
            routine.VirtualBidders = routine.GetVirtualBidders();
            return routine;
        }
        public static List<Routine> GetAllRoutines()
        {
            var routines = new List<Routine>();
            var query = $"SELECT idRoutine, nameRoutine, descriptionRoutine FROM routine";
            var routineDt = DbConnection.consultar_datos(query);
            foreach(DataRow row in routineDt.Rows)
            {
                var routine = new Routine();
                routine.IdRoutine = (int)row[0];
                routine.NameRoutine = (string)row[1];
                routine.DescriptionRoutine = (string)row[2];
                routine.Families = routine.GetFamilies();
                routine.SingleProducts = routine.GetSingleProducts();
                routine.ProductsByFamily = routine.GetProductsByFamily();
                routine.AllProducts = routine.GetAllProducts();
                routine.VirtualBidders = routine.GetVirtualBidders();
                routines.Add(routine);
            }
            return routines;
        }

        public List<Family> GetFamilies()
        {
            var families = new List<Family>();
            var query = "SELECT family.* FROM routine_has_family " +
                        "LEFT JOIN family " +
                        "ON family.idFamily = routine_has_family.FAMILY_idFamily " +
                        $"WHERE routine_has_family.ROUTINE_idRoutine = {IdRoutine}";
            var familiesDataTable = DbConnection.consultar_datos(query);
            if (familiesDataTable == null) return families;
            for (var index = 0; index < familiesDataTable.Rows.Count; index++)
            {
                var row = familiesDataTable.Rows[index];
                var family = new Family((int) row[0], (string) row[1], (int) row[2]);
                families.Add(family);
            }

            return families;
        }

        public List<Product> GetSingleProducts()
        {
            var products = new List<Product>();
            var query = $"SELECT * FROM single_products_per_routine WHERE ROUTINE_idRoutine = {IdRoutine}";

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

        public List<Product> GetProductsByFamily()
        {
            var products = new List<Product>();
            var query = $"SELECT * FROM products_per_family_per_routine WHERE ROUTINE_idRoutine = {IdRoutine}";

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

        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            var query =
                $"SELECT * FROM single_products_per_routine WHERE ROUTINE_idRoutine = {IdRoutine} UNION SELECT * FROM products_per_family_per_routine WHERE ROUTINE_idRoutine = {IdRoutine}";

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

        public List<VirtualBidder> GetVirtualBidders()
        {
            var virtualBidders = new List<VirtualBidder>();
            var query = "SELECT * FROM virtual_bidders_per_routine " +
                        $"WHERE ROUTINE_idRoutine = {IdRoutine}";
            var virtualBiddersDt = DbConnection.consultar_datos(query);

            if (virtualBiddersDt == null) return virtualBidders;
            for (var index = 0; index < virtualBiddersDt.Rows.Count; index++)
            {
                var row = virtualBiddersDt.Rows[index];
                var virtualBidder = new VirtualBidder()
                {
                    IdVirtualBidder = (int)row[0],
                    IdBidder = (int)row[1],
                    NameBidder = (string)row[2],
                    DescriptionBidder = (string)row[3],
                    Wallet = (decimal)row[4],
                    Role = new Role((int)row[5]),
                }; 
                virtualBidders.Add(virtualBidder);
            }

            return virtualBidders;
        }

        public List<Product> GetAvailableProducts()
        {
            var products = new List<Product>();
            var query = "SELECT products_view.* FROM products_view " +
                        "LEFT JOIN " +
                        "routine_has_product ON routine_has_product.PRODUCT_idProduct = products_view.idProduct " +
                        $"WHERE routine_has_product.ROUTINE_idRoutine IS NULL OR routine_has_product.ROUTINE_idRoutine != {IdRoutine}";
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
        public List<Family> GetAvailableFamilies()
        {
            var families = new List<Family>();
            var query = "SELECT families_view.* FROM families_view " +
                        "LEFT JOIN " +
                        "routine_has_family ON routine_has_family.FAMILY_idFamily = families_view.idFamily " +
                        $"WHERE routine_has_family.ROUTINE_idRoutine IS NULL OR routine_has_family.ROUTINE_idRoutine != {IdRoutine}";
            var consult = DbConnection.consultar_datos(query);
            if (consult == null) return families;
            for (var index = 0; index < consult.Rows.Count; index++)
            {
                var row = consult.Rows[index];
                var family = new Family((int)row[0], (string)row[1], (int)row[2]);
                families.Add(family);
            }

            return families;
        }
        public List<VirtualBidder> GetAvailableVirtualBidders()
        {
            var virtualBidders = new List<VirtualBidder>();
            var query = "SELECT virtual_bidders_view.* FROM virtual_bidders_view " +
                        "LEFT JOIN " +
                        "routine_has_virtual_bidder ON routine_has_virtual_bidder.VIRTUAL_BIDDER_idVIrtualBidder = virtual_bidders_view.idVirtualBidder " +
                        $"WHERE routine_has_virtual_bidder.ROUTINE_idRoutine IS NULL OR routine_has_virtual_bidder.ROUTINE_idRoutine != {IdRoutine}";
            var consult = DbConnection.consultar_datos(query);
            if (consult == null) return virtualBidders;
            for (var index = 0; index < consult.Rows.Count; index++)
            {
                var row = consult.Rows[index];
                var virtualBidder = new VirtualBidder()
                {
                    IdVirtualBidder = (int)row[0],
                    IdBidder = (int)row[1],
                    NameBidder = (string)row[2],
                    DescriptionBidder = (string)row[3],
                    Wallet = (decimal)row[4],
                    Role = new Role((int)row[5]),
                }; 
                virtualBidders.Add(virtualBidder);
            }

            return virtualBidders;
        }
    }
}
