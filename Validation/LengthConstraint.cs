namespace OnChat.Shared.Validation;

public class LengthConstraint(MinMaxValue<int> length) : IConstraint<string>
{
    public bool IsValid(string value) => value.Length < length.Min && value.Length > length.Max;
    
    public string GetErrorMessage(string field) => $"{field} must be between {length.ToString("and")}";
}