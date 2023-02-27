using DepotAnnounces._00.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace DepotAnnounces._03.Presentation.API.Dtos
{
    public class AnnounceForCreation
    {
        public string? Title { get; set; }
        [Required]
        [MinLength(5)]
        public string? Location { get; set; }
        [Required]
        [Range(1,3, ErrorMessage = "Type de bien non valide 1:Maison, 2: Appartement, 3: Parking")]
        public ePropertyType? PropertyType { get; set; }
        [Required]
        [Range(1, 2, ErrorMessage = "Type de announce non valide 1:Achat, 2: Location")]
        public eAnnounceType Type { get; set; }
        [Required]
        [MinLength(10)]
        public string? Description { get; set; }
        public string? Picture { get; set; }
        [Required]
        [Range(10,int.MaxValue)]
        public int? PriceWithoutCharges { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int? ChargesPrice { get; set; }
        public string? Reference { get; set; }
    }
}
