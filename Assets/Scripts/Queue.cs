using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue<T> : LinkedList<T>
{
    private readonly LinkedList<T> list = new LinkedList<T>(); // The structure in which we
                                                      // store the queue.

    /**
     * Appends a value to the end of the queue.
     * 
     * @param value
     *            The value to append.
     */
    public void Enqueue(T value)
    {
        //TODO Add first Parameter
        list.Add(value);
    }

    /**
     * Peeks at the object at the front of the queue without modifying it.
     */

    public override T Peek() {
        return list.Peek();
    }

    /**
     * Removes and returns the value at the front of the queue, assuming it
     * exists.
     * 
     * @return The value at the front of the queue.
     */
    public T Dequeue()
    {
        return list.Remove(0);
    }

    /**
     * Returns whether or not the queue is empty.
     * 
     * @return True if the queue is empty, false otherwise.
     */
    public override bool IsEmpty()
    {
        return list.IsEmpty();
    }

    public override string ToString()
    {
        return list.ToString();
    }
}

public class LinkedList<T>
{
    protected Node<T> first;
    protected Node<T> last;
    int size;

    public LinkedList()
    {
        first = null;
        last = null;
        size = 0;
    }

    public void Add(int index, T value)
    {
        // create a "box" to store new data
        Node<T> node = new Node<T>(value);

        if (index == 0)
        { // adding at index 0
            if (first == null)
            { // list is empty
                first = node;
                last = node;
                size = 1;
                return;
            }
            else
            { // list is not empty
              // node links to first
                node.next = first; // don't loose the first reference
                last = first;
                first = node;
            }
        }
        else
        { // adding to non-zero index
            if (index < 0)
            {
                return;
            }
            Node<T> current = first;  // get reference to first node (we don't
                                      // change first!)

            // take current to the node at index - 1
            for (int i = 0; i < index - 1; i++)
            {
                current = current.next;
                if (current == null)
                {
                    return;
                }
            }

            // node links to node at index (current.next)
            node.next = current.next;

            // node at index-1 (current) links to node
            current.next = node;

        }
        ++size;
        if (node.next != null)
        {
            last = node;
        }
    }

    public void Add(T value)
    {
        // Need to write this one
        if (first == null)
        {
            first = new Node<T>(value);
            last = first;
            size = 1;
            return;
        }
        last.next = new Node<T>(value);
        last = last.next;
        ++size;
    }

    public virtual T Peek() {
        if( first != null ) {
            return first.value;
        }

        return default( T );
    }

    public T Remove(int index)
    {

        if (first == null)
        {
            return default(T);
        }
        if (index == 0)
        { // removing from index 0
            if (first == null)
            {
                return default(T);
            }
            T tmp = first.value;
            first = first.next;
            --size;
            if (first == null)
            {
                last = null;
            }
            return tmp;

        }
        else
        { // removing from any other index
            Node<T> current = first;

            // take current to the node at index-1
            for (int i = 0; i < index - 1; i++)
            {
                current = current.next;
                if (current == null)
                {
                    return default(T);
                }
            }

            // have the node at index-1 (current) link to
            // the node at index+1 (current.next.next)
            if (current.next != null)
            {
                T tmp = current.next.value;
                current.next = current.next.next;
                --size;
                if (current.next == null)
                {
                    last = current;
                }
                return tmp;
            }
        }
        return default(T);
    }

    public int Size()
    {

        Node<T> current = first;
        int s = 0;

        while (current != null)
        {
            ++s;
            current = current.next;
        }

        return s;
    }

    public virtual bool IsEmpty()
    {
        return first == null;
    }

    public override string ToString()
    {
        string str = "";
        Node<T> current = first;
        while (current != null)
        {
            str += current; // Use the node toString
            current = current.next;
            if (current != null)
            {
                str += ",";
            }
        }
        return str;
    }
}

public class Node<T>
{
    public T value;
    public Node<T> next;

    public Node(T _value, Node<T> _next)
    {
        value = _value;
        next = _next;
    }

    public Node(T _value)
    {
        value = _value;
        next = null;
    }

    public override string ToString()
    {
        return value.ToString();
    }
}
