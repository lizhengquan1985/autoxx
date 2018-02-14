using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class NEO : BaseCoin
    {
        public static string coin = "neo";
        public static decimal buyAmount = (decimal)0.03;
        public static decimal sellAmount = (decimal)0.0294;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
