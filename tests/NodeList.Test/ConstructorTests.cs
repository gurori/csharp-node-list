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

    [Fact]
    public void Constructor_WithCollection_PreservesOrder()
    {
        int[] source = [1, 2, 3, 4, 5];

        var list = new NodeList<int>(source);

        Assert.Equal(source.Length, list.Count);

        int index = 0;
        foreach (var item in list)
        {
            Assert.Equal(item, source[index++]);
        }
    }

    [Fact]
    public void Constructor_WithNullCollection_ThrowsException()
    {
        ICollection<int>? source = null;

        Assert.Throws<ArgumentNullException>(() =>
        {
            var list = new NodeList<int>(source);
        });
    }
}
