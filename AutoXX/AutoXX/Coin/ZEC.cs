﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class ZEC : BaseCoin
    {
        public static string coin = "zec";
        public static decimal buyAmount = (decimal)0.02;
        public static decimal sellAmount = (decimal)0.0196;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
