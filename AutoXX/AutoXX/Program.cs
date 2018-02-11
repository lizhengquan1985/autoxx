using AutoXX.Coin;
using log4net;
using log4net.Config;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using SharpDapper;
using System;
using System.Collections.Generic;
using System.IO;
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
            XmlConfigurator.Configure(new FileInfo("log4net.config"));
            ILog logger = LogManager.GetLogger("program");
            logger.Error("test test test");

            //Test();


            Run();
        }

        public static void Test()
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

            var res = new AccountOrder().Accounts();
            Console.WriteLine(res);
            //Console.WriteLine(res.data.Count);
            while (true)
            {
                Console.WriteLine("请输入 id：");
                var id = Console.ReadLine();
                var b = new AccountOrder().AccountBalance(id);
                b.data.list = b.data.list.Where(it => it.balance > 0).ToList();
                var usdt = b.data.list.Find(it => it.currency == "usdt");
                Console.WriteLine(JsonConvert.SerializeObject(b));
                Console.WriteLine(JsonConvert.SerializeObject(usdt));
            }

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
        }

        public static void Run()
        {
            while (true)
            {
                Thread.Sleep(1000 * 20);

                try
                {
                    XEM.Do();
                    SMT.Do();
                    DTA.Do();
                    ELF.Do();
                    ZIL.Do();
                    LET.Do();
                    HT.Do();
                    THETA.Do();
                    SNT.Do();
                    STORJ.Do();
                    GNT.Do();
                    CVC.Do();
                    //VEN.Do();
                    IOST.Do();
                    XRP.Do();
                    //NEO.Do();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
