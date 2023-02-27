using AutoMapper;
using DepotAnnounces._00.Core.Entities;
using DepotAnnounces._03.Presentation.API.Dtos;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DepotAnnounces._03.Presentation.API.Profiles
{
    public class AnnounceProfile:Profile
    {
        public AnnounceProfile()
        {
            CreateMap<AnnounceEntity, AnnounceForDisplayDto>().ForMember(dest => dest.PropertyType,
                                                                                                opt => opt.MapFrom(src => $"{src.PropertyType.ToString()}"))
                                                             .ForMember(dest => dest.Status,
                                                                                                opt => opt.MapFrom(src => src.IsPublished ? "Publiée" : "En attente de validation"))
                                                             .ForMember(dest => dest.EnergyEfficiency,
                                                                                                opt => opt.MapFrom(src => $"{src.EnergyEfficiency.ToString()}"))
                                                             .ForMember(dest => dest.Type,
                                                                                                opt => opt.MapFrom(src => $"{src.Type.ToString()}"));
            CreateMap<AnnounceForCreation, AnnounceEntity>();
        } 
       
    }
}
