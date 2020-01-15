//-----------------------------------------------------------------------
// <copyright file="Configuration.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryProject.DomainModel
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

    /// <summary>Class for Configurations entity.</summary>
    public class Configuration
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [Key]
        [Required]
        [NotNullValidator(MessageTemplate = "Name cannot be null")]
        [StringLength(30, MinimumLength = 1)]
        [StringLengthValidator(1, RangeBoundaryType.Inclusive, 30, RangeBoundaryType.Inclusive, MessageTemplate = "Name should have between {3} and {5} chars")]
        public string Name { get; set; }

        /// <summary>Gets or sets the value.</summary>
        /// <value>The value.</value>
        [Required]
        [RangeValidator(1, RangeBoundaryType.Inclusive, -1, RangeBoundaryType.Ignore, MessageTemplate = "Value must be positive")]
        public int Value { get; set; }
    }
}
