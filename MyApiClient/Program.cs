using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyContract.DataStructures.Requests;
using Newtonsoft.Json;

namespace MyApiClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.ReadKey();

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

            //The url to post to.
            var url = "http://localhost:50063/api/Invoice";
            var client = new HttpClient();

            //Pass in the full URL and the json string content
            var response = await client.PostAsync(url, data);

            //It would be better to make sure this request actually made it through
            string result = await response.Content.ReadAsStringAsync();
            //var response = await httpClient.GetAsync("http://localhost:50063/WeatherForecast");
            //var json = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(json);

            Console.ReadKey();
        }
    }
}
