using MySql.Data.MySqlClient;
using SharpDapper;
using SharpDapper.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoXX
{
    public class CoinDao
    {
        public CoinDao()
        {
            string connectionString = "server=localhost;port=3306;user id=root; password=lyx123456; database=coins; pooling=true; charset=utf8mb4";
            var connection = new MySqlConnection(connectionString);
            Database = new DapperConnection(connection);

        }
        protected IDapperConnection Database { get; private set; }

        public void InsertLog(BuyRecord buyRecord)
        {
            if (buyRecord.BuyAnalyze.Length > 4000)
            {
                buyRecord.BuyAnalyze = buyRecord.BuyAnalyze.Substring(0, 4000);
            }
            if (buyRecord.BuyOrderResult.Length > 500)
            {
                buyRecord.BuyOrderResult = buyRecord.BuyOrderResult.Substring(0, 500);
            }

            using (var tx = Database.BeginTransaction())
            {
                Database.Insert(buyRecord);
                tx.Commit();
            }
        }

        public List<BuyRecord> ListNoSellRecord(string buyCoin)
        {
            var sql = $"select * from t_buy_record where BuyCoin = '{buyCoin}' and HasSell=0";
            return Database.Query<BuyRecord>(sql).ToList();
        }

        public void SetHasSell(long id, string sellOrderResult, string sellAnalyze)
        {
            if(sellAnalyze.Length > 4000)
            {
                sellAnalyze = sellAnalyze.Substring(0, 4000);
            }
            if (sellOrderResult.Length > 500)
            {
                sellOrderResult = sellOrderResult.Substring(0, 500);
            }

            using (var tx = Database.BeginTransaction())
            {
                var sql = $"update t_buy_record set HasSell=1, SellAnalyze='{sellAnalyze}', SellOrderResult='{sellOrderResult}' where Id = {id}";
                Database.Execute(sql);
                tx.Commit();
            }
        }
    }

    [Table("t_buy_record")]
    public class BuyRecord
    {
        public long Id { get; set; }
        public string BuyCoin { get; set; }
        public decimal BuyPrice { get; set; }
        public DateTime BuyDate { get; set; }
        public bool HasSell { get; set; }

        public string BuyAnalyze { get; set; }
        public string SellAnalyze { get; set; }
        public string BuyOrderResult { get; set; }
        public string SellOrderResult { get; set; }
    }
}
