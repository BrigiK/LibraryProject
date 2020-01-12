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

        /// <summary>Book's domain contains parent domain.</summary>
        /// <param name="book">The book.</param>
        /// <returns>a a</returns>
        public bool BookDomainContainsParentDomain(Book book)
        {
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
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>Book has only DOM domains.</summary>
        /// <param name="book">The book.</param>
        /// <returns>a a</returns>
        public bool BookHasOnlyDOMDomains(Book book)
        {
            SQLConfigurationDataService configuration = new SQLConfigurationDataService();

            if (book.Domains.Count <= configuration.GetConfiguration("MaxDOMBook").Value)
            {
                return true;
            }

            return false;
        }

        /// <summary>Gets the books from domain.</summary>
        /// <param name="domain">The domain.</param>
        /// <returns>a a</returns>
        public ICollection<Book> GetBooksFromDomain(Domain domain)
        {
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

                return books;
            }
        }
    }
}
