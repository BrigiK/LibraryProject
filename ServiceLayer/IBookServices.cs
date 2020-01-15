//-----------------------------------------------------------------------
// <copyright file="IBookServices.cs" company="Transilvania University of Brasov">
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

    /// <summary>Interface for Book Services.</summary>
    public interface IBookServices
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

        /// <summary>Gets the books from domain.</summary>
        /// <param name="domain">The domain.</param>
        /// <returns>a a</returns>
        ICollection<Book> GetBooksFromDomain(Domain domain);

        /// <summary>Books has only DOM domains.</summary>
        /// <param name="book">The book.</param>
        /// <returns>a a</returns>
        bool BookHasOnlyDOMDomains(Book book);

        /// <summary>Book domain not contains parent domain.</summary>
        /// <param name="book">The book.</param>
        /// <returns>a a</returns>
        bool BookDomainContainsParentDomain(Book book);

        /// <summary>Gets the books from author.</summary>
        /// <param name="author">The author.</param>
        /// <returns>a a</returns>
        ICollection<Book> GetBooksFromAuthor(Author author);
    }
}
