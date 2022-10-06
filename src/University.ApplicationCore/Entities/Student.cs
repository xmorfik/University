using System.ComponentModel.DataAnnotations;
using University.ApplicationCore.Interfaces;

namespace University.ApplicationCore.Entities;

public class Student : BaseEntity, IAggregateRoot
{
    [MaxLength(25)]
    public string FirstName { get; set; }
    [MaxLength(25)]
    public string LastName { get; set; }
    public int GroupId { get; set; }
    public Group ?Group { get; set; }
}
