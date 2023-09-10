using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Models;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IVillaNumberRepository
    {
        Task<IEnumerable<VillaNumber>> GetAllAsync(Expression<Func<VillaNumber, bool>> filter = null);
        Task<VillaNumber> GetAsync(Expression<Func<VillaNumber, bool>> filter = null, bool tracked = true);

        Task CreateAsync(VillaNumber entity);

        Task UpdateAsync(VillaNumber entity);
        Task RemoveAsync(VillaNumber entity);
        Task SaveAsync();
        Task<VillaNumber> CreateVillaNumberAsync(VillaNumberCreateDTO villaNumberCreateDTO);




    }
}
