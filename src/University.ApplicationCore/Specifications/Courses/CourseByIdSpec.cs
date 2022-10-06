using Ardalis.Specification;
using University.ApplicationCore.Entities;

namespace University.ApplicationCore.Specifications.Courses;

public class CourseByIdSpec : Specification<Course>, ISingleResultSpecification
{
    public CourseByIdSpec(int id)
    {
        Query.Where(c => c.Id == id).Include(c => c.Groups);
    }
}
