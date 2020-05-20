using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TreasuryApp.API.Domain.Models;
using TreasuryApp.API.Domain.Services;
using TreasuryApp.API.Resources;

namespace TreasuryApp.API.Controllers
{
    [Route("/api/companies")]
    [Produces("application/json")]
    [ApiController]
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all company profiles.
        /// </summary>
        /// <returns>List of company profiles.</returns>
        [HttpGet("getall")]
        [ProducesResponseType(typeof(IEnumerable<CompanyResource>), 200)]
        public async Task<IEnumerable<CompanyResource>> ListAsync()
        {
            var companies = await _companyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);

            return resources;
        }

        /// <summary>
        /// Add a new company profile.
        /// </summary>
        /// <param name="resource">Company data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(CategoryResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveCompanyResource resource)
        {
            var company = _mapper.Map<SaveCompanyResource, Company>(resource);
            var result = await _companyService.SaveAsync(company);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var companyResource = _mapper.Map<Company, CompanyResource>(result.Resource);
            //return Ok(companyResource);
            return CreatedAtAction(null, new { id = company.Id }, companyResource);
        }

        /// <summary>
        /// Updates an existing company profile according to an identifier.
        /// </summary>
        /// <param name="id">Company identifier.</param>
        /// <param name="resource">Updated Company profile data.</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(CompanyResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCompanyResource resource)
        {
            var company = _mapper.Map<SaveCompanyResource, Company>(resource);
            var result = await _companyService.UpdateAsync(id, company);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var companyResource = _mapper.Map<Company, CompanyResource>(result.Resource);
            return Ok(companyResource);
        }

        /// <summary>
        /// Activates or Deactivates a company profile
        /// </summary>
        /// <param name="id">Company identifier.</param>
        /// <param name="isActive">Company profile active or inactive? true or false?</param>
        /// <returns>Response for the request.</returns>
        [HttpPut("activate/{id}")]
        [ProducesResponseType(typeof(CompanyResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> ActivateAsync(int id, [FromBody] bool isActive)
        {
           // var company = _mapper.Map<SaveCompanyResource, Company>(resource);
            var result = await _companyService.UpdateAsync(id, isActive);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var companyResource = _mapper.Map<Company, CompanyResource>(result.Resource);
            return Ok(companyResource);
        }


        /// <summary>
        /// Deletes a given company profile according to an identifier.
        /// </summary>
        /// <param name="id">Company identifier.</param>
        /// <returns>Response for the request.</returns>
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(CompanyResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _companyService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var companyResource = _mapper.Map<Company, CompanyResource>(result.Resource);
            return Ok(companyResource);
        }
    }
}