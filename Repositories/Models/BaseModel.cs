namespace Repositories.Models
{
    public abstract class BaseModel : IBaseModel
    {
        public BaseModel() { }

        public BaseModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Gets or sets id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name { get; set; }
    }
}