namespace ListNode.Test;

public sealed class IndexOfTests
{
    [Fact]
    public void IndexOf_EmptyList_ReturnsMinusOne()
    {
        ListNode<int> list = [];

        Assert.Equal(-1, list.IndexOf(1));
    }

    [Fact]
    public void IndexOf_FirstElement_ReturnsZero()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.Equal(0, list.IndexOf(1));
    }

    [Fact]
    public void IndexOf_MiddleElement_ReturnsCorrectIndex()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.Equal(1, list.IndexOf(2));
    }

    [Fact]
    public void IndexOf_LastElement_ReturnsCorrectIndex()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.Equal(2, list.IndexOf(3));
    }

    [Fact]
    public void IndexOf_ElementDoesNotExist_ReturnsMinusOne()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.Equal(-1, list.IndexOf(4));
    }

    [Fact]
    public void IndexOf_DuplicateElements_ReturnsIndexOfFirstOccurrence()
    {
        ListNode<int> list = [1, 2, 3, 2, 4];

        Assert.Equal(1, list.IndexOf(2));
    }

    [Fact]
    public void IndexOf_DefaultValueInValueType_ReturnsCorrectIndex()
    {
        ListNode<int> list = [1, default, 2];

        Assert.Equal(1, list.IndexOf(default));
    }

    [Fact]
    public void IndexOf_DefaultValueNotPresent_ReturnsMinusOne()
    {
        ListNode<int> list = [1, 2, 3];

        Assert.Equal(-1, list.IndexOf(default));
    }

    [Fact]
    public void IndexOf_NullReferencePresent_ReturnsCorrectIndex()
    {
        ListNode<string?> list = ["A", null, "B"];

        Assert.Equal(1, list.IndexOf(null));
    }

    [Fact]
    public void IndexOf_NullReferenceNotPresent_ReturnsMinusOne()
    {
        ListNode<string?> list = ["A", "B", "C"];

        Assert.Equal(-1, list.IndexOf(null));
    }

    [Fact]
    public void IndexOf_AfterRemovingElement_ReturnsMinusOne()
    {
        ListNode<int> list = [1, 2, 3];

        list.Remove(2);

        Assert.Equal(-1, list.IndexOf(2));
    }

    [Fact]
    public void IndexOf_AfterClear_ReturnsMinusOne()
    {
        ListNode<int> list = [1, 2, 3];

        list.Clear();

        Assert.Equal(-1, list.IndexOf(1));
    }

    [Fact]
    public void IndexOf_AfterInsertion_ReturnsCorrectIndex()
    {
        ListNode<int> list = [1, 3];

        list.Insert(1, 2);

        Assert.Equal(1, list.IndexOf(2));
    }

    [Fact]
    public void IndexOf_SingleElement_ReturnsZero()
    {
        ListNode<int> list = [42];

        Assert.Equal(0, list.IndexOf(42));
    }
}
