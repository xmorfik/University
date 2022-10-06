using University.ApplicationCore.Entities;

namespace University.ApplicationCore.Interfaces.Services;

public interface IGroupsService
{
    Task AddAsync(Group group);
    Task DeleteAsync(int id);
    Task <ICollection<Group>> GetListAsync();
    Task <Group> GetAsync(int id);
    Task UpdateAsync(Group group);
}
