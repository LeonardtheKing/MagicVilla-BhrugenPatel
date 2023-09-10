using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Data
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Villa> Villas { get; set; }
        //public DbSet<LocalUser> LocalUsers { get; set; }

        public DbSet<VillaNumber> VillaNumber { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("OnModelCreating is called");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Villa>()
            .HasOne(v => v.VillaNumber)
            .WithOne(vn => vn.Villa)
            .HasForeignKey<VillaNumber>(vn => vn.VillaId);

            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    VillaId = 1,
                    Name = "Confidence Lounge",
                    Details = "Serenity at its best",
                    ImageUrl = "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                    Occupancy = 5,
                    Rate = 200,
                    SquareFit = 500,
                    Amenity = "Good road",
                    CreatedDate = DateTime.Now

                },
                 new Villa()
                 {
                     VillaId = 2,
                     Name = "Confidence Lounge",
                     Details = "Serenity at its best",
                     ImageUrl = "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                     Occupancy = 50,
                     Rate = 2000,
                     SquareFit = 5000,
                     Amenity = "Good road",
                     CreatedDate = DateTime.Now


                 },
                  new Villa()
                  {
                      VillaId = 3,
                      Name = "Confidence Lounge",
                      Details = "Serenity at its best",
                      ImageUrl = "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                      Occupancy = 51,
                      Rate = 2001,
                      SquareFit = 5001,
                      Amenity = "Good water",
                      CreatedDate = DateTime.Now


                  },
                   new Villa()
                   {
                       VillaId = 4,
                       Name = "Confidence Lounge",
                       Details = "Serenity at its best",
                       ImageUrl = "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                       Occupancy = 52,
                       Rate = 2002,
                       SquareFit = 5002,
                       Amenity = "Good electricity",
                       CreatedDate = DateTime.Now
                   },
                    new Villa()
                    {
                        VillaId = 5,
                        Name = "Confidence Lounge",
                        Details = "Serenity at its best",
                        ImageUrl = "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                        Occupancy = 5,
                        Rate = 200,
                        SquareFit = 500,
                        Amenity = "Good road",
                        CreatedDate = DateTime.Now

                    },
                     new Villa()
                     {
                         VillaId = 6,
                         Name = "Confidence Lounge",
                         Details = "Serenity at its best",
                         ImageUrl = "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                         Occupancy = 5,
                         Rate = 200,
                         SquareFit = 500,
                         Amenity = "Good road",
                         CreatedDate = DateTime.Now

                     },
                      new Villa()
                      {
                          VillaId = 7,
                          Name = "Confidence Lounge",
                          Details = "Serenity at its best",
                          ImageUrl = "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                          Occupancy = 5,
                          Rate = 200,
                          SquareFit = 500,
                          Amenity = "Good road",
                          CreatedDate = DateTime.Now

                      },
                       new Villa()
                       {
                           VillaId = 8,
                           Name = "Confidence Lounge",
                           Details = "Serenity at its best",
                           ImageUrl = "https://images.pexels.com/photos/18054267/pexels-photo-18054267.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                           Occupancy = 5,
                           Rate = 200,
                           SquareFit = 500,
                           Amenity = "Good road",
                           CreatedDate = DateTime.Now

                       }
                );

            modelBuilder.Entity<VillaNumber>().HasData(
                 new VillaNumber()
                 {
                     VillaNo = 10,
                     SpecialDetails = "no special details",
                     CreatedDate = DateTime.Now,
                     UpdatedDate = DateTime.Now,
                     VillaId=1
                 },
                new VillaNumber()
                {
                    VillaNo = 20,
                    SpecialDetails = "no special details",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    VillaId=2
                },
                 new VillaNumber()
                 {
                     VillaNo = 30,
                     SpecialDetails = "no special details",
                     CreatedDate = DateTime.Now,
                     UpdatedDate = DateTime.Now,
                     VillaId = 3
                 },
                  new VillaNumber()
                  {
                      VillaNo = 40,
                      SpecialDetails = "no special details",
                      CreatedDate = DateTime.Now,
                      UpdatedDate = DateTime.Now,
                      VillaId = 4
                  },
                   new VillaNumber()
                   {
                       VillaNo = 50,
                       SpecialDetails = "no special details",
                       CreatedDate = DateTime.Now,
                       UpdatedDate = DateTime.Now,
                       VillaId = 5
                   },
                    new VillaNumber()
                    {
                        VillaNo = 60,
                        SpecialDetails = "no special details",
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        VillaId = 6
                    },
                     new VillaNumber()
                     {
                         VillaNo = 70,
                         SpecialDetails = "no special details",
                         CreatedDate = DateTime.Now,
                         UpdatedDate = DateTime.Now,
                         VillaId = 7
                     },
                      new VillaNumber()
                      {
                          VillaNo = 80,
                          SpecialDetails = "no special details",
                          CreatedDate = DateTime.Now,
                          UpdatedDate = DateTime.Now,
                          VillaId = 8
                      }
                  );
                }
               

        }

    }

