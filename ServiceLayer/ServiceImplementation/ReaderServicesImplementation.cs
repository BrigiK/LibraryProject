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
        /// <returns>a a</returns>
        public bool AddReader(Reader reader)
        {
            if (!reader.Name.Equals(string.Empty) &&
                !reader.Username.Equals(string.Empty) &&
                !reader.Password.Equals(string.Empty) &&
                !reader.Email.Equals(string.Empty))
            {
                this.readerDataService.AddReader(reader);
                return true;
            }

            return false;
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

        /// <summary>Gives the back book.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="edition">The edition.</param>
        public void GiveBackBook(Reader reader, Edition edition)
        {
            this.readerDataService.GiveBackBook(reader, edition);
        }
    }
}
