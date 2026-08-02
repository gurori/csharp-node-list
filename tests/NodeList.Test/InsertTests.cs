namespace NodeList.Test;

public sealed class InsertTests
{
    [Fact]
    public void Insert_IntoEmptyList_AddsElement()
    {
        NodeList<int> list = [];

        list.Insert(0, 42);

        Assert.Single(list);
        Assert.Equal(42, list[0]);
    }

    [Fact]
    public void Insert_AtBeginning_InsertsElement()
    {
        NodeList<int> list = [2, 3];

        list.Insert(0, 1);

        Assert.Equal(3, list.Count);

        int[] expected = [1, 2, 3];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void Insert_AtMiddle_InsertsElement()
    {
        NodeList<int> list = [1, 3, 4];

        list.Insert(1, 2);

        Assert.Equal(4, list.Count);

        int[] expected = [1, 2, 3, 4];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void Insert_AtEnd_AppendsElement()
    {
        NodeList<int> list = [1, 2, 3];

        list.Insert(list.Count, 4);

        Assert.Equal(4, list.Count);

        int[] expected = [1, 2, 3, 4];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void Insert_DefaultValue_InsertsSuccessfully()
    {
        NodeList<int> list = [1, 2];

        list.Insert(1, default);

        Assert.Equal(3, list.Count);
        Assert.Equal(0, list[1]);
    }

    [Fact]
    public void Insert_NullReference_InsertsSuccessfully()
    {
        NodeList<string?> list = ["A", "B"];

        list.Insert(1, null);

        Assert.Equal(3, list.Count);
        Assert.Null(list[1]);
    }

    [Fact]
    public void Insert_DuplicateValue_InsertsSuccessfully()
    {
        NodeList<int> list = [1, 2, 3];

        list.Insert(2, 2);

        int[] expected = [1, 2, 2, 3];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void Insert_NegativeIndex_ThrowsArgumentOutOfRangeException()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(-1, 0));
    }

    [Fact]
    public void Insert_IndexGreaterThanCount_ThrowsArgumentOutOfRangeException()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.Throws<ArgumentOutOfRangeException>(() => list.Insert(4, 0));
    }

    [Fact]
    public void Insert_MultipleInsertions_PreserveOrder()
    {
        NodeList<int> list = [];

        list.Insert(0, 2);
        list.Insert(0, 1);
        list.Insert(2, 4);
        list.Insert(2, 3);

        int[] expected = [1, 2, 3, 4];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }

        Assert.Equal(4, list.Count);
    }

    [Fact]
    public void Insert_AfterClear_WorksCorrectly()
    {
        NodeList<int> list = [1, 2, 3];

        list.Clear();

        list.Insert(0, 10);

        Assert.Single(list);
        Assert.Equal(10, list[0]);
    }

    [Fact]
    public void Insert_AtEndMultipleTimes_PreservesOrder()
    {
        NodeList<int> list = [1];

        list.Insert(list.Count, 2);
        list.Insert(list.Count, 3);
        list.Insert(list.Count, 4);

        int[] expected = [1, 2, 3, 4];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void Insert_AtBeginningMultipleTimes_PreservesReverseOrder()
    {
        NodeList<int> list = [];

        list.Insert(0, 3);
        list.Insert(0, 2);
        list.Insert(0, 1);

        int[] expected = [1, 2, 3];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }
}