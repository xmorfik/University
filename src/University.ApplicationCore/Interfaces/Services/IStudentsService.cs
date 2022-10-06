using University.ApplicationCore.Entities;

namespace University.ApplicationCore.Interfaces.Services;

public interface IStudentsService
{
    Task AddAsync(Student student);
    Task DeleteAsync(int id);
    Task <ICollection<Student>> GetListAsync();
    Task <Student> GetAsync(int id);
    Task UpdateAsync(Student student);
}
