using System.Collections.Generic;
namespace PS_WebApp.Models
{
    public class CreateItemViewModel
    {
        public Item Item { get; set; }
        public IEnumerable<Item> ItemList { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
    }
}