using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class XRP : BaseCoin
    {
        public static string coin = "xrp";
        public static decimal buyAmount = (decimal)10;

        public static void Do()
        {
            BaseRun(coin, buyAmount);
        }
    }
}
