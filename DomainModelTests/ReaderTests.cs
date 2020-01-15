//-----------------------------------------------------------------------
// <copyright file="ReaderTests.cs" company="Transilvania University of Brasov">
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
    /// Reader Tests class.
    /// </summary>
    [TestClass]
    public class ReaderTests
    {
        /// <summary>The reader</summary>
        private Reader reader = null;

        /// <summary>Sets up.</summary>
        [TestInitialize]
        public void SetUp()
        {
            // a valid reader
            reader = new Reader()
            {
                Name = "Joel Northon",
                Username = "joey",
                Email = "joey_n@gmail.com",
                Password = "Pp*4hytgff",
                IsReader = true,
                IsWorker = false,
                Books = new List<Book>
                {
                    new Book()
                    {
                        Title = "Then Sings My Soul: 150 of the World's Greatest Hymn Stories",
                        Authors = new List<Author> { new Author { Name = "Robert J. Morgan" } },
                        Domains = new List<Domain> { new Domain { Name = "Music" } },
                        Editions = new List<Edition> { new Edition { PublisherName = "First Edition", Year = 2006, Number = 1, Type = "Paperback", NumberOfPages = 544, NumberOfCopies = 4, NumberOfLectureRoomCopies = 1 } },
                        Readers = new List<Reader> { new Reader { Name = "Joel", Username = "joey", Password = "pwd", Email = "joel@gmail.com", IsReader = true, IsWorker = false } }
                    }
                }
            };
        }

        /// <summary>Tests the reader is valid.</summary>
        [TestMethod]
        public void TestReaderIsValid()
        {
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
        }

        //// ID

        /// <summary>Tests the reader identifier set get.</summary>
        [TestMethod]
        public void TestReaderIdSetGet()
        {
            reader.ID = 1010;
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(1010, reader.ID);
        }

        /// <summary>Tests the reader identifier default is zero.</summary>
        [TestMethod]
        public void TestReaderIdDefaultIsZero()
        {
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual(0, reader.ID);
        }

        //// NAME

        /// <summary>Tests the reader name is null.</summary>
        [TestMethod]
        public void TestReaderNameIsNull()
        {
            reader.Name = null;
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader name is not null.</summary>
        [TestMethod]
        public void TestReaderNameIsNotNull()
        {
            reader.Name = "Helloooo";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader name is empty.</summary>
        [TestMethod]
        public void TestReaderNameIsEmpty()
        {
            reader.Name = string.Empty;
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader name is not empty.</summary>
        [TestMethod]
        public void TestReaderNameIsNotEmpty()
        {
            reader.Name = "ThisIsAName";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader name too short.</summary>
        [TestMethod]
        public void TestReaderNameTooShort()
        {
            reader.Name = "Tony";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader name lower boundary.</summary>
        [TestMethod]
        public void TestReaderNameLowerBoundary()
        {
            reader.Name = "Jo Hen";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader name upper boundary.</summary>
        [TestMethod]
        public void TestReaderNameUpperBoundary()
        {
            reader.Name = new string('a', 60);
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader name too long.</summary>
        [TestMethod]
        public void TestReaderNameTooLong()
        {
            reader.Name = new string('a', 61);
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// EMAIL

        /// <summary>Tests the reader email is null.</summary>
        [TestMethod]
        public void TestReaderEmailIsNull()
        {
            reader.Email = null;
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader email is empty.</summary>
        [TestMethod]
        public void TestReaderEmailIsEmpty()
        {
            reader.Email = string.Empty;
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader email has no host.</summary>
        [TestMethod]
        public void TestReaderEmailHasNoHost()
        {
            reader.Email = "jo.eng.com";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader email has no domain.</summary>
        [TestMethod]
        public void TestReaderEmailHasNoDomain()
        {
            reader.Email = "@gmail.com";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader email has no end.</summary>
        [TestMethod]
        public void TestReaderEmailHasNoEnd()
        {
            reader.Email = "jo.eng@gmail";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// USERNAME

        /// <summary>Tests the reader username is null.</summary>
        [TestMethod]
        public void TestReaderUsernameIsNull()
        {
            reader.Username = null;
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader username is not null.</summary>
        [TestMethod]
        public void TestReaderUsernameIsNotNull()
        {
            reader.Username = "johnnyh";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader username is empty.</summary>
        [TestMethod]
        public void TestReaderUsernameIsEmpty()
        {
            reader.Username = string.Empty;
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader username is not empty.</summary>
        [TestMethod]
        public void TestReaderUsernameIsNotEmpty()
        {
            reader.Username = "ThisIsAUName";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader username too short.</summary>
        [TestMethod]
        public void TestReaderUsernameTooShort()
        {
            reader.Username = "To";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader username lower boundary.</summary>
        [TestMethod]
        public void TestReaderUsernameLowerBoundary()
        {
            reader.Username = "JoH";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader username upper boundary.</summary>
        [TestMethod]
        public void TestReaderUsernameUpperBoundary()
        {
            reader.Username = new string('a', 30);
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader username too long.</summary>
        [TestMethod]
        public void TestReaderUsernameTooLong()
        {
            reader.Username = new string('a', 31);
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// PASSWORD

        /// <summary>Tests the reader password is null.</summary>
        [TestMethod]
        public void TestReaderPasswordIsNull()
        {
            reader.Password = null;
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password is not null.</summary>
        [TestMethod]
        public void TestReaderPasswordIsNotNull()
        {
            reader.Password = "Pp*4hytgff";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password is empty.</summary>
        [TestMethod]
        public void TestReaderPasswordIsEmpty()
        {
            reader.Password = string.Empty;
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password is not empty.</summary>
        [TestMethod]
        public void TestReaderPasswordIsNotEmpty()
        {
            reader.Password = "Pp*4hytgff";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password too short.</summary>
        [TestMethod]
        public void TestReaderPasswordTooShort()
        {
            reader.Password = "Pp*4h";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password lower boundary.</summary>
        [TestMethod]
        public void TestReaderPasswordLowerBoundary()
        {
            reader.Password = "Pp*4hytg";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password upper boundary.</summary>
        [TestMethod]
        public void TestReaderPasswordUpperBoundary()
        {
            reader.Password = "Pp*4kljkijuyhgtfrdewsxcvfgbhnk";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password too long.</summary>
        [TestMethod]
        public void TestReaderPasswordTooLong()
        {
            reader.Password = "Pp*4hhhhhhhhhhhhhhhhhhhhhhhhhhf";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password not contains lowercase letter.</summary>
        [TestMethod]
        public void TestReaderPasswordNotContainsLowercaseLetter()
        {
            reader.Password = "PPPP4*JJK";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password not contains lowercase and uppercase letter.</summary>
        [TestMethod]
        public void TestReaderPasswordNotContainsLowercaseAndUppercaseLetter()
        {
            reader.Password = "4*44444444";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password not contains lowercase and uppercase letter and number.</summary>
        [TestMethod]
        public void TestReaderPasswordNotContainsLowercaseAndUppercaseLetterAndNumber()
        {
            reader.Password = "**********";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password not contains lowercase and uppercase letter and special character.</summary>
        [TestMethod]
        public void TestReaderPasswordNotContainsLowercaseAndUppercaseLetterAndSpecialChar()
        {
            reader.Password = "654516546416541";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password not contains number.</summary>
        [TestMethod]
        public void TestReaderPasswordNotContainsNumber()
        {
            reader.Password = "jvdbA*vdjkf";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password not contains number and uppercase.</summary>
        [TestMethod]
        public void TestReaderPasswordNotContainsNumberAndUppercase()
        {
            reader.Password = "jvdb*vdjkf";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password not contains number and lowercase.</summary>
        [TestMethod]
        public void TestReaderPasswordNotContainsNumberAndLowercase()
        {
            reader.Password = "DB*BGDBNJB";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password not contains uppercase.</summary>
        [TestMethod]
        public void TestReaderPasswordNotContainsUppercase()
        {
            reader.Password = "vjrhbv45*";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password not contains uppercase and special character.</summary>
        [TestMethod]
        public void TestReaderPasswordNotContainsUppercaseAndSpecialChar()
        {
            reader.Password = "bbrgrg54165";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password not contains lowercase and special character.</summary>
        [TestMethod]
        public void TestReaderPasswordNotContainsLowercaseAndSpecialChar()
        {
            reader.Password = "JHGBGVYGH54165";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password not contains number and special character.</summary>
        [TestMethod]
        public void TestReaderPasswordNotContainsNumberAndSpecialChar()
        {
            reader.Password = "JHGBGVYGHdvbrfg";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the reader password not contains special character.</summary>
        [TestMethod]
        public void TestReaderPasswordNotContainsSpecialChar()
        {
            reader.Password = "JHGBGVYGH54165veds";
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// IS WORKER

        /// <summary>Tests the reader is worker.</summary>
        [TestMethod]
        public void TestReaderIsWorker()
        {
            reader.IsWorker = true;
            Assert.IsTrue(reader.IsWorker);
        }

        /// <summary>Tests the reader is not worker.</summary>
        [TestMethod]
        public void TestReaderIsNotWorker()
        {
            reader.IsWorker = false;
            Assert.IsFalse(reader.IsWorker);
        }

        //// IS READER

        /// <summary>Tests the reader is reader.</summary>
        [TestMethod]
        public void TestReaderIsReader()
        {
            reader.IsReader = true;
            Assert.IsTrue(reader.IsReader);
        }

        /// <summary>Tests the reader is not reader.</summary>
        [TestMethod]
        public void TestReaderIsNotReader()
        {
            reader.IsReader = false;
            Assert.IsFalse(reader.IsReader);
        }

        //// BOOKS

        /// <summary>Tests the reader books not null.</summary>
        [TestMethod]
        public void TestReaderBooksNotNull()
        {
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(null, reader.Books);
        }

        /// <summary>Tests the reader books empty.</summary>
        [TestMethod]
        public void TestReaderBooksEmpty()
        {
            reader.Books = new List<Book>();
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(0, reader.Books.Count);
        }

        /// <summary>Tests the reader books null.</summary>
        [TestMethod]
        public void TestReaderBooksNull()
        {
            reader.Books = null;
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreEqual(null, reader.Books);
        }

        /// <summary>Tests the reader books not empty.</summary>
        [TestMethod]
        public void TestReaderBooksNotEmpty()
        {
            ValidationResults validationResults = Validation.Validate<Reader>(reader);
            Assert.AreNotEqual(0, reader.Books.Count);
        }
    }
}
