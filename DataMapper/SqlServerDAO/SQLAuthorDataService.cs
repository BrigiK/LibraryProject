//-----------------------------------------------------------------------
// <copyright file="SQLAuthorDataService.cs" company="Transilvania University of Brasov">
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

    /// <summary>SQL Author Data Service.</summary>
    public class SQLAuthorDataService : IAuthorDataService
    {
        /// <summary>The logger instance.</summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(SQLAuthorDataService));

        /// <summary>Adds the author.</summary>
        /// <param name="author">The author.</param>
        public void AddAuthor(Author author)
        {
            Log.Info("Add new author.");
            using (var context = new LibraryContext())
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }

            Log.Info("New author successfully added.");
        }

        /// <summary>Deletes the author.</summary>
        /// <param name="author">The author.</param>
        public void DeleteAuthor(Author author)
        {
            Log.Info("Delete author.");
            using (var context = new LibraryContext())
            {
                var newAuthor = new Author { ID = author.ID };
                context.Authors.Attach(newAuthor);
                context.Authors.Remove(newAuthor);
                context.SaveChanges();
            }

            Log.Info("Author successfully deleted.");
        }

        /// <summary>Gets all authors.</summary>
        /// <returns>a a</returns>
        public IList<Author> GetAllAuthors()
        {
            Log.Info("Getting all authors.");
            using (var context = new LibraryContext())
            {
                return context.Authors.Select(author => author).ToList();
            }
        }

        /// <summary>Gets the author by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        public Author GetAuthorById(int id)
        {
            Log.Info("Getting author by id.");
            using (var context = new LibraryContext())
            {
                return context.Authors.Where(author => author.ID == id).SingleOrDefault();
            }
        }

        /// <summary>Updates the author.</summary>
        /// <param name="author">The author.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">e e</exception>
        public void UpdateAuthor(Author author)
        {
            Log.Info("Updating author.");
            using (var context = new LibraryContext())
            {
                Author authorRef = context.Authors.Where(a => a.ID == author.ID).SingleOrDefault();
                if (authorRef != null)
                {
                    authorRef = author;
                    context.SaveChanges();
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }

            Log.Info("Author successfully updated.");
        }

        /// <summary>Gets the author by name.</summary>
        /// <param name="name">The name.</param>
        /// <returns>a a</returns>
        public Author GetAuthorByName(string name)
        {
            Log.Info("Getting author by name.");
            using (var context = new LibraryContext())
            {
                return context.Authors.Where(author => author.Name.Equals(name)).SingleOrDefault();
            }
        }
    }
}
