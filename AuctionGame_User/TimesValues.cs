using System;
using System.Linq;

namespace AuctionGame_User
{
    public class TimesValues
    {
        public int TimeDownSeconds { get; set; }
        public int TimeTopSeconds { get; set; }
        public int FinallyValue { get; set; } //Expresado en segundos

        public TimesValues(int timeDownSeconds, int timeTopSeconds)
        {
            this.TimeDownSeconds = timeDownSeconds;
            this.TimeTopSeconds = timeTopSeconds;

            FinallyValue = NewFinallyValue();
        }

        public int NewFinallyValue()
        {
            FinallyValue = TimeRnd(TimeDownSeconds, TimeTopSeconds);
            return FinallyValue;
        }

        private int TimeRnd(int secondsDown, int secondsTop)
        {
            //se genera un random entre segundos
            var time = RandomData(secondsDown, secondsTop);
            return time;
        }

        protected virtual int RandomData(int d, int t)
        {
            var down = d;
            var top = t;

            var guid = Guid.NewGuid();
            var justNumbers = new string(guid.ToString().Where(char.IsDigit).ToArray());
            var seed = int.Parse(justNumbers.Substring(0, 9));
            var rnd = new Random(seed);

            var rndData = rnd.Next(down, top + 1);

            return rndData;
        }
    }
}
