//-----------------------------------------------------------------------
// <copyright file="DomainServicesImplementation.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace ServiceLayer.ServiceImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LibraryProject.DataLayer.DataMapper;
    using LibraryProject.DomainModel;

    /// <summary>Domain Services Implementation.</summary>
    public class DomainServicesImplementation : IDomainServices
    {
        /// <summary>The domain data service</summary>
        private IDomainDataService domainDataService;

        /// <summary>Initializes a new instance of the <see cref="DomainServicesImplementation"/> class.</summary>
        /// <param name="domainDataService">The domain data service.</param>
        public DomainServicesImplementation(IDomainDataService domainDataService = null)
        {
            if (domainDataService == null)
            {
                domainDataService = DAOFactoryMethod.CurrentDAOFactory.DomainDataService;
            }

            this.domainDataService = domainDataService;
        }

        /// <summary>Adds the domain.</summary>
        /// <param name="domain">The domain.</param>
        public void AddDomain(Domain domain)
        {
            if (!domain.Name.Equals(string.Empty))
            {
                this.domainDataService.AddDomain(domain);
            }
        }

        /// <summary>Deletes the domain.</summary>
        /// <param name="domain">The domain.</param>
        public void DeleteDomain(Domain domain)
        {
            this.domainDataService.DeleteDomain(domain);
        }

        /// <summary>Gets all domains.</summary>
        /// <returns>a a</returns>
        public IList<Domain> GetAllDomains()
        {
            return this.domainDataService.GetAllDomains();
        }

        /// <summary>Gets the child domains.</summary>
        /// <param name="domain">The domain.</param>
        /// <returns>a a</returns>
        public ICollection<Domain> GetChildDomains(Domain domain)
        {
            return this.domainDataService.GetChildDomains(domain);
        }

        /// <summary>Gets the domain by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        public Domain GetDomainById(int id)
        {
            return this.domainDataService.GetDomainById(id);
        }

        /// <summary>Gets the domain by name.</summary>
        /// <param name="name">The name.</param>
        /// <returns>a a</returns>
        public Domain GetDomainByName(string name)
        {
            return this.domainDataService.GetDomainByName(name);
        }

        /// <summary>Updates the domain.</summary>
        /// <param name="domain">The domain.</param>
        public void UpdateDomain(Domain domain)
        {
            this.domainDataService.UpdateDomain(domain);
        }
    }
}
