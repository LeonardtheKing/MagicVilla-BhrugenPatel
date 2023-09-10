﻿using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace MagicVilla_VillaAPI.Models.Dto
{
    public class VillaDTO
    {
        public int VillaId { get; set; }
        [MaxLength(255)]
        [Required]
        [UniqueVillaName]
        public string Name { get; set; }
        public int Occupancy { get; set; }
        public int SquareFit { get; set; }
        public string Amenity { get; set; }
        public double Rate { get; set; }
        public string Details { get; set; }
        public String ImageUrl { get; set; }

    }
}
