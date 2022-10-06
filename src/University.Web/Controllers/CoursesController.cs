using Microsoft.AspNetCore.Mvc;
using University.ApplicationCore.Entities;
using University.ApplicationCore.Exceptions;
using University.ApplicationCore.Interfaces.Services;

namespace University.Web.Controllers;

public class CoursesController : Controller
{
    private readonly ICoursesService _coursesService;

    public CoursesController( ICoursesService coursesService)
    {
        _coursesService = coursesService;
    }

    public async Task<IActionResult> Index()
    {
        var courses = await _coursesService.GetListAsync();

        return View(courses);
    }

    public async Task<IActionResult> Details(int id)
    {
        var course = await _coursesService.GetAsync(id);

        return View(course);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        var course = await _coursesService.GetAsync((int)id);

        return View(course);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _coursesService.DeleteAsync(id);
        }
        catch(NotEmptyCourseException)
        {
        }
        
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        var course = await _coursesService.GetAsync((int)id);

        return View(course);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([Bind ("Name,Description,Id")] Course course)
    {
        await _coursesService.UpdateAsync(course);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Create()
    { 
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Name,Description")] Course course)
    {
        await _coursesService.AddAsync(course);

        return RedirectToAction(nameof(Index));
    }
}
