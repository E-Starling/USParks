using System.ComponentModel.DataAnnotations;

namespace USParks.Models.Nature
{
    public class NatureDetail
    {
        public enum KingdomType { fauna, flora, funga }
        public enum DietType { herbivore, carnivore, omnivore, other }
        [Display(Name = "Nature Id")]
        public int NatureId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public KingdomType Kingdom { get; set; }
        public string Class { get; set; }
        public DietType? Diet { get; set; }
    }
}
