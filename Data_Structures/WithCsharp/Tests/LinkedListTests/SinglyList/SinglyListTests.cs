using DataStructure.LinkedList.Singly;

namespace Tests.LinkedListTests.SinglyList;

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

    [Fact]
    public static void StringLikedList()
    {
        // Arrange
        var newList = new SinglyList<string>();

        newList.StartList("Teste 1");

        // Act
        for (int i = 2; i < 20; i++)
        {
            newList.AddLast($"Teste {i}");
        }

        // Assert
        Assert.Equal(20, newList.GetLenght());
    }

    [Fact]
    public static void DeleteValue()
    {
        // Arrange
        var newList = new SinglyList<int>();

        newList.StartList(1);

        // Act
        for (int i = 2; i < 100; i++)
            newList.AddLast(i);

        newList.DeleteElement(5);

        // Assert
        Assert.Equal(99, newList.GetLenght());
    }

    [Fact]
    public static void ObjectLinkedList()
    {
        // Arrange
        var newList = new SinglyList<object>();

        newList.StartList(new object());

        // Act
        for (int i = 2; i < 100; i++)
        {
            object obj = new { Teste = $"teste {i}" };
            newList.AddLast(obj);
        }

        // Assert
        Assert.Equal(100, newList.GetLenght());
    }

    [Fact]
    public static void GetIndexLinkedList()
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
        Assert.Equal(6, newList.GetIndex(5));
        Assert.Equal(10, newList.GetIndex(9));
        Assert.Equal(20, newList.GetIndex(19));
        Assert.Equal(33, newList.GetIndex(32));
    }

    [Fact]
    public static void GetListLinkedList()
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
        Assert.Equal(99, newList.GetListData().Count);
        Assert.Equal(9, newList.GetListData().IndexOf(10));
        Assert.Equal(10, newList.GetIndex(9));
    }
}
