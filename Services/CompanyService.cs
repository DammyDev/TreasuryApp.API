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
            //var categories = await _cache.GetOrCreateAsync(CacheKeys.CompaniesList, (entry) => {
            //    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            //    return _companyRepository.ListAsync();
            //});

            var categories = await _companyRepository.ListAsync();


            return categories;
        }

        public async Task<CompanyResponse> SaveAsync(Company company)
        {
            try
            {
                await _companyRepository.AddAsync(company);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(company);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CompanyResponse($"An error occurred when saving the company profile: {ex.Message}");
            }
        }

        public async Task<CompanyResponse> UpdateAsync(int id, Company company)
        {
            var existingCompany = await _companyRepository.FindByIdAsync(id);

            if (existingCompany == null)
                return new CompanyResponse("Company profile not found.");

            existingCompany.Name = company.Name;
            existingCompany.Country = company.Country;
            existingCompany.EODGLDate = company.EODGLDate;
            existingCompany.LastEODDate = company.LastEODDate;
            existingCompany.MRSName = company.MRSName;
            existingCompany.NextEODDate = company.NextEODDate;
            existingCompany.NextTradingDate = company.NextTradingDate;
            existingCompany.ParentEntity = company.ParentEntity;
            existingCompany.PhoneNumber = company.PhoneNumber;
            existingCompany.PhysicalAddress = company.PhysicalAddress;
            existingCompany.ReportingCurrency = company.ReportingCurrency;
            existingCompany.ShortName = company.ShortName;
            existingCompany.SuspenseGLAccount = company.SuspenseGLAccount;
            existingCompany.SwiftAddress = company.SwiftAddress;
            existingCompany.TradingDate = company.TradingDate;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(existingCompany);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CompanyResponse($"An error occurred when updating the company: {ex.Message}");
            }
        }

        public async Task<CompanyResponse> UpdateAsync(int id, bool isActive)
        {
            var existingCompany = await _companyRepository.FindByIdAsync(id);

            if (existingCompany == null)
                return new CompanyResponse("Company profile not found.");

            existingCompany.IsActive = isActive;

            try
            {
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(existingCompany);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CompanyResponse($"An error occurred when updating the company's active status: {ex.Message}");
            }
        }

        public async Task<CompanyResponse> DeleteAsync(int id)
        {
            var existingCompany = await _companyRepository.FindByIdAsync(id);

            if (existingCompany == null)
                return new CompanyResponse("Category not found.");

            try
            {
                _companyRepository.Remove(existingCompany);
                await _unitOfWork.CompleteAsync();

                return new CompanyResponse(existingCompany);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CompanyResponse($"An error occurred when deleting the company profile: {ex.Message}");
            }
        }
    }
}
