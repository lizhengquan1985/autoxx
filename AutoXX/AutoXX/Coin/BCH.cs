using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class BCH : BaseCoin
    {
        public static string coin = "bch";
        public static decimal buyAmount = (decimal)0.006;
        public static decimal sellAmount = (decimal)0.0059;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
