using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class Time
    {
        private int hours;
        private int minutes;
        private int seconds;

        //Get Hours
        public int getHours()
        {
            return hours;
        }

        //Set Hours
        public void setHours(int hours)
        {
            this.hours = hours;
        }

        //Get Minutes
        public int getMinutes()
        {
            return minutes;
        }

        //Set Minutes
        public void setMinutes(int minutes)
        {
            this.minutes = minutes;
        }

        //Get Seconds
        public int getSeconds()
        {
            return seconds;
        }

        //Set Seconds
        public void setSeconds(int seconds)
        {
            this.seconds = seconds;
        }
    }
}
