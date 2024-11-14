using System;

public class ListaCircular<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }

    private Node head;
    public int count;
    public void AgregarAlInicio(T value)
    {
        Node newNode = new Node(value);

        if (head == null)
        {
            head = newNode;
            head.Next = head;
            head.Previous = head;
        }
        else
        {
            Node tail = head.Previous;
            newNode.Next = head;
            newNode.Previous = tail;
            tail.Next = newNode;
            head.Previous = newNode;
            head = newNode;
        }

        count++;
    }
    public void AgregarAlFinal(T value)
    {
        if (head == null)
        {
            AgregarAlInicio(value);
        }
        else
        {
            Node newNode = new Node(value);
            Node tail = head.Previous;

            tail.Next = newNode;
            newNode.Previous = tail;
            newNode.Next = head;
            head.Previous = newNode;
            count++;
        }
    }
    public void AgregarEnPosicion(T value, int position)
    {
        if (position < 0 || position > count)
        {
            throw new ArgumentOutOfRangeException("Posición inválida");
        }

        if (position == 0)
        {
            AgregarAlInicio(value);
        }
        else if (position == count)
        {
            AgregarAlFinal(value);
        }
        else
        {
            Node tem = head;

            for (int i = 0; i < position; i++)
            {
                tem = tem.Next;
            }

            Node newNode = new Node(value);
            Node prevNode = tem.Previous;

            newNode.Next = tem;
            newNode.Previous = prevNode;
            prevNode.Next = newNode;
            tem.Previous = newNode;

            count++;
        }
    }
    public void ModificarInicio(T value)
    {
        if (head == null)
        {
            throw new InvalidOperationException("La lista está vacía.");
        }

        head.Value = value;
    }
    public void ModificarFinal(T value)
    {
        if (head == null)
        {
            throw new InvalidOperationException("La lista está vacía.");
        }

        head.Previous.Value = value;
    }
    public void ModificarEnPosicion(T value, int position)
    {
        if (position < 0 || position >= count)
        {
            throw new ArgumentOutOfRangeException("Posición inválida");
        }

        Node tem = head;
        for (int i = 0; i < position; i++)
        {
            tem = tem.Next;
        }

        tem.Value = value;
    }
    public T OptenerIncio()
    {
        if (head == null)
        {
            throw new InvalidOperationException("La lista está vacía.");
        }

        return head.Value;
    }
    public T OptenerFinal()
    {
        if (head == null)
        {
            throw new InvalidOperationException("La lista está vacía.");
        }

        return head.Previous.Value;
    }
    public T OptenerEnPosicion(int position)
    {
        if (position < 0 || position >= count)
        {
            throw new ArgumentOutOfRangeException("Posición inválida");
        }

        Node tem = head;
        for (int i = 0; i < position; i++)
        {
            tem = tem.Next;
        }

        return tem.Value;
    }
    public void EliminarAlInicio()
    {
        if (head == null)
        {
            throw new InvalidOperationException("La lista está vacía.");
        }

        if (count == 1)
        {
            head = null;
        }
        else
        {
            Node tail = head.Previous;
            head = head.Next;
            head.Previous = tail;
            tail.Next = head;
        }
        count--;
    }
    public void EliminarAlFinal()
    {
        if (head == null)
        {
            throw new InvalidOperationException("La lista está vacía.");
        }

        if (count == 1)
        {
            head = null;
        }
        else
        {
            Node tail = head.Previous.Previous;
            tail.Next = head;
            head.Previous = tail;
        }
        count--;
    }

    public void EliminarEnPosicion(int position)
    {
        if (position < 0 || position >= count)
        {
            throw new ArgumentOutOfRangeException("Posición inválida");
        }

        if (position == 0)
        {
            EliminarAlInicio();
        }
        else if (position == count - 1)
        {
            EliminarAlFinal();
        }
        else
        {
            Node tem = head;
            for (int i = 0; i < position; i++)
            {
                tem = tem.Next;
            }

            Node prevNode = tem.Previous;
            Node nextNode = tem.Next;

            prevNode.Next = nextNode;
            nextNode.Previous = prevNode;
            count--;
        }
    }

}
