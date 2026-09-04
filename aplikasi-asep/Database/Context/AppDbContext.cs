using Microsoft.EntityFrameworkCore;
using aplikasi_asep.Models.Entities;

namespace aplikasi_asep.Database.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<PlanningRecord> PlanningRecords => Set<PlanningRecord>();
    public DbSet<PlanningDayRecord> PlanningDayRecords => Set<PlanningDayRecord>();
}