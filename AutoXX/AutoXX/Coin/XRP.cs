﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class XRP : BaseCoin
    {
        public static string coin = "xrp";
        public static decimal buyAmount = (decimal)3;
        public static decimal sellAmount = (decimal)2.94;

        public static void Do()
        {
            BaseRun(coin, buyAmount, sellAmount);
        }
    }
}
