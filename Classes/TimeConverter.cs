using BerlinClock.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private String colourY = "Y"; // Color Yellow
        private String colourR = "R"; //Color Red
        private String colourOff = "O"; //No Color        

        //Convert time to corresponding code
        public string convertTime(string sTime)
        {
            String sResult=string.Empty;

            Time time = SetTime(sTime);
            sResult = GetOutput(time);

            return sResult;
        }

        //Split the time to hours,minutes and Seconds
        private Time SetTime(String sTime)
        {
            Time time = new Time();
            string[] timeValues = sTime.Split(new string[] { ":" }, StringSplitOptions.None);
            
            time.setHours(Int32.Parse(timeValues[0]));
            time.setMinutes(Int32.Parse(timeValues[1]));
            time.setSeconds(Int32.Parse(timeValues[2]));

            return time;            
        }

        //Get Time Code
        private string GetOutput(Time time)
        {
            string sResult = string.Empty;
            string sseconds = GetSeconds(time.getSeconds());
            string shours = GetHours(time.getHours());
            string sminutes = GetMinutes(time.getMinutes());
            return sResult = sseconds.TrimEnd() + "\r\n" + shours.TrimEnd() + "\r\n" + sminutes.TrimEnd();
        }

        //Get Seconds - Row 01
        private String GetSeconds(int seconds)
        {
            if (seconds % 2 == 0)
                return colourY;
            else
                return colourOff;
        }

        //Get Hours - R02 and R03
        private String GetHours(int hours)
        {
            return GetLightValueRow02(4, (hours - (hours % 5)) / 5) + "\r\n" + GetLightValueRow02(4, hours % 5);
        }

        //Checks Whether the light is On/Off in Row02
        private String GetLightValueRow02(int noOfLight, int onLight)
        {
            return GetLightValueRow03(noOfLight, onLight, colourR);
        }

        //Checks Whether the Light is On/Off in Row03
        private String GetLightValueRow03(int noOfLight, int onLights, String onLight)
        {
            String output = "";
            for (int i = 0; i < onLights; i++)
            {
                output += onLight;
            }
            for (int i = 0; i < (noOfLight - onLights); i++)
            {
                output += colourOff;
            }
            return output;
        }

        //Get Minutes - Row04 Two Row05
        private String GetMinutes(int minutes)
        {
            return Regex.Replace(GetLightValueRow03(11, (minutes - (minutes % 5)) / 5, colourY), colourY + colourY + colourY, colourY + colourY + colourR) + "\r\n" +
                GetLightValueRow03(4, minutes % 5, colourY);
        }
    }
}
