using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashAlert.Models
{
    public class Limits
    {
        [PrimaryKey]
        public string LimitID { get; set; }
        public decimal Limit { get; set; }
    }
}
