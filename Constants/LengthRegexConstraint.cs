using System.Numerics;
using System.Text.RegularExpressions;

namespace OnChat.Shared.Constants;

public class LengthRegexConstraint<T>(MinMaxValue<T> length, Regex regex) : IConstraint<string> where T : INumber<T>
{
    public MinMaxValue<T> Length => length;
    public bool IsValid(string value) => regex.IsMatch(value);
}