//-----------------------------------------------------------------------
// <copyright file="SQLReaderDataService.cs" company="Transilvania University of Brasov">
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

    /// <summary>SQL Reader Data Service.</summary>
    public class SQLReaderDataService : IReaderDataService
    {
        /// <summary>Adds the reader.</summary>
        /// <param name="reader">The reader.</param>
        public void AddReader(Reader reader)
        {
            using (var context = new LibraryContext())
            {
                context.Readers.Add(reader);
                context.SaveChanges();
            }
        }

        /// <summary>Deletes the reader.</summary>
        /// <param name="reader">The reader.</param>
        public void DeleteReader(Reader reader)
        {
            using (var context = new LibraryContext())
            {
                var newReader = new Reader { ID = reader.ID };
                context.Readers.Attach(newReader);
                context.Readers.Remove(newReader);
                context.SaveChanges();
            }
        }

        /// <summary>Gets all books.</summary>
        /// <returns>a a</returns>
        public IList<Reader> GetAllReaders()
        {
            using (var context = new LibraryContext())
            {
                return context.Readers.Select(reader => reader).ToList();
            }
        }

        /// <summary>Gets the reader by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        public Reader GetReaderById(int id)
        {
            using (var context = new LibraryContext())
            {
                return context.Readers.Where(reader => reader.ID == id).SingleOrDefault();
            }
        }

        /// <summary>Updates the reader.</summary>
        /// <param name="reader">The reader.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">e e</exception>
        public void UpdateReader(Reader reader)
        {
            using (var context = new LibraryContext())
            {
                Reader readerRef = context.Readers.Where(r => r.ID == reader.ID).SingleOrDefault();
                if (readerRef != null)
                {
                    readerRef = reader;
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
