using DepotAnnounces._00.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DepotAnnounces._00.Core.Entities
{
    [Table("Announces")]
    public class AnnounceEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public eAnnounceType Type { get; set; }
        public string? Reference { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public bool IsPublished { get; set; }
        public decimal? Size { get; set; }
        public int? numRooms { get; set; }
        public int? numBedRooms { get; set; }
        public bool? IsFurnished { get; set; }        
        public string? Picture { get; set; }
        public int? PriceWithoutCharges { get; set; }
        public int? ChargesPrice { get; set; }
        public int DamageDeposit { get; set; }
        public bool IsIntenseArea { get; set; }        
        public ePropertyType PropertyType { get; set; }
        public eEnergyEfficiency EnergyEfficiency { get; set; }

        [ForeignKey(nameof(CityEntity.ZipCode))]
        public int ZipCode { get; set; }

        [ForeignKey(nameof(AddressEntity.Id))]
        public string AddressId { get; set; }

    }
}
