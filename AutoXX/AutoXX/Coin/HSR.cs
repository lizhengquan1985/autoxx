using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class HSR : BaseCoin
    {
        public static string coin = "hsr";
        public static decimal buyAmount = (decimal)0.7;
        public static decimal sellAmount = (decimal)0.69;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
