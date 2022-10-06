using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using University.ApplicationCore.Entities;
using University.ApplicationCore.Interfaces.Services;

namespace University.Web.Controllers;

public class StudentsController : Controller
{
    private readonly IStudentsService _studentsService;
    private readonly IGroupsService _groupsService;

    public StudentsController(IStudentsService studentsService, 
                              IGroupsService groupsService)
    {
        _studentsService = studentsService;
        _groupsService = groupsService;
    }

    public async Task<IActionResult> Index()
    {
        var students = await _studentsService.GetListAsync();

        return View(students);
    }

    public async Task<IActionResult> Details(int id)
    {
        var student = await _studentsService.GetAsync(id);

        return View(student);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        var student = await _studentsService.GetAsync((int)id);

        return View(student);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _studentsService.DeleteAsync(id);
       
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        var student = await _studentsService.GetAsync((int)id);

        await PopulateGroupsDropDownList(student);

        return View(student);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([Bind("GroupId,FirstName,LastName,Id")] Student student)
    {
        await _studentsService.UpdateAsync(student);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await PopulateGroupsDropDownList();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("GroupId,FirstName,LastName")] Student student)
    {
        await _studentsService.AddAsync(student);
        
        return RedirectToAction(nameof(Index));
    }

    private async Task PopulateGroupsDropDownList(object selectedCourse = null)
    {
        var groups = await _groupsService.GetListAsync();

        ViewBag.GroupId = new SelectList(groups, "Id", "Name", selectedCourse);
    }
}
