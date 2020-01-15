//-----------------------------------------------------------------------
// <copyright file="EditionServicesImplementation.cs" company="Transilvania University of Brasov">
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

    /// <summary>Edition Services Implementation.</summary>
    /// <seealso cref="ServiceLayer.IEditionServices" />
    public class EditionServicesImplementation : IEditionServices
    {
        /// <summary>The edition data service</summary>
        private IEditionDataService editionDataService;

        /// <summary>Initializes a new instance of the <see cref="EditionServicesImplementation"/> class.</summary>
        /// <param name="editionDataService">The edition data service.</param>
        public EditionServicesImplementation(IEditionDataService editionDataService = null)
        {
            if (editionDataService == null)
            {
                editionDataService = DAOFactoryMethod.CurrentDAOFactory.EditionDataService;
            }

            this.editionDataService = editionDataService;
        }

        /// <summary>Adds the edition.</summary>
        /// <param name="edition">The edition.</param>
        public void AddEdition(Edition edition)
        {
            if (edition.NumberOfCopies > edition.NumberOfLectureRoomCopies)
            {
                this.editionDataService.AddEdition(edition);
            }
        }

        /// <summary>Deletes the edition.</summary>
        /// <param name="edition">The edition.</param>
        public void DeleteEdition(Edition edition)
        {
            this.editionDataService.DeleteEdition(edition);
        }

        /// <summary>Gets all editions.</summary>
        /// <returns>a a</returns>
        public IList<Edition> GetAllEditions()
        {
            return this.editionDataService.GetAllEditions();
        }

        /// <summary>Gets the edition by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        public Edition GetEditionById(int id)
        {
            return this.editionDataService.GetEditionById(id);
        }

        /// <summary>Updates the edition.</summary>
        /// <param name="edition">The edition.</param>
        public void UpdateEdition(Edition edition)
        {
            this.editionDataService.UpdateEdition(edition);
        }
    }
}
