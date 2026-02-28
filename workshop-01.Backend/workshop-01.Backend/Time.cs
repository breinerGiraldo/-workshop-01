namespace workshop_01.Backend
{
    public class Time
    // create atributes 
    {
        private int _hour;
        private int _minute;
        private int _second;
        private int _millisecond;

        // constructor sin  oparameters
        public Time()
        {
            _hour = 0;
            _minute = 0;
            _second = 0;
            _millisecond = 0;

        }

        public Time(int hour)

        {
            Hour = hour;
        }

        //create constructor hour and minute
        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }
        // create constructor hour, minute and second
        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;

        }
        // create constructor hour, minute, second and milisecond
        public Time(int hour, int minute, int second, int millisecond)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
            MilliSecond = millisecond;
        }


        // create properties

        public int Hour
        {
            get => _hour;
            set => _hour = ValidHour(value);
        }

        public int Minute
        {
            get => _minute;
            set => _minute = ValidMinute(value);
        }

        public int Second
        {
            get => _second;
            set => _second = ValidSecond(value);
        }
        public int MilliSecond
        {
            get => _millisecond;
            set => _millisecond = ValidMilisecond(value);
        }

        override public string ToString()
        {

            if (Hour < 0 || Hour > 23)
            {
                throw new ArgumentException($"Hour: {Hour} is not valid.");
            }

            if (Minute < 0 || Minute > 59)
            {
                throw new ArgumentException($"Minute: {Minute} is not valid.");
            }

            if (Second < 0 || Second > 59)
            {
                throw new ArgumentException($"Second: {Second} is not valid.");
            }

            if (MilliSecond < 0 || MilliSecond > 999)
            {
                throw new ArgumentException($"Millisecond: {MilliSecond} is not valid.");
            }
            int hora12= Hour;
                string period;


                if (Hour == 0)
                {
                    hora12 = 12;
                    period = "AM";
                }
                else if (Hour < 12)
                {
                    hora12 = Hour;
                    period = "AM";
                }
                else if (Hour == 12)
                {
                    hora12 = 12;
                    period = "PM";
                }
                else
                {
                    hora12 = Hour - 12;
                    period = "PM";
                }
                
            return $"{hora12:00}:{Minute:00}:{_second:00}:{_millisecond:000}:{period}";

        }

        public int ToMilliseconds()
        {
            if (Hour < 0 ||  Hour > 23)
            {
                return 0 ;
            }
            if ( Minute < 0 || Minute > 59)
            {
                return 0;
            }
            if (Second < 0 || Second > 59)
            {
                return 0;
            }
            if (MilliSecond < 0 || MilliSecond > 999)

            {
                return 0;
            }
            return _hour * 3600000 + _minute * 60000 + _second * 1000 + _millisecond;
        }
        public int ToSeconds()
        {
            if (Hour < 0 || Hour > 23)
            {
                return 0;
            }
            if (Minute < 0 || Minute > 59)
            {
                return 0;
            }
            if (Second < 0 || Second > 59)
            {
                return 0;
            }
            if (MilliSecond < 0 || MilliSecond > 999)

            {
                return 0;
            }
            return _hour * 3600 + _minute * 60 + _second + _millisecond / 1000;


        }
        public int toMinutes()
        {
            if (Hour < 0 || Hour > 23)
            {
                return 0;
            }
            if (Minute < 0 || Minute > 59)
            {
                return 0;
            }
            if (Second < 0 || Second > 59)
            {
                return 0;
            }
            if (MilliSecond < 0 || MilliSecond > 999)

            {
                return 0;
            }
            return _hour * 60 + _minute + _second / 60 + _millisecond / 60000;
        }



        public bool IsOtherDay(Time other)
        {
            int Totalmilliseconds =this.ToMilliseconds() + other.ToMilliseconds();
            
            if (Totalmilliseconds >= 86400000)
            { 
                return true;
            }
            return false;
        }

        public Time Add(Time other)
        {
            int Totalmilliseconds = this.ToMilliseconds() + other.ToMilliseconds();
            Totalmilliseconds %= (24 * 3600000);

            int  newhour = (Totalmilliseconds / 3600000);
            int newminute = (Totalmilliseconds / 60000) % 60;
            int newsecond = (Totalmilliseconds / 1000) % 60;
            int newmilisecond = Totalmilliseconds % 1000;

            return new Time(newhour, newminute, newsecond, newmilisecond);
        }
        
       


        //create validation for hour
        private int ValidHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentException($"Hour: {hour} is not valid.");
            }
            return hour;
        }

        private int ValidMinute(int minute)
        {
            if (minute < 0 || minute > 59)
            {
                throw new ArgumentException($"Minute:{minute}is not valid");
            }
            return minute;
        }

        private int ValidSecond(int second)
        {
            if (second < 0 || second > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(second), $"Second:{second} is not valid .");
            }
            return second;
        }

        private int ValidMilisecond(int milisecond)
        {
            if (milisecond < 0 || milisecond > 999)
            {
                throw new ArgumentOutOfRangeException(nameof(milisecond), $"Milisecond : {milisecond} is not valid.");
            }
            return milisecond;
        }


        


       
      
    }
}
