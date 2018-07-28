using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PS_WebApp.Models
{
    public class Costumer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public bool IsActive { get; set; }

        public int MembershipTypeId { get; set; }

        public MembershipType MembershipType { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
