using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorMail { get; set; }
        public string?AuthorPassword { get; set; }
        public string? AuthorAbout { get; set; }
        public string? AuthorImage { get; set; }
        public bool AuthorStatus { get; set; }

    }
}
