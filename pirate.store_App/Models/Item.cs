using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PS_WebApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Título")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Autor")]
        public string Author { get; set; }
        [Display(Name = "Año")]
        public int Year { get; set; }
        [Display(Name = "Precio")]
        public decimal Price { get; set; }
        public string UniqueCode { get; set; }
        public string ImageURL { get; set; }
        public string MegaURL { get; set; }
        public string CoffeeURL { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }
        public bool IsDonated { get; set; }

        //public Item()
        //{
        //    Categories = new HashSet<Category>();
        //}
    }
}