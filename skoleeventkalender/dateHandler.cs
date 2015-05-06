using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace skoleeventkalender
{
    public class dateHandler
    {
        int dage = 0;

        public DateTime naesteUge()
        {
            dage += 7;
            return DateTime.Now.AddDays(dage);
        }

        public DateTime forrigeUge()
        {
            dage -= 7;
            return DateTime.Now.AddDays(dage);
        }

        public DateTime denneUge()
        {
            dage = 0;
            return DateTime.Now;
        }


    }
}