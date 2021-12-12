using Domain.Filter;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("schoolchildren")]
    public class ApiController : Controller
    {
        private ISchoolchildrenRepository _schoolchildrenRepository { get; }

        public ApiController(ISchoolchildrenRepository schoolchildrenRepository)
        {
            _schoolchildrenRepository = schoolchildrenRepository;
        }

        /// <summary>
        /// Get schoolchildren info as page
        /// </summary>
        [HttpGet("get/page")]
        public async Task<IEnumerable<Schoolchildren>> GetSchoolchildrenPageAsync(GetFilter filter)
        {
            return await _schoolchildrenRepository.GetPageAsync(filter);
        }

        /// <summary>
        /// Get evelites with schoollchildren
        /// </summary>
        [HttpGet("get/withelectives")]
        public async Task<IEnumerable<SchoolchildrenElectives>> GetWithElectivesAsync(int id, GetFilter filter)
        {
            return await _schoolchildrenRepository.GetWithElectivesAsync(id, filter);
        }

        /// <summary>
        /// Create schoolchildren
        /// </summary>
        [HttpPost("create")]
        public async Task<Schoolchildren> CreateAsync(Schoolchildren schoolchildren)
        {
            return await _schoolchildrenRepository.CreateAsync(schoolchildren);
        }

        /// <summary>
        /// Update schoolchildren
        /// </summary>
        [HttpPut("update")]
        public async Task<Schoolchildren> UpdateAsync(Schoolchildren schoolchildren)
        {
            return await _schoolchildrenRepository.UpdateAsync(schoolchildren);
        }

        /// <summary>
        /// Delete schoolchildren
        /// </summary>
        [HttpDelete("delete")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _schoolchildrenRepository.DeleteAsync(id);
        }
    }
}