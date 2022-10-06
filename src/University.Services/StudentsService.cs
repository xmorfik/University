using University.ApplicationCore.Entities;
using University.ApplicationCore.Interfaces.Repositories;
using University.ApplicationCore.Interfaces.Services;
using University.ApplicationCore.Specifications.Students;

namespace University.Services;

public class StudentsService : IStudentsService
{
    private readonly IRepository<Student> _studentsRepository;

    public StudentsService( IRepository<Student> studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    public async Task AddAsync(Student student)
    {
        await _studentsRepository.AddAsync(student);
    }

    public async Task UpdateAsync(Student student)
    {
        await _studentsRepository.UpdateAsync(student);
    }

    public async Task<ICollection<Student>> GetListAsync()
    {
        return await _studentsRepository.ListAsync(new StudentsSpec());
    }

    public async Task<Student> GetAsync(int id)
    {
        return await _studentsRepository.FirstOrDefaultAsync(new StudentByIdSpec(id));
    }

    public async Task DeleteAsync(int id)
    {
        var student= await _studentsRepository.GetByIdAsync(id);

        await _studentsRepository.DeleteAsync(student);
    }
}