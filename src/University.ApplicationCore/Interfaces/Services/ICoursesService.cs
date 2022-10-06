using University.ApplicationCore.Entities;

namespace University.ApplicationCore.Interfaces.Services;

public interface ICoursesService
{
    Task AddAsync(Course course);
    Task DeleteAsync(int id);
    Task <ICollection<Course>> GetListAsync();
    Task <Course> GetAsync(int id);
    Task UpdateAsync(Course course);
}
