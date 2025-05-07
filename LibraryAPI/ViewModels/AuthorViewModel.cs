namespace LibraryAPI.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Nationality { get; set; }
    }
}
