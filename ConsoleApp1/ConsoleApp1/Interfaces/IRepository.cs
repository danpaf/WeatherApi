namespace ConsoleApp1.Interfaces;

public interface IRepository<T> where T : IEntity
{
    void Add(T item);
    void Delete(T item);
    T FindById(int id);
    IEnumerable<T> GetAll();
}