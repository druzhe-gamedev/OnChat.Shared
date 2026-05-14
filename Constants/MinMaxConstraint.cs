using System.Numerics;

namespace OnChat.Shared.Constants;

public class MinMaxConstraint<T>(MinMaxValue<T> threshold) : IConstraint<T> where T : INumber<T>
{
    public MinMaxValue<T> Threshold => threshold;
    public bool IsValid(T value) => value >= threshold.Min && value <= threshold.Max;
}