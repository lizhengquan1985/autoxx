using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class HT : BaseCoin
    {
        public static string coin = "ht";
        public static decimal buyAmount = (decimal)3;

        public static void Do()
        {
            BaseRun(coin, buyAmount);
        }
    }
}
