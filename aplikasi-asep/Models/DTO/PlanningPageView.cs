using aplikasi_asep.Models.Entities;

namespace aplikasi_asep.Models.DTO;

public class PlanningPageView
{
    public List<PlanningDay> InputDays { get; set; } = [];
    public List<PlanningDay>? ResultDays { get; set; }
    public PagedResult<PlanningRecord> History { get; set; } = new();
}