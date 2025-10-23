﻿namespace ToDoMangament.Domain.Shared;

public sealed class ValidationResult : ResponseModel, IValidationResult
{
    private ValidationResult(string[] errors)
        : base(false, errors.Length > 0 ? errors[0] : "Validation failed")
    {
        ErrorMessages = errors;
    }


    public string[] ErrorMessages { get; }


    public static ValidationResult WithErrors(string[] errors) => new ValidationResult(errors);
}
