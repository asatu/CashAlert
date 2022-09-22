using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashAlert.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CashAlert.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScreenPage : ContentPage
    {
        private SQLiteConnection conn;
        public Trans Dev;
        bool upval = false;
        public ScreenPage()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Trans>();
            btnAddButton.Clicked += BtnAddButton_Clicked;

            LoadID();
        }
        private void LoadID()
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "select * from Trans";
                var r = cmd.ExecuteQuery<Trans>();
                if (r.Count > 0)
                {
                    if (r[0].ID == 0)
                    {
                        txtID.Text = "1";
                    }
                    else
                    {
                        txtID.Text =Convert.ToString(r[r.Count-1].ID+1).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Attenzione", ex.Message, "OK");
            }
        }
        private void LoadGrid()
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "select * from Limits";
                var r = cmd.ExecuteQuery<Trans>();
                if (r.Count > 0)
                {
                    upval = true;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Attenzione", ex.Message, "OK");
            }
        }
        private decimal CompareLimit()
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);
                //cmd.CommandText = "select * from Limits";
                // cmd.CommandText = "select sum(Amount) from Trans where Date = '" + DateTime.Now.Date + "'";
                decimal Remaining = 0;
                cmd.CommandText = "select * from Trans";
                var r = cmd.ExecuteQuery<Trans>();
                int TodayTotal = 0;
                if (r.Count > 0)
                {
                    foreach (var item in r)
                    {
                        if (item.Date.ToShortDateString().Equals(dtDate.Date.ToShortDateString()))
                        {
                            TodayTotal += item.Amount;
                        }
                    }
                }
                cmd.CommandText = "select * from Limits";
                var rr = cmd.ExecuteQuery<Limits>();
                if (rr.Count > 0)
                {
                    Remaining = rr[0].Limit - TodayTotal;
                }
                return Remaining;
            }
            catch (Exception ex)
            {
                DisplayAlert("Attenzione", ex.Message, "OK");
                return 0;
            }
        }
        private void BtnAddButton_Clicked(object sender, EventArgs e)
        {
            try
            {                       
                if (string.IsNullOrEmpty(txtAmount.Text))
                {
                    DisplayAlert("Attenzione", "L'Importo è obbligatorio", "OK");
                    return;
                }
                var x = CompareLimit();                
                Dev = new Trans();
                Dev.Amount = Convert.ToInt32(txtAmount.Text);
                Dev.Date = dtDate.Date;
                Dev.Remarks = txtRemarks.Text;

                if (x - Dev.Amount < 0)
                {
                    DisplayAlert("Attenzione", "Hai superato il Limite!", "OK");
                    return;
                }
                if (!upval)
                {
                    upval = false;
                    conn.Insert(Dev);
                }
                else
                {
                    upval = false;
                    conn.Update(Dev);
                }
                DisplayAlert("Confermato", "Spesa aggiunta correttamente!", "OK");
                LoadID();
                txtAmount.Text = "0";
                txtRemarks.Text = "";
            }
            catch (Exception ex)
            {
                DisplayAlert("Attenzione", ex.Message, "OK");
            }
        }
    }
}