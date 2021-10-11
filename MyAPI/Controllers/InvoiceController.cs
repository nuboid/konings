using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyContract.DataStructures.Requests;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {

        [HttpPost]
        public async Task<bool> CreateNewInvoice(CreateNewInvoiceRequest request)
        {
            Console.WriteLine(request.CustomerID);
            foreach (var invoiceLine in request.InvoiceLines)
            {
                Console.WriteLine(invoiceLine.ProductID);
            }
            return true;
        }

        [HttpGet]
        public async Task<bool> GetNewInvoice(CreateNewInvoiceRequest request)
        {
            Console.WriteLine(request.CustomerID);
            foreach (var invoiceLine in request.InvoiceLines)
            {
                Console.WriteLine(invoiceLine.ProductID);
            }
            return true;
        }

        //[HttpDelete]
        //public async Task<bool> GetNewInvoice(CreateNewInvoiceRequest request)
        //{
        //    Console.WriteLine(request.CustomerID);
        //    foreach (var invoiceLine in request.InvoiceLines)
        //    {
        //        Console.WriteLine(invoiceLine.ProductID);
        //    }
        //    return true;
        //}
    }
}
