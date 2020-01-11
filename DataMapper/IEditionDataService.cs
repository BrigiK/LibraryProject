//-----------------------------------------------------------------------
// <copyright file="IEditionDataService.cs" company="Transilvania University of Brasov">
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

    /// <summary>Edition Data Service.</summary>
    public interface IEditionDataService
    {
        /// <summary>Gets all editions.</summary>
        /// <returns>a a</returns>
        IList<Edition> GetAllEditions();

        /// <summary>
        /// Gets the edition by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        Edition GetEditionById(int id);

        /// <summary>
        /// Adds the edition.
        /// </summary>
        /// <param name="edition">The edition.</param>
        void AddEdition(Edition edition);

        /// <summary>
        /// Deletes the edition.
        /// </summary>
        /// <param name="edition">The edition.</param>
        void DeleteEdition(Edition edition);

        /// <summary>
        /// Updates the edition.
        /// </summary>
        /// <param name="edition">The edition.</param>
        void UpdateEdition(Edition edition);
    }
}
