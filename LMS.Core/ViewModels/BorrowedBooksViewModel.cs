using System.ComponentModel.DataAnnotations;

namespace LMS.Core.ViewModels
{
    public class BorrowedBooksViewModel
    {
        [Key]
        public int BorrowID { get; set; }
        public DateTime BorrowDate { get; set;}
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; }

        public int MemberID { get; set; }
        public int BookID { get; set; }

    }
}
