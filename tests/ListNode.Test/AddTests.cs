namespace ListNode.Test;

public sealed class AddTests
{
    [Fact]
    public void Add_EmptyList_IncreasesCount()
    {
        ListNode<int> list = [];

        list.Add(-47);

        Assert.Single(list);
    }

    [Fact]
    public void Add_MultipleItems_CountMatches()
    {
        ListNode<int> list = [];

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        Assert.Equal(4, list.Count);
    }

    [Fact]
    public void Add_Item_AppendedToEnd()
    {
        ListNode<int> list = [1, 2, 3, 4];

        list.Add(6);

        Assert.Equal(5, list.Count);

        int[] expected = [1, 2, 3, 4, 6];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void Add_FirstItem_FirstEqualsLast()
    {
        ListNode<int> list = [];

        list.Add(123);

        Assert.Single(list);

        int count = 0;
        int value = -1;

        foreach (var item in list)
        {
            count++;
            value = item;
        }

        Assert.Equal(1, count);
        Assert.Equal(123, value);
    }

    [Fact]
    public void Add_NullReferenceType_Allowed()
    {
        ListNode<string> list = [];

        list.Add(null);

        Assert.Single(list);
        Assert.Null(list[0]);
    }

    [Fact]
    public void Add_ValueType_DefaultValueHandledCorrectly()
    {
        ListNode<int> list = [];

        list.Add(default);

        Assert.Single(list);
        Assert.Equal(0, list[0]);
    }

    [Fact]
    public void Add_DuplicateItems_AllItemsAdded()
    {
        ListNode<int> list = [];

        list.Add(52);
        list.Add(51);
        list.Add(55);

        Assert.Equal(3, list.Count);

        int[] expected = [52, 51, 55];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void Add_MultipleNullValues_AllItemsAdded()
    {
        ListNode<string> list = [];

        list.Add(null);
        list.Add(null);

        Assert.Equal(2, list.Count);

        foreach (var item in list)
        {
            Assert.Null(item);
        }
    }

    [Fact]
    public void Add_AfterClear_ListContainsOnlyNewItems()
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
    public void Add_ManyItems_PreservesOrder()
    {
        ListNode<int> list = [];

        const int count = 1000;

        for (int i = 0; i < count; i++)
        {
            list.Add(i);
        }

        Assert.Equal(count, list.Count);

        int expected = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected++, item);
        }
    }
}
