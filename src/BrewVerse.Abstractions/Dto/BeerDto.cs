namespace BrewVerse.Abstractions.Dto
{
    public class BeerDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal PercentageAlcoholByVolume { get; set; }
    }
}
