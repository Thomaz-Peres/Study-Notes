namespace DataStructure.LinkedList.Singly
{
    public record SinglyListNode<T>
    {
        public SinglyListNode(T data)
        {
            Data = data;
            Next = null;
        }

        public T Data { get; set; }
        public SinglyListNode<T>? Next { get; set; }
    }

    public class SinglyList<T>
    {
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

        public T GetIndex(int index)
        {
            if (Head == null)
                return default;

            var tempElement = Head;

            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

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
}
