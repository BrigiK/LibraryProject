//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryProject
{
    using LibraryProject.DataMapper;
    using LibraryProject.DomainModel;
    using log4net;

    /// <summary>Main class.</summary>
    public class Program
    {
        /// <summary>  Logger instance.</summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));

        /// <summary>Defines the entry point of the application.</summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Log.Info("Entering application.");
            using (var context = new LibraryContext())
            {
                foreach (var reader in context.Readers)
                {
                    System.Console.WriteLine(reader.Name);
                }
            }

            // add test project, comment the necessary tests from project description
            // test if Book in Informatics => also in Science
            // test book title length: min and max
            // test a valid insert
        }

        /// <summary>Adds an author to the database.</summary>
        private static void AddAuthor()
        {
            using (var context = new LibraryContext())
            {
                Author author = new Author
                {
                    Name = "Joanne Antwood"
                };

                context.Authors.Add(author);
                context.SaveChanges();
            }
        }

        /// <summary>Adds a new edition to the database.</summary>
        private static void AddEdition()
        {
            using (var context = new LibraryContext())
            {
                Edition edition = new Edition
                {
                    Number = 1,
                    PublisherName = "Publisher",
                    Type = "Hardcover",
                    Year = 1965,
                    NumberOfPages = 254,
                    NumberOfCopies = 2,
                    NumberOfLectureRoomCopies = 2,
                    Book = new Book
                    {
                        Title = "Title"
                    }
                };

                context.Editions.Add(edition);
                context.SaveChanges();
            }
        }
    }
}
