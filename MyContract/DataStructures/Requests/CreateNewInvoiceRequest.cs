using System;
using System.Collections.Generic;

namespace MyContract.DataStructures.Requests
{
    public class CreateNewInvoiceRequest
    {
        public string CustomerID { get; set; }
        public DateTime InvoiceDate { get; set; }

        public List<InvoiceLine> InvoiceLines { get; set; }
    }

    public class InvoiceLine
    {
        public string ProductID { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int VatPercentage { get; set; }
        public double UnitPrice { get; set; }
    }
}
