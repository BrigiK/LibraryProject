//-----------------------------------------------------------------------
// <copyright file="IBookDataServices.cs" company="Transilvania University of Brasov">
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

    /// <summary>Book Data Services.</summary>
    public interface IBookDataServices
    {
        /// <summary>Gets all books.</summary>
        /// <returns>a a</returns>
        IList<Book> GetAllBooks();

        /// <summary>
        /// Gets the book by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        Book GetBookById(int id);

        /// <summary>
        /// Adds the book.
        /// </summary>
        /// <param name="book">The book.</param>
        void AddBook(Book book);

        /// <summary>
        /// Deletes the book.
        /// </summary>
        /// <param name="book">The book.</param>
        void DeleteBook(Book book);

        /// <summary>
        /// Updates the book.
        /// </summary>
        /// <param name="book">The book.</param>
        void UpdateBook(Book book);
    }
}
