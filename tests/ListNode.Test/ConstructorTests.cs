namespace ListNode.Test;

public sealed class ConstructorTests
{
    [Fact]
    public void Constructor_Default_ListIsEmpty()
    {
        var list = new ListNode<int>();

        Assert.Empty(list);
    }

    [Fact]
    public void Constructor_WithEmptyCollection_CreatesEmptyList()
    {
        int[] source = [];

        var list = new ListNode<int>(source);

        Assert.Empty(list);
    }

    [Fact]
    public void Constructor_WithSingleElement_CountIsOne()
    {
        ListNode<int> list = [52];

        Assert.Single(list);
        Assert.Equal(52, list[0]);
    }

    [Fact]
    public void Constructor_WithCollection_PreservesOrder()
    {
        int[] source = [1, 2, 3, 4, 5];

        var list = new ListNode<int>(source);

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

        var list = new ListNode<string?>(source);

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

        Assert.Throws<ArgumentNullException>(() => new ListNode<int>(source!));
    }
}
