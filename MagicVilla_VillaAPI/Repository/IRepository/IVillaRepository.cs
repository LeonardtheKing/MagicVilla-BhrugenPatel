﻿using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IVillaRepository
    {
        //Task<IEnumerable<Villa>> GetAllAsync(Expression<Func<Villa, bool>> filter = null);
        //Task<IEnumerable<Villa>> GetAllAsync(int? occupancy,int pageSize= 3, int pageNumber = 1);
        Task<IEnumerable<Villa>> GetAllAsync(int? occupancy, int pageSize = 3, int pageNumber = 1);

        Task<Villa> GetAsync(Expression<Func<Villa, bool>> filter = null, bool tracked = true);
        Task CreateAsync(Villa entity);

        Task UpdateAsync(Villa entity);
        Task RemoveAsync(Villa entity);
        Task SaveAsync();
        Task<Villa> CreateVillaAsync(VillaCreateDTO villaCreateDTO);

    }
}
