using ProtoBufPackages.CustomTypes;

namespace CustomTypes.Example;

public class Example
{
    public Example()
    {
        _ = new MyMessage
        {
            Money = 135.79m,
            Page = PageToken.Create(0, 10),
        };
    }
}