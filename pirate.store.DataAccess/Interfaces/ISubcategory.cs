using pirate.store.Domain.Entities;
using System.Collections.Generic;

namespace pirate.store.DataAccess.Interfaces
{
    public interface ISubcategory : IGeneric<Subcategory>
    {
        ICollection<Subcategory> GetAll();

    }
}