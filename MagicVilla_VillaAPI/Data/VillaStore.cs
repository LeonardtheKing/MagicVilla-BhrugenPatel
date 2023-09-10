using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI.Data
{
    public class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>()
        {
                new VillaDTO { VillaId = 1,Name="Pool View ",SquareFit=20,Occupancy=45},
                new VillaDTO { VillaId = 2,Name="Beach view",SquareFit=20,Occupancy=45}
        };
    }
}
