using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Models
{
    [Table("SchoolchildrenElectives")]
    public sealed class SchoolchildrenElectivesDB
    {
        /// <summary>
        /// Gets or sets id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Schoolchildren id
        /// </summary>
        [Required]
        public int SchoolchildrenId { get; set; }
        [ForeignKey(nameof(SchoolchildrenId))]
        public SchoolchildrenDB Schoolchildren { get; set; }

        /// <summary>
        /// Gets or sets Electives id
        /// </summary>
        [Required]
        public int ElectiveId { get; set; }
        [ForeignKey(nameof(ElectiveId))]
        public ElectiveDB Elective { get; set; }
    }
}