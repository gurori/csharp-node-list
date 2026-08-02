namespace ListNode.Test;

public sealed class ContainsTests
{
    [Fact]
    public void Contains_EmptyList_ReturnsFalse()
    {
        ListNode<int> list = [];

        Assert.DoesNotContain(1, list);
    }

    [Fact]
    public void Contains_ExistingFirstElement_ReturnsTrue()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.Contains(1, list);
    }

    [Fact]
    public void Contains_ExistingMiddleElement_ReturnsTrue()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.Contains(2, list);
    }

    [Fact]
    public void Contains_ExistingLastElement_ReturnsTrue()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.Contains(3, list);
    }

    [Fact]
    public void Contains_NonExistingElement_ReturnsFalse()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.DoesNotContain(4, list);
    }

    [Fact]
    public void Contains_DefaultValueInValueType_ReturnsTrue()
    {
        ListNode<int> list = [1, default, 3];

        Assert.Contains(default, list);
    }

    [Fact]
    public void Contains_DefaultValueNotPresent_ReturnsFalse()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.DoesNotContain(default, list);
    }

    [Fact]
    public void Contains_NullReferencePresent_ReturnsTrue()
    {
        ListNode<string?> list = ["A", null, "B"];

        Assert.Contains(null, list);
    }

    [Fact]
    public void Contains_NullReferenceNotPresent_ReturnsFalse()
    {
        ListNode<string?> list = ["A", "B", "C"];

        Assert.DoesNotContain(null, list);
    }

    [Fact]
    public void Contains_DuplicateElements_ReturnsTrue()
    {
        ListNode<int> list = [1, 2, 2, 3];

        Assert.Contains(2, list);
    }

    [Fact]
    public void Contains_AfterRemovingElement_ReturnsFalse()
    {
        ListNode<int> list = [1, 2, 3];

        list.Remove(2);

        Assert.DoesNotContain(2, list);
    }

    [Fact]
    public void Contains_AfterClear_ReturnsFalse()
    {
        ListNode<int> list = [1, 2, 3];

        list.Clear();

        Assert.DoesNotContain(1, list);
    }
}
