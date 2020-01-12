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
    }
}
