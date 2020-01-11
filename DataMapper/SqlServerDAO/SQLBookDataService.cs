//-----------------------------------------------------------------------
// <copyright file="SQLBookDataService.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryProject.DataLayer.DataMapper.SqlServerDAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LibraryProject.DataMapper;
    using LibraryProject.DomainModel;

    /// <summary>SQL Book Data Service.</summary>
    public class SQLBookDataService : IBookDataServices
    {
        /// <summary>Adds the book.</summary>
        /// <param name="book">The book.</param>
        public void AddBook(Book book)
        {
            using (var context = new LibraryContext())
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        /// <summary>Deletes the book.</summary>
        /// <param name="book">The book.</param>
        public void DeleteBook(Book book)
        {
            using (var context = new LibraryContext())
            {
                var newBook = new Book { ID = book.ID };
                context.Books.Attach(newBook);
                context.Books.Remove(newBook);
                context.SaveChanges();
            }
        }

        /// <summary>Gets all books.</summary>
        /// <returns>a a</returns>
        public IList<Book> GetAllBooks()
        {
            using (var context = new LibraryContext())
            {
                return context.Books.Select(book => book).ToList();
            }
        }

        /// <summary>Gets the book by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        public Book GetBookById(int id)
        {
            using (var context = new LibraryContext())
            {
                return context.Books.Where(book => book.ID == id).SingleOrDefault();
            }
        }

        /// <summary>Updates the book.</summary>
        /// <param name="book">The book.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">e e</exception>
        public void UpdateBook(Book book)
        {
            using (var context = new LibraryContext())
            {
                Book bookRef = context.Books.Where(b => b.ID == book.ID).SingleOrDefault();
                if (bookRef != null)
                {
                    bookRef = book;
                    context.SaveChanges();
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }
        }
    }
}
