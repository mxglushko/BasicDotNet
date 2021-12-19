using Domain.Filter;
using Repositories.Models;

namespace WebApplication1.Request
{
    public sealed class SchoolchildrenFilter : Schoolchildren, IGetFilter
    {
        /// <summary>
        /// Get or sets limit
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Get or sets limit
        /// </summary>

        public int Offset { get; set; }
    }
}