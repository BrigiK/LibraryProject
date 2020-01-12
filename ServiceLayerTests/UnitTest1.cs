//-----------------------------------------------------------------------
// <copyright file="UnitTest1.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace ServiceLayerTests
{
    using System;
    using System.Collections.Generic;
    using LibraryProject.DomainModel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using ServiceLayer;
    using ServiceLayer.ServiceImplementation;

    /// <summary>Unit tests.</summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>Tests the get child domains.</summary>
        [TestMethod]
        public void TestGetChildDomains()
        {
            IDomainServices dsi = new DomainServicesImplementation();
            Domain dom = dsi.GetDomainByName("Science & Math");

            List<Domain> expectedChilds = new List<Domain>
            {
                new Domain { Name = "Anatomy" },
                new Domain { Name = "Biology" },
                new Domain { Name = "Chemistry" },
                new Domain { Name = "Mathematics" },
                new Domain { Name = "Engineering" },
                new Domain { Name = "Statistics" }
            };

            List<Domain> actual = (List<Domain>)dsi.GetChildDomains(dom);

            for (int i = 0; i < actual.Count; i++)
            {
                if (!actual[i].Name.Equals(expectedChilds[i].Name))
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>Tests the book domain not contains parent domain.</summary>
        [TestMethod]
        public void TestBookDomainNotContainsParentDomain()
        {
            IBookServices bsi = new BookServicesImplementation();
            IDomainServices dsi = new DomainServicesImplementation();

            Book book = new Book
            {
                Title = "Tiitle",
                Domains = new List<Domain>
                {
                    dsi.GetDomainByName("Computer Science"),
                    dsi.GetDomainByName("Databases"),
                    dsi.GetDomainByName("Computers & Tech")
                }
            };

            bool flag = bsi.BookDomainContainsParentDomain(book);

            Assert.IsTrue(flag);
        }

        /// <summary>Tests the book domain contains parent domain.</summary>
        [TestMethod]
        public void TestBookDomainContainsParentDomain()
        {
            IBookServices bsi = new BookServicesImplementation();
            IDomainServices dsi = new DomainServicesImplementation();

            Book book = new Book
            {
                Title = "Tiitlee",
                Domains = new List<Domain>
                {
                    dsi.GetDomainByName("Computer Science"),
                    dsi.GetDomainByName("Databases")
                }
            };

            bool flag = bsi.BookDomainContainsParentDomain(book);

            Assert.IsFalse(flag);
        }

        /// <summary>Tests the book has more than DOM domains.</summary>
        [TestMethod]
        public void TestBookHasMoreThanDOMDomains()
        {
            IBookServices bsi = new BookServicesImplementation();

            Book book = new Book
            {
                Title = "gbujyhgb",
                Domains = new List<Domain>
                {
                    new Domain { Name = "Arts & Music" },
                    new Domain { Name = "Business" },
                    new Domain { Name = "Kids" },
                    new Domain { Name = "Computers & Tech" },
                    new Domain { Name = "Cooking" },
                    new Domain { Name = "Science & Math" },
                }
            };

            bool flag = bsi.BookHasOnlyDOMDomains(book);

            Assert.IsFalse(flag);
        }

        /// <summary>Tests the book has only DOM domains.</summary>
        [TestMethod]
        public void TestBookHasOnlyDOMDomains()
        {
            IBookServices bsi = new BookServicesImplementation();

            Book book = new Book
            {
                Title = "gbujyhgb",
                Domains = new List<Domain>
                {
                    new Domain { Name = "Arts & Music" },
                    new Domain { Name = "Business" },
                    new Domain { Name = "Kids" }
                }
            };

            bool flag = bsi.BookHasOnlyDOMDomains(book);

            Assert.IsTrue(flag);
        }

        /// <summary>Tests the book has less than DOM domains.</summary>
        [TestMethod]
        public void TestBookHasLessThanDOMDomains()
        {
            IBookServices bsi = new BookServicesImplementation();

            Book book = new Book
            {
                Title = "gbujyhgb",
                Domains = new List<Domain>
                {
                    new Domain { Name = "Arts & Music" },
                    new Domain { Name = "Business" }
                }
            };

            bool flag = bsi.BookHasOnlyDOMDomains(book);

            Assert.IsTrue(flag);
        }

        /// <summary>Tests the get books from null domain.</summary>
        [TestMethod]
        public void TestGetBooksFromNullDomain()
        {
            IBookServices bsi = new BookServicesImplementation();
            var books = bsi.GetBooksFromDomain(null);

            Assert.AreEqual(0, books.Count);
        }

        /// <summary>Tests the get books from exact domain.</summary>
        [TestMethod]
        public void TestGetBooksFromExactDomain()
        {
            IBookServices bsi = new BookServicesImplementation();
            IDomainServices dsi = new DomainServicesImplementation();

            var domain = dsi.GetDomainByName("Animals");
            var books = bsi.GetBooksFromDomain(domain);

            Assert.AreEqual(1, books.Count);
        }

        /// <summary>Tests the get books from parent domain.</summary>
        [TestMethod]
        public void TestGetBooksFromParentDomain()
        {
            IBookServices bsi = new BookServicesImplementation();
            IDomainServices dsi = new DomainServicesImplementation();

            var domain = dsi.GetDomainByName("Kids");
            var books = bsi.GetBooksFromDomain(domain);

            Assert.AreEqual(1, books.Count);
        }
    }
}
