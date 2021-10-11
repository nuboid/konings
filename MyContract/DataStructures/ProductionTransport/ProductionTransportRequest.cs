using System;
using System.Collections.Generic;
using System.Text;

namespace MyContract.DataStructures.ProductionTransport
{
    public class ProductionTransportRequest
    {
        public string SSCC { get; set; }
        public string Establishment { get; set; }
        public string Zone { get; set; }
        public string Location { get; set; }
        public int Quantity { get; set; }
        public string UOM { get; set; }
        public bool Override { get; set; }
    }
}
