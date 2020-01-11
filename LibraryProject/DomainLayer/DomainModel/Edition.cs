//-----------------------------------------------------------------------
// <copyright file="Edition.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryProject.DomainModel
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>Class for Edition entity.</summary>
    public class Edition
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int ID { get; set; }

        /// <summary>Gets or sets the book.</summary>
        /// <value>The book.</value>
        public Book Book { get; set; }

        /// <summary>Gets or sets the name of the publisher.</summary>
        /// <value>The name of the publisher.</value>
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string PublisherName { get; set; }

        /// <summary>Gets or sets the year.</summary>
        /// <value>The year.</value>
        [Required]
        public int Year { get; set; }

        /// <summary>Gets or sets the number.</summary>
        /// <value>The number.</value>
        [Required]
        public int Number { get; set; }

        /// <summary>Gets or sets the type of the book cover.</summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>Gets or sets the number of pages.</summary>
        /// <value>The number of pages.</value>
        [Required]
        public int NumberOfPages { get; set; }

        /// <summary>Gets or sets the number of copies.</summary>
        /// <value>The number of copies.</value>
        [Required]
        public int NumberOfCopies { get; set; }

        /// <summary>Gets or sets the number of lecture room copies.</summary>
        /// <value>The number of lecture room copies.</value>
        [Required]
        public int NumberOfLectureRoomCopies { get; set; }
    }
}