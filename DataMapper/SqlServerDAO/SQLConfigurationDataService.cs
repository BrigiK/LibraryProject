//-----------------------------------------------------------------------
// <copyright file="SQLConfigurationDataService.cs" company="Transilvania University of Brasov">
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

    /// <summary>SQL Configuration Data Service.</summary>
    /// <seealso cref="LibraryProject.DataLayer.DataMapper.SqlServerDAO.IConfigurationDataService" />
    public class SQLConfigurationDataService : IConfigurationDataService
    {
        /// <summary>The logger instance.</summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(SQLConfigurationDataService));

        /// <summary>Gets the configuration.</summary>
        /// <param name="name">The name.</param>
        /// <returns>a a</returns>
        public Configuration GetConfiguration(string name)
        {
            Log.Info("Getting configuration " + name);
            using (var context = new LibraryContext())
            {
                return context.Configurations.Where(config => config.Name == name).SingleOrDefault();
            }
        }
    }
}
