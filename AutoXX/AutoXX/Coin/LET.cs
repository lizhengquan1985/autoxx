using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class LET : BaseCoin
    {
        public static string coin = "let";
        public static decimal buyAmount = (decimal)200;
        public static decimal sellAmount = (decimal)196;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
