using Microsoft.AspNetCore.Mvc;
using aplikasi_asep.Models.DTO;
using aplikasi_asep.Services;

namespace aplikasi_asep.Controllers;

public class PlanningController(PlanningService planningService) : Controller
{
    private readonly PlanningService _planningService = planningService;

    [HttpGet]
    public async Task<IActionResult> Index(int historyPage = 1)
    {
        var model = new PlanningPageView
        {
            InputDays = [.. _planningService.Days.Select(h => new PlanningDay { Day = h, Value = 0 })],
            History = await _planningService.GetPlanRecord(historyPage)
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Process(List<PlanningDay> InputDays)
    {
        var input = new PlanningInput { Days = InputDays };

        var original = new PlanningInput
        {
            Days = [.. input.Days.Select(d => new PlanningDay { Day = d.Day, Value = d.Value })]
        };

        var result = _planningService.ProcessPlan(input);

        var model = new PlanningPageView
        {
            InputDays = original.Days,
            ResultDays = result.Days,
            History = await _planningService.GetPlanRecord(1)
        };

        return View("Index", model);
    }

    [HttpPost]
    public async Task<IActionResult> Save(SavePlanningRequest request)
    {
        var original = new PlanningInput { Days = request.InputDays };
        var result = new PlanningInput { Days = request.ResultDays };

        await _planningService.SavePlan(original, result);

        TempData["SuccessMessage"] = "Planning berhasil disimpan ke riwayat.";
        return RedirectToAction("Index");
    }
}