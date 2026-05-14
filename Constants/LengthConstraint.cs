namespace OnChat.Shared.Constants;

public class LengthConstraint(MinMaxValue<int> length) : IConstraint<string>
{
    public MinMaxValue<int> Length => length;
    public bool IsValid(string value) => value.Length < length.Min && value.Length > length.Max;
}