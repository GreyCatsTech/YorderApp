using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration.WindowsSpecific;
using Xamarin.Auth;


namespace YorderApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //YorderURL.On<Android>();
            Xamarin.Auth.AuthenticationUIType nativeweb = Xamarin.Auth.AuthenticationUIType.EmbeddedBrowser;
            YorderURL.Navigated += YorderURL_Navigated;
            
            
        }

        private void YorderURL_Navigated(object sender, WebNavigatedEventArgs e)
        {
            var url = e.Url;
            if (url.Contains("https://greycats.tech/?wc-api=razorpay&order_key=wc_order_") || url.Contains("https://greycats.tech/checkout/order-pay/"))
            {
                string[] urlordernumber = url.Split("order_".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                YorderURL.EvaluateJavaScriptAsync("https://greycats.tech/?wc-api=razorpay&order_key=wc_order_"+urlordernumber.Last());
            }
        }

    }
}
