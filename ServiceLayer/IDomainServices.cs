//-----------------------------------------------------------------------
// <copyright file="IDomainServices.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace ServiceLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LibraryProject.DomainModel;

    /// <summary>Interface for Domain Services.</summary>
    public interface IDomainServices
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

        /// <summary>  Gets the domain by name.</summary>
        /// <param name="name">The name.</param>
        /// <returns>a a</returns>
        Domain GetDomainByName(string name);

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

        /// <summary>Gets the child domains.</summary>
        /// <param name="domain">The domain.</param>
        /// <returns>a a</returns>
        ICollection<Domain> GetChildDomains(Domain domain);
    }
}
