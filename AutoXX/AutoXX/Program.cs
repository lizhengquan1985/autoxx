using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX
{
    class Program
    {
        static void Main(string[] args)
        {
            var flexPointList = new CoinAnalyze().Analyze("bch", "usdt");
            foreach(var flexPoint in flexPointList)
            {
                Console.WriteLine($"{flexPoint.isHigh}, {flexPoint.open}, {Utils.GetDateById(flexPoint.id)}");
            }


            Console.Read();
        }
    }
}
