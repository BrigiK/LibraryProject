//-----------------------------------------------------------------------
// <copyright file="DAOFactoryMethod.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryProject.DataLayer.DataMapper
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LibraryProject.DataLayer.DataMapper.SqlServerDAO;

    /// <summary>Data Access Object Factory.</summary>
    public class DAOFactoryMethod
    {
        /// <summary>The current DAO factory</summary>
        private static readonly IDAOFactory McurrentDAOFactory;

        /// <summary>Initializes static members of the <see cref="DAOFactoryMethod" /> class. Initializes the <see cref="DAOFactoryMethod"/> class.</summary>
        static DAOFactoryMethod()
        {
            string currentDataProvider = ConfigurationManager.AppSettings["dataProvider"];
            if (string.IsNullOrWhiteSpace(currentDataProvider))
            {
                McurrentDAOFactory = null;
            }
            else
            {
                switch (currentDataProvider.ToLower().Trim())
                {
                    case "sqlserver":
                        McurrentDAOFactory = new SQLServerDAOFactory();
                        break;
                    default:
                        McurrentDAOFactory = new SQLServerDAOFactory();
                        break;
                }
            }
        }

        /// <summary>Gets the current DAO factory.</summary>
        /// <value>The current DAO factory.</value>
        public static IDAOFactory CurrentDAOFactory
        {
            get
            {
                return McurrentDAOFactory;
            }
        }
    }
}
