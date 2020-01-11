//-----------------------------------------------------------------------
// <copyright file="IAuthorDataService.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryProject.DataLayer.DataMapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LibraryProject.DomainModel;

    /// <summary>Author Data Service.</summary>
    public interface IAuthorDataService
    {
        /// <summary>Gets all authors.</summary>
        /// <returns>a a</returns>
        IList<Author> GetAllAuthors();

        /// <summary>
        /// Gets the author by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        Author GetAuthorById(int id);

        /// <summary>
        /// Adds the author.
        /// </summary>
        /// <param name="author">The author.</param>
        void AddAuthor(Author author);

        /// <summary>
        /// Deletes the author.
        /// </summary>
        /// <param name="author">The author.</param>
        void DeleteAuthor(Author author);

        /// <summary>
        /// Updates the author.
        /// </summary>
        /// <param name="author">The author.</param>
        void UpdateAuthor(Author author);
    }
}
