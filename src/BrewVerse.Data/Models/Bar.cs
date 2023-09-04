using System.ComponentModel.DataAnnotations;

namespace BrewVerse.API.Models
{
    public class Bar
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
    }
}
