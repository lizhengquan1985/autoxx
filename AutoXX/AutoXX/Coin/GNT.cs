﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class GNT : BaseCoin
    {
        public static string coin = "gnt";
        public static decimal buyAmount = (decimal)8;
        public static decimal sellAmount = (decimal)7.84;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
