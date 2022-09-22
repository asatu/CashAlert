using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CashAlert.CustomeRenderer;
using CashAlert.Droid.CustomRenderer;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CashAlert.Models;
[assembly: ExportRenderer(typeof(MyCustomeEntry), typeof(MyEntryRenderer))]

namespace CashAlert.Droid.CustomRenderer
{
    class MyEntryRenderer : EntryRenderer
    {
        
        public MyEntryRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
        }
    }
}