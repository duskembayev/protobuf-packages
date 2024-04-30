using System.Diagnostics.CodeAnalysis;
using Google.Protobuf;

namespace ProtoBufPackages.CustomTypes;

partial class PageToken
{
    [MemberNotNullWhen(false, nameof(Offset), nameof(Count))]
    public bool IsEmpty => Value is not { Length: 4 };

    public ushort? Offset
    {
        get
        {
            if (IsEmpty)
            {
                return null;
            }

            return BitConverter.ToUInt16(Value.Span[..2]);
        }
    }

    public ushort? Count
    {
        get
        {
            if (IsEmpty)
            {
                return null;
            }

            return BitConverter.ToUInt16(Value.Span[2..]);
        }
    }

    public PageToken? NextPage()
    {
        if (IsEmpty)
        {
            return null;
        }

        if (Count.Value == 0)
        {
            return null;
        }

        return Create((ushort)(Offset.Value + Count.Value), Count.Value);
    }

    public PageToken? PreviousPage()
    {
        if (IsEmpty)
        {
            return null;
        }

        var offset = Offset.Value;
        var count = Count.Value;

        if (offset == 0)
        {
            return null;
        }

        if (count == 0)
        {
            return null;
        }

        if (offset <= count)
        {
            return Create(0, count);
        }

        return Create((ushort)(offset - count), count);
    }

    public static PageToken Create(ushort offset, ushort count)
    {
        if (count == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than 0");
        }

        Span<byte> buffer = stackalloc byte[4];

        BitConverter.TryWriteBytes(buffer[..2], offset);
        BitConverter.TryWriteBytes(buffer[2..], count);

        return new PageToken
        {
            Value = ByteString.CopyFrom(buffer)
        };
    }
}