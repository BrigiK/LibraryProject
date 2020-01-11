//-----------------------------------------------------------------------
// <copyright file="SQLDomainDataService.cs" company="Transilvania University of Brasov">
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

    /// <summary>SQL Domain Data Service.</summary>
    public class SQLDomainDataService : IDomainDataService
    {
        /// <summary>Adds the domain.</summary>
        /// <param name="domain">The domain.</param>
        public void AddDomain(Domain domain)
        {
            using (var context = new LibraryContext())
            {
                context.Domains.Add(domain);
                context.SaveChanges();
            }
        }

        /// <summary>Deletes the domain.</summary>
        /// <param name="domain">The domain.</param>
        public void DeleteDomain(Domain domain)
        {
            using (var context = new LibraryContext())
            {
                var newDomain = new Domain { ID = domain.ID };
                context.Domains.Attach(newDomain);
                context.Domains.Remove(newDomain);
                context.SaveChanges();
            }
        }

        /// <summary>Gets all domains.</summary>
        /// <returns>a a</returns>
        public IList<Domain> GetAllDomains()
        {
            using (var context = new LibraryContext())
            {
                return context.Domains.Select(domain => domain).ToList();
            }
        }

        /// <summary>Gets the domain by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        public Domain GetDomainById(int id)
        {
            using (var context = new LibraryContext())
            {
                return context.Domains.Where(domain => domain.ID == id).SingleOrDefault();
            }
        }

        /// <summary>Updates the domain.</summary>
        /// <param name="domain">The domain.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">e e</exception>
        public void UpdateDomain(Domain domain)
        {
            using (var context = new LibraryContext())
            {
                Domain domainRef = context.Domains.Where(d => d.ID == domain.ID).SingleOrDefault();
                if (domainRef != null)
                {
                    domainRef = domain;
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
