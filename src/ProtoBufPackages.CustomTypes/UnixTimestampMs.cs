namespace ProtoBufPackages.CustomTypes;

partial class UnixTimestampMs
{
    public static implicit operator UnixTimestampMs(DateTimeOffset value)
    {
        return new UnixTimestampMs
        {
            Value = value.ToUnixTimeMilliseconds()
        };
    }

    public static implicit operator DateTimeOffset(UnixTimestampMs value)
    {
        ArgumentNullException.ThrowIfNull(value, nameof(value));
        return DateTimeOffset.FromUnixTimeMilliseconds(value.Value);
    }
}