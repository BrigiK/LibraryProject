//-----------------------------------------------------------------------
// <copyright file="IConfigurationDataService.cs" company="Transilvania University of Brasov">
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
    using LibraryProject.DomainModel;

    /// <summary>Interface for Configuration Data Service.</summary>
    public interface IConfigurationDataService
    {
        /// <summary>Gets the configuration.</summary>
        /// <param name="name">The name.</param>
        /// <returns>a a</returns>
        Configuration GetConfiguration(string name);
    }
}
