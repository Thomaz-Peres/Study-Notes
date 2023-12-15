using DataStructure.LinkedList.Singly;

namespace Tests;

public static class SinglyListTests
{
    [Fact]
    public static void IntLinkedList()
    {
        // Arrange
        var newList = new SinglyList<int>();

        newList.StartList(1);

        // Act
        for (int i = 2; i < 100; i++)
        {
            newList.AddLast(i);
        }

        // Assert
        Assert.Equal(100, newList.GetLenght());
    }
}
