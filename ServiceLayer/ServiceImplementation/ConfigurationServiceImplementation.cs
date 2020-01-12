//-----------------------------------------------------------------------
// <copyright file="ConfigurationServiceImplementation.cs" company="Transilvania University of Brasov">
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
    using LibraryProject.DataLayer.DataMapper.SqlServerDAO;
    using LibraryProject.DomainModel;

    /// <summary>Configuration Service Implementation.</summary>
    /// <seealso cref="ServiceLayer.IConfigurationServices" />
    public class ConfigurationServiceImplementation : IConfigurationServices
    {
        /// <summary>The configuration data service</summary>
        private IConfigurationDataService configurationDataService;

        /// <summary>Initializes a new instance of the <see cref="ConfigurationServiceImplementation"/> class.</summary>
        /// <param name="configurationDataService">The configuration data service.</param>
        public ConfigurationServiceImplementation(IConfigurationDataService configurationDataService = null)
        {
            if (configurationDataService == null)
            {
                configurationDataService = DAOFactoryMethod.CurrentDAOFactory.ConfigurationDataService;
            }

            this.configurationDataService = configurationDataService;
        }

        /// <summary>Gets the configuration.</summary>
        /// <param name="name">The name.</param>
        /// <returns>a a</returns>
        public Configuration GetConfiguration(string name)
        {
            return this.configurationDataService.GetConfiguration(name);
        }
    }
}
