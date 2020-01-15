//-----------------------------------------------------------------------
// <copyright file="IAuthorServices.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace ServiceLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LibraryProject.DomainModel;

    /// <summary>Interface for author services.</summary>
    public interface IAuthorServices
    {
        /// <summary>Gets the list of authors.</summary>
        /// <returns>a a</returns>
        IList<Author> GetListOfAuthors();

        /// <summary>Deletes the author.</summary>
        /// <param name="author">The author.</param>
        void DeleteAuthor(Author author);

        /// <summary>Updates the author.</summary>
        /// <param name="author">The author.</param>
        void UpdateAuthor(Author author);

        /// <summary>Gets the author by identifier.</summary>
        /// <param name="id">The identifier.</param>
        void GetAuthorById(int id);

        /// <summary>Adds the author.</summary>
        /// <param name="author">The author.</param>
        void AddAuthor(Author author);

        /// <summary>Gets the author by name.</summary>
        /// <param name="name">The name.</param>
        /// <returns>a a</returns>
        Author GetAuthorByName(string name);
    }
}
