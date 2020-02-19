using System.Collections.Generic;

namespace AuctionGame_User
{
    public class Statistical
    {
        public int IdStatistical { get; set; }

        private readonly List<int> _roundsForBidd;
        private readonly List<int> _biddForRound;
        private readonly List<int> _secondsBetweenBidd;
        private readonly List<int> _increaseForBidd;


        public int BidTotal { get; set; }
        public int BidWin { get; set; }
        public double Points { get; set; }
        public decimal Wallet { get; set; }
        public string Log { get; set; }




        public Statistical()
        {
            _roundsForBidd = new List<int>();
            _biddForRound = new List<int>();
            _secondsBetweenBidd = new List<int>();
            _increaseForBidd = new List<int>();

        }

        public double mean(List<int> list)
        {
            var mean = 0.0;
            foreach (var n in list)
            {
                mean += n;
            }

            mean /= list.Count;
            return mean;
        }
        public void AddRoundsForBidd(int rounds)
        {
            this._roundsForBidd.Add(rounds);
        }
        public void AddBiddForRound(int bidds)
        
        {
            if(bidds > 0)
                this._biddForRound.Add(bidds);
        }
        public void AddSecondsBetweenBidd(int seconds)
        {
            this._secondsBetweenBidd.Add(seconds);
        }
        public void AddIncreaseForBidd(int increase)
        {
            this._increaseForBidd.Add(increase);
        }

        public void Results()
        {
            var roundsForBidd = (int)mean(_roundsForBidd);
            var biddForRound = (int)mean(_biddForRound);
            var secondsBetweenBidd = (int)mean(_secondsBetweenBidd);
            var increaseForBidd = (int) mean(_increaseForBidd);

            var query = $"UPDATE statistical_data SET " +
                           $"roundsForBid = {roundsForBidd}, " +
                           $"biddForRound={biddForRound}, " +
                           $"totalBid={BidTotal}, " +
                           $"bidWin={BidWin}, " +
                           $"secondsBetweenBidd={secondsBetweenBidd}, " +
                           $"increaseForBidd={increaseForBidd}, " +
                           $"points={Points}, " +
                           $"log = '{Log}'" +
                           $"WHERE idSTATISCAL = {IdStatistical}";
            DbConnection.ejecutar(query);
        }
    }
}
