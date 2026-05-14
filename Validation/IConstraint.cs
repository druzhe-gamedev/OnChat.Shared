namespace OnChat.Shared.Validation;

public interface IConstraint<T>
{
    bool IsValid(T value);
    string GetErrorMessage(string field);
}