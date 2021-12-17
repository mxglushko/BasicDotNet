using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models
{
    [Table("Schoolchildren")]
    public sealed class SchoolchildrenDB : BaseTable
    {
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

        public ICollection<SchoolchildrenElectivesDB> SchoolchildrenElectives { get; set; }
    }
}