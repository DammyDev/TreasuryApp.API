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
        /// Lists all company entities.
        /// </summary>
        /// <returns>List of company entities.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CompanyResource>), 200)]
        public async Task<IEnumerable<CompanyResource>> ListAsync()
        {
            var companies = await _companyService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);

            return resources;
        }

        ///// <summary>
        ///// Saves a new category.
        ///// </summary>
        ///// <param name="resource">Category data.</param>
        ///// <returns>Response for the request.</returns>
        //[HttpPost]
        //[ProducesResponseType(typeof(CategoryResource), 201)]
        //[ProducesResponseType(typeof(ErrorResource), 400)]
        //public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        //{
        //    var category = _mapper.Map<SaveCategoryResource, Category>(resource);
        //    var result = await _categoryService.SaveAsync(category);

        //    if (!result.Success)
        //    {
        //        return BadRequest(new ErrorResource(result.Message));
        //    }

        //    var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
        //    return Ok(categoryResource);
        //}

        ///// <summary>
        ///// Updates an existing category according to an identifier.
        ///// </summary>
        ///// <param name="id">Category identifier.</param>
        ///// <param name="resource">Updated category data.</param>
        ///// <returns>Response for the request.</returns>
        //[HttpPut("{id}")]
        //[ProducesResponseType(typeof(CategoryResource), 200)]
        //[ProducesResponseType(typeof(ErrorResource), 400)]
        //public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        //{
        //    var category = _mapper.Map<SaveCategoryResource, Category>(resource);
        //    var result = await _categoryService.UpdateAsync(id, category);

        //    if (!result.Success)
        //    {
        //        return BadRequest(new ErrorResource(result.Message));
        //    }

        //    var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
        //    return Ok(categoryResource);
        //}

        ///// <summary>
        ///// Deletes a given category according to an identifier.
        ///// </summary>
        ///// <param name="id">Category identifier.</param>
        ///// <returns>Response for the request.</returns>
        //[HttpDelete("{id}")]
        //[ProducesResponseType(typeof(CategoryResource), 200)]
        //[ProducesResponseType(typeof(ErrorResource), 400)]
        //public async Task<IActionResult> DeleteAsync(int id)
        //{
        //    var result = await _categoryService.DeleteAsync(id);

        //    if (!result.Success)
        //    {
        //        return BadRequest(new ErrorResource(result.Message));
        //    }

        //    var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
        //    return Ok(categoryResource);
        //}
    }
}