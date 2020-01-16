//-----------------------------------------------------------------------
// <copyright file="ReaderServiceTests.cs" company="Transilvania University of Brasov">
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
    /// Reader Service Tests class.
    /// </summary>
    [TestClass]
    public class ReaderServiceTests
    {
        /// <summary>The reader data services</summary>
        private IReaderDataService readerDataServices;

        /// <summary>The reader services</summary>
        private ReaderServicesImplementation readerServices;

        /// <summary>Sets up.</summary>
        [TestInitialize]
        public void SetUp()
        {
            readerDataServices = MockRepository.GenerateMock<IReaderDataService>();
            readerServices = new ReaderServicesImplementation(readerDataServices);
        }

        /// <summary>Tests the reader has data service with argument.</summary>
        [TestMethod]
        public void TestReaderHasDataServiceWithArgument()
        {
            readerServices = new ReaderServicesImplementation(readerDataServices);
            Assert.IsTrue(readerServices != null);
        }

        /// <summary>Tests the reader has data service with no argument.</summary>
        [TestMethod]
        public void TestReaderHasDataServiceWithNoArgument()
        {
            readerServices = new ReaderServicesImplementation();
        }

        /// <summary>Tests the reader get by identifier.</summary>
        [TestMethod]
        public void TestReaderGetById()
        {
            int id = 11;
            Reader reader = new Reader { ID = 11, Name = "Reader Name", Username = "username", Password = "Pp*4hytgf", IsReader = true, IsWorker = false, Email = "unam@gmail.com"};

            readerDataServices.Stub(dao => dao.GetReaderById(id)).Return(reader);

            Reader result = readerServices.GetReaderById(id);

            Assert.AreEqual(id, result.ID);
        }

        /// <summary>Tests the reader add.</summary>
        [TestMethod]
        public void TestReaderAdd()
        {
            Reader reader = new Reader { ID = 11, Name = "Reader Name", Username = "username", Password = "Pp*4hytgf", IsReader = true, IsWorker = false, Email = "unam@gmail.com" };

            readerDataServices.Expect(dao => dao.AddReader(reader));

            readerServices.AddReader(reader);

            readerDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the reader delete.</summary>
        [TestMethod]
        public void TestReaderDelete()
        {
            Reader reader = new Reader { ID = 11, Name = "Reader Name", Username = "username", Password = "Pp*4hytgf", IsReader = true, IsWorker = false, Email = "unam@gmail.com" };

            readerDataServices.Expect(dao => dao.DeleteReader(reader));

            readerServices.DeleteReader(reader);

            readerDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the reader update.</summary>
        [TestMethod]
        public void TestReaderUpdate()
        {
            Reader reader = new Reader { ID = 11, Name = "Reader Name", Username = "username", Password = "Pp*4hytgf", IsReader = true, IsWorker = false, Email = "unam@gmail.com" };

            readerDataServices.Expect(dao => dao.UpdateReader(reader));

            readerServices.UpdateReader(reader);

            readerDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the reader get all readers.</summary>
        [TestMethod]
        public void TestReaderGetAllReaders()
        {
            readerDataServices.Expect(dao => dao.GetAllReaders());

            readerServices.GetAllReaders();

            readerDataServices.VerifyAllExpectations();
        }
    }
}
