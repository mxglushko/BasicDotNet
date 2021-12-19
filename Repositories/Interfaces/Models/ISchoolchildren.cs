using Domain.Filter;
using Repositories.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Repositories.Interfaces.Models
{
    public interface ISchoolchildren : IBaseModel, IFilterModel
    {
        /// <summary>
        /// Gets or sets DateOfBirth
        /// </summary>
        [Required]
        DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets class number
        /// </summary>
        int ClassNumber { get; set; }

        /// <summary>
        /// Gets or sets Height
        /// </summary>
        int Height { get; set; }

        /// <summary>
        /// Gets or sets Weight
        /// </summary>
        int Weight { get; set; }
    }
}