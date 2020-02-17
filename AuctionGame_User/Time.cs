using System;

namespace AuctionGame_User
{
    class Time : IComparable<Time>
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Time(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Time(object time, string format)
        {
            var stringTime = string.Empty;
            switch (time)
            {
                case int _:
                case double _:
                    stringTime = time.ToString();
                    break;
                case string s:
                    stringTime = s;
                    break;
                default: Console.WriteLine(time.GetType().ToString()); break;
            }
            var timeArray = stringTime.Split(':');
            var hours = 0;
            var minutes = 0;
            var seconds = 0;
            var error = true;
            switch (format)
            {
                case "HH:mm:ss":
                    if (timeArray.Length == 3)
                    {
                        error = !int.TryParse(timeArray[0], out hours);
                        if(!error) error = !int.TryParse(timeArray[1], out minutes);
                        if(!error) error = !int.TryParse(timeArray[2], out seconds);

                    }
                    break;
                case "mm:ss":
                    if (timeArray.Length == 2)
                    {
                        error = !int.TryParse(timeArray[0], out minutes);
                        if (!error) error = !int.TryParse(timeArray[1], out seconds);

                    }
                    break;
                case "HH:mm":
                    if (timeArray.Length == 2)
                    {
                        error = !int.TryParse(timeArray[0], out hours);
                        if (!error) error = !int.TryParse(timeArray[1], out minutes);

                    }
                    break;
                case "HH":
                    error = !int.TryParse(stringTime, out hours);
                    break;
                case "mm":
                    error = !int.TryParse(stringTime, out minutes);
                    break;
                case "ss":
                    error = !int.TryParse(stringTime, out seconds);
                    break;

                default: throw new ArgumentException(@"El formato de entrada no es válido", nameof(format));

            }
            if (!error)
            {
                Seconds = seconds % 60;
                minutes += seconds / 60;
                Minutes = minutes % 60;
                hours += minutes / 60;
                Hours = hours;
            }
            else
            {
                throw new ArgumentException(@"Hubo un error en la cadena de texto ingresada", nameof(time));

            }
        }
        public string Format(string format)
        {
            var hh = Hours.ToString();
            if (Hours < 10)
                hh = "0" + hh;
            var mm = Minutes.ToString();
            if (Minutes < 10)
                mm = "0" + mm;
            var ss = Seconds.ToString();
            if (Seconds < 10)
                ss = "0" + ss;
            var hhmmInt = Hours * 60 + Minutes;
            var hhmm = hhmmInt.ToString();
            if (hhmmInt < 9)
                hhmm = "0" + hhmm;
            var hhmmssInt = Hours * 3600 + Minutes * 60 + Seconds * 60;
            var hhmmss = hhmmssInt.ToString();
            if (hhmmInt < 9)
                hhmmss = "0" + hhmmss;
            switch (format)
            {
                case "HH:mm:ss":
                    return $"{hh}:{mm}:{ss}";
                case "mm:ss": return $"{hhmm}:{ss}";
                case "ss": return $"{hhmmss}";
            }

            return string.Empty;
        }

        public double GetHours()
        {
            return GetMinutes() / 60;
        }
        public double GetMinutes()
        {
            return GetSeconds() / 60;
        }
        public double GetSeconds()
        {
            double seconds = Seconds;
            seconds += Minutes * 60;
            seconds += Hours * 60 * 60;
            return seconds;
        }

        public static bool TryParse(object time)
        {
            var stringTime = string.Empty;
            switch (time)
            {
                case int _:
                    stringTime = time.ToString();
                    break;
                case string s:
                    stringTime = s;
                    break;
            }

            bool error;
            var timeArray = stringTime.Split(':');
            if (timeArray.Length == 3)
            {
                error = !int.TryParse(timeArray[0], out _);
                if (!error) error = !int.TryParse(timeArray[1], out _);
                if (!error) error = !int.TryParse(timeArray[2], out _);
                return !error;
            }
            if (timeArray.Length == 2)
            {
                error = !int.TryParse(timeArray[0], out _);
                if (!error) error = !int.TryParse(timeArray[1], out _);
                return !error;

            }
            error = int.TryParse(stringTime, out _);
            return !error;
        }

        public int CompareTo(Time other)
        {
            if (other == null) return 1;

            return this.GetSeconds().CompareTo(other.GetSeconds());
        }

        // Define the is greater than operator.
        public static bool operator >(Time operand1, Time operand2)
        {
            return operand1.CompareTo(operand2) == 1;
        }

        // Define the is less than operator.
        public static bool operator <(Time operand1, Time operand2)
        {
            return operand1.CompareTo(operand2) == -1;
        }

        // Define the is greater than or equal to operator.
        public static bool operator >=(Time operand1, Time operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }

        // Define the is less than or equal to operator.
        public static bool operator <=(Time operand1, Time operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }

    }
}
