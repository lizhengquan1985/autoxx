using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class OMG : BaseCoin
    {
        public static string coin = "omg";
        public static decimal buyAmount = (decimal)0.5;

        public static void Do()
        {
            BaseRun(coin, buyAmount);
        }
    }
}
