namespace NodeList.Test;

public sealed class IndexerTests
{
    [Fact]
    public void Indexer_Get_FirstElement_ReturnsCorrectValue()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.Equal(1, list[0]);
    }

    [Fact]
    public void Indexer_Get_MiddleElement_ReturnsCorrectValue()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.Equal(2, list[1]);
    }

    [Fact]
    public void Indexer_Get_LastElement_ReturnsCorrectValue()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.Equal(3, list[2]);
    }

    [Fact]
    public void Indexer_Get_SingleElement_ReturnsCorrectValue()
    {
        NodeList<int> list = [42];

        Assert.Equal(42, list[0]);
    }

    [Fact]
    public void Indexer_Get_DefaultValue_ReturnsDefaultValue()
    {
        NodeList<int> list = [default];

        Assert.Equal(default, list[0]);
    }

    [Fact]
    public void Indexer_Get_NullReference_ReturnsNull()
    {
        NodeList<string?> list = [null];

        Assert.Null(list[0]);
    }

    [Fact]
    public void Indexer_Get_NegativeIndex_ThrowsArgumentOutOfRangeException()
    {
        NodeList<int> list = [1];

        Assert.Throws<ArgumentOutOfRangeException>(() => _ = list[-1]);
    }

    [Fact]
    public void Indexer_Get_IndexEqualToCount_ThrowsArgumentOutOfRangeException()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.Throws<ArgumentOutOfRangeException>(() => _ = list[list.Count]);
    }

    [Fact]
    public void Indexer_Get_IndexGreaterThanCount_ThrowsArgumentOutOfRangeException()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.Throws<ArgumentOutOfRangeException>(() => _ = list[100]);
    }

    [Fact]
    public void Indexer_Set_FirstElement_UpdatesValue()
    {
        NodeList<int> list = [1, 2, 3];

        list[0] = 10;

        Assert.Equal(10, list[0]);
        Assert.Equal(2, list[1]);
        Assert.Equal(3, list[2]);
    }

    [Fact]
    public void Indexer_Set_MiddleElement_UpdatesValue()
    {
        NodeList<int> list = [1, 2, 3];

        list[1] = 20;

        Assert.Equal(1, list[0]);
        Assert.Equal(20, list[1]);
        Assert.Equal(3, list[2]);
    }

    [Fact]
    public void Indexer_Set_LastElement_UpdatesValue()
    {
        NodeList<int> list = [1, 2, 3];

        list[2] = 30;

        Assert.Equal(1, list[0]);
        Assert.Equal(2, list[1]);
        Assert.Equal(30, list[2]);
    }

    [Fact]
    public void Indexer_Set_DefaultValue_UpdatesValue()
    {
        NodeList<int> list = [1];

        list[0] = default;

        Assert.Equal(default, list[0]);
    }

    [Fact]
    public void Indexer_Set_NullReference_UpdatesValue()
    {
        NodeList<string?> list = ["Hello"];

        list[0] = null;

        Assert.Null(list[0]);
    }

    [Fact]
    public void Indexer_Set_NegativeIndex_ThrowsArgumentOutOfRangeException()
    {
        NodeList<int> list = [1];

        Assert.Throws<ArgumentOutOfRangeException>(() => list[-1] = 0);
    }

    [Fact]
    public void Indexer_Set_IndexEqualToCount_ThrowsArgumentOutOfRangeException()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.Throws<ArgumentOutOfRangeException>(() => list[list.Count] = 0);
    }

    [Fact]
    public void Indexer_Set_IndexGreaterThanCount_ThrowsArgumentOutOfRangeException()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.Throws<ArgumentOutOfRangeException>(() => list[100] = 0);
    }

    [Fact]
    public void Indexer_Set_DoesNotChangeCount()
    {
        NodeList<int> list = [1, 2, 3];

        list[1] = 10;

        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void Indexer_Set_PreservesOrderExceptChangedElement()
    {
        NodeList<int> list = [1, 2, 3, 4];

        list[2] = 99;

        int[] expected = [1, 2, 99, 4];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }
}