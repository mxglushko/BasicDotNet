namespace Domain.Filter
{
    public interface IGetFilter
    {
        int Limit { get; set; }
        int Offset { get; set; }
    }
}