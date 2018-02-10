using AutoXX.Coin;
using MySql.Data.MySqlClient;
using SharpDapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoXX
{
    class Program
    {
        static void Main(string[] args)
        {
            //new CoinDao().InsertLog(new BuyRecord()
            //{
            //     BuyCoin ="ltc",
            //     BuyPrice = new decimal(1.1),
            //      BuyDate = DateTime.Now,
            //       HasSell = false,
            //});

            //var list = new CoinDao().ListNoSellRecord("ltc");
            //Console.WriteLine(list.Count);
            //new CoinDao().SetHasSell(1);

            //var res = new AccountOrder().Accounts();
            //Console.WriteLine(res);
            //Console.WriteLine(res.data.Count);
            //while (true)
            //{
            //    Console.WriteLine("请输入 id：");
            //    var id = Console.ReadLine();
            //    var b = new AccountOrder().AccountBalance(id);
            //    Console.WriteLine(b);
            //}

            //while (true)
            //{
            //    Console.WriteLine("请输入：");
            //    var coin = Console.ReadLine();

            //    decimal lastLow;
            //    decimal nowOpen;
            //    var flexPointList = new CoinAnalyze().Analyze(coin, "usdt", out lastLow, out nowOpen);
            //    foreach (var flexPoint in flexPointList)
            //    {
            //        Console.WriteLine($"{flexPoint.isHigh}, {flexPoint.open}, {Utils.GetDateById(flexPoint.id)}");
            //    }
            //}

            while (true)
            {
                Thread.Sleep(1000 * 10);

                try
                {
                    XEM.Do();
                    SMT.Do();
                    DTA.Do();
                    VEN.Do();
                    ELF.Do();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
