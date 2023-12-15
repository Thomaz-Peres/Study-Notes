public class SinglyListNode<T>
{
    public SinglyListNode(T data)
    {
        Data = data;
        Next = null;
    }

    public SinglyListNode() {}

    public required T Data { get; set; }
    public required SinglyListNode<T>? Next { get; set; }


    public SinglyListNode<T> StartList(T data) =>
        new SinglyListNode<T>()
        {
            Data = data,
            Next = null,
        };
}

public class SinglyList<T>
{
    private SinglyListNode<T> _singlyList;
    public SinglyList()
    {
        _singlyList = new SinglyListNode<T>() { Data = default, Next = null};
    }

    public SinglyListNode<T> StartList(T data) =>
        _singlyList.StartList(data);

    public SinglyListNode<T> AddLast(T data)
    {
        SinglyListNode<T> newElement = new SinglyListNode<T>() { Data = data, Next = null };
        if (_singlyList == null)
            return _singlyList = newElement;

        while (_singlyList.Next != null)
        {
            _singlyList = _singlyList.Next;
        }

        _singlyList.Next = newElement;
        return _singlyList;
    }

    public T GetIndex(int index)
    {
        if (_singlyList == null)
            return default;

        var tempElement = _singlyList;

        if (index < 0)
            throw new ArgumentOutOfRangeException(nameof(index));

        for(int i = 0; _singlyList != null && i < index; i++ )
        {
            tempElement = tempElement.Next;
        }

        if (tempElement == null)
            throw new ArgumentOutOfRangeException(nameof(index));

        return tempElement.Data;
    }

    public int GetLenght()
    {
        if (_singlyList == null)
            return 0;

        var tempElement = _singlyList;

        int lenght = 1;
        while(tempElement != null)
        {
            tempElement = tempElement.Next;
            lenght++;
        }

        return lenght;
    }

    public List<T> GetListData()
    {
        if (_singlyList == null)
            return new List<T>();

        var tempElement = _singlyList;
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
        if (_singlyList == null)
            return false;

        var tempElement = _singlyList;

        while (tempElement != null)
        {
            if (tempElement.Data != null && tempElement.Data.Equals(delete))
            {
                tempElement = tempElement.Next;
                _singlyList = tempElement;
            }
        }
    }
}