using CashAlert.ViewModels;
using CashAlert.Views;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CashAlert
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public string WebAPIkey = "AIzaSyDpJwmEi_i7lI2gDil8epd2AoPgUqiYfK4";
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            //GetProfileInformationAndRefreshToken();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }


        // private async void GetProfileInformationAndRefreshToken()
        // {
        //     var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
        //     try
        //     {
        //This is the saved firebaseauthentication that was saved during the time of login
        //         var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
        //Here we are Refreshing the token
        //var RefreshedContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
        //Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
        //Now lets grab user information
        //MyUserName = savedfirebaseauth.User.Email;
        //
        //}
        //      catch (Exception ex)
        //      {
        //Console.WriteLine(ex.Message);
        //await App.Current.MainPage.DisplayAlert("Alert", "Oh no !  Token expired", "OK");
        //}
        //}
    }
}
