using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class QTUM : BaseCoin
    {
        public static string coin = "qtum";
        public static decimal buyAmount = (decimal)0.1;
        public static decimal sellAmount = (decimal)0.098;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
