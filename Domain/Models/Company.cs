using System;
using System.Collections.Generic;

namespace TreasuryApp.API.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string PhysicalAddress { get; set; }
        public string Country { get; set; }
        public string SwiftAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string ReportingCurrency { get; set; }
        public string ParentEntity { get; set; }
        public string SuspenseGLAccount { get; set; }
        public DateTime TradingDate { get; set; }
        public DateTime NextTradingDate { get; set; }
        public DateTime LastEODDate { get; set; }
        public DateTime NextEODDate { get; set; }
        public DateTime EODGLDate { get; set; }
        public string MRSName { get; set; }
    }
}