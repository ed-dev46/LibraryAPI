using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models
{
    public class Book
    {

        [Key]
        public int Id { get; set; }
        [Required, MinLength(1), MaxLength(50)]
        public string Title { get; set; }
        [Required, MinLength(1), MaxLength(50)]
        public string Genre { get; set; }
        [Required, DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{MM/dd/yyyy}")]
        public DateOnly PublicationDate { get; set; }
        [ForeignKey("Author"), Column("Author")]
        public int AuthorId { get; set; }
    }
}
