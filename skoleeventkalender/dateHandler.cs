using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skoleeventkalender
{
    public class dateHandler
    {
        public DateTime naesteUge(DateTime currentDay)
        {
            return currentDay.AddDays(7);
        }

        public DateTime forrigeUge(DateTime currentDay)
        {
            return currentDay.AddDays(-7);
        }

        public DateTime denneUge()
        {
            return DateTime.Now;
        }
    }
}