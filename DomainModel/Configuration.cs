//-----------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryProject.DomainModel
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>Class for Configurations entity.</summary>
    public class Configuration
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [Key]
        [Required]
        public string Name { get; set; }

        /// <summary>Gets or sets the value.</summary>
        /// <value>The value.</value>
        [Required]
        public int Value { get; set; }
    }
}
