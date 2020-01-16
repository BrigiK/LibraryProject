//-----------------------------------------------------------------------
// <copyright file="ReaderServiceTests.cs" company="Transilvania University of Brasov">
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
            Reader reader = new Reader { ID = 11, Name = "Reader Name", Username = "username", Password = "Pp*4hytgf", IsReader = true, IsWorker = false, Email = "unam@gmail.com" };

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

        /// <summary>Tests the name of the reader add without.</summary>
        [TestMethod]
        public void TestReaderAddWithoutName()
        {
            Reader reader = new Reader { ID = 11, Name = string.Empty, Username = "username", Password = "Pp*4hytgf", IsReader = true, IsWorker = false, Email = "unam@gmail.com" };

            readerDataServices.Stub(dao => dao.AddReader(reader));

            Assert.AreEqual(false, readerServices.AddReader(reader));
        }

        /// <summary>Tests the reader add without username.</summary>
        [TestMethod]
        public void TestReaderAddWithoutUsername()
        {
            Reader reader = new Reader { ID = 11, Name = "This Is His Name", Username = string.Empty, Password = "Pp*4hytgf", IsReader = true, IsWorker = false, Email = "unam@gmail.com" };

            readerDataServices.Stub(dao => dao.AddReader(reader));

            Assert.AreEqual(false, readerServices.AddReader(reader));
        }

        /// <summary>Tests the reader add without email.</summary>
        [TestMethod]
        public void TestReaderAddWithoutEmail()
        {
            Reader reader = new Reader { ID = 11, Name = "This Is His Name", Username = "Thisisunam", Password = "Pp*4hytgf", IsReader = true, IsWorker = false, Email = string.Empty };

            readerDataServices.Stub(dao => dao.AddReader(reader));

            Assert.AreEqual(false, readerServices.AddReader(reader));
        }

        /// <summary>Tests the reader add without password.</summary>
        [TestMethod]
        public void TestReaderAddWithoutPassword()
        {
            Reader reader = new Reader { ID = 11, Name = "This Is His Name", Username = "Thisisunam", Password = string.Empty, IsReader = true, IsWorker = false, Email = "unam@gmail.com" };

            readerDataServices.Stub(dao => dao.AddReader(reader));

            Assert.AreEqual(false, readerServices.AddReader(reader));
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

        /// <summary>Tests the reader borrow book.</summary>
        [TestMethod]
        public void TestReaderBorrowBook()
        {
            Reader reader = new Reader { ID = 11, Name = "Reader Name", Username = "username", Password = "Pp*4hytgf", IsReader = true, IsWorker = false, Email = "unam@gmail.com" };

            Edition edition = new Edition { ID = 11, PublisherName = "Second Edition", Year = 1986, Number = 2, Type = "Mass Market Paperback", NumberOfPages = 480, NumberOfCopies = 15, NumberOfLectureRoomCopies = 2 };

            readerDataServices.Expect(dao => dao.BorrowBook(reader, edition));

            readerServices.BorrowBook(reader, edition);

            readerDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the reader borrow books.</summary>
        [TestMethod]
        public void TestReaderBorrowBooks()
        {
            Reader reader = new Reader { ID = 11, Name = "Reader Name", Username = "username", Password = "Pp*4hytgf", IsReader = true, IsWorker = false, Email = "unam@gmail.com" };

            List<Edition> editions = new List<Edition>
            {
                new Edition { ID = 11, PublisherName = "Second Edition", Year = 1986, Number = 2, Type = "Mass Market Paperback", NumberOfPages = 480, NumberOfCopies = 15, NumberOfLectureRoomCopies = 2 },
                new Edition { PublisherName = "Penguin Young Readers Group", Year = 2005, Number = 1, Type = "Paperback", NumberOfPages = 112, NumberOfCopies = 82, NumberOfLectureRoomCopies = 1 }
            };

            readerDataServices.Expect(dao => dao.BorrowBooks(reader, editions));

            readerServices.BorrowBooks(reader, editions);

            readerDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the reader give back book.</summary>
        [TestMethod]
        public void TestReaderGiveBackBook()
        {
            Reader reader = new Reader { ID = 11, Name = "Reader Name", Username = "username", Password = "Pp*4hytgf", IsReader = true, IsWorker = false, Email = "unam@gmail.com" };

            Edition edition = new Edition { ID = 11, PublisherName = "Second Edition", Year = 1986, Number = 2, Type = "Mass Market Paperback", NumberOfPages = 480, NumberOfCopies = 15, NumberOfLectureRoomCopies = 2 };

            readerDataServices.Expect(dao => dao.GiveBackBook(reader, edition));

            readerServices.GiveBackBook(reader, edition);

            readerDataServices.VerifyAllExpectations();
        }
    }
}
