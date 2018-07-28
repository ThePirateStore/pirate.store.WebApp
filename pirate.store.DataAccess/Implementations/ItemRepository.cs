using System.Collections.Generic;
using System.Data.Entity;
using pirate.store.DataAccess.Interfaces;
using pirate.store.DataAccess.DataContext;

using pirate.store.Domain.Entities;
using System.Linq;
using System;

namespace pirate.store.DataAccess.Implementations
{
    public class ItemRepository : IItem
    {
        public int Create(Item t)
        {
            using (var ctx = new DatabaseContext())
            {
                ctx.Items.Add(t);

                ctx.SaveChanges();

                return t.Id;
            }
        }

        public bool Delete(int id)
        {
            using (var ctx = new DatabaseContext())
            {
                Item item = ctx.Items.AsNoTracking().SingleOrDefault(x => x.Id == id);

                if (item == null) return false;

                item.IsActive = false;

                ctx.Entry(item).State = EntityState.Modified;

                ctx.SaveChanges();

                return true;
            }
        }

        public Item GetById(int id)
        {
            using (var ctx = new DatabaseContext())
            {
                return ctx.Items.AsNoTracking().SingleOrDefault(x => x.Id == id);
            }
        }

        public ICollection<Item> GetAll()
        {
            using (var ctx = new DatabaseContext())
            {
                return ctx.Items.ToList();
            }
        }

        public bool Update(Item t)
        {
            using (var ctx = new DatabaseContext())
            {
                Item currenItem = ctx.Items.SingleOrDefault(x => x.Id == t.Id);

                if (currenItem == null) return false;

                currenItem.Title = t.Title;
                currenItem.Author = t.Author;
                currenItem.Company = t.Company;
                currenItem.Quality = t.Quality;
                currenItem.Rate = t.Rate;
                currenItem.Version = t.Version;
                currenItem.Year = t.Year;
                currenItem.UniqueCode = t.UniqueCode;
                currenItem.MegaLink = t.MegaLink;
                currenItem.CoffeeLink = t.CoffeeLink;
                currenItem.ImageLink = t.ImageLink;
                
                currenItem.ModifiedDate = DateTime.Now;

                ctx.Entry(currenItem).State = EntityState.Modified;

                ctx.SaveChanges();

                return true;
            }
        }

        public bool Exist(object name)
        {
            throw new System.NotImplementedException();
        }
    }
}
