using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    class Reader
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
        public string Email
        {
            get;
            set;
        }

        [Required]
        public string Username
        {
            get;
            set;
        }

        [Required]
        public string Password
        {
            get;
            set;
        }

        public bool IsWorker
        {
            get;
            set;
        }
    }
}
