//-----------------------------------------------------------------------
// <copyright file="Author.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryProject.DomainModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

    /// <summary>Class for Author entity.</summary>
    public class Author
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [Key]
        public int ID { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [Required]
        [NotNullValidator(MessageTemplate = "Name cannot be null")]
        [StringLength(60, MinimumLength = 3)]
        [StringLengthValidator(3, RangeBoundaryType.Inclusive, 60, RangeBoundaryType.Inclusive, MessageTemplate = "Name should have between {3} and {5} chars")]
        public string Name { get; set; }

        /// <summary>Gets or sets the books.</summary>
        /// <value>The books.</value>
        public virtual ICollection<Book> Books { get; set; }
    }
}