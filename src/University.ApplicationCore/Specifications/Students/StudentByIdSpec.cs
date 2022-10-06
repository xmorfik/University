using Ardalis.Specification;
using University.ApplicationCore.Entities;

namespace University.ApplicationCore.Specifications.Students;

public class StudentByIdSpec : Specification<Student>, ISingleResultSpecification
{
    public StudentByIdSpec(int id)
    {
        Query.Where(s => s.Id == id).Include(s => s.Group);
    }
}
