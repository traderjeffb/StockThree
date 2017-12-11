using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StockThree.Web.Controllers
{
    public class StockCreate
    {   
        [Required]
        [MaxLength(4)]
        public string Ticker { get; set; }
        [Required]
        public int Shares { get; set; }
        [Required]
        public float EntryPrice { get; set; }

        public override string ToString() => Ticker;

    }
}