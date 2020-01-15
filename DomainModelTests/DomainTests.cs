//-----------------------------------------------------------------------
// <copyright file="DomainTests.cs" company="Transilvania University of Brasov">
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
    /// Domain Tests class.
    /// </summary>
    [TestClass]
    public class DomainTests
    {
        /// <summary>The domain</summary>
        private Domain domain = null;

        /// <summary>Sets up.</summary>
        [TestInitialize]
        public void SetUp()
        {
            // a valid configuration
            domain = new Domain()
            {
                Name = "Science",
                Books = new List<Book>
                {
                    new Book()
                    {
                        Title = "Then Sings My Soul: 150 of the World's Greatest Hymn Stories",
                        Authors = new List<Author> { new Author { Name = "Robert J. Morgan" } },
                        Domains = new List<Domain> { new Domain { Name = "Painting" } },
                        Editions = new List<Edition> { new Edition { PublisherName = "First Edition", Year = 2006, Number = 1, Type = "Paperback", NumberOfPages = 544, NumberOfCopies = 4, NumberOfLectureRoomCopies = 1 } },
                        Readers = new List<Reader> { new Reader { Name = "Joel", Username = "joey", Password = "pwd", Email = "joel@gmail.com", IsReader = true, IsWorker = false } }
                    }
                }
            };
        }

        /// <summary>Tests the domain is valid.</summary>
        [TestMethod]
        public void TestDomainIsValid()
        {
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreEqual(0, validationResults.Count);
        }

        //// ID

        /// <summary>Tests the domain identifier set get.</summary>
        [TestMethod]
        public void TestDomainIdSetGet()
        {
            domain.ID = 1010;
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(1010, domain.ID);
        }

        /// <summary>Tests the domain identifier default is zero.</summary>
        [TestMethod]
        public void TestDomainIdDefaultIsZero()
        {
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(0, domain.ID);
        }

        //// NAME

        /// <summary>Tests the domain name is null.</summary>
        [TestMethod]
        public void TestDomainNameIsNull()
        {
            domain.Name = null;
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the domain name is not null.</summary>
        [TestMethod]
        public void TestDomainNameIsNotNull()
        {
            domain.Name = "Hello";
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the domain name is empty.</summary>
        [TestMethod]
        public void TestDomainNameIsEmpty()
        {
            domain.Name = string.Empty;
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the domain name is not empty.</summary>
        [TestMethod]
        public void TestDomainNameIsNotEmpty()
        {
            domain.Name = "Title";
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the domain name too short.</summary>
        [TestMethod]
        public void TestDomainNameTooShort()
        {
            domain.Name = "To";
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the book title lower boundary.</summary>
        [TestMethod]
        public void TestBookTitleLowerBoundary()
        {
            domain.Name = "Dom";
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the domain name upper boundary.</summary>
        [TestMethod]
        public void TestDomainNameUpperBoundary()
        {
            domain.Name = new string('a', 30);
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the domain name too long.</summary>
        [TestMethod]
        public void TestDomainNameTooLong()
        {
            domain.Name = new string('a', 31);
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// PARENTDOMAIN

        /// <summary>Tests the parent domain not self.</summary>
        [TestMethod]
        public void TestParentDomainNotSelf()
        {
            domain.ParentDomain = new Domain { Name = "not" };
            Assert.AreNotEqual(domain, domain.ParentDomain);
        }

        /// <summary>Tests the parent domain self.</summary>
        [TestMethod]
        public void TestParentDomainSelf()
        {
            domain.ParentDomain = new Domain { Name = "Science" };
            Assert.AreNotEqual(domain, domain.ParentDomain);
        }

        /// <summary>Tests the parent domain not null.</summary>
        [TestMethod]
        public void TestParentDomainNotNull()
        {
            domain.ParentDomain = new Domain { Name = "Math" };
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreNotEqual(null, domain.ParentDomain);
        }

        //// BOOKS

        /// <summary>Tests the domain books not null.</summary>
        [TestMethod]
        public void TestDomainBooksNotNull()
        {
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreNotEqual(null, domain.Books);
        }

        /// <summary>Tests the domain books empty.</summary>
        [TestMethod]
        public void TestDomainBooksEmpty()
        {
            domain.Books = new List<Book>();
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreEqual(0, domain.Books.Count);
        }

        /// <summary>Tests the domain books null.</summary>
        [TestMethod]
        public void TestDomainBooksNull()
        {
            domain.Books = null;
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreEqual(null, domain.Books);
        }

        /// <summary>Tests the domain books not empty.</summary>
        [TestMethod]
        public void TestDomainBooksNotEmpty()
        {
            ValidationResults validationResults = Validation.Validate<Domain>(domain);
            Assert.AreNotEqual(0, domain.Books.Count);
        }
    }
}
