using University.ApplicationCore.Entities;
using University.ApplicationCore.Exceptions;
using University.ApplicationCore.Interfaces.Repositories;
using University.ApplicationCore.Interfaces.Services;
using University.ApplicationCore.Specifications.Courses;

namespace University.Services;

public class CoursesService : ICoursesService
{
    private readonly IRepository<Course> _coursesRepository;

    public CoursesService(IRepository<Course> coursesRepository)
    {
        _coursesRepository = coursesRepository;
    }

    public async Task AddAsync(Course course)
    {
        await _coursesRepository.AddAsync(course);
    }

    public async Task UpdateAsync(Course course)
    {
        await _coursesRepository.UpdateAsync(course);
    }

    public async Task<ICollection<Course>> GetListAsync()
    {
        return await _coursesRepository.ListAsync(new CoursesSpec());
    }

    public async Task<Course> GetAsync(int id)
    {
        return await _coursesRepository.FirstOrDefaultAsync(new CourseByIdSpec(id)); ;
    }


    public async Task DeleteAsync(int id)
    {
        var course = await _coursesRepository.FirstOrDefaultAsync(new CourseByIdSpec(id));

        if (course.Groups.Count > 0)
        {
            throw new NotEmptyCourseException(id);
        }

        await _coursesRepository.DeleteAsync(course);
    }
}