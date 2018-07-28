using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pirate.store.Domain.Entities
{
    public class Catalog
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        //public int SubcategoryId { get; set; }
        //public Subcategory Subcategory { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
        public ICollection<Item> ItemsOnCatalog { get; set; }

        public Catalog()
        {
            Subcategories = new HashSet<Subcategory>();
            ItemsOnCatalog = new HashSet<Item>();
        }
    }
}
