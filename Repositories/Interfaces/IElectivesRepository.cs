using Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Request;

namespace Repositories
{
    public interface IElectivesRepository
    {
        /// <summary>
        /// Get electives info as page
        /// </summary>
        Task<IEnumerable<Elective>> GetPageAsync(ElectiveFilter filter);

        /// <summary>
        /// Returns an electives with schoolchildren 
        /// </summary>
        Task<IEnumerable<SchoolchildrenElectives>> GetWithSchollchildrenAsync(ElectiveFilter filter);

        /// <summary>
        /// Creates elective
        /// </summary>
        Task<Elective> CreateAsync(Elective elective);

        /// <summary>
        /// Updates elective
        /// </summary>
        Task<Elective> UpdateAsync(Elective elective);

        /// <summary>
        /// Deletes elective
        /// </summary>
        Task<int> DeleteAsync(int electiveId);
    }
}