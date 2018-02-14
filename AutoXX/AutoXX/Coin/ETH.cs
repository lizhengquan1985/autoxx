using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    class ETH : BaseCoin
    {
        public static string coin = "eth";
        public static decimal buyAmount = (decimal)0.01;
        public static decimal sellAmount = (decimal)0.0098;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
