//-----------------------------------------------------------------------
// <copyright file="BookTests.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace DomainModelTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using LibraryProject.DomainModel;
    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Book Tests class.
    /// </summary>
    [TestClass]
    public class BookTests
    {
        /// <summary>The book</summary>
        private Book book = null;

        /// <summary>Sets up.</summary>
        [TestInitialize]
        public void SetUp()
        {
            // a valid book
            book = new Book()
            {
                Title = "Then Sings My Soul: 150 of the World's Greatest Hymn Stories",
                Authors = new List<Author> { new Author { Name = "Robert J. Morgan" } },
                Domains = new List<Domain> { new Domain { Name = "Painting" } },
                Editions = new List<Edition> { new Edition { PublisherName = "First Edition", Year = 2006, Number = 1, Type = "Paperback", NumberOfPages = 544, NumberOfCopies = 4, NumberOfLectureRoomCopies = 1 } },
                Readers = new List<Reader> { new Reader { Name = "Joel", Username = "joey", Password = "pwd", Email = "joel@gmail.com", IsReader = true, IsWorker = false } }
            }; 
        }

        /// <summary>Tests the book is valid.</summary>
        [TestMethod]
        public void TestBookIsValid()
        {
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(0, validationResults.Count);
        }

        //// ID

        /// <summary>Tests the book identifier set get.</summary>
        [TestMethod]
        public void TestBookIdSetGet()
        {
            book.ID = 1010;
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(1010, book.ID);
        }

        /// <summary>Tests the book identifier default is zero.</summary>
        [TestMethod]
        public void TestBookIdDefaultIsZero()
        {
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(0, book.ID);
        }

        //// TITLE

        /// <summary>Tests the book title is null.</summary>
        [TestMethod]
        public void TestBookTitleIsNull()
        {
            book.Title = null;
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the book title is not null.</summary>
        [TestMethod]
        public void TestBookTitleIsNotNull()
        {
            book.Title = "Hello";
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the book title is empty.</summary>
        [TestMethod]
        public void TestBookTitleIsEmpty()
        {
            book.Title = string.Empty;
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the book title is not empty.</summary>
        [TestMethod]
        public void TestBookTitleIsNotEmpty()
        {
            book.Title = "Title";
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the book title too short.</summary>
        [TestMethod]
        public void TestBookTitleTooShort()
        {
            book.Title = "T";
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the book title lower boundary.</summary>
        [TestMethod]
        public void TestBookTitleLowerBoundary()
        {
            book.Title = "Do";
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the book title upper boundary.</summary>
        [TestMethod]
        public void TestBookTitleUpperBoundary()
        {
            book.Title = new string('a', 150);
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the book title too long.</summary>
        [TestMethod]
        public void TestBookTitleTooLong()
        {
            book.Title = new string('a', 151);
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// AUTHORS

        /// <summary>Tests the book authors not null.</summary>
        [TestMethod]
        public void TestBookAuthorsNotNull()
        {
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreNotEqual(null, book.Authors);
        }

        /// <summary>Tests the book authors empty.</summary>
        [TestMethod]
        public void TestBookAuthorsEmpty()
        {
            book.Authors = new List<Author>();
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(0, book.Authors.Count);
        }

        /// <summary>Tests the book authors null.</summary>
        [TestMethod]
        public void TestBookAuthorsNull()
        {
            book.Authors = null;
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(null, book.Authors);
        }

        /// <summary>Tests the book authors not empty.</summary>
        [TestMethod]
        public void TestBookAuthorsNotEmpty()
        {
            book.Authors.Add(new Author { Name = "Robert J. Morgan" });
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreNotEqual(0, book.Authors.Count);
        }

        //// EDITIONS

        /// <summary>Tests the book editions not null.</summary>
        [TestMethod]
        public void TestBookEditionsNotNull()
        {
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreNotEqual(null, book.Editions);
        }

        /// <summary>Tests the book editions empty.</summary>
        [TestMethod]
        public void TestBookEditionsEmpty()
        {
            book.Editions = new List<Edition>();
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(0, book.Editions.Count);
        }

        /// <summary>Tests the book editions null.</summary>
        [TestMethod]
        public void TestBookEditionsNull()
        {
            book.Editions = null;
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(null, book.Editions);
        }

        /// <summary>Tests the book editions not empty.</summary>
        [TestMethod]
        public void TestBookEditionsNotEmpty()
        {
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreNotEqual(0, book.Authors.Count);
        }

        //// DOMAINS

        /// <summary>Tests the book domains not null.</summary>
        [TestMethod]
        public void TestBookDomainsNotNull()
        {
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreNotEqual(null, book.Domains);
        }

        /// <summary>Tests the book domains empty.</summary>
        [TestMethod]
        public void TestBookDomainsEmpty()
        {
            book.Domains = new List<Domain>();
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(0, book.Domains.Count);
        }

        /// <summary>Tests the book domains null.</summary>
        [TestMethod]
        public void TestBookDomainsNull()
        {
            book.Domains = null;
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(null, book.Domains);
        }

        /// <summary>Tests the book domains not empty.</summary>
        [TestMethod]
        public void TestBookDomainsNotEmpty()
        {
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreNotEqual(0, book.Domains.Count);
        }

        //// READERS

        /// <summary>Tests the book readers not null.</summary>
        [TestMethod]
        public void TestBookReadersNotNull()
        {
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreNotEqual(null, book.Readers);
        }

        /// <summary>Tests the book readers empty.</summary>
        [TestMethod]
        public void TestBookReadersEmpty()
        {
            book.Readers = new List<Reader>();
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(0, book.Readers.Count);
        }

        /// <summary>Tests the book readers null.</summary>
        [TestMethod]
        public void TestBookReadersNull()
        {
            book.Readers = null;
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreEqual(null, book.Readers);
        }

        /// <summary>Tests the book readers not empty.</summary>
        [TestMethod]
        public void TestBookReadersNotEmpty()
        {
            ValidationResults validationResults = Validation.Validate<Book>(book);
            Assert.AreNotEqual(0, book.Readers.Count);
        }
    }
}
