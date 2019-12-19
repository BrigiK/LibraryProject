using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Edition
    {
        public int Id
        {
            get;
            set;
        }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name
        {
            get;
            set;
        }

        [Required]
        public int Year
        {
            get;
            set;
        }

        [Required]
        public int Number
        {
            get;
            set;
        }

        // hard cover, ...
        public string Type
        {
            get;
            set;
        }

        [Required]
        public int NumberOfPages
        {
            get;
            set;
        }

        [Required]
        public int NumberOfCopies
        {
            get;
            set;
        }

        [Required]
        public int NumberOfLectureRoomCopies
        {
            get;
            set;
        }
    }
}