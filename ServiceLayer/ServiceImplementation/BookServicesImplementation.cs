//-----------------------------------------------------------------------
// <copyright file="BookServicesImplementation.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace ServiceLayer.ServiceImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LibraryProject.DataLayer.DataMapper;
    using LibraryProject.DomainModel;

    /// <summary>Book Services Implementation</summary>
    /// <seealso cref="ServiceLayer.IBookServices" />
    public class BookServicesImplementation : IBookServices
    {
        /// <summary>The book data services</summary>
        private IBookDataServices bookDataServices;

        /// <summary>Initializes a new instance of the <see cref="BookServicesImplementation"/> class.</summary>
        /// <param name="bookDataServices">The book data services.</param>
        public BookServicesImplementation(IBookDataServices bookDataServices = null)
        {
            if (bookDataServices == null)
            {
                bookDataServices = DAOFactoryMethod.CurrentDAOFactory.BookDataService;
            }

            this.bookDataServices = bookDataServices;
        }

        /// <summary>Book domain not contains parent domain.</summary>
        /// <param name="book">The book.</param>
        /// <returns>a a</returns>
        public bool BookDomainContainsParentDomain(Book book)
        {
            return this.bookDataServices.BookDomainContainsParentDomain(book);
        }

        /// <summary>Adds the book.</summary>
        /// <param name="book">The book.</param>
        /// <returns>a a</returns>
        public bool AddBook(Book book)
        {
            if (book.Domains.Count > 0 && 
                !this.BookDomainContainsParentDomain(book) && 
                this.BookHasOnlyDOMDomains(book) && 
                book.Authors.Count > 0  && 
                book.Editions.Count > 0)
            {
                this.bookDataServices.AddBook(book);
                return true;
            }

            return false;
        }

        /// <summary>Books has only DOM domains.</summary>
        /// <param name="book">The book.</param>
        /// <returns>a a</returns>
        public bool BookHasOnlyDOMDomains(Book book)
        {
            return this.bookDataServices.BookHasOnlyDOMDomains(book);
        }

        /// <summary>Deletes the book.</summary>
        /// <param name="book">The book.</param>
        public void DeleteBook(Book book)
        {
            this.bookDataServices.DeleteBook(book);
        }

        /// <summary>Gets all books.</summary>
        /// <returns>a a</returns>
        public IList<Book> GetAllBooks()
        {
            return this.bookDataServices.GetAllBooks();
        }

        /// <summary>Gets the book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        public Book GetBookById(int id)
        {
            return this.bookDataServices.GetBookById(id);
        }

        /// <summary>Gets the books from domain.</summary>
        /// <param name="domain">The domain.</param>
        /// <returns>a a</returns>
        public ICollection<Book> GetBooksFromDomain(Domain domain)
        {
            return this.bookDataServices.GetBooksFromDomain(domain);
        }

        /// <summary>Updates the book.</summary>
        /// <param name="book">The book.</param>
        public void UpdateBook(Book book)
        {
            this.bookDataServices.UpdateBook(book);
        }

        /// <summary>Gets the books from author.</summary>
        /// <param name="author">The author.</param>
        /// <returns>a a</returns>
        public ICollection<Book> GetBooksFromAuthor(Author author)
        {
            return this.bookDataServices.GetBooksFromAuthor(author);
        }
    }
}
