using System;
using Java.Util;

namespace HM.Source.calendar
{
    public class HMEvent
    {
        public string name;
        public Calendar date;
        public string location;
        public string duraion;
        public string desc;
        public Occurence occurence; 
        public enum Occurence {
            daily, weekly, monthly
        }
    }

}
