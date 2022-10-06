using System.ComponentModel.DataAnnotations;
using University.ApplicationCore.Interfaces;

namespace University.ApplicationCore.Entities;

public class Group : BaseEntity, IAggregateRoot
{
    [MaxLength(25)]
    public string Name { get; set; }
    public ICollection<Student> ?Students { get; set; }
    public int CourseId { get; set; }
    public Course ?Course { get; set; }
}
