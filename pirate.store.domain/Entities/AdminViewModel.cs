using pirate.store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pirate.store.Domain.Models
{
    public class AdminViewModel
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Category> Categories { get; set; }
        public Subcategory Subcategory { get; set; }
        public AdminViewModel()
        {
            Items = new HashSet<Item>();
            Categories = new HashSet<Category>();
        }
    }
}