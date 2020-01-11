//-----------------------------------------------------------------------
// <copyright file="Reader.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryProject.DomainModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>Class for Reader entity.</summary>
    public class Reader
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int ID { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        [Required]
        public string Name { get; set; }

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        [Required]
        public string Email { get; set; }

        /// <summary>Gets or sets the username.</summary>
        /// <value>The username.</value>
        [Required]
        public string Username { get; set; }

        /// <summary>Gets or sets the password.</summary>
        /// <value>The password.</value>
        [Required]
        public string Password { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is worker.</summary>
        /// <value>
        /// <c>true</c> if this instance is worker; otherwise, <c>false</c>.</value>
        public bool IsWorker { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is reader.</summary>
        /// <value>
        /// <c>true</c> if this instance is reader; otherwise, <c>false</c>.</value>
        public bool IsReader { get; set; }

        /// <summary>Gets or sets the books.</summary>
        /// <value>The books.</value>
        public virtual ICollection<Book> Books { get; set; }
    }
}
