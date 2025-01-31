namespace ToDoList.Domain.Abstractions;

public record Pageable<T>(
    int PageNumber,
    int PageSize,
    int TotalCount,
    IList<T> List) where T : class;