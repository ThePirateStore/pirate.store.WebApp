using pirate.store.DataAccess.DataContext;
using pirate.store.DataAccess.Interfaces;
using pirate.store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace pirate.store.DataAccess.Implementations
{
    public class SubSubcategoryRepository : ISubcategory
    {
        public int Create(Subcategory t)
        {
            using (var ctx = new DatabaseContext())
            {
                ctx.Subcategories.Add(t);

                ctx.SaveChanges();

                return t.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var ctx = new DatabaseContext())
            {
                Subcategory subSubcategory = ctx.Subcategories.AsNoTracking().SingleOrDefault(x => x.Id == id);

                if (subSubcategory == null) return false;

                //Subcategory.IsActive = false;

                ctx.Entry(subSubcategory).State = EntityState.Modified;

                ctx.SaveChanges();

                return true;
            }
        }

        public Subcategory GetById(int id)
        {
            using (var ctx = new DatabaseContext())
            {
                return ctx.Subcategories.AsNoTracking().SingleOrDefault(x => x.Id == id);
            }
        }

        public ICollection<Subcategory> GetAll()
        {
            using (var ctx = new DatabaseContext())
            {
                return ctx.Subcategories.ToList();
            }
        }

        public bool Update(Subcategory t)
        {
            using (var ctx = new DatabaseContext())
            {
                Subcategory currenSubcategory = ctx.Subcategories.SingleOrDefault(x => x.Id == t.Id);

                if (currenSubcategory == null) return false;

                currenSubcategory.Name = t.Name;

                ctx.Entry(currenSubcategory).State = EntityState.Modified;

                ctx.SaveChanges();

                return true;
            }
        }

        
    }
}
