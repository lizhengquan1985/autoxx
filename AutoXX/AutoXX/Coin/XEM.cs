using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class XEM : BaseCoin
    {
        public static string coin = "xem";
        public static decimal buyAmount = (decimal)10;
        public static decimal sellAmount = (decimal)9.8;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
