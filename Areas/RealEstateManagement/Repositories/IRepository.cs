namespace restate.RealEstateManagement.Repositories;

public interface IRepository<T>
{
  public Task<List<T>> FindAll();
  public Task<T> FindById(int id);
  public Task Create(T tparams);
  public Task Update(T tparams);
}