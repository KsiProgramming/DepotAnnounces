using DepotAnnounces._00.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepotAnnounces._03.Presentation.API.Dtos
{
    public class AnnounceForDisplayDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string Type { get; set; }
        public string? Reference { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string Status { get; set; }
        public decimal? Size { get; set; }
        public int? numRooms { get; set; }
        public int? numBedRooms { get; set; }
        public bool? IsFurnished { get; set; }
        public string? Picture { get; set; }        
        public string? FullPrice{ get; set; }
        public int DamageDeposit { get; set; }
        public bool IsIntenseArea { get; set; }
        public string PropertyType { get; set; }
        public string EnergyEfficiency { get; set; }

        [ForeignKey(nameof(CityEntity.ZipCode))]
        public int ZipCode { get; set; }
        public string? Temperature { get; set; }
    }
}
