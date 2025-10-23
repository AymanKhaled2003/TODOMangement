namespace ToDoMangament.Domain.Shared;

/// <summary>
/// Represents a validation result with errors and a value.
/// </summary>
public sealed class ValidationResult<TValue> : ResponseModel<TValue>, IValidationResult
{
    private ValidationResult(TValue value, string[] errors)
        : base(
            value,
            errors.Length > 0 ? errors[0] : "Validation failed")
    {
        Value = value;
        ErrorMessages = errors;
    }

    public TValue Value { get; }


    public string[] ErrorMessages { get; }

    public static ValidationResult<TValue> WithErrors(TValue value, string[] errors)
        => new ValidationResult<TValue>(value, errors);
}
