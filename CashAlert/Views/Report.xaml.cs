using CashAlert.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Syncfusion.Drawing;

namespace CashAlert.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class Report : ContentPage
    {
        private SQLiteConnection conn;
        public Trans Dev;
        public Report()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Trans>();
            btnPrint.Clicked += BtnPrint_Clicked;
        }

        private void BtnPrint_Clicked(object sender, EventArgs e)
        {        
           LoadPrintData();
        }
        
        private void LoadPrintData()
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "select * from Trans -- where Date = '" + dtDate.Date + "'";
                var r = cmd.ExecuteQuery<Trans>();
                List<Trans> Tr = new List<Trans>();
                lv.ItemsSource = null;
                int CalculateTotal = 0;
                foreach (var item in r)
                {
                    if (item.Date.ToShortDateString().Equals(dtDate.Date.ToShortDateString()))
                    {
                        Tr.Add(item);
                        CalculateTotal += item.Amount;
                    }                    
                }
                if (Tr.Count > 0)
                {
                    lv.ItemsSource = Tr;
                    lblTotal.Text = "Total : " + CalculateTotal;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Warning", ex.Message, "OK");
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            try
            {
               Xamarin.Forms.Image imageSender = (Xamarin.Forms.Image)sender;
                if (imageSender.GestureRecognizers.Count > 0)
                {
                    var gesture = (TapGestureRecognizer)imageSender.GestureRecognizers[0];
                    var fullPath = gesture.CommandParameter;
                    SQLiteCommand cmd = new SQLiteCommand(conn);
                    cmd.CommandText = "delete from Trans where ID = " + fullPath;
                    cmd.ExecuteNonQuery();
                    LoadPrintData();
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void lv_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private void lv_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }   
}