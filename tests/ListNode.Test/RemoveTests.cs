namespace ListNode.Test;

public sealed class RemoveTests
{
    [Fact]
    public void Remove_EmptyList_ReturnsFalse()
    {
        ListNode<int> list = [];

        Assert.False(list.Remove(1));
        Assert.Empty(list);
    }

    [Fact]
    public void Remove_SingleElement_ReturnsTrueAndListBecomesEmpty()
    {
        ListNode<int> list = [42];

        Assert.True(list.Remove(42));

        Assert.Empty(list);
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void Remove_FirstElement_RemovesElement()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.True(list.Remove(1));

        int[] expected = [2, 3];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }

        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void Remove_MiddleElement_RemovesElement()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.True(list.Remove(2));

        int[] expected = [1, 3];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }

        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void Remove_LastElement_RemovesElement()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.True(list.Remove(3));

        int[] expected = [1, 2];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }

        Assert.Equal(2, list.Count);
    }

    [Fact]
    public void Remove_NonExistingElement_ReturnsFalse()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.False(list.Remove(4));

        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void Remove_DefaultValue_RemovesElement()
    {
        ListNode<int> list = [1, default, 2];

        Assert.True(list.Remove(default));

        int[] expected = [1, 2];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void Remove_NullReference_RemovesElement()
    {
        ListNode<string?> list = ["A", null, "B"];

        Assert.True(list.Remove(null));

        Assert.Equal(2, list.Count);

        string?[] expected = ["A", "B"];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void Remove_DuplicateElements_RemovesFirstOccurrence()
    {
        ListNode<int> list = [1, 2, 2, 3];

        Assert.True(list.Remove(2));

        int[] expected = [1, 2, 3];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void Remove_AllElements_ListBecomesEmpty()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.True(list.Remove(1));
        Assert.True(list.Remove(2));
        Assert.True(list.Remove(3));

        Assert.Empty(list);
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void Remove_AfterClear_ReturnsFalse()
    {
        ListNode<int> list = [1, 2, 3];

        list.Clear();

        Assert.False(list.Remove(1));
        Assert.Empty(list);
    }

    [Fact]
    public void Remove_CalledTwiceForSameElement_SecondCallReturnsFalse()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.True(list.Remove(2));
        Assert.False(list.Remove(2));

        int[] expected = [1, 3];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }

    [Fact]
    public void Remove_LastRemainingElement_AfterPreviousRemovals_ListBecomesEmpty()
    {
        ListNode<int> list = [1, 2];

        Assert.True(list.Remove(1));
        Assert.True(list.Remove(2));

        Assert.Empty(list);
        Assert.Equal(0, list.Count);
    }

    [Fact]
    public void Remove_ManyElements_RemovesCorrectElement()
    {
        ListNode<int> list = [];

        for (int i = 0; i < 100; i++)
        {
            list.Add(i);
        }

        Assert.True(list.Remove(50));

        Assert.DoesNotContain(50, list);
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
