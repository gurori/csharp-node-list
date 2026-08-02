namespace NodeList.Test;

public sealed class EnumeratorTests
{
    [Fact]
    public void GetEnumerator_EmptyList_HasNoElements()
    {
        NodeList<int> list = [];

        Assert.Empty(list);
    }

    [Fact]
    public void GetEnumerator_SingleElement_EnumeratesElement()
    {
        NodeList<int> list = [42];

        int count = 0;

        foreach (var item in list)
        {
            Assert.Equal(42, item);
            count++;
        }

        Assert.Equal(1, count);
    }

    [Fact]
    public void GetEnumerator_MultipleElements_PreservesOrder()
    {
        NodeList<int> list = [1, 2, 3, 4, 5];

        int[] expected = [1, 2, 3, 4, 5];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }

        Assert.Equal(expected.Length, index);
    }

    [Fact]
    public void GetEnumerator_DefaultValues_EnumeratesCorrectly()
    {
        NodeList<int> list = [0, default, 2];

        int[] expected = [0, 0, 2];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void GetEnumerator_NullReference_EnumeratesCorrectly()
    {
        NodeList<string?> list = ["A", null, "C"];

        string?[] expected = ["A", null, "C"];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void GetEnumerator_AfterAdd_EnumeratesAllElements()
    {
        NodeList<int> list = [];

        list.Add(1);
        list.Add(2);
        list.Add(3);

        int[] expected = [1, 2, 3];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void GetEnumerator_AfterInsert_EnumeratesAllElements()
    {
        NodeList<int> list = [1, 3];

        list.Insert(1, 2);

        int[] expected = [1, 2, 3];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void GetEnumerator_AfterRemove_EnumeratesRemainingElements()
    {
        NodeList<int> list = [1, 2, 3];

        list.Remove(2);

        int[] expected = [1, 3];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void GetEnumerator_AfterRemoveAt_EnumeratesRemainingElements()
    {
        NodeList<int> list = [1, 2, 3];

        list.RemoveAt(1);

        int[] expected = [1, 3];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void GetEnumerator_AfterClear_HasNoElements()
    {
        NodeList<int> list = [1, 2, 3];

        list.Clear();

        Assert.Empty(list);
    }

    [Fact]
    public void GetEnumerator_CanEnumerateMultipleTimes()
    {
        NodeList<int> list = [1, 2, 3];

        int sum1 = 0;
        foreach (var item in list)
        {
            sum1 += item;
        }

        int sum2 = 0;
        foreach (var item in list)
        {
            sum2 += item;
        }

        Assert.Equal(sum1, sum2);
    }

    [Fact]
    public void GetEnumerator_LinqToArray_ReturnsCorrectArray()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.Equal(new[] { 1, 2, 3 }, list.ToArray());
    }

    [Fact]
    public void GetEnumerator_LinqCount_ReturnsCorrectCount()
    {
        NodeList<int> list = [1, 2, 3, 4];

        Assert.Equal(4, list.Count());
    }

    [Fact]
    public void GetEnumerator_LinqSum_ReturnsCorrectSum()
    {
        NodeList<int> list = [1, 2, 3, 4];

        Assert.Equal(10, list.Sum());
    }
}
