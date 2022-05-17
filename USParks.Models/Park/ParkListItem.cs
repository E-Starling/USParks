using System.ComponentModel.DataAnnotations;


namespace USParks.Models.Park
{
    public class ParkListItem
    {
        public enum ParkType { National, State }

        [Display(Name = "Park Id")]
        public int ParkId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Park Type")]
        public ParkType parkType { get; set; }
        public string Location { get; set; }
        public byte[] Image { get; set; }
    }
}
