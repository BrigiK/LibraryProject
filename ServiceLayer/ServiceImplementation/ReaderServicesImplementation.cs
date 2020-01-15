//-----------------------------------------------------------------------
// <copyright file="ReaderServicesImplementation.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace ServiceLayer.ServiceImplementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LibraryProject.DataLayer.DataMapper;
    using LibraryProject.DomainModel;

    /// <summary>Reader Services Implementation.</summary>
    public class ReaderServicesImplementation : IReaderServices
    {
        /// <summary>The reader data service</summary>
        private IReaderDataService readerDataService;

        /// <summary>Initializes a new instance of the <see cref="ReaderServicesImplementation"/> class.</summary>
        /// <param name="readerDataService">The reader data service.</param>
        public ReaderServicesImplementation(IReaderDataService readerDataService = null)
        {
            if (readerDataService == null)
            {
                readerDataService = DAOFactoryMethod.CurrentDAOFactory.ReaderDataService;
            }

            this.readerDataService = readerDataService;
        }

        /// <summary>Adds the reader.</summary>
        /// <param name="reader">The reader.</param>
        public void AddReader(Reader reader)
        {
            if (!reader.Name.Equals(string.Empty) &&
                !reader.Username.Equals(string.Empty) &&
                !reader.Password.Equals(string.Empty) &&
                !reader.Email.Equals(string.Empty))
            {
                this.readerDataService.AddReader(reader);
            }
        }

        /// <summary>Deletes the reader.</summary>
        /// <param name="reader">The reader.</param>
        public void DeleteReader(Reader reader)
        {
            this.readerDataService.DeleteReader(reader);
        }

        /// <summary>Gets all books.</summary>
        /// <returns>a a</returns>
        public IList<Reader> GetAllReaders()
        {
            return this.readerDataService.GetAllReaders();
        }

        /// <summary>Gets the reader by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        public Reader GetReaderById(int id)
        {
            return this.readerDataService.GetReaderById(id);
        }

        /// <summary>Updates the reader.</summary>
        /// <param name="reader">The reader.</param>
        public void UpdateReader(Reader reader)
        {
            this.readerDataService.UpdateReader(reader);
        }

        /// <summary>Borrows the book.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="edition">The edition.</param>
        public void BorrowBook(Reader reader, Edition edition)
        {
            this.readerDataService.BorrowBook(reader, edition);
        }

        /// <summary>Borrows the books.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="editions">The editions.</param>
        public void BorrowBooks(Reader reader, List<Edition> editions)
        {
            this.readerDataService.BorrowBooks(reader, editions);
        }

        /// <summary>Determines whether this instance [can borrow book] the specified book.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="edition">The edition.</param>
        /// <returns>
        /// <c>true</c> if this instance [can borrow book] the specified book; otherwise, <c>false</c>.</returns>
        public bool CanBorrowBook(Reader reader, Edition edition)
        {
            return this.readerDataService.CanBorrowBook(reader, edition);
        }

        /// <summary>Gives the back book.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="edition">The edition.</param>
        public void GiveBackBook(Reader reader, Edition edition)
        {
            this.readerDataService.GiveBackBook(reader, edition);
        }

        /// <summary>Ten percent more books remaining.</summary>
        /// <param name="edition">The edition.</param>
        /// <returns>a a</returns>
        public bool TenPercentMoreBooksRemaining(Edition edition)
        {
            return this.readerDataService.TenPercentMoreBooksRemaining(edition);
        }

        /// <summary>Determines whether [has fewer than NMC books borrowed] [the specified reader].</summary>
        /// <param name="reader">The reader.</param>
        /// <returns>
        /// <c>true</c> if [has fewer than NMC books borrowed] [the specified reader]; otherwise, <c>false</c>.</returns>
        public bool HasFewerThanNMCBooksBorrowed(Reader reader)
        {
            return this.readerDataService.HasFewerThanNMCBooksBorrowed(reader);
        }

        /// <summary>Called when [borrow more than three books minimum two different domains].</summary>
        /// <param name="editions">The editions.</param>
        /// <returns>a a</returns>
        public bool OnBorrowMoreThanThreeBooksMinTwoDiffDomains(List<Edition> editions)
        {
            return this.readerDataService.OnBorrowMoreThanThreeBooksMinTwoDiffDomains(editions);
        }

        /// <summary>Determines whether this instance [can borrow more than d books from same domain] the specified domain.</summary>
        /// <param name="editions">The editions.</param>
        /// <returns>
        /// <c>true</c> if this instance [can borrow more than d books from same domain] the specified domain; otherwise, <c>false</c>.</returns>
        public bool MoreThanDBooksFromSameDomain(List<Edition> editions)
        {
            return this.readerDataService.MoreThanDBooksFromSameDomain(editions);
        }
    }
}
