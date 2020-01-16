//-----------------------------------------------------------------------
// <copyright file="BookServiceTests.cs" company="Transilvania University of Brasov">
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
    /// Book Service Tests class.
    /// </summary>
    [TestClass]
    public class BookServiceTests
    {
        /// <summary>The book data services</summary>
        private IBookDataServices bookDataServices;

        /// <summary>The book services</summary>
        private BookServicesImplementation bookServices;

        /// <summary>Sets up.</summary>
        [TestInitialize]
        public void SetUp()
        {
            bookDataServices = MockRepository.GenerateMock<IBookDataServices>();
            bookServices = new BookServicesImplementation(bookDataServices);
        }

        /// <summary>Tests the book has data service with argument.</summary>
        [TestMethod]
        public void TestBookHasDataServiceWithArgument()
        {
            bookServices = new BookServicesImplementation(bookDataServices);
            Assert.IsTrue(bookServices != null);
        }

        /// <summary>Tests the book has data service with no argument.</summary>
        [TestMethod]
        public void TestBookHasDataServiceWithNoArgument()
        {
            bookServices = new BookServicesImplementation();
        }

        /// <summary>Tests the book get by identifier.</summary>
        [TestMethod]
        public void TestBookGetById()
        {
            int id = 11;
            Book book = new Book()
            {
                ID = id,
                Title = "Then Sings My Soul: 150 of the World's Greatest Hymn Stories",
                Authors = new List<Author> { new Author { Name = "Robert J. Morgan" } },
                Domains = new List<Domain> { new Domain { Name = "Painting" } },
                Editions = new List<Edition> { new Edition { PublisherName = "First Edition", Year = 2006, Number = 1, Type = "Paperback", NumberOfPages = 544, NumberOfCopies = 4, NumberOfLectureRoomCopies = 1 } },
                Readers = new List<Reader> { new Reader { Name = "Joel", Username = "joey", Password = "Pp4$vreegbrvd", Email = "joel@gmail.com", IsReader = true, IsWorker = false } }
            };

            bookDataServices.Stub(dao => dao.GetBookById(id)).Return(book);

            Book result = bookServices.GetBookById(id);

            Assert.AreEqual(id, result.ID);
        }

        /// <summary>Tests the book add.</summary>
        [TestMethod]
        public void TestBookAdd()
        {
            Book book = new Book()
            {
                Authors = new List<Author> { new Author { Name = "Robert J. Morgan" } },
                Domains = new List<Domain> { new Domain { Name = "Painting" } },
                Editions = new List<Edition> { new Edition { PublisherName = "First Edition", Year = 2006, Number = 1, Type = "Paperback", NumberOfPages = 544, NumberOfCopies = 4, NumberOfLectureRoomCopies = 1 } }
            };

            bookDataServices.Expect(dao => dao.AddBook(book));
            bookDataServices.Expect(dao => dao.BookDomainContainsParentDomain(book)).Return(false);
            bookDataServices.Expect(dao => dao.BookHasOnlyDOMDomains(book)).Return(true);

            bookServices.AddBook(book);

            bookDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the book delete.</summary>
        [TestMethod]
        public void TestBookDelete()
        {
            Book book = new Book()
            {
                ID = 15,
                Title = "Then Sings My Soul: 150 of the World's Greatest Hymn Stories",
                Authors = new List<Author> { new Author { Name = "Robert J. Morgan" } },
                Domains = new List<Domain> { new Domain { Name = "Painting" } },
                Editions = new List<Edition> { new Edition { PublisherName = "First Edition", Year = 2006, Number = 1, Type = "Paperback", NumberOfPages = 544, NumberOfCopies = 4, NumberOfLectureRoomCopies = 1 } },
                Readers = new List<Reader> { new Reader { Name = "Joel", Username = "joey", Password = "Pp4$vreegbrvd", Email = "joel@gmail.com", IsReader = true, IsWorker = false } }
            };

            bookDataServices.Expect(dao => dao.DeleteBook(book));

            bookServices.DeleteBook(book);

            bookDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the author update.</summary>
        [TestMethod]
        public void TestBookUpdate()
        {
            Book book = new Book()
            {
                ID = 15,
                Title = "Then Sings My Soul: 150 of the World's Greatest Hymn Stories",
                Authors = new List<Author> { new Author { Name = "Robert J. Morgan" } },
                Domains = new List<Domain> { new Domain { Name = "Painting" } },
                Editions = new List<Edition> { new Edition { PublisherName = "First Edition", Year = 2006, Number = 1, Type = "Paperback", NumberOfPages = 544, NumberOfCopies = 4, NumberOfLectureRoomCopies = 1 } },
                Readers = new List<Reader> { new Reader { Name = "Joel", Username = "joey", Password = "Pp4$vreegbrvd", Email = "joel@gmail.com", IsReader = true, IsWorker = false } }
            };

            bookDataServices.Expect(dao => dao.UpdateBook(book));

            bookServices.UpdateBook(book);

            bookDataServices.VerifyAllExpectations();
        }

        /// <summary>Tests the book get all books.</summary>
        [TestMethod]
        public void TestBookGetAllBooks()
        {
            bookDataServices.Expect(dao => dao.GetAllBooks());

            bookServices.GetAllBooks();

            bookDataServices.VerifyAllExpectations();
        }
    }
}
