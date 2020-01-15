//-----------------------------------------------------------------------
// <copyright file="AuthorServicesImplementation.cs" company="Transilvania University of Brasov">
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

    /// <summary>Author Services Implementation.</summary>
    public class AuthorServicesImplementation : IAuthorServices
    {
        /// <summary>The author data services</summary>
        private IAuthorDataService authorDataService;

        /// <summary>Initializes a new instance of the <see cref="AuthorServicesImplementation"/> class.</summary>
        /// <param name="authorDataService">The author data service.</param>
        public AuthorServicesImplementation(IAuthorDataService authorDataService = null)
        {
            if (authorDataService == null)
            {
                authorDataService = DAOFactoryMethod.CurrentDAOFactory.AuthorDataService;
            }

            this.authorDataService = authorDataService;
        }

        /// <summary>Adds the author.</summary>
        /// <param name="author">The author.</param>
        public void AddAuthor(Author author)
        {
            if (!author.Name.Equals(string.Empty))
            {
                this.authorDataService.AddAuthor(author);
            }
        }

        /// <summary>Deletes the author.</summary>
        /// <param name="author">The author.</param>
        public void DeleteAuthor(Author author)
        {
            this.authorDataService.DeleteAuthor(author);
        }

        /// <summary>Gets the author by identifier.</summary>
        /// <param name="id">The identifier.</param>
        public void GetAuthorById(int id)
        {
            this.authorDataService.GetAuthorById(id);
        }

        /// <summary>Gets the list of authors.</summary>
        /// <returns>a a</returns>
        public IList<Author> GetListOfAuthors()
        {
            return this.authorDataService.GetAllAuthors();
        }

        /// <summary>Updates the author.</summary>
        /// <param name="author">The author.</param>
        public void UpdateAuthor(Author author)
        {
            this.authorDataService.UpdateAuthor(author);
        }

        /// <summary>Gets the author by name.</summary>
        /// <param name="name">The name.</param>
        /// <returns>a a</returns>
        public Author GetAuthorByName(string name)
        {
            return this.authorDataService.GetAuthorByName(name);
        }
    }
}
