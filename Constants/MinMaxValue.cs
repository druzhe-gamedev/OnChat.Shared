using System.Numerics;

namespace OnChat.Shared.Constants;

public record MinMaxValue<T>(T Min, T Max) where T : INumber<T>
{
    public string ToString(string separator) => $"{Min} {separator} {Max}";
    
    public override string ToString() => $"{Min}-{Max}";
}