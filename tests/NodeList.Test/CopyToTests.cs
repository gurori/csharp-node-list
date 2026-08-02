namespace NodeList.Test;

public sealed class CopyToTests
{
    [Fact]
    public void CopyTo_EmptyList_DestinationArrayUnchanged()
    {
        NodeList<int> list = [];

        int[] destination = [1, 2, 3];

        list.CopyTo(destination, 0);

        Assert.Equal([1, 2, 3], destination);
    }

    [Fact]
    public void CopyTo_ArrayExactlyFits_CopiesAllElements()
    {
        NodeList<int> list = [1, 2, 3];

        int[] destination = new int[3];

        list.CopyTo(destination, 0);

        Assert.Equal([1, 2, 3], destination);
    }

    [Fact]
    public void CopyTo_ArrayLargerThanList_CopiesElementsFromBeginning()
    {
        NodeList<int> list = [1, 2, 3];

        int[] destination = [0, 0, 0, 0, 0];

        list.CopyTo(destination, 0);

        Assert.Equal([1, 2, 3, 0, 0], destination);
    }

    [Fact]
    public void CopyTo_NonZeroArrayIndex_CopiesElementsAtSpecifiedIndex()
    {
        NodeList<int> list = [1, 2, 3];

        int[] destination = [10, 20, 30, 40, 50];

        list.CopyTo(destination, 2);

        Assert.Equal([10, 20, 1, 2, 3], destination);
    }

    [Fact]
    public void CopyTo_WithDefaultValues_CopiesCorrectly()
    {
        NodeList<int> list = [0, 1, 0];

        int[] destination = new int[3];

        list.CopyTo(destination, 0);

        Assert.Equal([0, 1, 0], destination);
    }

    [Fact]
    public void CopyTo_WithNullReferenceValues_CopiesCorrectly()
    {
        NodeList<string?> list = ["A", null, "C"];

        string?[] destination = new string?[3];

        list.CopyTo(destination, 0);

        Assert.Equal(["A", null, "C"], destination);
    }

    [Fact]
    public void CopyTo_NullArray_ThrowsArgumentNullException()
    {
        NodeList<int> list = [1, 2, 3];

        Assert.Throws<ArgumentNullException>(() => list.CopyTo(null!, 0));
    }

    [Fact]
    public void CopyTo_NegativeIndex_ThrowsArgumentOutOfRangeException()
    {
        NodeList<int> list = [1, 2, 3];

        int[] destination = new int[3];

        Assert.Throws<ArgumentOutOfRangeException>(() => list.CopyTo(destination, -1));
    }

    [Fact]
    public void CopyTo_ArrayTooSmall_ThrowsArgumentException()
    {
        NodeList<int> list = [1, 2, 3];

        int[] destination = new int[2];

        Assert.Throws<ArgumentException>(() => list.CopyTo(destination, 0));
    }

    [Fact]
    public void CopyTo_InsufficientSpaceFromIndex_ThrowsArgumentException()
    {
        NodeList<int> list = [1, 2, 3];

        int[] destination = new int[4];

        Assert.Throws<ArgumentException>(() => list.CopyTo(destination, 2));
    }

    [Fact]
    public void CopyTo_ArrayIndexEqualsLength_OnEmptyList_DoesNotThrow()
    {
        NodeList<int> list = [];

        int[] destination = [1, 2, 3];

        list.CopyTo(destination, destination.Length);

        Assert.Equal([1, 2, 3], destination);
    }

    [Fact]
    public void CopyTo_ArrayIndexEqualsLength_OnNonEmptyList_ThrowsArgumentException()
    {
        NodeList<int> list = [1];

        int[] destination = [0];

        Assert.Throws<ArgumentException>(() => list.CopyTo(destination, destination.Length));
    }
}