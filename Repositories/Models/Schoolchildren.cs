using Repositories.Interfaces.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Repositories.Models
{
    // TODO [M.Go]: Remove BaseModel after mapping
    public class Schoolchildren : BaseModel, ISchoolchildren
    {
        public Schoolchildren() : base() { }

        public Schoolchildren(int id, string name) : base(id, name) { }

        /// <summary>
        /// Gets or sets DateOfBirth
        /// </summary>
        [Required]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets class number
        /// </summary>
        public int ClassNumber { get; set; }

        /// <summary>
        /// Gets or sets Height
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets Weight
        /// </summary>
        public int Weight { get; set; }
    }
}