//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("CashAlert.Views.SetLimit.xaml", "Views/SetLimit.xaml", typeof(global::CashAlert.Views.SetLimit))]

namespace CashAlert.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views/SetLimit.xaml")]
    public partial class SetLimit : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::CashAlert.CustomeRenderer.MyCustomeEntry txtDeviceName;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::CashAlert.CustomeRenderer.MyCustomeEntry txtDeviceIP;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Button btnAddButton;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(SetLimit));
            txtDeviceName = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::CashAlert.CustomeRenderer.MyCustomeEntry>(this, "txtDeviceName");
            txtDeviceIP = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::CashAlert.CustomeRenderer.MyCustomeEntry>(this, "txtDeviceIP");
            btnAddButton = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Button>(this, "btnAddButton");
        }
    }
}
