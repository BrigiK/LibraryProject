//-----------------------------------------------------------------------
// <copyright file="SQLEditionDataService.cs" company="Transilvania University of Brasov">
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

    /// <summary>SQL Edition Data Service.</summary>
    public class SQLEditionDataService : IEditionDataService
    {
        /// <summary>The logger instance.</summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(SQLEditionDataService));

        /// <summary>Adds the edition.</summary>
        /// <param name="edition">The edition.</param>
        public void AddEdition(Edition edition)
        {
            Log.Info("Add new edition.");
            using (var context = new LibraryContext())
            {
                context.Editions.Add(edition);
                context.SaveChanges();
            }

            Log.Info("New edition successfully added.");
        }

        /// <summary>Deletes the edition.</summary>
        /// <param name="edition">The edition.</param>
        public void DeleteEdition(Edition edition)
        {
            Log.Info("Delete edition for book " + edition.Book.Title);
            using (var context = new LibraryContext())
            {
                var newEdition = new Edition { ID = edition.ID };
                context.Editions.Attach(newEdition);
                context.Editions.Remove(newEdition);
                context.SaveChanges();
            }

            Log.Info("Edition successfully deleted for book " + edition.Book.Title);
        }

        /// <summary>Gets all editions.</summary>
        /// <returns>a a</returns>
        public IList<Edition> GetAllEditions()
        {
            Log.Info("Getting all editions.");
            using (var context = new LibraryContext())
            {
                return context.Editions.Select(edition => edition).ToList();
            }
        }

        /// <summary>Gets the edition by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        public Edition GetEditionById(int id)
        {
            Log.Info("Getting edition by id.");
            using (var context = new LibraryContext())
            {
                return context.Editions.Where(edition => edition.ID == id).SingleOrDefault();
            }
        }

        /// <summary>Updates the edition.</summary>
        /// <param name="edition">The edition.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">e e</exception>
        public void UpdateEdition(Edition edition)
        {
            Log.Info("Updating edition.");
            using (var context = new LibraryContext())
            {
                Edition editionRef = context.Editions.Where(e => e.ID == edition.ID).SingleOrDefault();
                if (editionRef != null)
                {
                    editionRef = edition;
                    context.SaveChanges();
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }

            Log.Info("Edition successfully updated.");
        }
    }
}
