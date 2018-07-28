using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS_WebApp.Models
{
    public class CreateCostumerViewModel
    {
        public Costumer Costumer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}