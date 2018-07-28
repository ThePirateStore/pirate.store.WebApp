using pirate.store.DataAccess.Interfaces;
using pirate.store.DataAccess.DataContext;
using pirate.store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pirate.store.DataAccess.Implementations
{
    public class CatalogRepository : ICatalog
    {
        public int Create(Catalog t)
        {
            using (var ctx = new DatabaseContext())
            {
                ctx.Catalogs.Add(t);

                ctx.SaveChanges();

                return t.Id;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Catalog GetById(int id)
        {
            using (var ctx = new DatabaseContext())
            {
                return ctx.Catalogs.AsNoTracking().SingleOrDefault(x => x.Id == id);
            }
        }

        public ICollection<Catalog> GetAll()
        {
            using (var ctx = new DatabaseContext())
            {
                return ctx.Catalogs.ToList();
            }
        }

        public bool Update(Catalog t)
        {
            throw new NotImplementedException();
        }


        public ICollection<Subcategory> GetSubcategoriesBtCategoryName(string name)
        {
            using (var ctx = new DatabaseContext())
            {
                return ctx.Subcategories.ToList();
            }
        }
    }
}
