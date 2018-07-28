using System.Collections.Generic;

namespace pirate.store.Domain.Entities
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Item> ItemsOnSubcategory { get; set; }

        public Subcategory()
        {
            ItemsOnSubcategory = new HashSet<Item>();
        }
    }
}