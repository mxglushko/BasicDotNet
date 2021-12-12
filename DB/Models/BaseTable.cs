using Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models
{
    public abstract class BaseTable
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        [Required]
        [MaxLength(Constraints.MaxNameLength)]
        public string Name { get; set; }
    }
}