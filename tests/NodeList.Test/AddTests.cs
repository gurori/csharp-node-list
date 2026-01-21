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
}
