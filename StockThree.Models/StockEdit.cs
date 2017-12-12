using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockThree.Models
{
    public class StockEdit
    {
        public int TransactionId { get; set; }
        public string Ticker { get; set; }
        public int Shares { get; set; }


    }
}
