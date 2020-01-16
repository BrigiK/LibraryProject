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

        /// <summary>Tests the author has data service with no argument.</summary>
        [TestMethod]
        public void TestAuthorHasDataServiceWithNoArgument()
        {
            authorServices = new AuthorServicesImplementation();
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

            Author result = authorServices.GetAuthorById(id);

            Assert.AreEqual(id, result.ID);
        }

        /// <summary>Tests the author add.</summary>
        [TestMethod]
        public void TestAuthorAdd()
        {
            Author author = new Author() { ID = 15, Name = "Jo Joel" };

            authorDataServices.Expect(dao => dao.AddAuthor(author));

            authorServices.AddAuthor(author);

            authorDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the author delete.</summary>
        [TestMethod]
        public void TestAuthorDelete()
        {
            Author author = new Author() { ID = 15, Name = "Jo Joel" };

            authorDataServices.Expect(dao => dao.DeleteAuthor(author));

            authorServices.DeleteAuthor(author);

            authorDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the author update.</summary>
        [TestMethod]
        public void TestAuthorUpdate()
        {
            Author author = new Author() { ID = 15, Name = "Jo Joel" };

            authorDataServices.Expect(dao => dao.UpdateAuthor(author));

            authorServices.UpdateAuthor(author);

            authorDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the author get list of authors.</summary>
        [TestMethod]
        public void TestAuthorGetListOfAuthors()
        {
            authorDataServices.Expect(dao => dao.GetAllAuthors());

            authorServices.GetListOfAuthors();

            authorDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the name of the author get author by.</summary>
        [TestMethod]
        public void TestAuthorGetAuthorByName()
        {
            Author author = new Author() { ID = 15, Name = "Jo Joel" };

            authorDataServices.Expect(dao => dao.GetAuthorByName(author.Name));

            authorServices.GetAuthorByName(author.Name);

            authorDataServices.VerifyAllExpectations();
        }
    }
}
