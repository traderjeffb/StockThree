using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockThree.Models
{
    public class StockListItem
    {
        public int TransactionId { get; set; }
        public string Ticker { get; set; }
        public int Shares { get; set; }

        [Display(Name= "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
