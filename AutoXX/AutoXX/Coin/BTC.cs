using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class BTC : BaseCoin
    {
        public static string coin = "btc";
        public static decimal buyAmount = (decimal)0.005;
        public static decimal sellAmount = (decimal)0.0049;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
