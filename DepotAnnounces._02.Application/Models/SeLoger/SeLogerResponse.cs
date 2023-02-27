using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DepotAnnounces._02.Application.Models.SeLoger
{
    public class SeLogerResponse
    {
        public List<object>? Places { get; set; }
        public List<Address>? Addresses { get; set; }
    }
    public class Address
    {
        public string? Type { get; set; }
        public string? Display { get; set; }
        public string? Tag { get; set; }
        public Params? Params { get; set; }
    }
    public class Params
    {
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Precision { get; set; }
        public string? Address { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? ExternalId { get; set; }
    }
}
