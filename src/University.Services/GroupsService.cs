using University.ApplicationCore.Entities;
using University.ApplicationCore.Exceptions;
using University.ApplicationCore.Interfaces.Repositories;
using University.ApplicationCore.Interfaces.Services;
using University.ApplicationCore.Specifications.Groups;

namespace University.Services;

public class GroupsService : IGroupsService
{
    private readonly IRepository<Group> _groupsRepository;

    public GroupsService(IRepository<Group> groupsRepository)
    {
        _groupsRepository = groupsRepository;
    }

    public async Task AddAsync(Group group)
    {
        await _groupsRepository.AddAsync(group);
    }

    public async Task UpdateAsync(Group group)
    {
        await _groupsRepository.UpdateAsync(group);
    }

    public async Task<ICollection<Group>> GetListAsync()
    {
        return await _groupsRepository.ListAsync(new GroupsSpec());
    }

    public async Task<Group> GetAsync(int id)
    {
        return await _groupsRepository.FirstOrDefaultAsync(new GroupByIdSpec(id));
    }

    public async Task DeleteAsync(int id)
    {
        var group = await _groupsRepository.FirstOrDefaultAsync(new GroupByIdSpec(id));
       
        if (group.Students.Count > 0)
        {
            throw new NotEmptyGroupException(id);
        }
   
        await _groupsRepository.DeleteAsync(group);
    }
}