namespace LibraryAPI.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateOnly PublicationDate { get; set; }
        public int AuthorId { get; set; }
    }
}
