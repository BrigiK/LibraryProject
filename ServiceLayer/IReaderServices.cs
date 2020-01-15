//-----------------------------------------------------------------------
// <copyright file="IReaderServices.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace ServiceLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LibraryProject.DomainModel;

    /// <summary>Interface for Reader Services.</summary>
    public interface IReaderServices
    {
        /// <summary>Gets all books.</summary>
        /// <returns>a a</returns>
        IList<Reader> GetAllReaders();

        /// <summary>
        /// Gets the reader by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        Reader GetReaderById(int id);

        /// <summary>
        /// Adds the reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        void AddReader(Reader reader);

        /// <summary>
        /// Deletes the reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        void DeleteReader(Reader reader);

        /// <summary>
        /// Updates the reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        void UpdateReader(Reader reader);

        /// <summary>Borrows the book.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="edition">The edition.</param>
        void BorrowBook(Reader reader, Edition edition);

        /// <summary>Borrows the books.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="editions">The editions.</param>
        void BorrowBooks(Reader reader, List<Edition> editions);

        /// <summary>Determines whether this instance [can borrow book] the specified book.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="edition">The edition.</param>
        /// <returns>
        /// <c>true</c> if this instance [can borrow book] the specified book; otherwise, <c>false</c>.</returns>
        bool CanBorrowBook(Reader reader, Edition edition);

        /// <summary>Gives the back book.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="edition">The edition.</param>
        void GiveBackBook(Reader reader, Edition edition);

        /// <summary>Ten percent more books remaining.</summary>
        /// <param name="edition">The edition.</param>
        /// <returns>a a</returns>
        bool TenPercentMoreBooksRemaining(Edition edition);

        /// <summary>Determines whether [has fewer than NMC books borrowed] [the specified reader].</summary>
        /// <param name="reader">The reader.</param>
        /// <returns>
        /// <c>true</c> if [has fewer than NMC books borrowed] [the specified reader]; otherwise, <c>false</c>.</returns>
        bool HasFewerThanNMCBooksBorrowed(Reader reader);

        /// <summary>Called when [borrow more than three books minimum two different domains].</summary>
        /// <param name="editions">The editions.</param>
        /// <returns>a a</returns>
        bool OnBorrowMoreThanThreeBooksMinTwoDiffDomains(List<Edition> editions);

        /// <summary>Determines whether this instance [can borrow more than d books from same domain] the specified domain.</summary>
        /// <param name="editions">The editions.</param>
        /// <returns>
        /// <c>true</c> if this instance [can borrow more than d books from same domain] the specified domain; otherwise, <c>false</c>.</returns>
        bool MoreThanDBooksFromSameDomain(List<Edition> editions);
    }
}
