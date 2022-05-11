using System.ComponentModel.DataAnnotations;

namespace USParks.Models.Nature
{
    public class NatureListItem
    {
        public enum KingdomType { fauna, flora, funga }
        [Display(Name = "Nature Id")]
        public int NatureId { get; set; }
        public string Name { get; set; }
        public KingdomType Kingdom { get; set; }
        public string Class { get; set; }
    }
}
