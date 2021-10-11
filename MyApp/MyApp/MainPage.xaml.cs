using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyContract.DataStructures.Requests;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MyApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var invoiceCreateRequest =
                new CreateNewInvoiceRequest();

            invoiceCreateRequest.CustomerID = "KLANT1";
            invoiceCreateRequest.InvoiceLines = new List<InvoiceLine>();
            invoiceCreateRequest.InvoiceLines.Add(new InvoiceLine
            {
                ProductID = "P1",
                Description = "ksjdhfkjdhfkjsdf",
                Quantity = 100,
                UnitPrice = 100.78,
                VatPercentage = 6
            });
            invoiceCreateRequest.InvoiceLines.Add(new InvoiceLine
            {
                ProductID = "P2",
                Description = "ksjdhfkjdhfkjsdf",
                Quantity = 200,
                UnitPrice = 10.78,
                VatPercentage = 21
            });

            var json = JsonConvert.SerializeObject(invoiceCreateRequest);
            Console.WriteLine(json);


            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "https://konnigsdemo.azurewebsites.net/api/Invoice";
            var client = new HttpClient();

            try
            {
                var response = await client.PostAsync(url, data);
                response.EnsureSuccessStatusCode();
                string result = await response.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                DisplayAlert("Demo", ex.ToString(), "ok");
            }



            //if (result)
            //{
            //    DisplayAlert("Demo", result, "ok");
            //}
        }
    }
}
