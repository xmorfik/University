using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using University.ApplicationCore.Entities;
using University.ApplicationCore.Exceptions;
using University.ApplicationCore.Interfaces.Services;

namespace University.Web.Controllers;

public class GroupsController : Controller
{
    private readonly IGroupsService _groupsService;
    private readonly ICoursesService _coursesService;

    public GroupsController(IGroupsService groupsService, ICoursesService coursesService)
    {
        _groupsService = groupsService;
        _coursesService = coursesService;
    }

    public async Task<IActionResult> Index()
    {
        var groups = await _groupsService.GetListAsync();

        return View(groups);
    }

    public async Task<IActionResult> Details(int id)
    {
        var group = await _groupsService.GetAsync(id);

        return View(group);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        var group = await _groupsService.GetAsync((int)id);

        return View(group);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _groupsService.DeleteAsync(id);
        }
        catch (NotEmptyGroupException)
        {
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        var group = await _groupsService.GetAsync((int)id);

        await PopulateCoursesDropDownListAsync(group);

        return View(group);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([Bind("CourseId,Name,Id")] Group group)
    {
        await _groupsService.UpdateAsync(group);

        return View(group);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await PopulateCoursesDropDownListAsync();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("CourseId,Name")] Group group)
    {
        await _groupsService.UpdateAsync(group);

        return RedirectToAction(nameof(Index));
    }

    private async Task PopulateCoursesDropDownListAsync(object selectedCourse = null)
    {
        var courses = await _coursesService.GetListAsync();

        ViewBag.CourseId = new SelectList(courses, "Id", "Name", selectedCourse);
    }
}
