using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models
{
    [Table("Electives")]
    public sealed class ElectiveDB : BaseTable
    {
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

        public ICollection<SchoolchildrenElectivesDB> SchoolchildrenElectives { get; set; }
    }
}