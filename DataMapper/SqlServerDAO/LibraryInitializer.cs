//-----------------------------------------------------------------------
// <copyright file="LibraryInitializer.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------

namespace LibraryProject.DataMapper
{
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using LibraryProject.DomainModel;
    using log4net;

    /// <summary>Initializes database with data.</summary>
    /// <seealso cref="System.Data.Entity.DropCreateDatabaseIfModelChanges{LibraryProject.DataAccessLayer.LibraryContext}" />
    internal class LibraryInitializer : System.Data.Entity.DropCreateDatabaseAlways<LibraryContext>
    {
        /// <summary>The logger instance.</summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(LibraryInitializer));

        /// <summary>A method that adds data to the context for seeding.</summary>
        /// <param name="context">The context to seed.</param>
        protected override void Seed(LibraryContext context)
        {
            var authors = new List<Author>
            {
                new Author { Name = "J. R. R. Tolkien" },
                new Author { Name = "George R. R. Martin" },
                new Author { Name = "J. K. Rowling" },
                new Author { Name = "Stephenie Meyer" },
                new Author { Name = "Robert J. Morgan" },
                new Author { Name = "Roberta Edwards" },
                new Author { Name = "Napoleon Hill" },
                new Author { Name = "Laura Joffe Numeroff" },
                new Author { Name = "Bert Bates" },
                new Author { Name = "Kathy Sierra" }
            };

            Log.Info("Adding data to author entity.");
            authors.ForEach(a => context.Authors.Add(a));
            context.SaveChanges();
            Log.Info("Data successfully added to database.");

            var editions = new List<Edition>
            {
                new Edition { PublisherName = "Second Edition", Year = 1986, Number = 2, Type = "Mass Market Paperback", NumberOfPages = 480, NumberOfCopies = 8, NumberOfLectureRoomCopies = 2 },
                new Edition { PublisherName = "First Edition", Year = 1967, Number = 1, Type = "Paperback", NumberOfPages = 480, NumberOfCopies = 2, NumberOfLectureRoomCopies = 1 },
                new Edition { PublisherName = "Second Edition", Year = 2012, Number = 2, Type = "Paperback", NumberOfPages = 784, NumberOfCopies = 6, NumberOfLectureRoomCopies = 3 },
                new Edition { PublisherName = "Third Edition", Year = 1999, Number = 3, Type = "Hardcover", NumberOfPages = 448, NumberOfCopies = 10, NumberOfLectureRoomCopies = 2 },
                new Edition { PublisherName = "First Edition", Year = 2006, Number = 1, Type = "Paperback", NumberOfPages = 544, NumberOfCopies = 4, NumberOfLectureRoomCopies = 1 },
                new Edition { PublisherName = "Thomas Nelson", Year = 2003, Number = 1, Type = "Paperback", NumberOfPages = 308, NumberOfCopies = 8, NumberOfLectureRoomCopies = 4 },
                new Edition { PublisherName = "Penguin Young Readers Group", Year = 2005, Number = 1, Type = "Paperback", NumberOfPages = 112, NumberOfCopies = 2, NumberOfLectureRoomCopies = 1 },
                new Edition { PublisherName = "CreateSpace Independent Publishing Platform", Year = 2010, Number = 2, Type = "Paperback", NumberOfPages = 244, NumberOfCopies = 7, NumberOfLectureRoomCopies = 5 },
                new Edition { PublisherName = "Scholastic, Incorporated", Year = 1988, Number = 1, Type = "Paperback", NumberOfPages = 28, NumberOfCopies = 1, NumberOfLectureRoomCopies = 1 },
                new Edition { PublisherName = "O'Reilly Media, Incorporated", Year = 2003, Number = 2, Type = "Paperback", NumberOfPages = 656, NumberOfCopies = 8, NumberOfLectureRoomCopies = 4 },
            };

            Log.Info("Adding data to edition entity.");
            editions.ForEach(e => context.Editions.Add(e));
            context.SaveChanges();
            Log.Info("Data successfully added to database.");

            var domains = new List<Domain>
            {
                new Domain { Name = "Arts & Music" },
                new Domain { Name = "Business" },
                new Domain { Name = "Kids" },
                new Domain { Name = "Computers & Tech" },
                new Domain { Name = "Cooking" },
                new Domain { Name = "Science & Math" },
                new Domain { Name = "Sci-Fi & Fantasy" },
                new Domain { Name = "Travel" }
            };

            domains.AddRange(
                new List<Domain>
                {
                    new Domain { Name = "Music", ParentDomain = domains[0] },
                    new Domain { Name = "Painting", ParentDomain = domains[0] },
                    new Domain { Name = "Photography", ParentDomain = domains[0] },
                    new Domain { Name = "Sculpture", ParentDomain = domains[0] },
                    new Domain { Name = "Finance", ParentDomain = domains[1] },
                    new Domain { Name = "Economics", ParentDomain = domains[1] },
                    new Domain { Name = "Industries", ParentDomain = domains[1] },
                    new Domain { Name = "Animals", ParentDomain = domains[2] },
                    new Domain { Name = "Cars & Trains", ParentDomain = domains[2] },
                    new Domain { Name = "Fairy Tales", ParentDomain = domains[2] },
                    new Domain { Name = "Networking", ParentDomain = domains[3] },
                    new Domain { Name = "Computer Science", ParentDomain = domains[3] },
                    new Domain { Name = "Databases", ParentDomain = domains[3] },
                    new Domain { Name = "Baking", ParentDomain = domains[4] },
                    new Domain { Name = "BBQ", ParentDomain = domains[4] },
                    new Domain { Name = "Desserts", ParentDomain = domains[4] },
                    new Domain { Name = "Anatomy", ParentDomain = domains[5] },
                    new Domain { Name = "Biology", ParentDomain = domains[5] },
                    new Domain { Name = "Chemistry", ParentDomain = domains[5] },
                    new Domain { Name = "Mathematics", ParentDomain = domains[5] },
                    new Domain { Name = "Engineering", ParentDomain = domains[5] },
                    new Domain { Name = "Statistics", ParentDomain = domains[5] },
                    new Domain { Name = "Action", ParentDomain = domains[6] },
                    new Domain { Name = "Fantasy", ParentDomain = domains[6] },
                    new Domain { Name = "Fantasy Epics", ParentDomain = domains[6] },
                    new Domain { Name = "Africa", ParentDomain = domains[7] },
                    new Domain { Name = "Asia", ParentDomain = domains[7] },
                    new Domain { Name = "Caribbean", ParentDomain = domains[7] }
                });

            Log.Info("Adding data to domain entity.");
            domains.ForEach(d => context.Domains.Add(d));
            context.SaveChanges();
            Log.Info("Data successfully added to database.");

            var books = new List<Book>
            {
                new Book
                {
                    Title = "Then Sings My Soul: 150 of the World's Greatest Hymn Stories",
                    Authors = new List<Author> { authors[4] },
                    Domains = new List<Domain> { domains[8] },
                    Editions = new List<Edition> { editions[5] }
                },
                new Book
                {
                    Title = "Who Was Leonardo Da Vinci?",
                    Authors = new List<Author> { authors[5] },
                    Domains = new List<Domain> { domains[9] },
                    Editions = new List<Edition> { editions[6] }
                },
                new Book
                {
                    Title = "Think and Grow Rich",
                    Authors = new List<Author> { authors[6] },
                    Domains = new List<Domain> { domains[13] },
                    Editions = new List<Edition> { editions[7] }
                },
                new Book
                {
                    Title = "If You Give a Mouse a Cookie",
                    Authors = new List<Author> { authors[7] },
                    Domains = new List<Domain> { domains[15] },
                    Editions = new List<Edition> { editions[8] }
                },
                new Book
                {
                    Title = "Head First Java : Your Brain on Java- A Learner's Guide",
                    Authors = new List<Author> { authors[8] },
                    Domains = new List<Domain> { domains[19] },
                    Editions = new List<Edition> { editions[9] }
                },
            };

            Log.Info("Adding data to book entity.");
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
            Log.Info("Data successfully added to database.");

            var readers = new List<Reader>
            {
                new Reader
                {
                    Name = "Name",
                    Username = "uname",
                    Password = "pwdvdvgvgrgr",
                    IsReader = true,
                    IsWorker = false,
                    Email = "unam@gmail.com",
                    Books = new List<Book>
                    {
                        books[0]
                    }
                }
            };

            Log.Info("Adding data to reader entity.");
            readers.ForEach(r => context.Readers.Add(r));
            context.SaveChanges();
            Log.Info("Data successfully added to database.");

            var configurations = new List<Configuration>
            {
                new Configuration
                {
                    Name = "MaxDOMBook",
                    Value = 3
                },
                new Configuration
                {
                    Name = "NrMaxBooksBorrowed",
                    Value = 6
                },
                new Configuration
                {
                    Name = "MaxPeriodForMaxBooks",
                    Value = 7
                },
                new Configuration
                {
                    Name = "MaxBooksOneBorrow",
                    Value = 4
                },
                new Configuration
                {
                    Name = "MaxBooksFromSameDomain",
                    Value = 2
                },
                new Configuration
                {
                    Name = "NrMonthsBooksSameDomain",
                    Value = 1
                },
                new Configuration
                {
                    Name = "MaxDelayInLast3Months",
                    Value = 10
                },
                new Configuration
                {
                    Name = "BorrowSameBookForDays",
                    Value = 30
                },
                new Configuration
                {
                    Name = "MaxBooksOneDay",
                    Value = 6
                },
                new Configuration
                {
                    Name = "MaxBooksToGive",
                    Value = 20
                }
            };

            Log.Info("Adding data to configuration entity.");
            configurations.ForEach(c => context.Configurations.Add(c));
            context.SaveChanges();
            Log.Info("Data successfully added to database.");
        }
    }
}
