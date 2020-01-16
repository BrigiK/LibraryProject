//-----------------------------------------------------------------------
// <copyright file="EditionServiceTests.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace ServiceLayerTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using LibraryProject.DataLayer.DataMapper;
    using LibraryProject.DomainModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Rhino.Mocks;
    using ServiceLayer.ServiceImplementation;

    /// <summary>
    /// Edition Service Tests class.
    /// </summary>
    [TestClass]
    public class EditionServiceTests
    {
        /// <summary>The edition data services</summary>
        private IEditionDataService editionDataServices;

        /// <summary>The edition services</summary>
        private EditionServicesImplementation editionServices;

        /// <summary>Sets up.</summary>
        [TestInitialize]
        public void SetUp()
        {
            editionDataServices = MockRepository.GenerateMock<IEditionDataService>();
            editionServices = new EditionServicesImplementation(editionDataServices);
        }

        /// <summary>Tests the edition has data service with argument.</summary>
        [TestMethod]
        public void TestEditionHasDataServiceWithArgument()
        {
            editionServices = new EditionServicesImplementation(editionDataServices);
            Assert.IsTrue(editionServices != null);
        }

        /// <summary>Tests the edition has data service with no argument.</summary>
        [TestMethod]
        public void TestEditionHasDataServiceWithNoArgument()
        {
            editionServices = new EditionServicesImplementation();
        }

        /// <summary>Tests the edition get by identifier.</summary>
        [TestMethod]
        public void TestEditionGetById()
        {
            int id = 11;
            Edition edition = new Edition { ID = 11, PublisherName = "Second Edition", Year = 1986, Number = 2, Type = "Mass Market Paperback", NumberOfPages = 480, NumberOfCopies = 8, NumberOfLectureRoomCopies = 2 };

            editionDataServices.Stub(dao => dao.GetEditionById(id)).Return(edition);

            Edition result = editionServices.GetEditionById(id);

            Assert.AreEqual(id, result.ID);
        }

        /// <summary>Tests the edition add.</summary>
        [TestMethod]
        public void TestEditionAdd()
        {
            Edition edition = new Edition { ID = 11, PublisherName = "Second Edition", Year = 1986, Number = 2, Type = "Mass Market Paperback", NumberOfPages = 480, NumberOfCopies = 8, NumberOfLectureRoomCopies = 2 };

            editionDataServices.Expect(dao => dao.AddEdition(edition));

            editionServices.AddEdition(edition);

            editionDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the edition delete.</summary>
        [TestMethod]
        public void TestEditionDelete()
        {
            Edition edition = new Edition { ID = 11, PublisherName = "Second Edition", Year = 1986, Number = 2, Type = "Mass Market Paperback", NumberOfPages = 480, NumberOfCopies = 8, NumberOfLectureRoomCopies = 2 };

            editionDataServices.Expect(dao => dao.DeleteEdition(edition));

            editionServices.DeleteEdition(edition);

            editionDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the edition update.</summary>
        [TestMethod]
        public void TestEditionUpdate()
        {
            Edition edition = new Edition { ID = 11, PublisherName = "Second Edition", Year = 1986, Number = 2, Type = "Mass Market Paperback", NumberOfPages = 480, NumberOfCopies = 8, NumberOfLectureRoomCopies = 2 };

            editionDataServices.Expect(dao => dao.UpdateEdition(edition));

            editionServices.UpdateEdition(edition);

            editionDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the edition get all editions.</summary>
        [TestMethod]
        public void TestEditionGetAllEditions()
        {
            editionDataServices.Expect(dao => dao.GetAllEditions());

            editionServices.GetAllEditions();

            editionDataServices.VerifyAllExpectations();
        }
    }
}
