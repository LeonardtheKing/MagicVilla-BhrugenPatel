using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using MagicVilla_VillaAPI.Repository.IRepository;

namespace MagicVilla_VillaAPI.Repository
{
    public class VillaNumberRepository:IVillaNumberRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VillaNumberRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context =context;
            _mapper = mapper;
        }
        public async Task CreateAsync(VillaNumber entity)
        {
            await _context.VillaNumber.AddAsync(entity);
            await SaveAsync();

        }

        public async Task<VillaNumber> GetAsync(Expression<Func<VillaNumber, bool>> filter = null, bool tracked = true)
        {
            IQueryable<VillaNumber> query = _context.VillaNumber;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<VillaNumber>> GetAllAsync(Expression<Func<VillaNumber, bool>> filter = null)
        {
            IQueryable<VillaNumber> query = _context.VillaNumber;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task RemoveAsync(VillaNumber entity)
        {
            _context.VillaNumber.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> VillaExistsWithNameAsync(int villaNumber)
        {
            return await _context.VillaNumber.AnyAsync(v => v.VillaNo.Equals(villaNumber));
        }

        public async Task<VillaNumber> CreateVillaNumberAsync(VillaNumberCreateDTO villaNumberCreateDTO)
        {
            if (villaNumberCreateDTO == null)
            {
                throw new ArgumentNullException(nameof(villaNumberCreateDTO), "Villa data is missing.");
            }

            if (await VillaExistsWithNameAsync(villaNumberCreateDTO.VillaNo))
            {
                throw new InvalidOperationException("Villa already exists.");
            }

            //var villa = MapVillaCreateDtoToModel(villaCreateDTO); // If you have a mapping method
            VillaNumber model = _mapper.Map<VillaNumber>(villaNumberCreateDTO); // Assuming you have AutoMapper configured
            await _context.VillaNumber.AddAsync(model);
            await _context.SaveChangesAsync();

            return model;
        }

        public async Task UpdateAsync(VillaNumber entity)
        {
            _context.VillaNumber.Update(entity);
            await SaveAsync();
        }
    }
}
