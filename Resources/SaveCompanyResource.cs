using System;
using System.ComponentModel.DataAnnotations;

namespace TreasuryApp.API.Resources
{
    public class SaveCompanyResource
    {   
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string PhysicalAddress { get; set; }
        public string Country { get; set; }
        [Required]
        public string SwiftAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string ReportingCurrency { get; set; }
        public string ParentEntity { get; set; }
        [Required]
        public string SuspenseGLAccount { get; set; }
        [Required]
        public DateTime TradingDate { get; set; }
        [Required]
        public DateTime NextTradingDate { get; set; }
        [Required]
        public DateTime LastEODDate { get; set; }
        [Required]
        public DateTime NextEODDate { get; set; }
        [Required]
        public DateTime EODGLDate { get; set; }
        [Required]
        public string MRSName { get; set; }
    }
}