using System.Collections.Generic;
using System.Linq;
using USParks.Data;
using USParks.Models.ParkNature;

namespace USParks.Services
{
    public class ParkNatureService
    {
        // private readonly Guid _userId;

        public ParkNatureService() { }
        //public ParkNatureService(Guid userId)
        //{
        //    _userId = userId;
        //}

        public bool CreateParkNature(ParkNatureCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var parks = ctx.Parks.ToArray();
                var nature = ctx.Nature.ToArray();
                foreach (var p in parks)
                {
                    if (p.ParkId == model.ParkId)
                    {
                        foreach (var n in nature)
                        {
                            if (n.NatureId == model.NatureId)
                            {
                                var entity = new ParkNature()
                                {
                                    NatureId = model.NatureId,
                                    ParkId = model.ParkId
                                };
                                ctx.ParkNatures.Add(entity);
                                return ctx.SaveChanges() == 1;
                            }
                        }
                    }
                }
                return false;
            }


            //var entity = new ParkNature()
            //{
            //    NatureId = model.NatureId,
            //    ParkId = model.ParkId,
            //};


            //using (var ctx = new ApplicationDbContext())
            //{
            //    ctx.ParkNatures.Add(entity);
            //    return ctx.SaveChanges() == 1;
            //}

        }

        public IEnumerable<ParkNatureListItem> GetParkNature()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.ParkNatures.Select(e => new ParkNatureListItem
                {
                    ParkNatureId = e.ParkNatureId,
                    NatureId = e.NatureId,
                    NatureName = e.Nature.Name,
                    ParkId = e.ParkId,
                    ParkName = e.Park.Name
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

            //using (var ctx = new ApplicationDbContext())
            //{
            //    var entity = ctx.ParkNatures.Single(e => e.ParkNatureId == id);
            //    return
            //                new ParkNatureDetail()
            //                {
            //                    ParkNatureId = entity.ParkNatureId,
            //                    NatureId = entity.NatureId,
            //                    NatureName = entity.Nature.Name,
            //                    ParkId = entity.ParkId,
            //                    ParkName = entity.Park.Name
            //                };
            //}
        }

        public bool UpdateParkNature(ParkNatureEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {

                var entity = ctx.ParkNatures.Single(e => e.ParkNatureId == model.ParkNatureId);
                var nature = ctx.Nature.ToArray();
                foreach (var n in nature)
                {
                    if (n.NatureId == model.NatureId)
                    {
                        entity.ParkNatureId = model.ParkNatureId;
                        entity.NatureId = model.NatureId;
                        ctx.Entry(entity).Property(u => u.ParkId).IsModified = false;
                        return ctx.SaveChanges() == 1;
                    }
                }
                return false;
            }
        }

        public bool DeleteParkNature(int parkNatureId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.ParkNatures.Single(e => e.ParkNatureId == parkNatureId);
                ctx.ParkNatures.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
