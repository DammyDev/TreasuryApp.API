using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using TreasuryApp.API.Domain.Models;
using TreasuryApp.API.Domain.Repositories;
using TreasuryApp.API.Domain.Services;
using TreasuryApp.API.Domain.Services.Communication;
using TreasuryApp.API.Infrastructure;

namespace TreasuryApp.API.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;

        public CompanyService(ICompanyRepository companyRepository, IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _companyRepository = companyRepository;
            _unitOfWork = unitOfWork;
            _cache = cache;
        }

        public async Task<IEnumerable<Company>> ListAsync()
        {
            // Here I try to get the categories list from the memory cache. If there is no data in cache, the anonymous method will be
            // called, setting the cache to expire one minute ahead and returning the Task that lists the categories from the repository.
            var categories = await _cache.GetOrCreateAsync(CacheKeys.CompaniesList, (entry) => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
                return _companyRepository.ListAsync();
            });
            
            return categories;
        }

        //public async Task<CategoryResponse> SaveAsync(Category category)
        //{
        //    try
        //    {
        //        await _categoryRepository.AddAsync(category);
        //        await _unitOfWork.CompleteAsync();

        //        return new CategoryResponse(category);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Do some logging stuff
        //        return new CategoryResponse($"An error occurred when saving the category: {ex.Message}");
        //    }
        //}

        //public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        //{
        //    var existingCategory = await _categoryRepository.FindByIdAsync(id);

        //    if (existingCategory == null)
        //        return new CategoryResponse("Category not found.");

        //    existingCategory.Name = category.Name;

        //    try
        //    {
        //        await _unitOfWork.CompleteAsync();

        //        return new CategoryResponse(existingCategory);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Do some logging stuff
        //        return new CategoryResponse($"An error occurred when updating the category: {ex.Message}");
        //    }
        //}

        //public async Task<CategoryResponse> DeleteAsync(int id)
        //{
        //    var existingCategory = await _categoryRepository.FindByIdAsync(id);

        //    if (existingCategory == null)
        //        return new CategoryResponse("Category not found.");

        //    try
        //    {
        //        _categoryRepository.Remove(existingCategory);
        //        await _unitOfWork.CompleteAsync();

        //        return new CategoryResponse(existingCategory);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Do some logging stuff
        //        return new CategoryResponse($"An error occurred when deleting the category: {ex.Message}");
        //    }
        //}
    }
}
