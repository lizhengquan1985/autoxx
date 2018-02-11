using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class BaseCoin
    {
        static ILog logger = LogManager.GetLogger("BaseCoin");

        public static string accountId = "1040955"; // yanxiuq
        private static AccountBalanceItem usdt;
        //public static string accountId = "529880";  // lizhengq

        public static bool CheckBalance()
        {
            if(usdt == null)
            {
                var accountInfo = new AccountOrder().AccountBalance(accountId);
                usdt = accountInfo.data.list.Find(it => it.currency == "usdt");
            }
            if(usdt.balance < 1)
            {
                Console.WriteLine("---------------------余额小于1，无法交易----------------------------");
                return false;
            }
            return true;
        }

        public static bool CheckCanBuy(decimal nowOpen, decimal nearLowOpen)
        {
            //nowOpen > flexPointList[0].open * (decimal)1.005 && nowOpen < flexPointList[0].open * (decimal)1.01
            return nowOpen > nearLowOpen * (decimal)1.005 && nowOpen < nearLowOpen * (decimal)1.01;
        }

        public static bool CheckCanSell(decimal buyPrice, decimal nearHigherOpen, decimal nowOpen)
        {
            //item.BuyPrice, higher, itemNowOpen
            // if (item.BuyPrice * (decimal)1.05 < higher && itemNowOpen * (decimal)1.005 < higher)
            if (nowOpen < buyPrice * (decimal)1.03)
            {
                // 如果不高于 3% 没有意义
                return false;
            }

            if (nowOpen * (decimal)1.005 < nearHigherOpen)
            {
                // 表示回头趋势， 暂时定为 0.5% 就有回头趋势
                return true;
            }

            return false;
            // buyPrice * (decimal)1.05 < nearHigherOpen && 
        }


        public static void BaseRun(string coin, decimal buyAmount, decimal sellAmount)
        {
            try
            {
                BusinessRun(coin, buyAmount, sellAmount);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message, ex);
            }
        }

        public static void BusinessRun(string coin, decimal buyAmount, decimal sellAmount)
        {
            // 获取最近行情
            decimal lastLow;
            decimal nowOpen;
            var flexPointList = new CoinAnalyze().Analyze(coin, "usdt", out lastLow, out nowOpen);
            if(coin == "xem")
            {
                //logger.Error(JsonConvert.SerializeObject(flexPointList));
            }
            // 分析是否下跌， 下跌超过一定数据，可以考虑
            var list = new CoinDao().ListNoSellRecord(coin);
            if (coin == "xem")
            {
                //logger.Error(JsonConvert.SerializeObject(list));
            }
            if (!flexPointList[0].isHigh)
            {
                // 最后一次是高位
                if (list.Count <= 0 && CheckCanBuy(nowOpen, flexPointList[0].open) && CheckBalance())
                {
                    // 可以考虑
                    ResponseOrder order = new AccountOrder().NewOrderBuy(accountId, buyAmount, decimal.Round(nowOpen * (decimal)1.005, 4), null, coin, "usdt");
                    logger.Error($"下单结果 coin{coin} accountId:{accountId}  购买数量{buyAmount} nowOpen{nowOpen} {JsonConvert.SerializeObject(order)}");
                    logger.Error($"下单结果 分析 {JsonConvert.SerializeObject(flexPointList)}");
                    if (order.status != "error")
                    {
                        new CoinDao().InsertLog(new BuyRecord()
                        {
                            BuyCoin = coin,
                            BuyPrice = nowOpen * (decimal)1.005,
                            BuyDate = DateTime.Now,
                            HasSell = false,
                            BuyOrderResult = JsonConvert.SerializeObject(order),
                            BuyAnalyze = JsonConvert.SerializeObject(flexPointList)
                        });
                        usdt = null;
                    }
                }

                if (list.Count > 0)
                {
                    // 获取最小的那个， 如果有，
                    decimal minBuyPrice = 9999;
                    foreach (var item in list)
                    {
                        if (item.BuyPrice < minBuyPrice)
                        {
                            minBuyPrice = item.BuyPrice;
                        }
                    }

                    // 再少于5%， 
                    if (nowOpen * (decimal)1.05 < minBuyPrice && CheckBalance())
                    {
                        ResponseOrder order = new AccountOrder().NewOrderBuy(accountId, buyAmount, decimal.Round(nowOpen * (decimal)1.005, 4), null, coin, "usdt");
                        logger.Error($"下单结果 coin{coin} accountId:{accountId}  购买数量{buyAmount} nowOpen{nowOpen} {JsonConvert.SerializeObject(order)}");
                        logger.Error($"下单结果 分析 {JsonConvert.SerializeObject(flexPointList)}");
                        if (order.status != "error")
                        {
                            new CoinDao().InsertLog(new BuyRecord()
                            {
                                BuyCoin = coin,
                                BuyPrice = nowOpen * (decimal)1.005,
                                BuyDate = DateTime.Now,
                                HasSell = false,
                                BuyOrderResult = JsonConvert.SerializeObject(order),
                                BuyAnalyze = JsonConvert.SerializeObject(flexPointList)
                            });
                            usdt = null;
                        }
                    }
                }
            }

            // 查询数据库中已经下单数据，如果有，则比较之后的最高值，如果有，则出售
            if (list.Count > 0)
            {
                foreach (var item in list)
                {
                    // 分析是否 大于
                    decimal itemNowOpen = 0;
                    decimal higher = new CoinAnalyze().AnalyzeNeedSell(item.BuyPrice, item.BuyDate, coin, "usdt", out itemNowOpen);
                    if (coin == "xem")
                    {
                        //logger.Error($"计算 {higher}, {itemNowOpen} {item.BuyPrice}");
                    }

                    if (CheckCanSell(item.BuyPrice, higher, itemNowOpen))
                    {
                        // 出售
                        ResponseOrder order = new AccountOrder().NewOrderSell(accountId, sellAmount, decimal.Round(itemNowOpen * (decimal)0.98, 4), null, coin, "usdt");
                        logger.Error($"出售结果 coin{coin} accountId:{accountId}  出售数量{sellAmount} itemNowOpen{itemNowOpen} higher{higher} {JsonConvert.SerializeObject(order)}");
                        logger.Error($"出售结果 分析 {JsonConvert.SerializeObject(flexPointList)}");
                        new CoinDao().SetHasSell(item.Id, JsonConvert.SerializeObject(order), JsonConvert.SerializeObject(flexPointList));
                        usdt = null;
                    }
                }
            }
        }
    }
}
