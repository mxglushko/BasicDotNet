using Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Request;

namespace Repositories
{
    public interface ISchoolchildrenRepository
    {
        /// <summary>
        /// Gets Schoolchildren page
        /// </summary>
        Task<IEnumerable<Schoolchildren>> GetPageAsync(SchoolchildrenFilter filter);

        /// <summary>
        /// Get schoolchildren with electives
        /// </summary>
        Task<IEnumerable<SchoolchildrenElectives>> GetWithElectivesAsync(SchoolchildrenFilter filter);

        /// <summary>
        /// Creates schoolchildren
        /// </summary>
        Task<Schoolchildren> CreateAsync(Schoolchildren schoolchildren);

        /// <summary>
        /// Updates schoolchildren
        /// </summary>
        Task<Schoolchildren> UpdateAsync(Schoolchildren schoolchildren);

        /// <summary>
        /// Deletes schoolchildren
        /// </summary>
        Task<int> DeleteAsync(int schoolchildrenId);
    }
}