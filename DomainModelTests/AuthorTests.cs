//-----------------------------------------------------------------------
// <copyright file="AuthorTests.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace DomainModelTests
{
    using System.Collections.Generic;
    using LibraryProject.DomainModel;
    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Author Tests class.
    /// </summary>
    [TestClass]
    public class AuthorTests
    {
        /// <summary>The author</summary>
        private Author author = null;

        /// <summary>Setups this instance.</summary>
        [TestInitialize]
        public void Setup()
        {
            // a valid author
            this.author = new Author()
            {
                Name = "John Deer",
                Books = new List<Book>()
            };
        }

        /// <summary>Tests the author is valid.</summary>
        [TestMethod]
        public void TestAuthorIsValid()
        {
            ValidationResults validationResults = Validation.Validate<Author>(this.author);
            Assert.AreEqual(0, validationResults.Count);
        }

        //// ID

        /// <summary>Tests the author identifier set get.</summary>
        [TestMethod]
        public void TestAuthorIdSetGet()
        {
            author.ID = 101;
            ValidationResults validationResults = Validation.Validate<Author>(author);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(101, author.ID);
        }

        /// <summary>Tests the author identifier default is zero.</summary>
        [TestMethod]
        public void TestAuthorIdDefaultIsZero()
        {
            ValidationResults validationResults = Validation.Validate<Author>(author);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(0, author.ID);
        }

        //// NAME

        /// <summary>Tests the author name is null.</summary>
        [TestMethod]
        public void TestAuthorNameIsNull()
        {
            this.author.Name = null;
            ValidationResults validationResults = Validation.Validate<Author>(this.author);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the author name is empty.</summary>
        [TestMethod]
        public void TestAuthorNameIsEmpty()
        {
            author.Name = string.Empty;
            ValidationResults validationResults = Validation.Validate<Author>(author);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the author name too short.</summary>
        [TestMethod]
        public void TestAuthorNameTooShort()
        {
            author.Name = "Ta";
            ValidationResults validationResults = Validation.Validate<Author>(author);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the author name lower boundary.</summary>
        [TestMethod]
        public void TestAuthorNameLowerBoundary()
        {
            author.Name = "Dan";
            ValidationResults validationResults = Validation.Validate<Author>(author);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the author name upper boundary.</summary>
        [TestMethod]
        public void TestAuthorNameUpperBoundary()
        {
            author.Name = new string('a', 60);
            ValidationResults validationResults = Validation.Validate<Author>(author);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the author name too long.</summary>
        [TestMethod]
        public void TestAuthorNameTooLong()
        {
            author.Name = new string('a', 61);
            ValidationResults validationResults = Validation.Validate<Author>(author);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// BOOKS

        /// <summary>Tests the author books not null.</summary>
        [TestMethod]
        public void TestAuthorBooksNotNull()
        {
            ValidationResults validationResults = Validation.Validate<Author>(author);
            Assert.AreNotEqual(null, author.Books);
        }

        /// <summary>Tests the author books empty.</summary>
        [TestMethod]
        public void TestAuthorBooksEmpty()
        {
            ValidationResults validationResults = Validation.Validate<Author>(author);
            Assert.AreEqual(0, author.Books.Count);
        }

        /// <summary>Tests the author books null.</summary>
        [TestMethod]
        public void TestAuthorBooksNull()
        {
            author.Books = null;
            ValidationResults validationResults = Validation.Validate<Author>(author);
            Assert.AreEqual(null, author.Books);
        }

        /// <summary>Tests the author books not empty.</summary>
        [TestMethod]
        public void TestAuthorBooksNotEmpty()
        {
            author.Books.Add(new Book
            {
                Title = "Then Sings My Soul: 150 of the World's Greatest Hymn Stories",
                Authors = new List<Author> { new Author { Name = "Robert J. Morgan" } },
                Domains = new List<Domain> { new Domain { Name = "Painting" } },
                Editions = new List<Edition> { new Edition { PublisherName = "First Edition", Year = 2006, Number = 1, Type = "Paperback", NumberOfPages = 544, NumberOfCopies = 4, NumberOfLectureRoomCopies = 1 } }
            });

            ValidationResults validationResults = Validation.Validate<Author>(author);
            Assert.AreNotEqual(0, author.Books.Count);
        }
    }
}
