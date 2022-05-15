using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using USParks.Data;
using USParks.Models.Attraction;
using USParks.Models.Park;
using USParks.Models.ParkNature;

namespace USParks.Services
{
    public class ParkService
    {
        private readonly Guid _userId;
        public ParkService() { }
        public ParkService(Guid userId)
        {
            _userId = userId;
        }
     

        public int CreatePark(HttpPostedFileBase file, ParkCreate model)
        {
            model.Image = ConvertToBytes(file);

            var entity = new Park()
            {
                OwnerId = _userId,
                Name = model.Name,
                parkType = (Park.ParkType)model.parkType,
                Description = model.Description,
                Location = model.Location,
                Size = model.Size,
                YearlyVisitors = model.YearlyVisitors,
                Image = model.Image
            };


            using (var ctx = new ApplicationDbContext())
            {
                ctx.Parks.Add(entity);
                int i = ctx.SaveChanges();
                if (i == 1)

                    return 1;
                else
                    return 0;
            }
        }

        public IEnumerable<ParkListItem> GetPark()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Parks.Select(e => new ParkListItem
                {
                    ParkId = e.ParkId,
                    Name = e.Name,
                    parkType = (ParkListItem.ParkType)e.parkType,
                    Location = e.Location,
                    Image = e.Image
                });
                return query.ToArray();
            }
        }

        public ParkDetail GetParkById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var parks = ctx.Parks.Where(e => e.ParkId == id).ToArray();
                foreach (var p in parks)
                {
                    if (p.ParkId == id)
                    {
                        var entity = ctx.Parks.Single(e => e.ParkId == id);
                        return
                            new ParkDetail()
                            {
                                ParkId = entity.ParkId,
                                Name = entity.Name,
                                parkType = (ParkDetail.ParkType)entity.parkType,
                                Description = entity.Description,
                                Location = entity.Location,
                                Size = entity.Size,
                                YearlyVisitors = entity.YearlyVisitors,
                                Nature = entity.ParkNature.Select(n => new ParkNatureListItem()
                                {
                                    ParkNatureId = n.ParkNatureId,
                                    NatureId = n.Nature.NatureId,
                                    NatureName = n.Nature.Name,
                                }).ToList(),
                                Attractions = entity.Attraction.Select(a => new AttractionListItem()
                                {
                                    AttractionId = a.AttractionId,
                                    Name = a.Name
                                }).ToList(),
                                Image = entity.Image
                            };
                    }
                }
                return null;
            }
        }

        public bool UpdatePark(ParkEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userPark = ctx.Parks.Where(e => e.OwnerId == _userId).ToArray();
                foreach (var p in userPark)
                {
                    if (p.ParkId == model.ParkId)
                    {
                        var entity = ctx.Parks.Single(e => e.ParkId == model.ParkId && e.OwnerId == _userId);
                        entity.Name = model.Name;
                        entity.parkType = (Park.ParkType)model.parkType;
                        entity.Description = model.Description;
                        entity.Location = model.Location;
                        entity.Size = model.Size;
                        return ctx.SaveChanges() == 1;
                    }
                }
                return false;
            }
        }

        public bool DeletePark(int parkId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userPark = ctx.Parks.Where(e => e.OwnerId == _userId).ToArray();
                foreach (var p in userPark)
                {
                    if (p.ParkId == parkId)
                    {
                        var entity = ctx.Parks.Single(e => e.ParkId == parkId && e.OwnerId == _userId);
                        var attract = ctx.Attractions.Where(e => e.OwnerId == _userId).ToArray();
                        var pk = ctx.ParkNatures.Where(e => e.ParkNatureId == parkId).ToArray();
                        foreach (var attraction in attract)
                        {
                            if (attraction.AttractionId == parkId)
                                ctx.Attractions.Remove(attraction);
                            break;
                        }
                        foreach (var parknature in pk)
                        {
                            if (parknature.ParkNatureId == parkId)
                                ctx.ParkNatures.Remove(parknature);
                            break;
                        }
                        ctx.Parks.Remove(entity);
                        return ctx.SaveChanges() == 1;
                    }
                }
                return false;
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
                var q = from temp in ctx.Parks where temp.ParkId == Id select temp.Image;
                byte[] cover = q.First();
                return cover;
            }
        }
    }
}
