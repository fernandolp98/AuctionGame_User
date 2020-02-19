using System;
using System.Linq;

namespace AuctionGame_User
{
    public class BetwenValues
    {
        public int TopValue { get; set; }
        public int DownValue { get; set; }
        public int FinallyValue { get; set; }

        public BetwenValues(int downValue, int topValue)
        {
            this.TopValue = topValue;
            this.DownValue = downValue;
            this.FinallyValue = RandomData();
        }

        private int RandomData()
        {
            var down = DownValue;
            var top = TopValue;

            var guid = Guid.NewGuid();
            var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            var seed = int.Parse(justNumbers.Substring(0, 9));
            var rnd = new Random(seed);

            var rndData = rnd.Next(down, top + 1);

            return rndData;
        }

        public int GetNewFinallyValue()
        {
            FinallyValue = RandomData();
            return FinallyValue;
        }
    }
}
