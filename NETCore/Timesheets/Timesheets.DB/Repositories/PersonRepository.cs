using Timesheets.DB.Data;
using Timesheets.DB.Entities;

namespace Timesheets.DB;

public class PersonRepository: IRepository<PersonEntity>
{
    private List<PersonEntity> _listPersons = PersonStore.GetPersonEntities();

    public async Task<PersonEntity?> GetByIdAsync(long id)
    {
        return _listPersons.Find(entity => entity.Id == id);
    }

    public IList<PersonEntity> GetAll()
    {
        return _listPersons;
    }

    public async Task AddAsync(PersonEntity entity)
    {
        _listPersons.Add(entity);
    }

    public async Task DeleteAsync(PersonEntity entity)
    {
        _listPersons.RemoveAt(_listPersons.FindIndex(personEntity => personEntity.Id == entity.Id));
    }

    public async Task UpdateAsync(PersonEntity entity)
    {
        DeleteAsync(entity);
        AddAsync(entity);
    }
}