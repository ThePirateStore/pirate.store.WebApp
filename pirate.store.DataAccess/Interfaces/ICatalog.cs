using pirate.store.Domain.Entities;
using System.Collections.Generic;

namespace pirate.store.DataAccess.Interfaces
{
    public interface ICatalog : IGeneric<Catalog>
    {
        ICollection<Catalog> GetAll();

        ICollection<Subcategory> GetSubcategoriesBtCategoryName(string name);

    }
}
