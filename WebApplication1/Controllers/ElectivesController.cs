using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Request;

namespace WebApplication1.Controllers
{
    [Route("electives")]
    public class ElectivesController : BaseDotNetController
    {
        private IElectivesRepository _electivesRepository { get; }

        public ElectivesController(IElectivesRepository electivesRepository)
        {
            _electivesRepository = electivesRepository;
        }

        /// <summary>
        /// Get electives info as page
        /// </summary>
        [HttpPost("post/page")]
        public async Task<IEnumerable<Elective>> GetElectivesAsync([FromQuery] ElectiveRequest request)
        {
            return await _electivesRepository.GetPageAsync(request.Filter);
        }

        /// <summary>
        /// Get evelites with schoollchildren
        /// </summary>
        [HttpPost("post/withschoolchildren")]
        public async Task<IEnumerable<SchoolchildrenElectives>> GetWithSchollchildrenAsync([FromQuery] ElectiveRequest request)
        {
            return await _electivesRepository.GetWithSchollchildrenAsync(request.Filter);
        }

        /// <summary>
        /// Create elective
        /// </summary>
        [HttpPost("create")]
        public async Task<Elective> CreateAsync(Elective elective)
        {
            return await _electivesRepository.CreateAsync(elective);
        }

        /// <summary>
        /// Update elective
        /// </summary>
        [HttpPut("update")]
        public async Task<Elective> UpdateAsync(Elective elective)
        {
            return await _electivesRepository.UpdateAsync(elective);
        }

        /// <summary>
        /// Delete elective
        /// </summary>
        [HttpDelete("delete")]
        public async Task<int> DeleteAsync(int id)
        {
            return await _electivesRepository.DeleteAsync(id);
        }
    }
}