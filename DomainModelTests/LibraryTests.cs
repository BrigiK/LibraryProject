//-----------------------------------------------------------------------
// <copyright file="LibraryTests.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LibraryProject.DataMapper;
    using LibraryProject.DomainModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>Test class for LibraryProject.</summary>
    [TestClass]
    public class LibraryTests
    {
        /// <summary>Tests if author inserted in database.</summary>
        [TestMethod]
        public void TestIfAuthorInsertedInDb()
        {
            Author author, testedAuthor;
            using (var context = new LibraryContext())
            {
                author = new Author
                {
                    Name = "Jimmy Hen"
                };

                context.Authors.Add(author);
                context.SaveChanges();
            }

            using (var context = new LibraryContext())
            {
                testedAuthor = (from auth in context.Authors
                                where auth.Name == author.Name
                                select auth).Single();
            }

            Assert.AreEqual(testedAuthor.Name, author.Name);
        }

        /// <summary>Tests if configuration name correct.</summary>
        [TestMethod]
        public void TestIfConfigNameCorrect()
        {
            Configuration config;

            using (var context = new LibraryContext())
            {
                config = (from p in context.Configurations
                                where p.Name == "MaxDOMBook"
                                select p).Single();
            }

            Assert.AreEqual("MaxDOMBook", config.Name);
        }

        /// <summary>Tests the add empty author list to book.</summary>
        [TestMethod]
        [ExpectedException(typeof(System.Data.Entity.Validation.DbEntityValidationException), "Trying to add empty author list to book.")]
        public void TestAddEmptyAuthorListToBook()
        {
            Book book;

            using (var context = new LibraryContext())
            {
                book = new Book
                {
                    Title = "A book",
                    Authors = new List<Author>()
                };

                context.Books.Add(book);
                context.SaveChanges();
            }
        }
    }
}
