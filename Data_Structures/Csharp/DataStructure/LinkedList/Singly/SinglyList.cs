namespace DataStructure.LinkedList.Singly;

public record SinglyListNode<T>
{
    public SinglyListNode(T data, SinglyListNode<T>? next = default)
    {
        Data = data;
        Next = next;
    }

    public T Data { get; private set; }
    public SinglyListNode<T>? Next { get; set; }
}

public static class SinglyListExtension
{
    public static SinglyListNode<T> Append<T>(this SinglyListNode<T> list, T data) =>
        new SinglyListNode<T>(data, list);

    public static SinglyListNode<T>? Map<T>(this SinglyListNode<T> list, Func<T, T> f)
    {
        if (list.IsEmpty())
            return null;
        else {
            var element = f(list.Data);
            if (list.Next == null)
                return null;

            var next = Map(list.Next, f);
            return next?.Append(element);
        }
    }

    public static bool IsEmpty<T>(this SinglyListNode<T> list) =>
        list == null;
}

public class SinglyList<T>
{
    // public SinglyListNode<T> Append(SinglyListNode<T> list, T data) =>
    //     new SinglyListNode<T>(data, list);

    private SinglyListNode<T>? Head { get; set; }

    public SinglyListNode<T> StartList(T data)
    {
        var newList = new SinglyListNode<T>(data);
        return Head = newList;
    }

    public SinglyListNode<T> AddLast(T data)
    {
        SinglyListNode<T> newElement = new SinglyListNode<T>(data);
        if (Head == null)
        {
            Head = newElement;
            return newElement;
        }

        var tempElement = Head;

        while (tempElement.Next != null)
        {
            tempElement = tempElement.Next;
        }

        tempElement.Next = newElement;
        return newElement;
    }

    public T? GetIndex(int index)
    {
        if (Head == null)
            return default;

        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        var tempElement = Head;

        for (int i = 0; tempElement != null && i < index; i++)
        {
            tempElement = tempElement.Next;
        }

        if (tempElement == null)
            throw new ArgumentOutOfRangeException(nameof(index));

        return tempElement.Data;
    }

    public int GetLenght()
    {
        if (Head == null)
            return 0;

        var tempElement = Head;

        int lenght = 1;
        while (tempElement != null)
        {
            tempElement = tempElement.Next;
            lenght++;
        }

        return lenght;
    }

    public List<T> GetListData()
    {
        if (Head == null)
            return new List<T>();

        var tempElement = Head;
        List<T> list = new();

        while (tempElement != null)
        {
            list.Add(tempElement.Data);
            tempElement = tempElement.Next;
        }

        return list;
    }

    public bool DeleteElement(T delete)
    {
        if (Head == null)
            return false;

        var currentElement = Head;
        var tempElement = Head;

        while (currentElement != null)
        {
            if (currentElement.Data != null && currentElement.Data.Equals(delete))
            {
                if (currentElement.Equals(Head))
                {
                    Head = Head.Next;
                    return true;
                }

                if (tempElement != null)
                {
                    tempElement.Next = currentElement.Next;
                    return true;
                }
            }

            tempElement = currentElement;
            currentElement = currentElement.Next;
        }

        return false;
    }
}
