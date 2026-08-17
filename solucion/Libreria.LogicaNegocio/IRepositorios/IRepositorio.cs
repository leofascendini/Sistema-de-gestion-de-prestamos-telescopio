namespace Libreria.LogicaNegocio.IRepositorios
{
    public interface IRepositorio<T> where T : class
    {
        int Add(T obj);

        List<T> FindAll();

        void Remove(T obj);

        void Update(T obj);

        T FindById(int id);

    }
}