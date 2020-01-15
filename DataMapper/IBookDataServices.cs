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

        /// <summary>Book's domain contains parent domain.</summary>
        /// <param name="book">The book.</param>
        /// <returns>a a</returns>
        bool BookDomainContainsParentDomain(Book book);

        /// <summary>Book has only DOM domains.</summary>
        /// <param name="book">The book.</param>
        /// <returns>a a</returns>
        bool BookHasOnlyDOMDomains(Book book);

        /// <summary>Gets the books from domain.</summary>
        /// <param name="domain">The domain.</param>
        /// <returns>a a</returns>
        ICollection<Book> GetBooksFromDomain(Domain domain);

        /// <summary>Gets the books by author.</summary>
        /// <param name="author">The author.</param>
        /// <returns>a a</returns>
        ICollection<Book> GetBooksFromAuthor(Author author);
    }
}
