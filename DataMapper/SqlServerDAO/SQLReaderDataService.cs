//-----------------------------------------------------------------------
// <copyright file="SQLReaderDataService.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryProject.DataLayer.DataMapper.SqlServerDAO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LibraryProject.DataMapper;
    using LibraryProject.DomainModel;
    using log4net;

    /// <summary>SQL Reader Data Service.</summary>
    public class SQLReaderDataService : IReaderDataService
    {
        /// <summary>The logger instance.</summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(SQLReaderDataService));

        /// <summary>The hundred percent.</summary>
        private static readonly int HUNDREDPERCENT = 100;

        /// <summary>The ten percent</summary>
        private static readonly int TENPERCENT = 10;

        /// <summary>Adds the reader.</summary>
        /// <param name="reader">The reader.</param>
        public void AddReader(Reader reader)
        {
            Log.Info("Add new reader " + reader.Name);
            using (var context = new LibraryContext())
            {
                context.Readers.Add(reader);
                context.SaveChanges();
            }

            Log.Info("New reader successfully added.");
        }

        /// <summary>Deletes the reader.</summary>
        /// <param name="reader">The reader.</param>
        public void DeleteReader(Reader reader)
        {
            Log.Info("Delete reader " + reader.Name);
            using (var context = new LibraryContext())
            {
                var newReader = new Reader { ID = reader.ID };
                context.Readers.Attach(newReader);
                context.Readers.Remove(newReader);
                context.SaveChanges();
            }

            Log.Info("Reader" + reader.Name + " successfully deleted.");
        }

        /// <summary>Gets all books.</summary>
        /// <returns>a a</returns>
        public IList<Reader> GetAllReaders()
        {
            Log.Info("Getting all readers.");
            using (var context = new LibraryContext())
            {
                return context.Readers.Select(reader => reader).ToList();
            }
        }

        /// <summary>Gets the reader by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>a a</returns>
        public Reader GetReaderById(int id)
        {
            Log.Info("Getting reader by id.");
            using (var context = new LibraryContext())
            {
                return context.Readers.Where(reader => reader.ID == id).SingleOrDefault();
            }
        }

        /// <summary>Updates the reader.</summary>
        /// <param name="reader">The reader.</param>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">e e</exception>
        public void UpdateReader(Reader reader)
        {
            Log.Info("Updating reader " + reader.Name);
            using (var context = new LibraryContext())
            {
                Reader readerRef = context.Readers.Where(r => r.ID == reader.ID).SingleOrDefault();
                if (readerRef != null)
                {
                    readerRef = reader;
                    context.SaveChanges();
                }
                else
                {
                    throw new KeyNotFoundException();
                }
            }

            Log.Info("Reader successfully updated.");
        }

        /// <summary>Ten percent more books remaining.</summary>
        /// <param name="edition">The edition.</param>
        /// <returns>a a</returns>
        public bool TenPercentMoreBooksRemaining(Edition edition)
        {
            Log.Info("Checking if ten percent more books remaining than the initial number of books");
            using (var context = new LibraryContext())
            {
                Edition editionToBeBorrowed = context.Editions.Where(e => e.ID == edition.ID).SingleOrDefault();

                int tenPercentOfInitialBookNumber = (editionToBeBorrowed.NumberOfCopies * TENPERCENT) / HUNDREDPERCENT;

                if (editionToBeBorrowed.NumberOfCopies > tenPercentOfInitialBookNumber)
                {
                    Log.Info("There are ten percent more books remaining than the initial number of books");
                    return true;
                }
            }

            Log.Info("There are less than ten percent more books remaining than the initial number of books");
            return false;
        }

        /// <summary>Determines whether [has fewer than NMC books borrowed] [the specified reader].</summary>
        /// <param name="reader">The reader.</param>
        /// <returns>
        /// <c>true</c> if [has fewer than NMC books borrowed] [the specified reader]; otherwise, <c>false</c>.</returns>
        public bool HasFewerThanNMCBooksBorrowed(Reader reader)
        {
            Log.Info("Checking if reader has fewer thank NMC books borrowed at the moment.");
            IConfigurationDataService cds = new SQLConfigurationDataService();

            using (var context = new LibraryContext())
            {
                Reader currentReader = context.Readers.Where(r => r.ID == reader.ID).SingleOrDefault();

                if (currentReader.Books.Count < cds.GetConfiguration("NrMaxBooksBorrowed").Value)
                {
                    Log.Info("Reader has fewer thank NMC books borrowed at the moment.");
                    return true;
                }
            }

            Log.Info("Reader has more thank NMC books borrowed at the moment.");
            return false;
        }

        /// <summary>Borrows the book.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="edition">The edition.</param>
        public void BorrowBook(Reader reader, Edition edition)
        {
            Log.Info("Reader " + reader.Name + " borrowing book " + edition.Book.Title);
            using (var context = new LibraryContext())
            {
                Edition editionToBeBorrowed = context.Editions.Where(e => e.ID == edition.ID).SingleOrDefault();
                Reader currentReader = context.Readers.Where(r => r.ID == reader.ID).SingleOrDefault();

                if (this.CanBorrowBook(currentReader, editionToBeBorrowed))
                {
                    currentReader.Books.Add(editionToBeBorrowed.Book);
                    editionToBeBorrowed.NumberOfCopies -= 1;
                    context.SaveChanges();
                }
            }

            Log.Info("Reader " + reader.Name + " successfully borrowed book " + edition.Book.Title);
        }

        /// <summary>Borrows the books.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="editions">The editions.</param>
        public void BorrowBooks(Reader reader, List<Edition> editions)
        {
            Log.Info("Reader " + reader.Name + " borrowing books");

            IConfigurationDataService cds = new SQLConfigurationDataService();

            using (var context = new LibraryContext())
            {
                if (editions.Count <= cds.GetConfiguration("MaxBooksOneBorrow").Value &&
                    (editions.Count <= 3 || this.OnBorrowMoreThanThreeBooksMinTwoDiffDomains(editions)) &&
                    this.MoreThanDBooksFromSameDomain(editions))
                {
                    foreach (Edition ed in editions)
                    {
                        this.BorrowBook(reader, ed);
                    }
                }
            }

            Log.Info("Reader " + reader.Name + " successfully borrowed books");
        }

        /// <summary>Determines whether this instance [can borrow book] the specified book.</summary>
        /// <param name="reader">The reader</param>
        /// <param name="edition">The edition.</param>
        /// <returns>
        /// <c>true</c> if this instance [can borrow book] the specified book; otherwise, <c>false</c>.</returns>
        public bool CanBorrowBook(Reader reader, Edition edition)
        {
            Log.Info("Checking if reader " + reader.Name + " can borrow " + edition.Book.Title);
            using (var context = new LibraryContext())
            {
                Edition editionToBeBorrowed = context.Editions.Where(e => e.ID == edition.ID).SingleOrDefault();
                Reader currentReader = context.Readers.Where(r => r.ID == reader.ID).SingleOrDefault();

                if (editionToBeBorrowed.NumberOfCopies > 0 &&
                   editionToBeBorrowed.NumberOfCopies > editionToBeBorrowed.NumberOfLectureRoomCopies &&
                   this.TenPercentMoreBooksRemaining(editionToBeBorrowed) &&
                   this.HasFewerThanNMCBooksBorrowed(currentReader))
                {
                    Log.Info("Reader " + reader.Name + " can borrow " + edition.Book.Title);
                    return true;
                }
            }

            Log.Info("Reader " + reader.Name + " can not borrow " + edition.Book.Title);
            return false;
        }

        /// <summary>Gives the back book.</summary>
        /// <param name="reader">The reader.</param>
        /// <param name="edition">The edition.</param>
        public void GiveBackBook(Reader reader, Edition edition)
        {
            Log.Info("Reader " + reader.Name + " giving back book " + edition.Book.Title);
            using (var context = new LibraryContext())
            {
                Edition editionToGiveBack = context.Editions.Where(e => e.ID == edition.ID).SingleOrDefault();
                Reader currentReader = context.Readers.Where(r => r.ID == reader.ID).SingleOrDefault();

                editionToGiveBack.NumberOfCopies++;
                var searchedBook = currentReader.Books.Where(b => b.ID == edition.Book.ID).FirstOrDefault();

                if (searchedBook != null)
                {
                    currentReader.Books.Remove(searchedBook);
                }
            }

            Log.Info("Reader " + reader.Name + " successfully gave back book " + edition.Book.Title);
        }

        /// <summary>Called when [borrow more than three books minimum two different domains].</summary>
        /// <param name="editions">The editions.</param>
        /// <returns>a a</returns>
        public bool OnBorrowMoreThanThreeBooksMinTwoDiffDomains(List<Edition> editions)
        {
            Log.Info("Checking if reader borrows more than three books, there must be books from at least two different domains.");
            if (editions.Count < 3)
            {
                return false;
            }

            ISet<int> ids = new HashSet<int>();

            using (var context = new LibraryContext())
            {
                foreach (Edition ed in editions)
                {
                    Edition currentEdition = context.Editions.Where(e => e.ID == ed.ID).Single();

                    foreach (Domain dom in currentEdition.Book.Domains)
                    {
                        ids.Add(dom.ID);
                    }
                }
            }

            if (ids.Count >= 2)
            {
                Log.Info("There are at least two different domains");
                return true;
            }

            Log.Info("There are not at least two different domains");
            return false;
        }

        /// <summary>Determines whether this instance [can borrow more than d books from same domain] the specified domain.</summary>
        /// <param name="editions">The editions.</param>
        /// <returns>
        /// <c>true</c> if this instance [can borrow more than d books from same domain] the specified domain; otherwise, <c>false</c>.</returns>
        public bool MoreThanDBooksFromSameDomain(List<Edition> editions)
        {
            Log.Info("Checking if the books the reader tries to borrow are from the same domain.");
            IDomainDataService dds = new SQLDomainDataService();
            IConfigurationDataService cds = new SQLConfigurationDataService();
            
            IDictionary<int, int> domainApparitions = new Dictionary<int, int>();

            using (var context = new LibraryContext())
            {
                foreach (Edition ed in editions)
                {
                    Edition currentEdition = context.Editions.Where(e => e.ID == ed.ID).Single();

                    foreach (Domain dom in currentEdition.Book.Domains)
                    {
                        var id = dds.GetRootDomain(dom).ID;

                        if (!domainApparitions.ContainsKey(id))
                        {
                            domainApparitions.Add(id, 1);
                        }
                        else
                        {
                            domainApparitions[id]++;
                        }
                    }
                }

                foreach (var counter in domainApparitions.Values)
                {
                    if (counter > cds.GetConfiguration("MaxBooksFromSameDomain").Value)
                    {
                        Log.Info("The books the reader tries to borrow are not from the same domain.");
                        return false;
                    }
                }
            }

            Log.Info("The books the reader tries to borrow are from the same domain.");
            return true;
        }
    }
}
