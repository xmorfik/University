using Ardalis.Specification;
using University.ApplicationCore.Entities;

namespace University.ApplicationCore.Specifications.Groups;

public class GroupByIdSpec : Specification<Group>, ISingleResultSpecification
{
    public GroupByIdSpec(int id)
    {
        Query.Where(g => g.Id == id).Include(g => g.Students).Include(g=>g.Course);
    }
}
