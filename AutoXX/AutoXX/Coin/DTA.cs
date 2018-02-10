using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX.Coin
{
    public class DTA
    {
        public static void Do()
        {
            // 获取最近行情
            string accountId = "1040955";
            string coin = "dta";
            decimal lastLow;
            decimal nowOpen;
            var flexPointList = new CoinAnalyze().Analyze(coin, "usdt", out lastLow, out nowOpen);
            // 分析是否下跌， 下跌超过一定数据，可以考虑
            Console.WriteLine(flexPointList[0].isHigh);
            var list = new CoinDao().ListNoSellRecord(coin);
            if (!flexPointList[0].isHigh)
            {
                // 最后一次是高位
                if (nowOpen > flexPointList[0].open * (decimal)1.005 && nowOpen < flexPointList[0].open * (decimal)1.01)
                {
                    var b = new AccountOrder().AccountBalance(accountId);

                    if (list.Count <= 0)
                    {
                        // 可以考虑
                        ResponseOrder order = new AccountOrder().NewOrderBuy(accountId, 10, decimal.Round(nowOpen * (decimal)1.005, 4), null, coin, "usdt");
                        new CoinDao().InsertLog(new BuyRecord()
                        {
                            BuyCoin = coin,
                            BuyPrice = nowOpen * (decimal)1.005,
                            BuyDate = DateTime.Now,
                            HasSell = false,
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
                    if (item.BuyPrice * (decimal)1.05 < higher && itemNowOpen * (decimal)1.005 < higher)
                    {
                        // 出售
                        ResponseOrder order = new AccountOrder().NewOrderSell(accountId, (decimal)9.8, decimal.Round(itemNowOpen * (decimal)0.98, 4), null, coin, "usdt");
                        new CoinDao().SetHasSell(item.Id);
                    }
                }
            }
        }
    }
}
