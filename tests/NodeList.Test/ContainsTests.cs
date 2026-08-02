namespace NodeList.Test;

public sealed class ContainsTests
{
    [Fact]
    public void Contains_EmptyList_ReturnsFalse()
    {
        NodeList<int> list = [];

        Assert.DoesNotContain(1, list);
    }

    [Fact]
    public void Contains_ExistingFirstElement_ReturnsTrue()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.Contains(1, list);
    }

    [Fact]
    public void Contains_ExistingMiddleElement_ReturnsTrue()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.Contains(2, list);
    }

    [Fact]
    public void Contains_ExistingLastElement_ReturnsTrue()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.Contains(3, list);
    }

    [Fact]
    public void Contains_NonExistingElement_ReturnsFalse()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.DoesNotContain(4, list);
    }

    [Fact]
    public void Contains_DefaultValueInValueType_ReturnsTrue()
    {
        NodeList<int> list = [1, default, 3];

        Assert.Contains(default, list);
    }

    [Fact]
    public void Contains_DefaultValueNotPresent_ReturnsFalse()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.DoesNotContain(default, list);
    }

    [Fact]
    public void Contains_NullReferencePresent_ReturnsTrue()
    {
        NodeList<string?> list = ["A", null, "B"];

        Assert.Contains(null, list);
    }

    [Fact]
    public void Contains_NullReferenceNotPresent_ReturnsFalse()
    {
        NodeList<string?> list = ["A", "B", "C"];

        Assert.DoesNotContain(null, list);
    }

    [Fact]
    public void Contains_DuplicateElements_ReturnsTrue()
    {
        NodeList<int> list = [1, 2, 2, 3];

        Assert.Contains(2, list);
    }

    [Fact]
    public void Contains_AfterRemovingElement_ReturnsFalse()
    {
        NodeList<int> list = [1, 2, 3];

        list.Remove(2);

        Assert.DoesNotContain(2, list);
    }

    [Fact]
    public void Contains_AfterClear_ReturnsFalse()
    {
        NodeList<int> list = [1, 2, 3];

        list.Clear();

        Assert.DoesNotContain(1, list);
    }
}