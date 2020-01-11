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

    /// <summary>SQL Author Data Service.</summary>
    public class SQLAuthorDataService : IAuthorDataService
    {
        /// <summary>Adds the author.</summary>
        /// <param name="author">The author.</param>
        public void AddAuthor(Author author)
        {
            using (var context = new LibraryContext())
            {
                context.Authors.Add(author);
                context.SaveChanges();
            }
        }

        /// <summary>Deletes the author.</summary>
        /// <param name="author">The author.</param>
        public void DeleteAuthor(Author author)
        {
            using (var context = new LibraryContext())
            {
                var newAuthor = new Author { ID = author.ID };
                context.Authors.Attach(newAuthor);
                context.Authors.Remove(newAuthor);
                context.SaveChanges();
            }
        }

        /// <summary>Gets all authors.</summary>
        /// <returns>a a</returns>
        public IList<Author> GetAllAuthors()
        {
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
        }
    }
}
