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
    using log4net;

    /// <summary>SQL Book Data Service.</summary>
    public class SQLBookDataService : IBookDataServices
    {
        /// <summary>The logger instance.</summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(SQLBookDataService));

        /// <summary>Adds the book.</summary>
        /// <param name="book">The book.</param>
        public void AddBook(Book book)
        {
            Log.Info("Add new book.");
            using (var context = new LibraryContext())
            {
                context.Books.Add(book);
                context.SaveChanges();
            }

            Log.Info("New book successfully added.");
        }

        /// <summary>Deletes the book.</summary>
        /// <param name="book">The book.</param>
        public void DeleteBook(Book book)
        {
            Log.Info("Delete book.");
            using (var context = new LibraryContext())
            {
                var newBook = new Book { ID = book.ID };
                context.Books.Attach(newBook);
                context.Books.Remove(newBook);
                context.SaveChanges();
            }

            Log.Info("Author successfully deleted.");
        }

        /// <summary>Gets all books.</summary>
        /// <returns>a a</returns>
        public IList<Book> GetAllBooks()
        {
            Log.Info("Getting all books.");
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
            Log.Info("Getting book by id.");
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
            Log.Info("Updating book.");
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

            Log.Info("Book successfully updated.");
        }

        /// <summary>Book's domain contains parent domain.</summary>
        /// <param name="book">The book.</param>
        /// <returns>a a</returns>
        public bool BookDomainContainsParentDomain(Book book)
        {
            Log.Info("Checking if book domain also contains parent domain.");
            using (var context = new LibraryContext())
            {
                List<Domain> domains = new List<Domain>();
                foreach (var domain in book.Domains)
                {
                    domains.Add(context.Domains.Where(d => d.ID == domain.ID).Single());
                }

                foreach (Domain domain in domains)
                {
                    foreach (Domain d in domains)
                    {
                        if (d.ParentDomain != null && domain.Name.Equals(d.ParentDomain.Name))
                        {
                            Log.Info("Book domain also contains parent domain.");
                            return true;
                        }
                    }
                }
            }

            Log.Info("Book domain not contains parent domain.");
            return false;
        }

        /// <summary>Book has only DOM domains.</summary>
        /// <param name="book">The book.</param>
        /// <returns>a a</returns>
        public bool BookHasOnlyDOMDomains(Book book)
        {
            Log.Info("Checking if book has only DOM domains.");
            SQLConfigurationDataService configuration = new SQLConfigurationDataService();

            if (book.Domains.Count <= configuration.GetConfiguration("MaxDOMBook").Value)
            {
                Log.Info("Book has only DOM domains.");
                return true;
            }

            Log.Info("Book has more than DOM domains.");
            return false;
        }

        /// <summary>Gets the books from domain.</summary>
        /// <param name="domain">The domain.</param>
        /// <returns>a a</returns>
        public ICollection<Book> GetBooksFromDomain(Domain domain)
        {
            Log.Info("Getting books from domain ");
            if (domain == null)
            {
                return new List<Book>();
            }

            IDomainDataService domainServices = new SQLDomainDataService();

            using (var context = new LibraryContext())
            {
                List<Domain> domains = new List<Domain>
                {
                    domain
                };

                List<Book> books = new List<Book>();

                while (domains.Count > 0)
                {
                    var currentDomain = domains[0];
                    currentDomain = context.Domains.Where(d => d.ID == currentDomain.ID).Single();
                    domains.RemoveAt(0);

                    if (currentDomain.Books != null)
                    {
                        books.AddRange(currentDomain.Books);
                    }

                    domains.AddRange(domainServices.GetChildDomains(currentDomain));
                }

                Log.Info("Returning books from domain " + domain.Name);
                return books;
            }
        }

        /// <summary>Gets the books by author.</summary>
        /// <param name="author">The author.</param>
        /// <returns>a a</returns>
        public ICollection<Book> GetBooksFromAuthor(Author author)
        {
            Log.Info("Getting books from author ");
            if (author == null)
            {
                return new List<Book>();
            }

            using (var context = new LibraryContext())
            {
                List<Book> books = new List<Book>();
                
                var currentAuthor = context.Authors.Where(a => a.ID == author.ID).Single();
                books.AddRange(currentAuthor.Books);

                Log.Info("Returning books from author " + author.Name);
                return books;
            }
        }
    }
}
