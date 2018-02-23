using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class RUFF : BaseCoin
    {
        public static string coin = "ruff";
        public static decimal buyAmount = (decimal)60;
        public static decimal sellAmount = (decimal)59;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
