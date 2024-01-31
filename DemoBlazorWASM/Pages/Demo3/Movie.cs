using System.ComponentModel.DataAnnotations;

namespace DemoBlazorWASM.Pages.Demo3
{
    public class Movie
    {
        
        [Required(ErrorMessage = "Titre requis")]
        public string Title { get; set; }
        [Range(1960, 2024)]
        public int ReleaseYear { get; set; }
        [MinLength(100)]
        [Required]
        public string Synopsis { get; set; }
        [ValidateComplexType]
        public Person Realisator { get; set; }
    }

    public class Person
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
    }
}
