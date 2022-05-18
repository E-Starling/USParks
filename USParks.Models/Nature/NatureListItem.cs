using System.ComponentModel.DataAnnotations;

namespace USParks.Models.Nature
{
    public class NatureListItem
    {
        
        public enum KingdomType { Fauna, Flora, Funga }
        [Display(Name = "Nature Id")]
        public int NatureId { get; set; }
        public string Name { get; set; }
        public KingdomType Kingdom { get; set; }
        public string Class { get; set; }
        public byte[] Image { get; set; }
    }
}
