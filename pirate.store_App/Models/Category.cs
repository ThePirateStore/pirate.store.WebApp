using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace PS_WebApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public int ItemOnCategoryId { get; set; }
        public ICollection<Item> ItemsOnCategory { get; set; }
        
        public Category()
        {
            ItemsOnCategory = new HashSet<Item>();
        }
    }
}