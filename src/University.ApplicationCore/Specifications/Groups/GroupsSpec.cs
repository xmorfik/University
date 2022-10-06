using Ardalis.Specification;
using University.ApplicationCore.Entities;

namespace University.ApplicationCore.Specifications.Groups;

public class GroupsSpec : Specification<Group>, ISingleResultSpecification
{
    public GroupsSpec()
    {
        Query.Include(g => g.Students).Include(g => g.Course);
    }
}
