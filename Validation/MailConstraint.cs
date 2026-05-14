using System.Numerics;
using System.Text.RegularExpressions;

namespace OnChat.Shared.Validation;

public class MailConstraint<T>(Regex regex) : IConstraint<string> where T : INumber<T>
{
    public bool IsValid(string value) => regex.IsMatch(value);

    public string GetErrorMessage(string? field) => $"Wrong email format{(string.IsNullOrEmpty(field) ? "" : $" for {field}")}";
}