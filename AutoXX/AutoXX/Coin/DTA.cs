using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class DTA : BaseCoin
    {
        public static string coin = "dta";
        public static decimal buyAmount = (decimal)50;
        public static decimal sellAmount = (decimal)49;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
