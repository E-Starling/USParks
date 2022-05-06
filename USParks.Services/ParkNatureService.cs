using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USParks.Data;
using USParks.Models.ParkNature;

namespace USParks.Services
{
    public class ParkNatureService
    {
        private readonly Guid _userId;

        public ParkNatureService() { }
        public ParkNatureService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateParkNature(ParkNatureCreate model)
        {
            var entity = new ParkNature()
            {
                OwnerId = _userId,
                
                NatureId = model.NatureId,
                ParkId = model.ParkId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ParkNatures.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ParkNatureListItem> GetParkNature()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ParkNatures.Select(e => new ParkNatureListItem
                {
                    NatureId = e.NatureId,
                    ParkId = e.ParkId
                });
                return query.ToArray();
            }
        }

        public ParkNatureDetail GetParkNatureById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var parknatures = ctx.ParkNatures.Where(e => e.ParkNatureId == id).ToArray();
                foreach (var p in parknatures)
                {
                    if (p.ParkNatureId == id)
                    {
                        var entity = ctx.ParkNatures.Single(e => e.ParkNatureId == id);
                        return
                            new ParkNatureDetail()
                            {
                                ParkNatureId = entity.ParkNatureId,
                                NatureId = entity.NatureId,
                                NatureName = entity.Nature.Name,
                                ParkId = entity.ParkId,
                                ParkName = entity.Park.Name 
                            };
                    }
                }
                return null;
            }
        }

        public bool UpdateParkNature(ParkNatureEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userParkNature = ctx.ParkNatures.Where(e => e.OwnerId == _userId).ToArray();
                foreach (var p in userParkNature)
                {
                    if (p.ParkNatureId == model.ParkNatureId)
                    {
                        var entity = ctx.ParkNatures.Single(e => e.ParkNatureId == model.ParkNatureId && e.OwnerId == _userId);
                        var parks = ctx.Parks.ToArray();
                        var nature = ctx.Nature.ToArray();
                        foreach (var s in parks)
                        {
                            if (s.ParkId == model.ParkId)
                            {
                                foreach (var n in nature)
                                {
                                    if (n.NatureId == model.NatureId)
                                    {
                                        entity.ParkNatureId = model.ParkNatureId;
                                        entity.ParkId = model.ParkNatureId;
                                        entity.NatureId = model.NatureId;
                                        return ctx.SaveChanges() == 1;
                                    }
                                }
                            }
                        }
                    }
                }
                return false;
            }
        }

        public bool DeleteParkNature(int parkNatureId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userParkNature = ctx.ParkNatures.Where(e => e.OwnerId == _userId).ToArray();
                foreach (var p in userParkNature)
                {
                    if (p.ParkNatureId == parkNatureId)
                    {
                        var entity = ctx.ParkNatures.Single(e => e.ParkNatureId == parkNatureId && e.OwnerId == _userId);
                        ctx.ParkNatures.Remove(entity);
                        return ctx.SaveChanges() == 1;
                    }
                }
                return false;
            }
        }
    }
}
