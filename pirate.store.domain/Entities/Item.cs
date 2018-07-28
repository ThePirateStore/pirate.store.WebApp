using System;

namespace pirate.store.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Company { get; set; }
        public int? Year { get; set; }
        public int? Rate { get; set; }
        public int? Quality { get; set; }
        public string Version { get; set; }
        public string UniqueCode { get; set; }
        public string MegaLink { get; set; }
        public string CoffeeLink { get; set; }
        public string ImageLink { get; set; }
        public bool IsActive { get; set; }
        public string FileFormat { get; set; }
        public int? FileSize { get; set; }
        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; }
        //public int CategoryId { get; set; }
        //public Category Category { get; set; }
        //public int SubcategoryId { get; set; }
        //public Subcategory Subcategory { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        

    }
}
