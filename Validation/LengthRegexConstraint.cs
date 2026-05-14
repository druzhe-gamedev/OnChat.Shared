using System.Numerics;
using System.Text.RegularExpressions;

namespace OnChat.Shared.Validation;

public class LengthRegexConstraint<T>(MinMaxValue<T> length, Regex regex) : IConstraint<string> where T : INumber<T>
{
    public bool IsValid(string value) => regex.IsMatch(value);
    
    public string GetErrorMessage(string? field) => $"{field} must be between {length.ToString("and")}";
}