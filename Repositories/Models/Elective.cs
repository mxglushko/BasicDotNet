using Repositories.Interfaces.Models;
using System;

namespace Repositories.Models
{
    public class Elective : BaseModel, IElective
    {
        public Elective() : base() { }

        public Elective(int id, string name) : base(id, name) { }

        /// <summary>
        /// Gets or sets StartDate
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets EndDate
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets Photo
        /// </summary>
        public byte CountOfStudents { get; set; }

        /// <summary>
        /// Gets or sets ClassNumber
        /// </summary>
        public byte ClassNumber { get; set; }
    }
}