using System.ComponentModel.DataAnnotations;

namespace BrewVerse.API.Models
{
    public class Brewery
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
