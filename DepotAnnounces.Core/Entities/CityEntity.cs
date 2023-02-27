using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DepotAnnounces._00.Core.Entities
{
    [Table("Cities")]
    public class CityEntity
    {
        [Key]       
        public int ZipCode { get; set; }
        public string? Name { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
    }
}
