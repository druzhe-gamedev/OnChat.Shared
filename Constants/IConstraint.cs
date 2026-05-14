namespace OnChat.Shared.Constants;

public interface IConstraint<T>
{
    bool IsValid(T value);
}