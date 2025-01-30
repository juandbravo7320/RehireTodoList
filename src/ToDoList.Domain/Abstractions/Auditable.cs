namespace ToDoList.Domain.Abstractions;

public abstract class Auditable
{
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public string CreatedBy { get; set; } = "System";
    public DateTime? UpdatedAtUtc { get; set; }
    public string? UpdatedBy { get; set; }
}