namespace NodeList.Test;

public sealed class AddTests
{
    [Fact]
    public void Add_EmptyList_IncreasesCount()
    {
        NodeList<int> list = [];

        list.Add(-47);

        Assert.Single(list);
    }

    [Fact]
    public void Add_MultipleItems_CountMatches()
    {
        NodeList<int> list = [];

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        Assert.Equal(4, list.Count);
    }

    [Fact]
    public void Add_Item_AppendedToEnd()
    {
        NodeList<int> list = [1, 2, 3, 4];

        list.Add(6);

        Assert.Equal(5, list.Count);

        int[] expected = [1, 2, 3, 4, 6];
        int index = 0;

        foreach (var item in list)
        {
            Assert.Equal(expected[index++], item);
        }
    }
}
