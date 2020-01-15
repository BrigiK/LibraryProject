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
    using log4net;

    /// <summary>SQL Domain Data Service.</summary>
    public class SQLDomainDataService : IDomainDataService
    {
        /// <summary>The logger instance.</summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(SQLDomainDataService));

        /// <summary>Adds the domain.</summary>
        /// <param name="domain">The domain.</param>
        public void AddDomain(Domain domain)
        {
            Log.Info("Add new domain " + domain.Name);
            using (var context = new LibraryContext())
            {
                context.Domains.Add(domain);
                context.SaveChanges();
            }

            Log.Info("New domain successfully added.");
        }

        /// <summary>Deletes the domain.</summary>
        /// <param name="domain">The domain.</param>
        public void DeleteDomain(Domain domain)
        {
            Log.Info("Delete domain " + domain.Name);
            using (var context = new LibraryContext())
            {
                var newDomain = new Domain { ID = domain.ID };
                context.Domains.Attach(newDomain);
                context.Domains.Remove(newDomain);
                context.SaveChanges();
            }

            Log.Info("Domain" + domain.Name + " successfully deleted.");
        }

        /// <summary>Gets all domains.</summary>
        /// <returns>a a</returns>
        public IList<Domain> GetAllDomains()
        {
            Log.Info("Getting all domains.");
            using (var context = new LibraryContext())
            {
                return context.Domains.Select(domain => domain).ToList();
            }
        }

        /// <summary>Gets the child domains.</summary>
        /// <param name="domain">The domain.</param>
        /// <returns>a a</returns>
        public ICollection<Domain> GetChildDomains(Domain domain)
        {
            Log.Info("Getting the child domains for domain " + domain.Name);
            ICollection<Domain> childDomains = new List<Domain>();

            using (var context = new LibraryContext())
            {
                childDomains = (from p in context.Domains
                        where p.ParentDomain.ID == domain.ID
                        select p).ToList();
            }

            Log.Info("Returning the child domains for domain " + domain.Name);
            return childDomains;
        }

        /// <summary>Gets the domain by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        public Domain GetDomainById(int id)
        {
            Log.Info("Getting domain by id.");
            using (var context = new LibraryContext())
            {
                return context.Domains.Where(domain => domain.ID == id).SingleOrDefault();
            }
        }

        /// <summary>Gets the domain by name.</summary>
        /// <param name="name">The name.</param>
        /// <returns>a a</returns>
        public Domain GetDomainByName(string name)
        {
            Log.Info("Getting domain by name.");
            using (var context = new LibraryContext())
            {
                return context.Domains.Where(domain => domain.Name == name).SingleOrDefault();
            }
        }

        /// <summary>Updates the domain.</summary>
        /// <param name="domain">The domain.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">e e</exception>
        public void UpdateDomain(Domain domain)
        {
            Log.Info("Updating domain " + domain.Name);
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

            Log.Info("Domain successfully updated.");
        }

        /// <summary>Gets the root domain.</summary>
        /// <param name="domain">The domain.</param>
        /// <returns>a a</returns>
        public Domain GetRootDomain(Domain domain)
        {
            Log.Info("Getting the root domain for domain " + domain.Name);
            using (var context = new LibraryContext())
            {
                Domain currentDomain = context.Domains.Where(d => d.ID == domain.ID).Single();

                while (currentDomain.ParentDomain != null)
                {
                    currentDomain = currentDomain.ParentDomain;
                }

                Log.Info("Returning the root domain for domain " + domain.Name);
                return currentDomain;
            }
        }
    }
}
