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
    public partial class SetLimit : ContentPage
    {
        private SQLiteConnection conn;
        public Limits Dev;
        bool upval = false;
        public SetLimit()
        {
            InitializeComponent();
            txtDeviceName.Text = "1";            
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Limits>();
            btnAddButton.Clicked += BtnAddButton_Clicked;
            LoadGrid();
        }
        private void LoadGrid()
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "select * from Limits";               
                var r = cmd.ExecuteQuery<Limits>();
                if (r.Count > 0)
                {
                    txtDeviceIP.Text = r[0].Limit.ToString();
                    upval = true;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Attenzione", ex.Message, "OK");
            }
        }
        private void BtnAddButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDeviceName.Text))
                {
                    DisplayAlert("Attenzione", "Il Limite è obbligatorio", "OK");
                    return;
                }
                if (string.IsNullOrEmpty(txtDeviceIP.Text))
                {
                    DisplayAlert("Attenzione", "ID è obbligatorio ", "OK");
                    return;
                }
                Dev = new Limits();

                decimal val = 0;
                decimal.TryParse(txtDeviceIP.Text,out val);

                Dev.LimitID = txtDeviceName.Text;
                Dev.Limit = val;

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
                DisplayAlert("Confermato", "Limite impostato correttamente!", "OK");
                LoadGrid();
            }
            catch (Exception ex)
            {
                DisplayAlert("Attenzione", ex.Message, "OK");
            }
        }
    }
}