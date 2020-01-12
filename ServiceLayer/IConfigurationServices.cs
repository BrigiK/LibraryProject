//-----------------------------------------------------------------------
// <copyright file="IConfigurationServices.cs" company="Transilvania University of Brasov">
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

    /// <summary>Interface for Configuration Services.</summary>
    public interface IConfigurationServices
    {
        /// <summary>Gets the configuration.</summary>
        /// <param name="name">The name.</param>
        /// <returns>a a</returns>
        Configuration GetConfiguration(string name);
    }
}
