using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using Xamarin.Essentials;
using Android.Support.CustomTabs;

namespace YorderApp.Droid
{
    [Activity(Label = "YorderApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    [IntentFilter(new[] { Intent.ActionMain, Intent.ActionView, Intent.ActionAllApps }, 
        Categories = new[]
    {
        Intent.CategoryDefault,
        Intent.CategoryBrowsable
    }, DataSchemes = new[] { "http","https","upi","gpay" }, DataHosts = new[] { "*.xamarin.com", "xamarin.com", "greycats.tech", "*.greycats.tech" }, DataMimeType = "text/plain",AutoVerify =true,Priority =0
    )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, savedInstanceState);
            var builder = new CustomTabsIntent.Builder().EnableUrlBarHiding();
            var customTabsIntent = builder.Build();
            Android.Net.Uri websiteurl = Android.Net.Uri.Parse("https://www.greycats.tech");
           // customTabsIntent.LaunchUrl(this, websiteurl);
           // Android.Support.CustomTabs.TrustedWebUtils.LaunchAsTrustedWebActivity(this,customTabsIntent,Android.Net.Uri.Parse("https://greycats.tech"));
           
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        public class WebAuthenticationCallbackActivity : Xamarin.Essentials.WebAuthenticatorCallbackActivity
        {
        }

    }
}
