using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockThree.Models
{
    public class StockCreate
    {   
        [Required]
        [ MaxLength(4)]
        public string Ticker { get; set; }
        [Required]
        public int Shares { get; set; }
        [Required]
        public float EntryPrice { get; set; }



    }
}
