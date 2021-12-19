namespace Domain.Filter
{
    // TODO [M.Go]: Add filters to each models
    public interface IGetFilter
    {
        /// <summary>
        /// Get or sets limit
        /// </summary>
        int Limit { get; set; }

        /// <summary>
        /// Get or sets limit
        /// </summary>
        int Offset { get; set; }
    }
}