//-----------------------------------------------------------------------
// <copyright file="AuthorServiceTests.cs" company="Transilvania University of Brasov">
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
    /// Author Service Tests class.
    /// </summary>
    [TestClass]
    public class AuthorServiceTests
    {
        /// <summary>The author data services</summary>
        private IAuthorDataService authorDataServices;

        /// <summary>The author services</summary>
        private AuthorServicesImplementation authorServices;

        /// <summary>Sets up.</summary>
        [TestInitialize]
        public void SetUp()
        {
            authorDataServices = MockRepository.GenerateMock<IAuthorDataService>();
            authorServices = new AuthorServicesImplementation(authorDataServices);
        }

        /// <summary>Tests the author has data service with argument.</summary>
        [TestMethod]
        public void TestAuthorHasDataServiceWithArgument()
        {
            authorServices = new AuthorServicesImplementation(authorDataServices);
            Assert.IsTrue(authorServices != null);
        }

        /// <summary>Tests the author get by identifier.</summary>
        [TestMethod]
        public void TestAuthorGetById()
        {
            int id = 15;
            Author author = new Author()
            {
                ID = id,
                Name = "Jo Joel"
            };

            authorDataServices.Stub(dao => dao.GetAuthorById(id)).Return(author);

            Author result = authorDataServices.GetAuthorById(id);

            Assert.AreEqual(id, result.ID);
        }
    }
}
