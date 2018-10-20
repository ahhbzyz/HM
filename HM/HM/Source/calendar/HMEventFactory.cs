using System;
using System.Collections.Generic;
using Java.Text;
using Java.Util;

namespace HM.Source.calendar
{
    public class HMEventFactory
    {
        public HMEventFactory()
        {
        }

        public static Dictionary<string, List<HMEvent>> produceEvents() {

            Dictionary<string, List<HMEvent>> dict = new Dictionary<string, List<HMEvent>>();

            // one day
            List<HMEvent> ea = new List<HMEvent>();
            HMEvent ea1 = new HMEvent
            {
                name = "Pay electricty bill",
                location = "home",
                duraion = "45m",
                occurence = "weekly",
                desc = "This is a notice"
            };
            Calendar cEa1 = Calendar.GetInstance(new Locale("en_AU"));
            // event 1 2018-10-10 9:00:00
            cEa1.Set(Calendar.Second, 0);
            cEa1.Set(Calendar.Minute, 0);
            cEa1.Set(Calendar.Hour, 9);
            cEa1.Set(Calendar.AmPm, Calendar.Am);
            cEa1.Set(Calendar.Month, Calendar.October);
            cEa1.Set(Calendar.DayOfMonth, 10);
            cEa1.Set(Calendar.Year, 2018);
            ea1.date = cEa1;
            ea.Add(ea1);
            HMEvent ea2 = new HMEvent
            {
                name = "JD MJ 101 Meeting",
                location = "Cafe Coffe",
                duraion = "1h 30m",
                occurence = "weekly",
                desc = "This is a notice"
            };
            Calendar cEa2 = Calendar.GetInstance(new Locale("en_AU"));
            // event 2 2018-10-10 12:30:00
            cEa2.Set(Calendar.Second, 0);
            cEa2.Set(Calendar.Minute, 30);
            cEa2.Set(Calendar.Hour, 12);
            cEa2.Set(Calendar.AmPm, Calendar.Am);
            cEa2.Set(Calendar.Month, Calendar.October);
            cEa2.Set(Calendar.DayOfMonth, 10);
            cEa2.Set(Calendar.Year, 2018);
            ea2.date = cEa2;
            ea.Add(ea2);

            // Another day
            List<HMEvent> eb = new List<HMEvent>();
            HMEvent eb1 = new HMEvent
            {
                name = "Painting company comming",
                location = "home",
                duraion = "15m",
                occurence = "monthly",
                desc = "This is a notice"
            };
            Calendar cEb1 = Calendar.GetInstance(new Locale("en_AU"));
            // 2018-10-10 9:00:00
            cEb1.Set(Calendar.Second, 0);
            cEb1.Set(Calendar.Minute, 0);
            cEb1.Set(Calendar.Hour, 9);
            cEb1.Set(Calendar.AmPm, Calendar.Am);
            cEb1.Set(Calendar.Month, Calendar.October);
            cEb1.Set(Calendar.DayOfMonth, 13);
            cEb1.Set(Calendar.Year, 2018);
            eb1.date = cEb1;
            eb.Add(eb1);

            String cEa1str = new SimpleDateFormat("MM-dd-yyyy").Format(cEa1.Time);
            String cEb1str = new SimpleDateFormat("MM-dd-yyyy").Format(cEb1.Time);
            dict.Add(cEa1str, ea);
            dict.Add(cEb1str, eb);
            return dict;
        }
    }
}
