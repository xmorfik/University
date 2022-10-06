using University.ApplicationCore.Entities;
using University.ApplicationCore.Interfaces.Repositories;
using University.Services;
using FluentAssertions;
using Ardalis.Specification;

namespace University.UnitTests.ApplicationCore.Services.CoursesServiceTests;

public class ServiceGetList
{
    [Fact]
    public async void ReturnsCorrectList()
    {
        var coursesRepository = new Mock<IRepository<Course>>();
        coursesRepository.Setup(r => r.ListAsync(It.IsAny<Specification<Course>>(),default)).ReturnsAsync(GetTestCourses());

        var coursesService = new CoursesService(coursesRepository.Object);
        var actual = await coursesService.GetListAsync(); 

        var expected = (ICollection<Course>)GetTestCourses();

        actual.Should().BeEquivalentTo(expected);
    }

    private List<Course> GetTestCourses()
    {
        var courses = new List<Course>
            {
                new Course { Id=1, Name="A", Description="a"},
                new Course { Id=2, Name="B", Description="b"},
                new Course { Id=3, Name="C", Description="c"},
                new Course { Id=4, Name="D", Description="d"}
            };

        return courses;
    }
}
