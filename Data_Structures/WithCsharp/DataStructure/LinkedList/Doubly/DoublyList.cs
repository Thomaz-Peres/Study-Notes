namespace DataStructure.LinkedList.Doubly;

public record DoublyLinkedListNode<T>
{
    public DoublyLinkedListNode(T data) =>
        Data = data;

    public T Data { get; set; }
    public DoublyLinkedListNode<T>? Next { get; set; }
    public DoublyLinkedListNode<T>? Prev { get; set; }
}

public class DoublyLinkedList<T>
{
    public DoublyLinkedList(T data)
    {
        Head = new DoublyLinkedListNode<T>(data);
    }

    public DoublyLinkedListNode<T>? Head { get; set; }
    public DoublyLinkedListNode<T>? Tail { get; set; }

    public DoublyLinkedListNode<T> InsertLast(T data)
    {
        DoublyLinkedListNode<T> newNode = new(data);

        if (Head == null)
        {
            Head = newNode;
            return Head;
        }

        var tempElement = Head;
        var prevElement = tempElement;

        while (tempElement.Next != null)
        {
            tempElement = tempElement.Next;
            prevElement = tempElement;
        }

        newNode.Prev = prevElement;
        tempElement.Next = newNode;
        return newNode;
    }

    public DoublyLinkedListNode<T> InsertAfterTo(T afterTo, T data)
    {
        DoublyLinkedListNode<T> newNode = new(data);

        if (Head == null)
        {
            Head = newNode;
            return Head;
        }

        var tempElement = Head;

        while (tempElement != null)
        {
            if (tempElement.Data != null && tempElement.Data.Equals(afterTo))
            {
                newNode.Prev = tempElement;
                newNode.Next = tempElement.Next;
                tempElement.Next = newNode;
            }

            tempElement = tempElement.Next;
        }

        return newNode;
    }

    public DoublyLinkedListNode<T> InsertBeforeTo(T beforeTo, T data)
    {
        DoublyLinkedListNode<T> newNode = new(data);

        if (Head == null)
        {
            Head = newNode;
            return Head;
        }

        var tempElement = Head;

        while (tempElement != null)
        {
            if (tempElement.Data != null && tempElement.Data.Equals(beforeTo))
            {
                newNode.Next = tempElement;
                newNode.Prev = tempElement.Prev;
                tempElement.Prev.Next = newNode;
                tempElement.Prev = newNode;
            }

            tempElement = tempElement.Next;
        }

        return newNode;
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

    public List<T> GetListDatas()
    {
        if (Head == null)
            return new List<T>();

        var tempElement = Head;
        List<T> listVal = new();

        while (tempElement != null)
        {
            listVal.Add(tempElement.Data);
            tempElement = tempElement.Next;
        }

        return listVal;
    }

    public bool DeleteElement(T element)
    {
        if (Head == null)
            return false;

        var tempElement = Head;
        var currentElement = Head;

        while (currentElement != null)
        {
            if (currentElement.Data != null && currentElement.Data.Equals(element))
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

    public T? GetIndex(int index)
    {
        if (Head == null)
            return default;

        var tempElement = Head;

        if (index < 0)
            throw new IndexOutOfRangeException(nameof(index));
        
        for (int i = 0; tempElement != null && i < index; i++)
        {
            tempElement = tempElement.Next;
        }

        if (tempElement == null)
            throw new IndexOutOfRangeException(nameof(index));

        return tempElement.Data;
    }
}