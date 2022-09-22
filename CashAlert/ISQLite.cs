using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashAlert
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
