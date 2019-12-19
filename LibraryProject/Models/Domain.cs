using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Domain
    {
        public int Id
        {
            get;
            set;
        }

        [Required]
        public string Name
        {
            get;
            set;
        }
        
        public List<Domain> ParentDomains
        {
            get;
            set;
        }

        public List<Domain> ChildDomains
        {
            get;
            set;
        }
    }
}