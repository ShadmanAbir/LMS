using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Models
{
    public class Books
    {
        [Key]
        public int BookID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int? AuthorID { get; set; }
        public DateTime PublishedDate { get; set; }
        public int? AvailableCopies { get; set; }
        public int? TotalCopies { get; set; }
    }
}
