using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class VEN : BaseCoin
    {
        public static string coin = "ven";
        public static decimal buyAmount = (decimal)0.5;
        public static decimal sellAmount = (decimal)0.49;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
