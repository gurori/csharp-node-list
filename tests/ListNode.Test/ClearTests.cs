namespace ListNode.Test;

public sealed class ClearTests
{
    [Fact]
    public void Clear_EmptyList_RemainsEmpty()
    {
        ListNode<int> list = [];

        list.Clear();

        Assert.Empty(list);
    }

    [Fact]
    public void Clear_SingleElement_ListBecomesEmpty()
    {
        ListNode<int> list = [42];

        list.Clear();

        Assert.Empty(list);
    }

    [Fact]
    public void Clear_MultipleElements_ListBecomesEmpty()
    {
        ListNode<int> list = [1, 2, 3, 4, 5];

        list.Clear();

        Assert.Empty(list);
    }

    [Fact]
    public void Clear_CalledMultipleTimes_DoesNotThrow()
    {
        ListNode<int> list = [1, 2, 3];

        list.Clear();
        list.Clear();
        list.Clear();

        Assert.Empty(list);
    }

    [Fact]
    public void Clear_AfterClear_CanAddNewItems()
    {
        ListNode<int> list = [1, 2, 3];

        list.Clear();

        list.Add(10);
        list.Add(20);

        Assert.Equal(2, list.Count);

        int[] expected = [10, 20];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void Clear_AfterClear_ContainsReturnsFalse()
    {
        ListNode<int> list = [1, 2, 3];

        list.Clear();

        Assert.DoesNotContain(1, list);
        Assert.DoesNotContain(2, list);
        Assert.DoesNotContain(3, list);
    }

    [Fact]
    public void Clear_AfterClear_IndexOfReturnsMinusOne()
    {
        ListNode<int> list = [1, 2, 3];

        list.Clear();

        Assert.Equal(-1, list.IndexOf(1));
    }

    [Fact]
    public void Clear_AfterClear_EnumerationReturnsNoItems()
    {
        ListNode<int> list = [1, 2, 3];

        list.Clear();

        int count = 0;

        foreach (var _ in list)
        {
            count++;
        }

        Assert.Equal(0, count);
    }

    [Fact]
    public void Clear_AfterClear_IndexerThrowsArgumentOutOfRangeException()
    {
        ListNode<int> list = [1, 2, 3];

        list.Clear();

        Assert.Throws<ArgumentOutOfRangeException>(() => _ = list[0]);
    }

    [Fact]
    public void Clear_AfterClear_InsertWorksCorrectly()
    {
        ListNode<int> list = [1, 2, 3];

        list.Clear();

        list.Insert(0, 100);

        Assert.Single(list);
        Assert.Equal(100, list[0]);
    }
}
