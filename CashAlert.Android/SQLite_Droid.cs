using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CashAlert.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Droid))]
namespace CashAlert.Droid
{
    public class SQLite_Droid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var dbName = "mydatabase.db3";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            // var dbPath = Directory.GetCurrentDirectory();
            var path = Path.Combine(dbPath, dbName);
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}