namespace BinaryTreeLibrary;

public class BinarySearchTree
{
    // private readonly List<Node> _tree;
    private Node? _root;

    // public BinaryTree()
    // {
    //     // _tree = [];
    // }

    public Node Insert(int data)
    {
        var newNode = new Node(data);
        
        if (_root is null)
        {
            _root = newNode;
            return _root;
        }
        
        Node currentNode = _root;

        do
        {
            if (newNode.Data <= currentNode.Data)
            {
                // If the inserted value is smaller or equal, it goes left
                if (currentNode.LeftChild is null)
                {
                    // If there is no left node
                    currentNode.LeftChild = newNode;
                    break;
                }
                else
                {
                    currentNode = currentNode.LeftChild;
                }
            }
            else
            {
                // If the inserted value is greater than, it goes right
                if (currentNode.RightChild is null)
                {
                    // If there is no left node
                    currentNode.RightChild = newNode;
                    break;
                }
                else
                {
                    currentNode = currentNode.RightChild;
                }
            }
        } while (true);

        return newNode;
    }
    
    
    // public void Remove(int data)
    // {
    //     // Remove Item
    // }

    public List<Node> PreOrder()
    {
        List<Node> preorder = [];
        
        TraversePreOrder(_root, preorder);

        return preorder;
    }
    
    private void TraversePreOrder(Node? node, List<Node> output)
    {
        if (node is null)
        {
            return;
        }
        
        output.Add(node);
        TraversePreOrder(node.LeftChild, output);
        TraversePreOrder(node.RightChild, output);
    }

    public List<Node> InOrder()
    {
        List<Node> inorder = [];
        TraverseInOrder(_root, inorder);

        return inorder;
    }

    private void TraverseInOrder(Node? node, List<Node> output)
    {
        if (node is null)
        {
            return;
        }
        
        TraverseInOrder(node.LeftChild, output);
        output.Add(node);
        TraverseInOrder(node.RightChild, output);
    }

    public List<Node> PostOrder()
    {
        List<Node> postorder = [];
        
        TraversePostOrder(_root, postorder);

        return postorder;
    }
    
    private void TraversePostOrder(Node? node, List<Node> output)
    {
        if (node is null)
        {
            return;
        }
        
        TraversePostOrder(node.LeftChild, output);
        TraversePostOrder(node.RightChild, output);
        output.Add(node);
    }
}