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
        public static decimal buyAmount = (decimal)3.0;
        public static decimal sellAmount = (decimal)2.94;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
