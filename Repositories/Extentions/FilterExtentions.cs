using Domain.Filter;
using System.Linq;

namespace Repositories.Extentions
{
    public static class FilterExtentions
    {
        public static IQueryable<TModel> ApplyFilter<TModel>(this IQueryable<TModel> models, IGetFilter filter) where TModel : IFilterModel
        {
            return filter.Limit > 0 ? models.Take(filter.Limit).Skip(filter.Offset) : models;
        }
    }
}