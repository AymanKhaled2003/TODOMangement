namespace ToDoMangament.Domain.Shared;

public interface IValidationResult
{
    string[] ErrorMessages { get; }
}
