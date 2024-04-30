namespace ProtoBufPackages.CustomTypes;

partial class Money
{
    private const decimal Multiplier = 100m;

    public static implicit operator Money(decimal value)
    {
        return new Money
        {
            Value = (long)(value * Multiplier)
        };
    }

    public static implicit operator decimal(Money value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        return value.Value / Multiplier;
    }
}