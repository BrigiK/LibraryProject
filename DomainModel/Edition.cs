//-----------------------------------------------------------------------
// <copyright file="Edition.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryProject.DomainModel
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

    /// <summary>Class for Edition entity.</summary>
    public class Edition
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [Key]
        public int ID { get; set; }

        /// <summary>Gets or sets the book.</summary>
        /// <value>The book.</value>
        public Book Book { get; set; }

        /// <summary>Gets or sets the name of the publisher.</summary>
        /// <value>The name of the publisher.</value>
        [Required]
        [NotNullValidator(MessageTemplate = "Publisher name cannot be null")]
        [StringLength(70, MinimumLength = 3)]
        [StringLengthValidator(3, RangeBoundaryType.Inclusive, 70, RangeBoundaryType.Inclusive, MessageTemplate = "Publisher name should have between {3} and {5} chars")]
        public string PublisherName { get; set; }

        /// <summary>Gets or sets the year.</summary>
        /// <value>The year.</value>
        [Required]
        [RangeValidator(1, RangeBoundaryType.Inclusive, 2020, RangeBoundaryType.Inclusive, MessageTemplate = "Year must be between {3} and {5}")]
        public int Year { get; set; }

        /// <summary>Gets or sets the number.</summary>
        /// <value>The number.</value>
        [Required]
        [RangeValidator(1, RangeBoundaryType.Inclusive, -1, RangeBoundaryType.Ignore, MessageTemplate = "Number must be positive!")]
        public int Number { get; set; }

        /// <summary>Gets or sets the type of the book cover.</summary>
        /// <value>The type.</value>
        [Required]
        [NotNullValidator(MessageTemplate = "Type cannot be null")]
        [StringLength(100, MinimumLength = 3)]
        [StringLengthValidator(3, RangeBoundaryType.Inclusive, 100, RangeBoundaryType.Inclusive, MessageTemplate = "Type should have between {3} and {5} chars")]
        public string Type { get; set; }

        /// <summary>Gets or sets the number of pages.</summary>
        /// <value>The number of pages.</value>
        [Required]
        [RangeValidator(1, RangeBoundaryType.Inclusive, -1, RangeBoundaryType.Ignore, MessageTemplate = "Number of pages must be positive!")]
        public int NumberOfPages { get; set; }

        /// <summary>Gets or sets the number of copies.</summary>
        /// <value>The number of copies.</value>
        [Required]
        [RangeValidator(1, RangeBoundaryType.Inclusive, -1, RangeBoundaryType.Ignore, MessageTemplate = "Number of copies must be positive!")]
        public int NumberOfCopies { get; set; }

        /// <summary>Gets or sets the number of lecture room copies.</summary>
        /// <value>The number of lecture room copies.</value>
        [Required]
        [RangeValidator(0, RangeBoundaryType.Inclusive, -1, RangeBoundaryType.Ignore, MessageTemplate = "Number of lecture room copies must be positive!")]
        public int NumberOfLectureRoomCopies { get; set; }
    }
}