using System;
using System.Collections.Generic;

namespace AuctionGame_User
{
    public class Bidder
    {
        public int IdBidder { get; set; }
        public string NameBidder { get; set; }
        public decimal Wallet { get; set; }
        public decimal Offert { get; set; }
        public int ParticipationsRound { get; set; }
        public int Rounds { get; set; }
        public  bool RoundActual { get; set; }
        public bool OutBidder { get; set; }
        public double Points { get; set; }
        public Statistical Statistics { get; set; }
        public DateTime LastBiddTime { get; set; }
        public List<Product> ProductsEarned { get; set; }
        public Bidder()
        {
            ProductsEarned = new List<Product>();
            Statistics = new Statistical();
            LastBiddTime = DateTime.Now;
        }


        public void UpdateParticipation()
        {
            ParticipationsRound++;
            if (ParticipationsRound == 1)
            {
                Rounds++;
            }
        }
    }
}
