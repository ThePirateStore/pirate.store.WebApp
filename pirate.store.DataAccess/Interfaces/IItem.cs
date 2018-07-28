using pirate.store.Domain.Entities;
using System.Collections.Generic;

namespace pirate.store.DataAccess.Interfaces
{
    public interface IItem : IGeneric<Item>
    {
        ICollection<Item> GetAll();
        bool Exist(object name);
    }
}
