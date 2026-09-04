using aplikasi_asep.Database.Context;
using aplikasi_asep.Models.DTO;
using aplikasi_asep.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace aplikasi_asep.Repositories;

public class PlanningRepository(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task Save(PlanningInput input, PlanningInput result)
    {
        var record = new PlanningRecord
        {
            CreatedAt = DateTime.Now,
            DayRecords = [.. input.Days
                .Select((originalDay, index) => new PlanningDayRecord
                {
                    Day = originalDay.Day,
                    OriginalValue = originalDay.Value,
                    ResultValue = result.Days[index].Value
                })]
        };

        _context.PlanningRecords.Add(record);
        await _context.SaveChangesAsync();
    }

    public async Task<(List<PlanningRecord> Items, int TotalCount)> Get(int page, int pageSize)
    {
        var query = _context.PlanningRecords
            .Include(r => r.DayRecords)
            .OrderByDescending(r => r.CreatedAt);

        int totalCount = await query.CountAsync();

        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }

}