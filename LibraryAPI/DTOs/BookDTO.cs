namespace LibraryAPI.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateOnly PublicationDate { get; set; }
        public int AuthorId { get; set; }
    }
}
