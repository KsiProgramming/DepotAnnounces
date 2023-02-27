using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepotAnnounces._00.Core.Entities
{
    public class AddressEntity
    {
        [Key]
        public string? Id { get; set; }        
        public string? Name { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }

        [ForeignKey(nameof(CityEntity.ZipCode))]
        public int ZipCode { get; set; }
    }
}
