namespace aplikasi_asep.Models.DTO;

public class SavePlanningRequest
{
    public List<PlanningDay> InputDays { get; set; } = [];
    public List<PlanningDay> ResultDays { get; set; } = [];
}