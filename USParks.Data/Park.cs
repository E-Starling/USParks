using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace USParks.Data
{
    public class Park
    {
        public enum ParkType { National, State }
        [Key]
        public int ParkId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ParkType parkType { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public int YearlyVisitors { get; set; }

        public byte[] Image { get; set; }

        public virtual List<ParkNature> ParkNature { get; set; } = new List<ParkNature>();
        public virtual List<Attraction> Attraction { get; set; } = new List<Attraction>();
    }
}
