namespace OnChat.Shared.Validation;

public interface IValidator<T> where T : BasePacket
{
    ValidationResult Validate(T packet);
}