using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using USParks.Data;
using USParks.Models.Attraction;

namespace USParks.Services
{
    public class AttractionService
    {
        private readonly Guid _userId;
        public AttractionService() { }
        public AttractionService(Guid userId)
        {
            _userId = userId;
        }
        public int CreateAttraction(HttpPostedFileBase file, AttractionCreate model)
        {
            model.Image = ConvertToBytes(file);
            var entity = new Attraction()
            {
                OwnerId = _userId,
                Name = model.Name,
                Description = model.Description,
                ParkId = model.ParkId,
                Image = model.Image
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Attractions.Add(entity);
                int i = ctx.SaveChanges();
                if (i == 1)
                    return 1;
                else
                    return 0;
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
                    ParkName = e.Park.Name,
                    Image = e.Image
                });
                return query.ToArray();
            }
        }

        public AttractionDetail GetAttractionById(int id)
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
                        ParkName = entity.Park.Name,
                        Image = entity.Image
                    };
            }
        }

        public bool UpdateAttraction(HttpPostedFileBase file, AttractionEdit model)
        {
            model.Image = ConvertToBytes(file);
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
                        entity.Image = model.Image;
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
                var q = from temp in ctx.Attractions where temp.AttractionId == Id select temp.Image;
                byte[] cover = q.First();
                return cover;
            }
        }
    }
}
