﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class ITC : BaseCoin
    {
        public static string coin = "itc";
        public static decimal buyAmount = (decimal)4;

        public static void Do()
        {
            BaseRun(coin, buyAmount);
        }
    }
}
