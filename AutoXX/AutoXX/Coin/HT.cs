﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class HT : BaseCoin
    {
        public static string coin = "ht";
        public static decimal buyAmount = (decimal)2;
        public static decimal sellAmount = (decimal)1.96;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
