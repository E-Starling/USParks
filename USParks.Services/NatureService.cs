using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool CreateNature(NatureCreate model)
        {
            var entity = new Nature()
            {
                OwnerId = _userId,
                Name = model.Name,
                Description = model.Description,
                Kingdom = (Nature.KingdomType)model.Kingdom,
                Class = model.Class,
                Diet = (Nature.DietType?)model.Diet
            };


            using (var ctx = new ApplicationDbContext())
            {
                ctx.Nature.Add(entity);
                return ctx.SaveChanges() == 1;
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
                    Class = e.Class
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
                        Diet = (NatureDetail.DietType)entity.Diet
                    };
            }
        }

        public bool UpdateNature(NatureEdit model)
        {
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
    }
}



