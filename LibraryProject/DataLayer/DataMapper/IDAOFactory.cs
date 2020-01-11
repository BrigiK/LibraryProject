//-----------------------------------------------------------------------
// <copyright file="IDAOFactory.cs" company="Transilvania University of Brasov">
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
    using LibraryProject.DataLayer.DataMapper.SqlServerDAO;

    /// <summary>Data Access Object Factory Interface.</summary>
    public interface IDAOFactory
    {
        /// <summary>Gets the author data service.</summary>
        /// <value>The author data service.</value>
        IAuthorDataService AuthorDataService
        {
            get;
        }

        /// <summary>Gets the book data service.</summary>
        /// <value>The book data service.</value>
        IBookDataServices BookDataService
        {
            get;
        }

        /// <summary>Gets the domain data service.</summary>
        /// <value>The domain data service.</value>
        IDomainDataService DomainDataService
        {
            get;
        }

        /// <summary>Gets the edition data service.</summary>
        /// <value>The edition data service.</value>
        IEditionDataService EditionDataService
        {
            get;
        }

        /// <summary>Gets the reader data service.</summary>
        /// <value>The reader data service.</value>
        IReaderDataService ReaderDataService
        {
            get;
        }
    }
}
