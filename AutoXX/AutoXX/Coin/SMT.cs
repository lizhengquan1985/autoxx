using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class SMT : BaseCoin
    {
        public static string coin = "smt";
        public static decimal buyAmount = (decimal)40;
        public static decimal sellAmount = (decimal)39.2;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
