//-----------------------------------------------------------------------
// <copyright file="SQLServerDAOFactory.cs" company="Transilvania University of Brasov">
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

    /// <summary>SQL Server DAO Factory.</summary>
    public class SQLServerDAOFactory : IDAOFactory
    {
        /// <summary>Gets the author data service.</summary>
        /// <value>The author data service.</value>
        public IAuthorDataService AuthorDataService
        {
            get
            {
                return new SQLAuthorDataService();
            }
        }

        /// <summary>Gets the book data service.</summary>
        /// <value>The book data service.</value>
        public IBookDataServices BookDataService
        {
            get
            {
                return new SQLBookDataService();
            }
        }

        /// <summary>Gets the domain data service.</summary>
        /// <value>The domain data service.</value>
        public IDomainDataService DomainDataService
        {
            get
            {
                return new SQLDomainDataService();
            }
        }

        /// <summary>Gets the edition data service.</summary>
        /// <value>The edition data service.</value>
        public IEditionDataService EditionDataService
        {
            get
            {
                return new SQLEditionDataService();
            }
        }

        /// <summary>Gets the reader data service.</summary>
        /// <value>The reader data service.</value>
        public IReaderDataService ReaderDataService
        {
            get
            {
                return new SQLReaderDataService();
            }
        }
    }
}
