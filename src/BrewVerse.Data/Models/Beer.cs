using System.ComponentModel.DataAnnotations;

namespace BrewVerse.API.Models
{
    public class Beer
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal PercentageAlcoholByVolume { get; set; }
    }
}
