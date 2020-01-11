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

    /// <summary>SQL Edition Data Service.</summary>
    public class SQLEditionDataService : IEditionDataService
    {
        /// <summary>Adds the edition.</summary>
        /// <param name="edition">The edition.</param>
        public void AddEdition(Edition edition)
        {
            using (var context = new LibraryContext())
            {
                context.Editions.Add(edition);
                context.SaveChanges();
            }
        }

        /// <summary>Deletes the edition.</summary>
        /// <param name="edition">The edition.</param>
        public void DeleteEdition(Edition edition)
        {
            using (var context = new LibraryContext())
            {
                var newEdition = new Edition { ID = edition.ID };
                context.Editions.Attach(newEdition);
                context.Editions.Remove(newEdition);
                context.SaveChanges();
            }
        }

        /// <summary>Gets all editions.</summary>
        /// <returns>a a</returns>
        public IList<Edition> GetAllEditions()
        {
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
        }
    }
}
