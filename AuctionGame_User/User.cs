using System.Collections.Generic;

namespace AuctionGame_User
{
    public class User : Bidder
    {
        public int IdUser { get; set; }
        public Statistical Statistics { get; set; }
        public List<Product> ProductsEarned { get; set; }


        public User()
        {
            Statistics = new Statistical();
            ProductsEarned = new List<Product>();
        }

        public static User GetUserById(int idUser)
        {
            var user = new User();
            var query = $"SELECT * FROM users_view WHERE idUser = {idUser}";
            var userDt = DbConnection.consultar_datos(query);
            if (userDt != null)
            {
                user.IdUser = (int)userDt.Rows[0][0];
                user.IdBidder = (int)userDt.Rows[0][1];
                user.NameBidder = (string)userDt.Rows[0][2];
                user.Wallet = (decimal)userDt.Rows[0][3];
                user.Statistics.IdStatistical = (int)userDt.Rows[0][4];
            }
            return user;
        }

    }
}
