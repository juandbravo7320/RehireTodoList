namespace ToDoList.Domain.Abstractions;

public record Page(int Number, int Size)
{
    public int Start()
    {
        return Size * (Number - 1);
    }
}