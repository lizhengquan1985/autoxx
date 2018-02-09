using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX
{
    /// <summary>
    /// 分析
    /// 1. 是否是拐点
    /// 2. 离上一次最高多少
    /// 3. 今日最高， 今日最低， 目前离最高多少，离最低多少
    /// 4. 24小时内最高， 24小时内最低，目前
    /// 4. 48小时内最高， 48小时内最低，目前
    /// 4. 72小时内最高， 72小时内最低，目前
    /// </summary>
    public class CoinAnalyze
    {
        public class ddd
        {
            public bool isHigh { get; set; }
            public decimal open { get; set; }
            public long id { get; set; }
        }

        public DateTime getdt(long id)
        {
            return new DateTime(id * 10000000 + new DateTime(1970, 1, 1, 8, 0, 0).Ticks);
        }

        /// <summary>
        /// 分析价位走势
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="toCoin"></param>
        public void Analyze(string coin, string toCoin)
        {
            int buyPlus = 0;
            int sellPlus = 0;
            string buyId = null;
            string sellId = null;

            try
            {
                ResponseKline res = new AnaylyzeApi().kline(coin+toCoin, "1min");

                List<ddd> dd = new List<ddd>();

                //List<decimal> high = new List<decimal>();
                //List<decimal> low = new List<decimal>();
                decimal openHigh = 0;
                long idHigh = 0;
                decimal openLow = 0;
                long idLow = 0;
                foreach (var item in res.data)
                {
                    if (openHigh == 0)
                    {
                        openHigh = item.open;
                    }
                    if (openLow == 0)
                    {
                        openLow = item.open;
                    }

                    if (item.open > openHigh)
                    {
                        openHigh = item.open;
                        idHigh = item.id;
                    }
                    if (item.open < openLow)
                    {
                        openLow = item.open;
                        idLow = item.id;
                    }

                    if (openHigh >= openLow * (decimal)1.02)
                    {
                        // 相差了3%， 说明是一个节点了。
                        if ((dd.Count == 0 && idHigh > idLow) || (dd.Count > 0 && !dd[dd.Count - 1].isHigh))
                        {
                            if (dd.Count > 0 && dd[dd.Count - 1].isHigh && dd[dd.Count - 1].open < openHigh)
                            {
                                dd[dd.Count - 1].open = openHigh;
                                dd[dd.Count - 1].id = idHigh;
                            }
                            else
                            {
                                dd.Add(new ddd() { isHigh = true, open = openHigh, id = idHigh });
                                openHigh = openLow;
                                idHigh = idLow;
                            }
                        }
                        else
                        {
                            if (dd.Count > 0 && !dd[dd.Count - 1].isHigh && dd[dd.Count - 1].open > openLow)
                            {
                                dd[dd.Count - 1].open = openLow;
                                dd[dd.Count - 1].id = idLow;
                            }
                            else
                            {
                                dd.Add(new ddd() { isHigh = false, open = openLow, id = idLow });
                                openLow = openHigh;
                                idLow = idHigh;
                            }
                        }
                    }

                }

                Console.WriteLine(dd.Count);

                decimal lowGo = 0;
                decimal highGo = 0;
                int i = 0;
                foreach (var item in dd)
                {
                    if (i < 8)
                    {
                        if (item.isHigh)
                        {
                            highGo += item.open;
                        }
                        else
                        {
                            lowGo += item.open;
                        }
                        i++;
                    }
                    Console.WriteLine($"{item.isHigh},  {item.open}，  {getdt(item.id)}");
                }

                Console.WriteLine(Math.Round(lowGo / 4, 8));
                Console.WriteLine(Math.Round(highGo / 4, 8));

                try
                {

                    //if(buyPlus < sellPlus + 2 && buyPlus < 5) //res.data[0].open <= Math.Round(lowGo / 3, 8) * (decimal) 1.015
                    //{
                    Console.WriteLine("买入： " + Math.Round(lowGo / 4, 8));
                    ResponseOrder order = new HuobiDemo().NewOrderBuy(accountId, 10050, Math.Round(lowGo / 4, 8), null);
                    if (order.status == "ok")
                    {
                        Console.WriteLine("buy buy");
                        buyId = order.data;
                        buyPlus++;
                    }
                    Console.WriteLine("buy buy over");
                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine("buy buy error");
                }


                try
                {
                    // 卖出高价

                    //if (sellPlus < buyPlus + 2 && sellPlus<3) //res.data[0].open <= Math.Round(lowGo / 3, 8) * (decimal)1.015
                    //{
                    //    Console.WriteLine("卖出： " + Math.Round(highGo / 4, 8));
                    //    ResponseOrder order = new HuobiDemo().NewOrderSell(accountId, 10000, Math.Round(highGo / 4, 8), null);
                    //    if(order.status == "ok")
                    //    {
                    //        Console.WriteLine("sell sell");
                    //        sellId = order.data;
                    //        sellPlus++;
                    //    }
                    //    Console.WriteLine("sell sell over");
                    //}
                }
                catch (Exception ex)
                {
                    Console.WriteLine("sell sell err");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("1111111111111111111111 over");
            }

        }
    }
}
