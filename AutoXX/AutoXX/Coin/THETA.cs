﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class THETA : BaseCoin
    {
        public static string coin = "theta";
        public static decimal buyAmount = (decimal)20;
        public static decimal sellAmount = (decimal)19.6;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
