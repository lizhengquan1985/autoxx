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
        public static string accountId = "1040955"; // yanxiuq
        //public static string accountId = "529880";  // lizhengq

        public static bool CheckCanBuy(decimal nowOpen, decimal nearLowOpen)
        {
            //nowOpen > flexPointList[0].open * (decimal)1.005 && nowOpen < flexPointList[0].open * (decimal)1.01
            return nowOpen > nearLowOpen * (decimal)1.005 && nowOpen < nearLowOpen * (decimal)1.01;
        }

        public static bool CheckCanSell(decimal buyPrice, decimal nearHigherOpen, decimal nowOpen)
        {
            // if (item.BuyPrice * (decimal)1.05 < higher && itemNowOpen * (decimal)1.005 < higher)
            if (nowOpen < buyPrice * (decimal)1.03)
            {
                // 如果不高于 3% 没有意义
                return false;
            }

            if(nearHigherOpen * (decimal)1.005 < nearHigherOpen)
            {
                // 表示回头趋势， 暂时定为 0.5% 就有回头趋势
                return true;
            }

            return false;
            // buyPrice * (decimal)1.05 < nearHigherOpen && 
        }


        public static void BaseRun(string coin, decimal buyAmount, decimal sellAmount)
        {
            // 获取最近行情
            decimal lastLow;
            decimal nowOpen;
            var flexPointList = new CoinAnalyze().Analyze(coin, "usdt", out lastLow, out nowOpen);
            // 分析是否下跌， 下跌超过一定数据，可以考虑
            var list = new CoinDao().ListNoSellRecord(coin);
            if (!flexPointList[0].isHigh)
            {
                // 最后一次是高位
                if (list.Count <= 0 && CheckCanBuy(nowOpen, flexPointList[0].open))
                {
                    // 可以考虑
                    ResponseOrder order = new AccountOrder().NewOrderBuy(accountId, buyAmount, decimal.Round(nowOpen * (decimal)1.005, 4), null, coin, "usdt");
                    new CoinDao().InsertLog(new BuyRecord()
                    {
                        BuyCoin = coin,
                        BuyPrice = nowOpen * (decimal)1.005,
                        BuyDate = DateTime.Now,
                        HasSell = false,
                        BuyOrderResult = JsonConvert.SerializeObject(order),
                        BuyAnalyze = JsonConvert.SerializeObject(flexPointList)
                    });
                }

                if(list.Count > 0)
                {
                    // 获取最小的那个， 如果有，
                    decimal minBuyPrice = 9999;
                    foreach(var item in list)
                    {
                        if(item.BuyPrice < minBuyPrice)
                        {
                            minBuyPrice = item.BuyPrice;
                        }
                    }

                    // 再少于5%， 
                    if(nowOpen * (decimal)1.05 < minBuyPrice)
                    {
                        ResponseOrder order = new AccountOrder().NewOrderBuy(accountId, buyAmount, decimal.Round(nowOpen * (decimal)1.005, 4), null, coin, "usdt");
                        new CoinDao().InsertLog(new BuyRecord()
                        {
                            BuyCoin = coin,
                            BuyPrice = nowOpen * (decimal)1.005,
                            BuyDate = DateTime.Now,
                            HasSell = false,
                            BuyOrderResult = JsonConvert.SerializeObject(order),
                            BuyAnalyze = JsonConvert.SerializeObject(flexPointList)
                        });
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

                    if (CheckCanSell(item.BuyPrice, higher, itemNowOpen))
                    {
                        // 出售
                        ResponseOrder order = new AccountOrder().NewOrderSell(accountId, sellAmount, decimal.Round(itemNowOpen * (decimal)0.98, 4), null, coin, "usdt");
                        new CoinDao().SetHasSell(item.Id, JsonConvert.SerializeObject(order), JsonConvert.SerializeObject(flexPointList));
                    }
                }
            }
        }
    }
}
