using Domain.Filter;
using Repositories.Models;
using System;

namespace Repositories.Interfaces.Models
{
    public interface IElective : IBaseModel, IFilterModel
    {
        /// <summary>
        /// Gets or sets StartDate
        /// </summary>
        DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets EndDate
        /// </summary>
        DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets Photo
        /// </summary>
        byte CountOfStudents { get; set; }

        /// <summary>
        /// Gets or sets ClassNumber
        /// </summary>
        byte ClassNumber { get; set; }
    }
}