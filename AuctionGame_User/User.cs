using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AuctionGame_User
{
    public class User
    {
        public int IdUser { get; set; }
        public Bidder Bidder { get; set; }
        public Statistical Statistics { get; set; }
        public List<Product> ProductsEarned { get; set; }


        public User()
        {
            Bidder = new Bidder();
            Statistics = new Statistical();
            ProductsEarned = new List<Product>();
        }

    }
}
