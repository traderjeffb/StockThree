using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockThree.Data
{
    public class Stock
    {   [Key]
        public int TransactionId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Ticker { get; set; }
        [Required]
        public float EntryPrice { get; set; }
        public float ExitPrice { get; set; }
        public float AccountBalance { get; set; }
        [Required]
        public int Shares { get; set; }
        public float ProfitLoss { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }


}

