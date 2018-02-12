using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class EOS : BaseCoin
    {
        public static string coin = "eos";
        public static decimal buyAmount = (decimal)0.2;
        public static decimal sellAmount = (decimal)0.196;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
