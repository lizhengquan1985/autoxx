using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class ELF : BaseCoin
    {
        public static string coin = "elf";
        public static decimal buyAmount = (decimal)6;

        public static void Do()
        {
            BaseRun(coin, buyAmount);
        }
    }
}
