namespace aplikasi_asep.Models.Entities;

public class PlanningRecord
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public List<PlanningDayRecord> DayRecords { get; set; } = [];
}