using Ardalis.Specification;
using University.ApplicationCore.Entities;

namespace University.ApplicationCore.Specifications.Students;

public class StudentsSpec : Specification<Student>, ISingleResultSpecification
{
    public StudentsSpec()
    {
        Query.Include(s => s.Group);
    }
}
