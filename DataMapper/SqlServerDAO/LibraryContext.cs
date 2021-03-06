﻿//-----------------------------------------------------------------------
// <copyright file="LibraryContext.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace LibraryProject.DataMapper
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using DomainModel;
    using log4net;

    /// <summary>The main class that coordinates Entity Framework functionality for a given data model.</summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class LibraryContext : DbContext
    {
        /// <summary>The logger instance.</summary>
        private static readonly ILog Log = LogManager.GetLogger(typeof(LibraryContext));

        /// <summary>Initializes a new instance of the <see cref="LibraryContext"/> class.</summary>
        public LibraryContext() : base("name=connStr")
        {
            Log.Info("Setting the initializer for the database.");
            Database.SetInitializer(new LibraryInitializer());
        }

        /// <summary>Gets or sets the authors.</summary>
        /// <value>The authors.</value>
        public virtual DbSet<Author> Authors { get; set; }

        /// <summary>Gets or sets the books.</summary>
        /// <value>The books.</value>
        public virtual DbSet<Book> Books { get; set; }

        /// <summary>Gets or sets the domains.</summary>
        /// <value>The domains.</value>
        public virtual DbSet<Domain> Domains { get; set; }

        /// <summary>Gets or sets the editions.</summary>
        /// <value>The editions.</value>
        public virtual DbSet<Edition> Editions { get; set; }

        /// <summary>Gets or sets the readers.</summary>
        /// <value>The readers.</value>
        public virtual DbSet<Reader> Readers { get; set; }

        /// <summary>Gets or sets the configurations.</summary>
        /// <value>The configurations.</value>
        public virtual DbSet<Configuration> Configurations { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuilder, but note that this can seriously degrade performance.
        /// classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
