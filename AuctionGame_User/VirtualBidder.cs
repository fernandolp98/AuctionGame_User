using System.Collections.Generic;
using System.Data;
using System.Threading;

namespace AuctionGame_User
{
    public class VirtualBidder : Bidder
    {
        public int IdVirtualBidder { get; set; }
        public  Role Role { get; set; }
        public string DescriptionBidder { get; set; }

        public Thread Hilo;
        public VirtualBidder()
        {
        }
        public bool WantToBid(decimal ultimateOffert, int winner, int round)
        {
            if (winner == IdBidder) return false;//Si el ganador actual esél mismo, no puja
            if (OutBidder) return false;//Si está fuera de la apuesta, no puja
            if (Role.Rounds.FinallyValue < round) return false;//Si su límite de rounds es mayor al actual, no puja
            if (Role.OffertsForRound.FinallyValue < ParticipationsRound) return false;//Si su límite de ofertas por round es mayor a las participaciones que ha hecho, no puja
            if (ultimateOffert + Role.BidIncrease.GetNewFinallyValue() > Wallet) return false;//Si lo que desea ofertar es mayor a su dinero disponible, no puja

            Offert = (int)ultimateOffert + Role.BidIncrease.FinallyValue;
            UpdateParticipation();//Incrementa sus participaciones
            return true;//Puja
        }

        public static List<VirtualBidder> GetAllVirtualBidders(string query)
        {
            if(string.IsNullOrEmpty(query))
                query = "SELECT * FROM virtual_bidders_view";
            var virtualBidders = new List<VirtualBidder>();
            var virtualBiddersDt = DbConnection.consultar_datos(query);
            if (virtualBiddersDt == null) return null;
            foreach (DataRow row in virtualBiddersDt.Rows)
            {
                var virtualBidder = new VirtualBidder()
                {
                    IdVirtualBidder = (int)row[0],
                    IdBidder = (int)row[1],
                    NameBidder = (string)row[2],
                    DescriptionBidder = (string)row[3],
                    Wallet = (decimal)row[4],
                    Role = new Role((int)row[5])
                };
                virtualBidders.Add(virtualBidder);
            }
            return virtualBidders;
        }

        public static VirtualBidder GetVirtualBidderById(int idVirtualBidder)
        {
            var query = $"SELECT * FROM virtual_bidders_view WHERE idVirtualBidder = {idVirtualBidder}";
            var virtualBiddersDt = DbConnection.consultar_datos(query);
            if (virtualBiddersDt == null) return null;
            var row = virtualBiddersDt.Rows[0];
            var virtualBidder = new VirtualBidder()
            {
                IdVirtualBidder = (int)row[0], 
                IdBidder = (int)row[1], 
                NameBidder = (string)row[2], 
                DescriptionBidder = (string)row[3],
                Wallet = (decimal)row[4],
                Role = new Role((int)row[5])
            };
            return virtualBidder;
        }
    }
}
