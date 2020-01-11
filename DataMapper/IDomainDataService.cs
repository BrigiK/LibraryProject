//-----------------------------------------------------------------------
// <copyright file="IDomainDataService.cs" company="Transilvania University of Brasov">
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

    /// <summary>Domain Data Service.</summary>
    public interface IDomainDataService
    {
        /// <summary>Gets all domains.</summary>
        /// <returns>a a</returns>
        IList<Domain> GetAllDomains();

        /// <summary>
        /// Gets the domain by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        Domain GetDomainById(int id);

        /// <summary>
        /// Adds the domain.
        /// </summary>
        /// <param name="domain">The domain.</param>
        void AddDomain(Domain domain);

        /// <summary>
        /// Deletes the domain.
        /// </summary>
        /// <param name="domain">The domain.</param>
        void DeleteDomain(Domain domain);

        /// <summary>
        /// Updates the domain.
        /// </summary>
        /// <param name="domain">The domain.</param>
        void UpdateDomain(Domain domain);
    }
}
