using Domain.Filter;

namespace Repositories.Models
{
    public sealed class Schoolchildren : BaseModel, IFilterModel
    {
        public Schoolchildren() : base() { }

        public Schoolchildren(int id, string name) : base(id, name) { }
    }
}