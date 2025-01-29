namespace ToDoList.Domain.Abstractions;

public abstract class Audit
{
    public DateTime CreatedAtUtc { get; init; }
    public string CreatedBy { get; init; }
    public DateTime? UpdatedAtUtc { get; init; }
    public string UpdatedBy { get; init; }
}