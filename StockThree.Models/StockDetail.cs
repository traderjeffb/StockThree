using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockThree.Models
{
    public class StockDetail
    {
        public int TransactionId { get; set; }
        public string Ticker { get; set; }
        public float EntryPrice { get; set; }
        public int Shares { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        public override string ToString() => $"[{TransactionId}] {Ticker}";
    }
}
