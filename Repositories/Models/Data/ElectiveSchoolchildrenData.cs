using Domain.Filter;
using System.Collections.Generic;

namespace Repositories.Models
{
    public sealed class ElectiveSchoolchildrenData : IFilterModel
    {
        /// <summary>
        /// Gets or sets Elective
        /// </summary>
        public Elective Elective { get; set; }

        /// <summary>
        /// Gets or sets Schoolchildren
        /// </summary>
        public IEnumerable<Schoolchildren> Schoolchildren { get; set; }
    }
}