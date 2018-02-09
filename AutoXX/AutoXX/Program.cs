using MySql.Data.MySqlClient;
using SharpDapper;
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
            new CoinDao().InsertLog(new BuyRecord()
            {
                 BuyCoin ="ltc",
                 BuyPrice = new decimal(1.1),
                  BuyDate = DateTime.Now,
                   HasSell = false,
            });

            var list = new CoinDao().ListNoSellRecord("ltc");
            Console.WriteLine(list.Count);
            new CoinDao().SetHasSell(1);

            while (true)
            {
                Console.WriteLine("请输入：");
                var coin = Console.ReadLine();

                var flexPointList = new CoinAnalyze().Analyze(coin, "usdt");
                foreach (var flexPoint in flexPointList)
                {
                    Console.WriteLine($"{flexPoint.isHigh}, {flexPoint.open}, {Utils.GetDateById(flexPoint.id)}");
                }
            }
        }
    }
}
