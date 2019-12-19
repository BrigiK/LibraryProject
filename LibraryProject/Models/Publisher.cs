using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Publisher
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

        [Required]
        public string Address
        {
            get;
            set;
        }
    }
}