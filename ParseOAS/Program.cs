using System;
using System.Net.Http;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Readers;

namespace ParseOAS
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://raw.githubusercontent.com/OAI/OpenAPI-Specification/")
            };

            var stream = await httpClient.GetStreamAsync("master/examples/v3.0/petstore.yaml");

            // Read V3 as YAML
            var openApiDocument = new OpenApiStreamReader().Read(stream, out var diagnostic);
            foreach (var s in openApiDocument.Components.Schemas)
            {
                Console.WriteLine(s.Key);
                foreach (var p in s.Value.Properties) 
                {
                    Console.WriteLine(p.Key);
                    var x = p.Value;
                }
            }


            //// Write V2 as JSON
            //var outputString = openApiDocument.Serialize(OpenApiSpecVersion.OpenApi2_0, OpenApiFormat.Json);

            //Console.WriteLine(outputString);

            Console.ReadKey();
        }
    }
}
