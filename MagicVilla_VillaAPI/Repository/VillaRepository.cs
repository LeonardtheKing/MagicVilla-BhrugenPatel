using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MagicVilla_VillaAPI.Repository
{
    public class VillaRepository : IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        

        public VillaRepository(ApplicationDbContext db,IMapper mapper)
        {
            _db= db;
            _mapper= mapper;
        }
        public async Task CreateAsync(Villa entity)
        {
           await _db.Villas.AddAsync(entity);
            await SaveAsync();

        }

        public  async Task<Villa> GetAsync(Expression<Func<Villa,bool>> filter = null, bool tracked = true)
        {
            IQueryable<Villa> query = _db.Villas;
            if(!tracked)
            {
                query=query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }

        //public async Task<IEnumerable<Villa>> GetAllAsync(int occupancy,Expression<Func<Villa, bool>> filter = null)
        //{
        //    IQueryable<Villa> query = _db.Villas;
        //    if(filter != null)
        //    {
        //        query = query.Where(filter);
        //        //query = query.Where(x => x.Occupancy == occupancy);
        //    }
        //    return await query.ToListAsync();
        //}

        //public async Task<IEnumerable<Villa>> GetAllAsync(int? occupancy, int pageSize = 3, int pageNumber = 1)
        //{

        //    if (occupancy > 0)
        //    {
        //        IQueryable<Villa> query = _db.Villas.Where(x => x.Occupancy == occupancy);
        //        return await query.ToListAsync();
        //    }
        //    else
        //    {
        //        // Return all villas because occupancy is not specified.
        //        return await _db.Villas.ToListAsync();
        //    }
        //    if (pageSize > 0)
        //    {
        //        if (pageSize > 100)
        //        {
        //            pageSize = 100;
        //        }
        //        query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
        //    }
        //}
        public async Task<IEnumerable<Villa>> GetAllAsync(int? occupancy, int pageSize=4, int pageNumber=1 )
        {
            IQueryable<Villa> query = _db.Villas;

            if (occupancy.HasValue && occupancy > 0)
            {
                query = query.Where(x => x.Occupancy == occupancy);
            }

            if (pageSize > 100)
            {
                pageSize = 100;
            }

            if (pageSize > 0)
            {
                query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            }

            return await query.ToListAsync();
        }




        public async Task RemoveAsync(Villa entity)
        {
             _db.Villas.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<bool> VillaExistsWithNameAsync(string name)
        {
            return await _db.Villas.AnyAsync(v => v.Name.ToLower() == name.ToLower());
        }

        public async Task<Villa> CreateVillaAsync(VillaCreateDTO villaCreateDTO)
        {
            if (villaCreateDTO == null)
            {
                throw new ArgumentNullException(nameof(villaCreateDTO), "Villa data is missing.");
            }

            if (await VillaExistsWithNameAsync(villaCreateDTO.Name))
            {
                throw new InvalidOperationException("Villa already exists.");
            }

            //var villa = MapVillaCreateDtoToModel(villaCreateDTO); // If you have a mapping method
            Villa model = _mapper.Map<Villa>(villaCreateDTO); // Assuming you have AutoMapper configured
            await _db.Villas.AddAsync(model);
            await _db.SaveChangesAsync();

            return model;
        }

        public async Task UpdateAsync(Villa entity)
        {
            _db.Villas.Update(entity);
            await SaveAsync();
        }

        
    }
}
