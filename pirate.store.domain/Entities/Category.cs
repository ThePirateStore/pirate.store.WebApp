using System.Collections.Generic;

namespace pirate.store.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> ItemsOnCategory { get; set; }
        public ICollection<Subcategory> SubCategoriesOnCategory { get; set; }

        public Category()
        {
            ItemsOnCategory = new HashSet<Item>();
            SubCategoriesOnCategory = new HashSet<Subcategory>();
        }
    }
}