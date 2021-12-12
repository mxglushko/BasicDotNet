using System.Collections.Generic;

namespace Repositories.Models
{
    public sealed class SchoolchildrenElectivesData
    {
        /// <summary>
        /// Gets or sets Schoolchildren
        /// </summary>
        public Schoolchildren Schoolchildren { get; set; }

        /// <summary>
        /// Gets or sets Electives
        /// </summary>
        public IEnumerable<Elective> Electives { get; set; }
    }
}