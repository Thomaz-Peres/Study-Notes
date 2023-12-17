using DataStructure.LinkedList.Doubly;

namespace Tests.LinkedListTests.DoublyList;

public static class DoublyListTests
{
    [Fact]
    public static void IntLinkedList()
    {
        // Arrange
        var newList = new DoublyLinkedList<int>(1);

        // Act
        for (int i = 2; i < 30; i++)
        {
            newList.InsertLast(i);
        }

        // Assert
        Assert.Equal(30, newList.GetLenght());
    }

    [Fact]
    public static void InsertAfterTo()
    {
        // Arrange
        var newList = new DoublyLinkedList<int>(1);

        // Act
        for (int i = 2; i < 30; i++)
        {
            newList.InsertLast(i);
        }

        newList.InsertAfterTo(10, 55);
        newList.InsertAfterTo(29, 100);

        // Assert
        Assert.Equal(32, newList.GetLenght());
    }

    [Fact]
    public static void InsertBeforeTo()
    {
        // Arrange
        var newList = new DoublyLinkedList<int>(1);

        // Act
        for (int i = 2; i < 30; i++)
        {
            newList.InsertLast(i);
        }

        newList.InsertBeforeTo(10, 55);
        newList.InsertBeforeTo(29, 100);

        // Assert
        Assert.Equal(32, newList.GetLenght());
    }

    [Fact]
    public static void Remove()
    {
        // Arrange
        var newList = new DoublyLinkedList<int>(1);

        // Act
        for (int i = 2; i < 30; i++)
        {
            newList.InsertLast(i);
        }

        newList.DeleteElement(10);

        // Assert
        Assert.Equal(29, newList.GetLenght());
    }

    [Fact]
    public static void GetIndex()
    {
        // Arrange
        var newList = new DoublyLinkedList<int>(1);

        // Act
        for (int i = 2; i < 30; i++)
        {
            newList.InsertLast(i);
        }

        // Assert
        Assert.Equal(6, newList.GetIndex(5));
        Assert.Equal(10, newList.GetIndex(9));
        Assert.Equal(20, newList.GetIndex(19));
    }
}
 