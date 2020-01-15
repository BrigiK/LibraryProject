//-----------------------------------------------------------------------
// <copyright file="Reader.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryProject.DomainModel
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;

    /// <summary>Class for Reader entity.</summary>
    public class Reader
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
        [StringLengthValidator(6, RangeBoundaryType.Inclusive, 60, RangeBoundaryType.Inclusive, MessageTemplate = "Name should have between {3} and {5} chars")]
        public string Name { get; set; }

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>Gets or sets the username.</summary>
        /// <value>The username.</value>
        [Required]
        [NotNullValidator(MessageTemplate = "Username cannot be null")]
        [StringLength(30, MinimumLength = 3)]
        [StringLengthValidator(3, RangeBoundaryType.Inclusive, 30, RangeBoundaryType.Inclusive, MessageTemplate = "Username should have between {3} and {5} chars")]
        public string Username { get; set; }

        /// <summary>Gets or sets the password.</summary>
        /// <value>The password.</value>
        [Required]
        [NotNullValidator(MessageTemplate = "Password cannot be null")]
        [StringLength(30, MinimumLength = 8)]
        [StringLengthValidator(8, RangeBoundaryType.Inclusive, 30, RangeBoundaryType.Inclusive, MessageTemplate = "Password should have between {3} and {5} chars")]
        [RegexValidator(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,30}$", MessageTemplate = "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character.")]
        public string Password { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is worker.</summary>
        /// <value>
        /// <c>true</c> if this instance is worker; otherwise, <c>false</c>.</value>
        public bool IsWorker { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is reader.</summary>
        /// <value>
        /// <c>true</c> if this instance is reader; otherwise, <c>false</c>.</value>
        [Required]
        public bool IsReader { get; set; }

        /// <summary>Gets or sets the books.</summary>
        /// <value>The books.</value>
        public virtual ICollection<Book> Books { get; set; }

        /// <summary>Validates the email exists.</summary>
        /// <param name="validationResult">The validation result.</param>
        [SelfValidation]
        public void ValidateEmailExists(ValidationResults validationResult)
        {
            if (this.Email == null)
            {
                validationResult.AddResult(new Microsoft.Practices.EnterpriseLibrary.Validation.ValidationResult("Email must be set", this, "ValidateEmailExists", "error", null));
            }
        }
    }
}
