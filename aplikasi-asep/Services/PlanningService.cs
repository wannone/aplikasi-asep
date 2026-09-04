using aplikasi_asep.Models.Entities;

namespace aplikasi_asep.Services;

public class PlanningService
{
    public readonly string[] Days =
        ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
        
    public PlanningInput ProcessPlan(PlanningInput input)
    {
        int totalCount = input.Days.Sum(d => d.Value);

        int baseCount = totalCount / input.Days.Count;
        int leftover = totalCount - (baseCount * input.Days.Count);
        
        var highestDays = input.Days
            .OrderByDescending(day => day.Value)
            .Take(leftover)
            .ToList();

        foreach (var day in input.Days)
        {
            day.Value = baseCount;
            if (highestDays.Any(d => d.Day == day.Day))
            {
                day.Value++;
            }
        }

        return input;
    }
}