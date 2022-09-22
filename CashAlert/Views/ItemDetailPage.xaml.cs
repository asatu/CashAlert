using CashAlert.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace CashAlert.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}