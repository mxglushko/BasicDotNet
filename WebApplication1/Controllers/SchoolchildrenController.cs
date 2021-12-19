using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Request;

namespace WebApplication1.Controllers
{
    [Route("schoolchildren")]
    public class SchoolchildrenController : BaseDotNetController
    {
        private ISchoolchildrenRepository _schoolchildrenRepository { get; }

        public SchoolchildrenController(ISchoolchildrenRepository schoolchildrenRepository)
        {
            _schoolchildrenRepository = schoolchildrenRepository;
        }

        /// <summary>
        /// Get schoolchildren info as page
        /// </summary>
        [HttpPost("post/page")]
        public async Task<IEnumerable<Schoolchildren>> GetPageAsync([FromQuery] SchoolchildrenRequest request)
        {
            return await _schoolchildrenRepository.GetPageAsync(request.Filter);
        }

        /// <summary>
        /// Get evelites with schoollchildren
        /// </summary>
        [HttpPost("post/withelectives")]
        public async Task<IEnumerable<SchoolchildrenElectives>> GetWithElectivesAsync([FromQuery] SchoolchildrenRequest request)
        {
            return await _schoolchildrenRepository.GetWithElectivesAsync(request.Filter);
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
        [HttpDelete("delete/{id}")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _schoolchildrenRepository.DeleteAsync(id);
        }
    }
}