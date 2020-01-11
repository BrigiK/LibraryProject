//-----------------------------------------------------------------------
// <copyright file="LibraryTests.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryTest
{
    using System;
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
    }
}
