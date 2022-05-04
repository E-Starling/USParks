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
    }
}



