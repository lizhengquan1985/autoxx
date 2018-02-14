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
        public static decimal buyAmount = (decimal)500;
        public static decimal sellAmount = (decimal)490;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
