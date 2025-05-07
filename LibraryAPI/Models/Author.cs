using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryAPI.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(1), MaxLength(50)]
        public string Name { get; set; }
        [Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy}")]
        public DateOnly DateOfBirth { get; set; }
        [Required, MinLength(1), MaxLength(50)]
        public string Nationality { get; set; }
        [JsonIgnore]
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
