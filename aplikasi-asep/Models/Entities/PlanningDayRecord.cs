namespace aplikasi_asep.Models.Entities;

public class PlanningDayRecord
{
    public int Id { get; set; }
    public string Day { get; set; } = string.Empty;
    public int OriginalValue { get; set; }
    public int ResultValue { get; set; }

    public int PlanningRecordId { get; set; }
    public PlanningRecord? PlanningRecord { get; set; }
}