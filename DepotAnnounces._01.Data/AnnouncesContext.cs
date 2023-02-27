using DepotAnnounces._00.Core.Entities;
using DepotAnnounces._00.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace DepotAnnounces._01.Data
{
    public class AnnouncesContext : DbContext
    {
        public DbSet<AnnounceEntity> Announces { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public AnnouncesContext(DbContextOptions<AnnouncesContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AnnounceEntity>().HasData(
                  new AnnounceEntity()
                  {
                      Id = Guid.Parse("3bf5f181-f806-4fc4-bbf7-45676dc677ec"),
                      Title = "edrf gvt",
                      Description = "12345",
                      Location = "Rue du Nord 67860 Rhinau",
                      IsPublished = true,
                      PropertyType = ePropertyType.Maison,
                      Picture = "https://images.pexels.com/photos/1571460/pexels-photo-1571460.jpeg?auto=compress&cs=tinysrgb&w=1600",
                      ZipCode = 67860,
                      Type = eAnnounceType.Location,
                      Size = 45,
                      numRooms = 2,
                      numBedRooms = 1,
                      IsFurnished = true,
                      PriceWithoutCharges = 300,
                      ChargesPrice = 50,
                      DamageDeposit = 600,
                      IsIntenseArea = false,
                      EnergyEfficiency = eEnergyEfficiency.B,
                      AddressId = "Rue du Nord 67860 Rhinau".Trim()
                  },
                  new AnnounceEntity()
                  {
                      Id = Guid.Parse("3bf5f181-f806-4fc4-bbf7-45676dc777ec"),
                      Title = "Appartement haussmannien",
                      Description = "12345",
                      Location = "Rue Saint-Jacques 75005 Paris",
                      IsPublished = false,
                      PropertyType = ePropertyType.Appartement,
                      Picture = "https://photo.barnes-international.com/annonces/bms/111/xl/17181965645f219d33ac0973.31884369_a6028841d1_1920.jpg",
                      ZipCode = 75005,
                      Type = eAnnounceType.Location,
                      Size = 45,
                      numRooms = 2,
                      numBedRooms = 1,
                      IsFurnished = true,
                      PriceWithoutCharges = 300,
                      ChargesPrice = 50,
                      DamageDeposit = 600,
                      IsIntenseArea = true,
                      EnergyEfficiency = eEnergyEfficiency.C,
                      AddressId = "Rue Saint-Jacques 75005 Paris".Trim()
                  },
                  new AnnounceEntity()
                  {
                      Id = Guid.Parse("29354a4e-f133-495e-8158-d33009d74f3e"),
                      Title = "Appartement-terrasse rénové – vue panoramique\r\n",
                      Description = "Proche de la clinique mutualiste, ce bien en dernier étage profite d’une grande terrasse sans vis-à-vis et d’une vue sur la ville et les montagnes à couper le souffle !",
                      Location = "Avenue Jean Perrot 38100 Grenoble",
                      IsPublished = false,
                      PropertyType = ePropertyType.Appartement,
                      Picture = "https://www.espaces-atypiques.com/wp-content/uploads/2020/08/appartement-terrasse-vue-panoramique-grenoble-506eag-1-Copier-1680x1118.jpg",
                      ZipCode = 38100,
                      Type = eAnnounceType.Location,
                      Size = 45,
                      numRooms = 2,
                      numBedRooms = 1,
                      IsFurnished = true,
                      PriceWithoutCharges = 300,
                      ChargesPrice = 50,
                      DamageDeposit = 600,
                      IsIntenseArea = true,
                      EnergyEfficiency = eEnergyEfficiency.B,
                      AddressId = "Avenue Jean Perrot 38100 Grenoble".Trim()
                  },
                  new AnnounceEntity()
                  {
                      Id = Guid.Parse("8f3064c9-b4cd-4165-b6c7-e7ab5ba2ee97"),
                      Title = "Appartement 2 pièces à louer",
                      Description = "dans un petit immeuble situé à deux pas de l'hôpital et de naval group, appartement entièrement rénové offrant un séjour lumineux, une cuisine ouverte équipée, une chambre et une salle d'eau.",
                      Location = "Boulevard Cosmao Dumanoir 56100 Lorient",
                      IsPublished = false,
                      PropertyType = ePropertyType.Appartement,
                      Picture = "https://d7b3sch6x3cpd.cloudfront.net/annonces/c2/e1/ff/ac/47/42/52/6d/07/d9/34/5e/ba/6a/c0/60/lg.jpeg",
                      ZipCode = 56100,
                      Type = eAnnounceType.Location,
                      Size = 45,
                      numRooms = 2,
                      numBedRooms = 1,
                      IsFurnished = false,
                      PriceWithoutCharges = 300,
                      ChargesPrice = 50,
                      DamageDeposit = 600,
                      IsIntenseArea = false,
                      EnergyEfficiency = eEnergyEfficiency.F,
                      AddressId = "Boulevard Cosmao Dumanoir 56100 Lorient".Trim()
                  },
                  new AnnounceEntity()
                  {
                      Id = Guid.Parse("763f03a7-284d-4022-ad81-a882ffa6ad5f"),
                      Title = "Location appartement 1 pièce 10 m²",
                      Description = "CHAMBRE EN COLOCATION\r\nPentagone entre la place Napoléon et la gare",
                      Location = "Boulevard Louis Blanc 85000 La Roche-sur-Yon",
                      IsPublished = true,
                      PropertyType = ePropertyType.Appartement,
                      Picture = "https://file.bienici.com/photo/immo-facile-48308006_media.immo-facile.com_office5_ajp_rochesuryon_catalog_images_pr_p_4_8_3_0_8_0_0_6_48308006a.jpg_DATEMAJ_09_12_2021-10_12_33?width=600&height=370&fit=cover",
                      ZipCode = 85000,
                      Type = eAnnounceType.Location,
                      Size = 45,
                      numRooms = 2,
                      numBedRooms = 1,
                      IsFurnished = true,
                      PriceWithoutCharges = 300,
                      ChargesPrice = 50,
                      DamageDeposit = 600,
                      IsIntenseArea = true,
                      EnergyEfficiency = eEnergyEfficiency.B,
                      AddressId = "Boulevard Louis Blanc 85000 La Roche-sur-Yon".Trim()
                  },
                  new AnnounceEntity()
                  {
                      Id = Guid.Parse("6703c0fd-d026-442e-9189-5c7f3f9d06e2"),
                      Title = "Location Appartement 3 pièces",
                      Description = "Bel Appartement de 70 m², refait à neuf, au 3ème étage d'une copropriété calme.\r\n\r\nCuisine meublée\r\n\r\nGrand Séjour avec sol en travertin\r\n\r\nune chambre,\r\n\r\nun WC séparé\r\n\r\ndeux balcon\r\n\r\ntrès bonne isolation ; chauffage gaz.\r\n\r\nVue dégagée.\r\n\r\n \r\n\r\nune cave / possibilité de louer un garage.",
                      Location = "Avenue Victor Hugo 26000 Valence",
                      IsPublished = false,
                      PropertyType = ePropertyType.Appartement,
                      Picture = "https://www.administrateurs-de-biens.fr/1768-6954-thickbox/location-appartement-3-pieces-valence-26000-chateauvert.jpg",
                      ZipCode = 26000,
                      Type = eAnnounceType.Location,
                      Size = 70,
                      numRooms = 2,
                      numBedRooms = 1,
                      IsFurnished = true,
                      PriceWithoutCharges = 300,
                      ChargesPrice = 50,
                      DamageDeposit = 600,
                      IsIntenseArea = false,
                      EnergyEfficiency = eEnergyEfficiency.A,
                      AddressId = "Avenue Victor Hugo 26000 Valence".Trim()
                  }
                  ) ;

            modelBuilder.Entity<CityEntity>().HasData(
                new CityEntity()
                {
                    ZipCode = 67860,
                },
                new CityEntity()
                {
                    ZipCode = 75005,
                },
                new CityEntity()
                {
                    ZipCode = 38100,
                },
                new CityEntity()
                {
                    ZipCode = 56100,
                },
                new CityEntity()
                {
                    ZipCode = 85000,
                },
                new CityEntity()
                {
                    ZipCode = 26000,
                });
            modelBuilder.Entity<AddressEntity>().HasData(
                new AddressEntity()
                {
                    Id = "Rue du Nord 67860 Rhinau".Trim(),
                    Latitude = "48.322983",
                    Longitude = "7.705567",
                    Name = "Rue du Nord",
                    ZipCode = 67860
                },
                new AddressEntity()
                {
                    Id = "Rue Saint-Jacques 75005 Paris".Trim(),
                    Latitude = "48.844609",
                    Longitude = "2.342241",
                    Name = "Rue Saint-Jacques",
                    ZipCode = 75005
                },
                new AddressEntity()
                {
                    Id = "Avenue Jean Perrot 38100 Grenoble".Trim(),
                    Latitude = "45.17561",
                    Longitude = "5.737515",
                    Name = "Avenue Jean Perrot",
                    ZipCode = 38100
                },
                new AddressEntity()
                {
                    Id = "Boulevard Cosmao Dumanoir 56100 Lorient".Trim(),
                    Latitude = "47.753803",
                    Longitude = "-3.368552",
                    Name = "Boulevard Cosmao Dumanoir",
                    ZipCode = 56100
                },
                new AddressEntity()
                {
                    Id = "Boulevard Louis Blanc 85000 La Roche-sur-Yon".Trim(),
                    Latitude = "46.673584",
                    Longitude = "-1.435006",
                    Name = "Boulevard Louis Blanc",
                    ZipCode = 85000
                },
                new AddressEntity()
                {
                    Id = "Avenue Victor Hugo 26000 Valence".Trim(),
                    Latitude = "44.921048",
                    Longitude = "4.886904",
                    Name = "Avenue Victor Hugo",
                    ZipCode = 26000
                });

        }
    }
}
