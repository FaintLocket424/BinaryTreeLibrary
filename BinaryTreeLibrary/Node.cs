namespace BinaryTreeLibrary;

public class Node
{
    public int Data;
    private Node? _parent;
    private Node? _leftChild;
    private Node? _rightChild;
    
    public Node(int data)
    {
        Data = data;
    }

    public Node? LeftChild
    {
        get => _leftChild;

        set
        {
            _leftChild = value;
            
            if (_leftChild is null) return;
            _leftChild.Parent = this;
        }
    }
    
    public Node? RightChild
    {
        get => _rightChild;

        set
        {
            _rightChild = value;
            
            if (_rightChild is null) return;
            _rightChild.Parent = this;
        }
    }

    public Node? Parent
    {
        get;
        set;
    }

    public override string ToString()
    {
        var payload = "";

        payload += $"Node Data: {Data}\n";
        
        if (Parent is null)
        {
            payload += $"Node Parent: null\n";
        }
        else
        {
            payload += $"Node Parent: {Parent.Data}\n";
        }
        
        if (LeftChild is null)
        {
            payload += $"Node Left Child: null\n";
        }
        else
        {
            payload += $"Node Left Child: {LeftChild.Data}\n";
        }
        
        if (RightChild is null)
        {
            payload += $"Node Right Child: null\n";
        }
        else
        {
            payload += $"Node Right Child: {RightChild.Data}\n";
        }

        return payload;
    }
}