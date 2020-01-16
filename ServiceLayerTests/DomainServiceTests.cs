//-----------------------------------------------------------------------
// <copyright file="DomainServiceTests.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace ServiceLayerTests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LibraryProject.DataLayer.DataMapper;
    using ServiceLayer.ServiceImplementation;
    using Rhino.Mocks;
    using LibraryProject.DomainModel;

    /// <summary>
    /// Domain Service Tests class.
    /// </summary>
    [TestClass]
    public class DomainServiceTests
    {
        /// <summary>The domain data services</summary>
        private IDomainDataService domainDataServices;

        /// <summary>The domain services</summary>
        private DomainServicesImplementation domainServices;

        /// <summary>Sets up.</summary>
        [TestInitialize]
        public void SetUp()
        {
            domainDataServices = MockRepository.GenerateMock<IDomainDataService>();
            domainServices = new DomainServicesImplementation(domainDataServices);
        }

        /// <summary>Tests the configuration has data service with argument.</summary>
        [TestMethod]
        public void TestDomainHasDataServiceWithArgument()
        {
            domainServices = new DomainServicesImplementation(domainDataServices);
            Assert.IsTrue(domainServices != null);
        }

        /// <summary>Tests the configuration has data service with no argument.</summary>
        [TestMethod]
        public void TestDomainHasDataServiceWithNoArgument()
        {
            domainServices = new DomainServicesImplementation();
        }

        /// <summary>Tests the domain get by identifier.</summary>
        [TestMethod]
        public void TestDomainGetById()
        {
            int id = 11;
            Domain domain = new Domain { ID = 11, Name = "Science & Math" };

            domainDataServices.Stub(dao => dao.GetDomainById(id)).Return(domain);

            Domain result = domainServices.GetDomainById(id);

            Assert.AreEqual(id, result.ID);
        }

        /// <summary>Tests the domain add.</summary>
        [TestMethod]
        public void TestDomainAdd()
        {
            Domain domain = new Domain { Name = "Science & Math" };

            domainDataServices.Expect(dao => dao.AddDomain(domain));

            domainServices.AddDomain(domain);

            domainDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the domain delete.</summary>
        [TestMethod]
        public void TestDomainDelete()
        {
            Domain domain = new Domain { Name = "Science & Math" };

            domainDataServices.Expect(dao => dao.DeleteDomain(domain));

            domainServices.DeleteDomain(domain);

            domainDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the domain update.</summary>
        [TestMethod]
        public void TestDomainUpdate()
        {
            Domain domain = new Domain { Name = "Science & Math" };

            domainDataServices.Expect(dao => dao.UpdateDomain(domain));

            domainServices.UpdateDomain(domain);

            domainDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the domain get all domains.</summary>
        [TestMethod]
        public void TestDomainGetAllDomains()
        {
            domainDataServices.Expect(dao => dao.GetAllDomains());

            domainServices.GetAllDomains();

            domainDataServices.VerifyAllExpectations();
        }
    }
}
