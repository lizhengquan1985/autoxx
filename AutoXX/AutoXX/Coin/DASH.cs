﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class DASH : BaseCoin
    {
        public static string coin = "dash";
        public static decimal buyAmount = (decimal)0.012;

        public static void Do()
        {
            BaseRun(coin, buyAmount);
        }
    }
}
