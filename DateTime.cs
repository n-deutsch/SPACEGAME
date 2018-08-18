using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPACEGAME
{
    class DateTime
    {
        private int day;

        public DateTime()
        {
            day = 0;
        }

        public void setDay(int newDay)
        { day = newDay; }

        public int getDay()
        { return day; }

        public void updateDay(int seconds)
        {
            int minutes = seconds / 60;
            minutes = minutes + 1;

            day = minutes;
        }
    }
}
