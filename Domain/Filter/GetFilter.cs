using System.ComponentModel.DataAnnotations;

namespace Domain.Filter
{
    public sealed class GetFilter : IGetFilter
    {
        /// <summary>
        /// Gets or sets limit
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Gets or sets offset
        /// </summary>
        public int Offset { get; set; }
    }
}