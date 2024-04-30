namespace ProtoBufPackages.CustomTypes;

partial class UnixTimestamp
{
    public static implicit operator UnixTimestamp(DateTimeOffset value)
    {
        return new UnixTimestamp
        {
            Value = value.ToUnixTimeSeconds()
        };
    }

    public static implicit operator DateTimeOffset(UnixTimestamp value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        return DateTimeOffset.FromUnixTimeSeconds(value.Value);
    }
}