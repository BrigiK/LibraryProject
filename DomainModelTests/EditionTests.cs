//-----------------------------------------------------------------------
// <copyright file="EditionTests.cs" company="Transilvania University of Brasov">
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
    /// Edition Tests class.
    /// </summary>
    [TestClass]
    public class EditionTests
    {
        /// <summary>The edition</summary>
        private Edition edition = null;

        /// <summary>Sets up.</summary>
        [TestInitialize]
        public void SetUp()
        {
            // a valid configuration
            edition = new Edition()
            {
                PublisherName = "Publisher",
                Year = 1956,
                Number = 3,
                Type = "Hardcover",
                NumberOfPages = 456,
                NumberOfCopies = 20,
                NumberOfLectureRoomCopies = 5,
                Book = new Book()
                {
                    Title = "Then Sings My Soul: 150 of the World's Greatest Hymn Stories",
                    Authors = new List<Author> { new Author { Name = "Robert J. Morgan" } },
                    Domains = new List<Domain> { new Domain { Name = "Painting" } },
                    Editions = new List<Edition> { new Edition { PublisherName = "First Edition", Year = 2006, Number = 1, Type = "Paperback", NumberOfPages = 544, NumberOfCopies = 4, NumberOfLectureRoomCopies = 1 } },
                    Readers = new List<Reader> { new Reader { Name = "Joel", Username = "joey", Password = "pwd", Email = "joel@gmail.com", IsReader = true, IsWorker = false } }
                }
            };
        }

        /// <summary>Tests the edition is valid.</summary>
        [TestMethod]
        public void TestEditionIsValid()
        {
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, validationResults.Count);
        }

        //// ID

        /// <summary>Tests the edition identifier set get.</summary>
        [TestMethod]
        public void TestEditionIdSetGet()
        {
            edition.ID = 1010;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(1010, edition.ID);
        }

        /// <summary>Tests the edition identifier default is zero.</summary>
        [TestMethod]
        public void TestEditionIdDefaultIsZero()
        {
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(0, edition.ID);
        }

        //// BOOK

        /// <summary>Tests the edition book not null.</summary>
        [TestMethod]
        public void TestEditionBookNotNull()
        {
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(null, edition.Book);
        }

        /// <summary>Tests the edition book title not null.</summary>
        [TestMethod]
        public void TestEditionBookTitleNotNull()
        {
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(null, edition.Book.Title);
        }

        /// <summary>Tests the edition book authors not null.</summary>
        [TestMethod]
        public void TestEditionBookAuthorsNotNull()
        {
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(null, edition.Book.Authors);
        }

        /// <summary>Tests the edition book authors null.</summary>
        [TestMethod]
        public void TestEditionBookAuthorsNull()
        {
            edition.Book.Authors = null;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(null, edition.Book.Authors);
        }

        /// <summary>Tests the edition book authors not empty.</summary>
        [TestMethod]
        public void TestEditionBookAuthorsNotEmpty()
        {
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, edition.Book.Authors.Count);
        }

        /// <summary>Tests the edition book authors empty.</summary>
        [TestMethod]
        public void TestEditionBookAuthorsEmpty()
        {
            edition.Book.Authors.Clear();
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, edition.Book.Authors.Count);
        }

        /// <summary>Tests the edition book domains not null.</summary>
        [TestMethod]
        public void TestEditionBookDomainsNotNull()
        {
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(null, edition.Book.Domains);
        }

        /// <summary>Tests the edition book domains null.</summary>
        [TestMethod]
        public void TestEditionBookDomainsNull()
        {
            edition.Book.Domains = null;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(null, edition.Book.Domains);
        }

        /// <summary>Tests the edition book domains not empty.</summary>
        [TestMethod]
        public void TestEditionBookDomainsNotEmpty()
        {
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, edition.Book.Domains.Count);
        }

        /// <summary>Tests the edition book domains empty.</summary>
        [TestMethod]
        public void TestEditionBookDomainsEmpty()
        {
            edition.Book.Domains.Clear();
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, edition.Book.Domains.Count);
        }

        /// <summary>Tests the edition book editions not null.</summary>
        [TestMethod]
        public void TestEditionBookEditionsNotNull()
        {
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(null, edition.Book.Editions);
        }

        /// <summary>Tests the edition book editions null.</summary>
        [TestMethod]
        public void TestEditionBookEditionsNull()
        {
            edition.Book.Editions = null;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(null, edition.Book.Editions);
        }

        /// <summary>Tests the edition book editions not empty.</summary>
        [TestMethod]
        public void TestEditionBookEditionsNotEmpty()
        {
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, edition.Book.Editions.Count);
        }

        /// <summary>Tests the edition book editions empty.</summary>
        [TestMethod]
        public void TestEditionBookEditionsEmpty()
        {
            edition.Book.Editions.Clear();
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, edition.Book.Editions.Count);
        }

        //// PUBLISHER NAME

        /// <summary>Tests the publisher name is null.</summary>
        [TestMethod]
        public void TestPublisherNameIsNull()
        {
            edition.PublisherName = null;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the publisher name is not null.</summary>
        [TestMethod]
        public void TestPublisherNameIsNotNull()
        {
            edition.PublisherName = "Hello";
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the publisher name is empty.</summary>
        [TestMethod]
        public void TestPublisherNameIsEmpty()
        {
            edition.PublisherName = string.Empty;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the publisher name is not empty.</summary>
        [TestMethod]
        public void TestPublisherNameIsNotEmpty()
        {
            edition.PublisherName = "Title";
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the publisher name too short.</summary>
        [TestMethod]
        public void TestPublisherNameTooShort()
        {
            edition.PublisherName = "To";
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the publisher name lower boundary.</summary>
        [TestMethod]
        public void TestPublisherNameLowerBoundary()
        {
            edition.PublisherName = "Dom";
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the publisher name upper boundary.</summary>
        [TestMethod]
        public void TestPublisherNameUpperBoundary()
        {
            edition.PublisherName = new string('a', 70);
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the publisher name too long.</summary>
        [TestMethod]
        public void TestPublisherNameTooLong()
        {
            edition.PublisherName = new string('a', 71);
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// YEAR

        /// <summary>Tests the edition year is zero.</summary>
        [TestMethod]
        public void TestEditionYearIsZero()
        {
            edition.Year = 0;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition year negative.</summary>
        [TestMethod]
        public void TestEditionYearNegative()
        {
            edition.Year = -5;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition year lower boundary.</summary>
        [TestMethod]
        public void TestEditionYearLowerBoundary()
        {
            edition.Year = 1;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition year upper boundary.</summary>
        [TestMethod]
        public void TestEditionYearUpperBoundary()
        {
            edition.Year = 2020;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition year too big.</summary>
        [TestMethod]
        public void TestEditionYearTooBig()
        {
            edition.Year = 2021;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition year too small.</summary>
        [TestMethod]
        public void TestEditionYearTooSmall()
        {
            edition.Year = 0;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// NUMBER

        /// <summary>Tests the edition number is zero.</summary>
        [TestMethod]
        public void TestEditionNumberIsZero()
        {
            edition.Number = 0;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition number negative.</summary>
        [TestMethod]
        public void TestEditionNumberNegative()
        {
            edition.Number = -5;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// TYPE

        /// <summary>Tests the edition type is null.</summary>
        [TestMethod]
        public void TestEditionTypeIsNull()
        {
            edition.Type = null;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition type is not null.</summary>
        [TestMethod]
        public void TestEditionTypeIsNotNull()
        {
            edition.Type = "Hello";
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition type is empty.</summary>
        [TestMethod]
        public void TestEditionTypeIsEmpty()
        {
            edition.Type = string.Empty;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition type is not empty.</summary>
        [TestMethod]
        public void TestEditionTypeIsNotEmpty()
        {
            edition.Type = "Title";
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition type too short.</summary>
        [TestMethod]
        public void TestEditionTypeTooShort()
        {
            edition.Type = "To";
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition type lower boundary.</summary>
        [TestMethod]
        public void TestEditionTypeLowerBoundary()
        {
            edition.Type = "Dom";
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition type upper boundary.</summary>
        [TestMethod]
        public void TestEditionTypeUpperBoundary()
        {
            edition.Type = new string('a', 100);
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition type too long.</summary>
        [TestMethod]
        public void TestEditionTypeTooLong()
        {
            edition.Type = new string('a', 101);
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// NUMBER OF PAGES

        /// <summary>Tests the edition number of pages is zero.</summary>
        [TestMethod]
        public void TestEditionNumberOfPagesIsZero()
        {
            edition.NumberOfPages = 0;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition number negative.</summary>
        [TestMethod]
        public void TestEditionNumberOfPagesNegative()
        {
            edition.NumberOfPages = -5;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// NUMBER OF COPIES

        /// <summary>Tests the edition number of copies is zero.</summary>
        [TestMethod]
        public void TestEditionNumberOfCopiesIsZero()
        {
            edition.NumberOfCopies = 0;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the edition number of copies negative.</summary>
        [TestMethod]
        public void TestEditionNumberOfCopiesNegative()
        {
            edition.NumberOfCopies = -5;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// NUMBER OF LECTURE ROOM COPIES

        /// <summary>Tests the edition number of lecture room copies negative.</summary>
        [TestMethod]
        public void TestEditionNumberOfLectureRoomCopiesNegative()
        {
            edition.NumberOfLectureRoomCopies = -5;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// NUMBER OF COPIES -- NUMBER OF LECTURE ROOM COPIES

        /// <summary>Tests the edition number of lecture room copies bigger than number of copies.</summary>
        [TestMethod]
        public void TestEditionNumberOfLectureRoomCopiesBiggerThanNumberOfCopies()
        {
            edition.NumberOfLectureRoomCopies = 200;
            edition.NumberOfCopies = 100;

            Assert.IsTrue(edition.NumberOfLectureRoomCopies > edition.NumberOfCopies);
        }

        /// <summary>Tests the edition number of lecture room copies equal to number of copies.</summary>
        [TestMethod]
        public void TestEditionNumberOfLectureRoomCopiesEqualToNumberOfCopies()
        {
            edition.NumberOfCopies = edition.NumberOfLectureRoomCopies;
            ValidationResults validationResults = Validation.Validate<Edition>(edition);
            Assert.AreNotEqual(5, validationResults.Count);
        }
    }
}
