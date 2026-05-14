namespace OnChat.Shared.Validation;

public record ValidationResult;

public record SuccessfulValidationResult : ValidationResult;

public record ValidationResultError<TError>(string Description, TError ErrorCode) : ValidationResult;

public static class ValidationResultExtension
{
    extension(ValidationResult)
    {
        public static SuccessfulValidationResult Success() => new();

        public static ValidationResultError<TError> Error<T, TError>(IConstraint<T> constraint, string field, TError errorCode) =>
            new(constraint.GetErrorMessage(field), errorCode);

        public static ValidationResultError<TError> Error<TError>(string description, TError errorCode) => new(description, errorCode);
    }
}