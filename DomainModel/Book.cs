//-----------------------------------------------------------------------
// <copyright file="Book.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryProject.DomainModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

    /// <summary>Class for Book entity.</summary>
    public class Book
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [Key]
        public int ID { get; set; }

        /// <summary>Gets or sets the title.</summary>
        /// <value>The title.</value>
        [Required]
        [NotNullValidator(MessageTemplate = "Book title cannot be null")]
        [StringLength(150, MinimumLength = 2)]
        [StringLengthValidator(2, RangeBoundaryType.Inclusive, 150, RangeBoundaryType.Inclusive, MessageTemplate = "Book title should have between {3} and {5} chars")]
        public string Title { get; set; }

        /// <summary>Gets or sets the authors.</summary>
        /// <value>The authors.</value>
        [Required]
        public virtual ICollection<Author> Authors { get; set; }

        /// <summary>Gets or sets the editions.</summary>
        /// <value>The editions.</value>
        public virtual ICollection<Edition> Editions { get; set; }

        /// <summary>Gets or sets the domains.</summary>
        /// <value>The domains.</value>
        [Required]
        public virtual ICollection<Domain> Domains { get; set; }

        /// <summary>Gets or sets the readers.</summary>
        /// <value>The readers.</value>
        public virtual ICollection<Reader> Readers { get; set; }
    }
}
