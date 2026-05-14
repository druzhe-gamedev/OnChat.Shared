namespace OnChat.Shared.Validation;

public record ValidationResult;

public record SuccessfulValidationResult : ValidationResult;

public record ValidationResultError(string Description) : ValidationResult;

public static class ValidationResultExtension
{
    extension(ValidationResult)
    {
        public static SuccessfulValidationResult Success() => new();
        public static ValidationResultError Error(string description) => new(description);

        public static ValidationResultError Error<T>(IConstraint<T> constraint, string field) =>
            new(constraint.GetErrorMessage(field));
    }
}