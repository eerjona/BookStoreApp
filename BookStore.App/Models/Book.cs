using System.ComponentModel.DataAnnotations;

namespace BookStore.App.Models
{
    public class Book
    {
        [Key]
        internal static Book bookDetails;

        public int Id { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }

        [Display(Name = "Author")]
        [Required(ErrorMessage = "Author is required")]
        [StringLength(50, MinimumLength = 3,ErrorMessage ="Author name must be between 3 and 50 chars.")]
        public string Author { get; set; }

        [Display(Name = "PublshedYear")]
        [Required(ErrorMessage = "Published Year is required")]
        public int PublishedYear { get; set; }

        [Display(Name = "NrOfPages")]
        [Required(ErrorMessage = "Number of pages is required")]
        public int NrOfPages { get; set; }


        [Display(Name = "URLimg")]
        [Required(ErrorMessage = "URLimg of pages is required")]
        public string  URLimg{ get; set; }

    }
}
