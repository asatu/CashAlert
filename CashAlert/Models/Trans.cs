using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashAlert.Models
{
    public class Trans
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public DateTime Date { get; set; }       
        public int Amount { get; set; }
        public string Remarks { get; set; }
    }
}
