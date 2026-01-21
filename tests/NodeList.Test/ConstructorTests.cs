namespace NodeList.Test;

public sealed class ConstructorTests
{
    [Fact]
    public void Constructor_Empty_ListHasZeroCount()
    {
        NodeList<int> list = [];

        Assert.Empty(list);
    }

    [Fact]
    public void Constructor_WithSingleElement_CountIsOne()
    {
        NodeList<int> list = [52];
    
        Assert.Single(list);
    }
}
