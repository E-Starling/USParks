using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using USParks.Data;
using USParks.Models.ParkNature;

namespace USParks.Services
{
    public class ParkNatureService
    {
        public ParkNatureService() { }

        public bool CreateParkNature(ParkNatureCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var parks = ctx.Parks.ToArray();
                var nature = ctx.Nature.ToArray();
                var parknatures = ctx.ParkNatures.ToArray();
                foreach (var p in parks)
                {
                    if (p.ParkId == model.ParkId)
                    {
                        foreach (var n in nature)
                        {
                            if (n.NatureId == model.NatureId)
                            {
                                foreach (var pi in parknatures)
                                {
                                    if (pi.ParkId == model.ParkId)
                                    {
                                        if (pi.NatureId == model.NatureId)
                                        {
                                            return false;
                                        }
                                    }
                                }
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
                    Image = e.Nature.Image,
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
                                Image = entity.Nature.Image,
                                ParkId = entity.ParkId,
                                ParkName = entity.Park.Name
                            };
                    }
                }
                return null;
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

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }

        public byte[] GetImageFromDataBase(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var q = from temp in ctx.Nature where temp.NatureId == Id select temp.Image;
                byte[] cover = q.First();
                return cover;
            }
        }
    }
}
