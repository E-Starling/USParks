using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using USParks.Data;
using USParks.Models.Nature;

namespace USParks.Services
{
    public class NatureService
    {
        private readonly Guid _userId;

        public NatureService() { }
        public NatureService(Guid userId)
        {
            _userId = userId;
        }

        public int CreateNature(HttpPostedFileBase file, NatureCreate model)
        {
            model.Image = ConvertToBytes(file);
            var entity = new Nature()
            {
                OwnerId = _userId,
                Name = model.Name,
                Description = model.Description,
                Kingdom = (Nature.KingdomType)model.Kingdom,
                Class = model.Class,
                Diet = (Nature.DietType?)model.Diet,
                Image = model.Image
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Nature.Add(entity);
                int i = ctx.SaveChanges();
                if (i == 1)
                    return 1;
                else
                    return 0;
            }
        }

        public IEnumerable<NatureListItem> GetNature()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Nature.Select(e => new NatureListItem
                {
                    NatureId = e.NatureId,
                    Name = e.Name,
                    Kingdom = (NatureListItem.KingdomType)e.Kingdom,
                    Class = e.Class,
                    Image = e.Image
                });
                return query.ToArray();
            }
        }

        public NatureDetail GetNatureById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Nature.Single(e => e.NatureId == id);
                return
                    new NatureDetail()
                    {
                        NatureId = entity.NatureId,
                        Name = entity.Name,
                        Description = entity.Description,
                        Kingdom = (NatureDetail.KingdomType)entity.Kingdom,
                        Class = entity.Class,
                        Diet = (NatureDetail.DietType)entity.Diet,
                        Image = entity.Image
                    };
            }
        }

        public bool UpdateNature(HttpPostedFileBase file, NatureEdit model)
        {
            model.Image = ConvertToBytes(file);
            using (var ctx = new ApplicationDbContext())
            {
                var userNature = ctx.Nature.Where(e => e.OwnerId == _userId).ToArray();
                foreach (var n in userNature)
                {
                    if (n.NatureId == model.NatureId)
                    {
                        var entity = ctx.Nature.Single(e => e.NatureId == model.NatureId && e.OwnerId == _userId);
                        entity.Name = model.Name;
                        entity.Description = model.Description;
                        entity.Kingdom = (Nature.KingdomType)model.Kingdom;
                        entity.Class = model.Class;
                        entity.Diet = (Nature.DietType)model.Diet;
                        entity.Image = model.Image;
                        return ctx.SaveChanges() == 1;
                    }
                }
                return false;
            }
        }

        public bool DeleteNature(int natureId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var userNature = ctx.Nature.Where(e => e.OwnerId == _userId).ToArray();
                foreach (var n in userNature)
                {
                    if (n.NatureId == natureId)
                    {
                        var entity = ctx.Nature.Single(e => e.NatureId == natureId && e.OwnerId == _userId);
                        ctx.Nature.Remove(entity);
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
                var q = from temp in ctx.Nature where temp.NatureId == Id select temp.Image;
                byte[] cover = q.First();
                return cover;
            }
        }
    }
}
