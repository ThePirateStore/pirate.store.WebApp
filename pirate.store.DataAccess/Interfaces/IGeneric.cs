namespace pirate.store.DataAccess.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        int Create(T t);

        T GetById(int id);

        bool Update(T t);

        bool Delete(int id);
    }
}
