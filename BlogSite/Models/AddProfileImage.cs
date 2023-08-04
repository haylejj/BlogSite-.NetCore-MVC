namespace BlogSite.Models
{
    public class AddProfileImage
    {
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorMail { get; set; }
        public string? AuthorPassword { get; set; }
        public string? AuthorAbout { get; set; }
        public IFormFile ?AuthorImage { get; set; }
        public bool AuthorStatus { get; set; }
    }
}
