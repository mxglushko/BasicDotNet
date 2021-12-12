using Domain.Filter;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("electives")]
    public class ElectivesController : Controller
    {
        private IElectivesRepository _electivesRepository { get; }

        public ElectivesController(IElectivesRepository electivesRepository)
        {
            _electivesRepository = electivesRepository;
        }

        /// <summary>
        /// Get electives info as page
        /// </summary>
        [HttpGet("get/page")]
        public async Task<IEnumerable<Elective>> GetElectivesAsync(GetFilter filter)
        {
            return await _electivesRepository.GetPageAsync(filter);
        }

        /// <summary>
        /// Get evelites with schoollchildren
        /// </summary>
        [HttpGet("get/withschoolchildren")]
        public async Task<IEnumerable<SchoolchildrenElectives>> GetWithSchollchildrenAsync(int id, GetFilter filter)
        {
            return await _electivesRepository.GetWithSchollchildrenAsync(id, filter);
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