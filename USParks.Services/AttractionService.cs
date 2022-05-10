using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USParks.Data;
using USParks.Models.Attraction;

namespace USParks.Services
{
    public class AttractionService
    {
        public class NatureService
        {
            private readonly Guid _userId;

            public NatureService() { }
            public NatureService(Guid userId)
            {
                _userId = userId;
            }

            public bool CreateAttraction(AttractionCreate model)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var parks = ctx.Parks.ToArray();
                    foreach (var p in parks)
                    {
                        if (p.ParkId == model.ParkId)
                        {
                            var entity = new Attraction()
                            {
                                OwnerId = _userId,
                                Name = model.Name,
                                Description = model.Description,
                                ParkId = model.ParkId
                            };
                            ctx.Attractions.Add(entity);
                            return ctx.SaveChanges() == 1;
                        }
                    }
                    return false;
                }
            }

            public IEnumerable<AttractionListItem> GetAttraction()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query = ctx.Attractions.Select(e => new AttractionListItem
                    {
                        AttractionId = e.AttractionId,
                        Name = e.Name,
                        ParkId = e.ParkId,
                        ParkName = e.Park.Name
                    });
                    return query.ToArray();
                }
            }

            public AttractionDetail GetNatureById(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity = ctx.Attractions.Single(e => e.AttractionId == id);
                    return
                        new AttractionDetail()
                        {
                            AttractionId = entity.AttractionId,
                            Name = entity.Name,
                            Description = entity.Description,
                            ParkId = entity.ParkId,
                            ParkName = entity.Park.Name
                        };
                }
            }

            public bool UpdateAttraction(AttractionEdit model)
            {
                using (var ctx = new ApplicationDbContext())
                {

                    var userAttraction = ctx.Attractions.Where(e => e.OwnerId == _userId).ToArray();
                    foreach (var a in userAttraction)
                    {
                        if (a.AttractionId == model.AttractionId)
                        {
                            var entity = ctx.Attractions.Single(e => e.AttractionId == model.AttractionId && e.OwnerId == _userId);
                            entity.Name = model.Name;
                            entity.Description = model.Description;
                            entity.ParkId = model.ParkId;
                            return ctx.SaveChanges() == 1;
                        }
                    }
                    return false;
                }
            }

            public bool DeleteAttraction(int attractionId)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var userAttractions = ctx.Attractions.Where(e => e.OwnerId == _userId).ToArray();
                    foreach (var a in userAttractions)
                    {
                        if (a.AttractionId == attractionId)
                        {
                            var entity = ctx.Attractions.Single(e => e.AttractionId == attractionId && e.OwnerId == _userId);
                            ctx.Attractions.Remove(entity);
                            return ctx.SaveChanges() == 1;
                        }
                    }
                    return false;
                }
            }
        }
    }
}

