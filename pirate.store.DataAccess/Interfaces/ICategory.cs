using pirate.store.Domain.Entities;
using System.Collections.Generic;

namespace pirate.store.DataAccess.Interfaces
{
    public interface ICategory : IGeneric<Category>
    {
        ICollection<Category> GetAll();

        bool CreateSubcategory(Category category);

        bool ExistCategory(string name);

    }
}
