using Domain.Filter;

namespace Repositories.Models
{
    public sealed class SchoolchildrenElectives : IFilterModel
    {
        /// <summary>
        /// Gets or sets Schoolchildren id
        /// </summary>
        public Schoolchildren Schoolchildren { get; set; }

        /// <summary>
        /// Gets or sets Electives id
        /// </summary>
        public Elective Elective { get; set; }
    }
}