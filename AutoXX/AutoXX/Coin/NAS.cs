﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class NAS : BaseCoin
    {
        public static string coin = "nas";
        public static decimal buyAmount = (decimal)0.4;
        public static decimal sellAmount = (decimal)0.392;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
