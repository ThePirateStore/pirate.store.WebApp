using pirate.store.Domain.Entities;
using pirate.store.DataAccess.Interfaces;
using System.Collections.Generic;
using pirate.store.DataAccess.DataContext;
using System.Linq;
using System.Data.Entity;

namespace pirate.store.DataAccess.Implementations
{
    public class CategoryRepository : ICategory
    {
        public int Create(Category t)
        {
            using (var ctx = new DatabaseContext())
            {
                ctx.Categories.Add(t);

                ctx.SaveChanges();

                return t.Id;
            }
        }

        public bool CreateSubcategory(Category category)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            using (var ctx = new DatabaseContext())
            {
                Category category = ctx.Categories.AsNoTracking().SingleOrDefault(x => x.Id == id);

                if (category == null) return false;

                //category.IsActive = false;

                ctx.Entry(category).State = EntityState.Modified;

                ctx.SaveChanges();

                return true;
            }
        }

        public Category GetById(int id)
        {
            using (var ctx = new DatabaseContext())
            {
                return ctx.Categories.AsNoTracking().SingleOrDefault(x => x.Id == id);
            }
        }

        public ICollection<Category> GetAll()
        {
            using (var ctx = new DatabaseContext())
            {
                return ctx.Categories.ToList();
            }
        }

        public bool Update(Category t)
        {
            using (var ctx = new DatabaseContext())
            {
                Category currenCategory = ctx.Categories.SingleOrDefault(x => x.Id == t.Id);

                if (currenCategory == null) return false;

                currenCategory.Name = t.Name;
                
                ctx.Entry(currenCategory).State = EntityState.Modified;

                ctx.SaveChanges();

                return true;
            }
        }

        public bool ExistCategory(string name)
        {
            using (var ctx = new DatabaseContext())
            {
                return ctx.Categories.AsNoTracking().Any(x => x.Name.ToLower() == name.ToLower());
            }
        }
    }
}
