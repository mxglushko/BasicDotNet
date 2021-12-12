using Domain.Filter;

namespace Repositories.Models
{
    public sealed class Elective : BaseModel, IFilterModel
    {
        public Elective() : base() { }

        public Elective(int id, string name) : base(id, name) { }
    }
}