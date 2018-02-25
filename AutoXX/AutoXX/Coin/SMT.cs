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
        public static decimal buyAmount = (decimal)120;

        public static void Do()
        {
            BaseRun(coin, buyAmount);
        }
    }
}
