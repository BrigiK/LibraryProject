using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Book
    {
        public int Id
        {
            get;
            set;
        }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Title
        {
            get;
            set;
        }

        [Required]
        public List<Author> Authors
        {
            get;
            set;
        }

        [Required]
        public List<Publisher> Publishers
        {
            get;
            set;
        }

        [Required]
        public List<Edition> Editions
        {
            get;
            set;
        }

        [Required]
        public List<Domain> Domains
        {
            get;
            set;
        }
    }
}
