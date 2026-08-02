namespace NodeList.Test;

public sealed class ConstructorTests
{
    [Fact]
    public void Constructor_Default_ListIsEmpty()
    {
        var list = new NodeList<int>();

        Assert.Empty(list);
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void Constructor_WithEmptyCollection_CreatesEmptyList()
    {
        int[] source = [];

        var list = new NodeList<int>(source);

        Assert.Empty(list);
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void Constructor_WithSingleElement_CountIsOne()
    {
        NodeList<int> list = [52];

        Assert.Single(list);
        Assert.Equal(52, list[0]);
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
            Assert.Equal(source[index++], item);
        }
    }

    [Fact]
    public void Constructor_WithNullValues_PreservesNullValues()
    {
        string?[] source = ["A", null, "B"];

        var list = new NodeList<string?>(source);

        Assert.Equal(source.Length, list.Count);

        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(source[index++], item);
        }
    }

    [Fact]
    public void Constructor_WithNullCollection_ThrowsArgumentNullException()
    {
        IEnumerable<int>? source = null;

        Assert.Throws<ArgumentNullException>(() => new NodeList<int>(source!));
    }
}