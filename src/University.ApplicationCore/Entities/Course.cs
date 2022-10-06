using System.ComponentModel.DataAnnotations;
using University.ApplicationCore.Interfaces;

namespace University.ApplicationCore.Entities;

public class Course : BaseEntity, IAggregateRoot
{
    [MaxLength(25)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string Description { get; set; }
    public ICollection<Group> ?Groups { get; set; }
}
