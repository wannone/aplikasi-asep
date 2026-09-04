using Microsoft.AspNetCore.Mvc;
using aplikasi_asep.Models.Entities;
using aplikasi_asep.Services;

namespace aplikasi_asep.Controllers;

public class PlanningController(PlanningService planningService) : Controller
{
    private readonly PlanningService _planningService = planningService;

    [HttpGet]
    public IActionResult Index()
    {
        var model = new PlanningInput
        {
            Days = [.. _planningService.Days.Select(h => new PlanningDay { Day = h, Value = 0 })]
        };
        return View(model);
    }

    [HttpPost]
    public IActionResult Index(PlanningInput input)
    {
        return View(_planningService.ProcessPlan(input));
    }
}