using aplikasi_asep.Models.DTO;
using aplikasi_asep.Models.Entities;
using aplikasi_asep.Repositories;

namespace aplikasi_asep.Services;

public class PlanningService(PlanningRepository repository)
{
    private readonly PlanningRepository _repository = repository;

    public readonly string[] Days =
        ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];

    public PlanningInput ProcessPlan(PlanningInput input)
    {
        int totalCount = input.Days.Sum(d => d.Value);

        var activeDays = input.Days.Where(d => d.Value != 0).ToList();

        int baseCount = totalCount / activeDays.Count;
        int leftover = totalCount - (baseCount * activeDays.Count);

        var highestDays = activeDays
            .OrderByDescending(day => day.Value)
            .Take(leftover)
            .ToList();

        foreach (var day in activeDays)
        {
            day.Value = baseCount;
            if (highestDays.Any(d => d.Day == day.Day))
            {
                day.Value++;
            }
        }

        return input;
    }

    public async Task SavePlan(PlanningInput original, PlanningInput result)
    {
        await _repository.Save(original, result);
    }

    public async Task<PagedResult<PlanningRecord>> GetPlanRecord(int page, int pageSize = 5)
    {
        var (items, totalCount) = await _repository.Get(page, pageSize);

        return new PagedResult<PlanningRecord>
        {
            Items = items,
            CurrentPage = page,
            PageSize = pageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
        };
    }
}