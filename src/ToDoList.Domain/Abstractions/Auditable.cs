namespace ToDoList.Domain.Abstractions;

public abstract class Auditable
{
    public DateTime CreatedAtUtc { get; init; } = DateTime.UtcNow;
    public string CreatedBy { get; init; } = "System";
    public DateTime? UpdatedAtUtc { get; init; }
    public string? UpdatedBy { get; init; }
}