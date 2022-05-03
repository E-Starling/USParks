using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USParks.Data
{
    public class Park
    {
        public enum ParkType { National, State }
        [Key]
        public int ParkId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        public string Name { get; set; }
        public ParkType park_type { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Size { get; set; }
        public int YearlyVisitors { get; set; }
        public virtual List<ParkNature> ParkNature { get; set; } = new List<ParkNature>();
        public virtual List<Attraction> Attraction { get; set; }= new List<Attraction>();
    }
}
