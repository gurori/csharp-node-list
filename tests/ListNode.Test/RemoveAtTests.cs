namespace ListNode.Test;

public sealed class RemoveAtTests
{
    [Fact]
    public void RemoveAt_EmptyList_ThrowsArgumentOutOfRangeException()
    {
        ListNode<int> list = [];

        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(0));
    }

    [Fact]
    public void RemoveAt_SingleElement_ListBecomesEmpty()
    {
        ListNode<int> list = [42];

        list.RemoveAt(0);

        Assert.Empty(list);
    }

    [Fact]
    public void RemoveAt_FirstElement_RemovesElement()
    {
        ListNode<int> list = [1, 2, 3];

        list.RemoveAt(0);

        Assert.Equal(2, list.Count);

        int[] expected = [2, 3];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void RemoveAt_MiddleElement_RemovesElement()
    {
        ListNode<int> list = [1, 2, 3];

        list.RemoveAt(1);

        Assert.Equal(2, list.Count);

        int[] expected = [1, 3];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void RemoveAt_LastElement_RemovesElement()
    {
        ListNode<int> list = [1, 2, 3];

        list.RemoveAt(2);

        Assert.Equal(2, list.Count);

        int[] expected = [1, 2];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void RemoveAt_NegativeIndex_ThrowsArgumentOutOfRangeException()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(-1));
    }

    [Fact]
    public void RemoveAt_IndexEqualToCount_ThrowsArgumentOutOfRangeException()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(list.Count));
    }

    [Fact]
    public void RemoveAt_IndexGreaterThanCount_ThrowsArgumentOutOfRangeException()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(10));
    }

    [Fact]
    public void RemoveAt_RemoveAllElements_ListBecomesEmpty()
    {
        ListNode<int> list = [1, 2, 3];

        list.RemoveAt(2);
        list.RemoveAt(1);
        list.RemoveAt(0);

        Assert.Empty(list);
    }

    [Fact]
    public void RemoveAt_AfterClear_ThrowsArgumentOutOfRangeException()
    {
        ListNode<int> list = [1, 2, 3];

        list.Clear();

        Assert.Throws<ArgumentOutOfRangeException>(() => list.RemoveAt(0));
    }

    [Fact]
    public void RemoveAt_RemoveFirstTwice_RemovesCorrectElements()
    {
        ListNode<int> list = [1, 2, 3, 4];

        list.RemoveAt(0);
        list.RemoveAt(0);

        int[] expected = [3, 4];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }

        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void RemoveAt_RemoveMiddleRepeatedly_RemovesCorrectElements()
    {
        ListNode<int> list = [1, 2, 3, 4, 5];

        list.RemoveAt(2);
        list.RemoveAt(2);

        int[] expected = [1, 2, 5];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }

        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void RemoveAt_FromLargeList_RemovesCorrectElement()
    {
        ListNode<int> list = [];

        for (int i = 0; i < 100; i++)
        {
            list.Add(i);
        }

        list.RemoveAt(50);

        Assert.Equal(99, list.Count);

        int expected = 0;

        foreach (var item in list)
        {
            if (expected == 50)
            {
                expected++;
            }

            Assert.Equal(expected++, item);
        }
    }
}
