using Ardalis.Specification;
using University.ApplicationCore.Entities;

namespace University.ApplicationCore.Specifications.Courses;

public class CoursesSpec : Specification<Course>, ISingleResultSpecification
{
    public CoursesSpec()
    {
        Query.Include(c => c.Groups);
    }
}
