using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace МагазинчикУДома
{
    public static class Capcha
    {
        public static string NewCapcha()
        {
            string cap = "";
            Random random = new Random();
            for(int i = 0; i < 3; i++)
            {
                cap += (char)random.Next('A', 'Z' + 1) + random.Next(1, 100).ToString();
            }
            return cap;
        }
    }
}
