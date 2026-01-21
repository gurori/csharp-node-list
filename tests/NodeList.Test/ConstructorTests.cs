namespace NodeList.Test;

public sealed class ConstructorTests
{
    [Fact]
    public void Constructor_Empty_ListHasZeroCount()
    {
        NodeList<int> list = [];

        Assert.Empty(list);
    }
}
