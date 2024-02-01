namespace BinaryTreeLibrary;

public class BinarySearchTree
{
    private Node? _root;

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

    public (Node?, Node?) Search(int targetData)
    {
        if (_root is null) return (null,null);

        Node? currentNode = _root;
        Node? currentNodeParent = null;

        do
        {
            if (currentNode is null || currentNode.Data == targetData)
            {
                return (currentNode, currentNodeParent);
            }
            
            currentNodeParent = currentNode;

            if (targetData <= currentNode.Data)
            {
                // Data is less, need to look left
                currentNode = currentNode.LeftChild;
                continue;
            }

            if (targetData > currentNode.Data)
            {
                // Data is more, need to look right
                currentNode = currentNode.RightChild;
                continue;
            }
        } while (true);
    }
    
    /// <summary>
    /// Removes a specified item from the tree.
    /// </summary>
    /// <param name="data">The value to be removed.</param>
    public void Remove(int data)
    {
        // Remove Item
        (Node? nodeToDelete, Node? parentNode) = Search(data);
        if (nodeToDelete is null) return;

        // Node? parentNode = nodeToDelete.Parent;

        List<Node> nodesFound = [];

        if (nodeToDelete.LeftChild is not null)
            nodesFound.Add(nodeToDelete.LeftChild);

        if (nodeToDelete.RightChild is not null)
            nodesFound.Add(nodeToDelete.RightChild);

        switch (nodesFound.Count)
        {
            case 0:
                // Has no children
                
                // Just delete the node.

                if (parentNode is null)
                {
                    // If the parent is null,
                    // we're working with the root.
                
                    // If the root is being deleted with no children,
                    // then the root pointer can be set to null.

                    _root = null;
                    return;
                }
            
                if (parentNode.LeftChild == nodeToDelete)
                {
                    // If we're deleting the left child.
                    parentNode.LeftChild = null;
                }

                if (parentNode.RightChild == nodeToDelete)
                {
                    // If we're deleting the right child.
                    parentNode.RightChild = null;
                }
                break;
            case 1:
                Node child = nodesFound.First();
                // Has just one child
                // Just move the child node in place of the deleted one.
                
                if (parentNode is null)
                {
                    // If the parentnode is null,
                    // we're deleting a root with one child.

                    _root = child;
                    // child.Parent = null;

                    return;
                }

                // Update the parent to child pointer
                if (parentNode.LeftChild == nodeToDelete)
                {
                    // If it's the left child
                    parentNode.LeftChild = child;
                }

                if (parentNode.RightChild == nodeToDelete)
                {
                    // If it's the right child
                    parentNode.RightChild = child;
                }

                break;
            case 2:
                // Has two children
                // Swap in the smallest node that is bigger than the target.
                
                if (nodeToDelete.RightChild is null) return;
                
                Node swapNode = nodeToDelete.RightChild;
                Node swapNodeParent = nodeToDelete;
                do
                {
                    if (swapNode.LeftChild is null)
                    {
                        break;
                    }

                    swapNodeParent = swapNode;
                    swapNode = swapNode.LeftChild;
                } while (true);
                
                Console.WriteLine($"Swap Node: {swapNode.Data}");
                Console.WriteLine($"Swap Node Parent: {swapNodeParent.Data}");

                if (parentNode is null)
                {
                    _root = swapNode;
                }
                else
                {
                    if (parentNode.LeftChild == nodeToDelete)
                    {
                        // If we're deleting the left child
                        parentNode.LeftChild = swapNode;
                    }
                    else
                    {
                        // If we're deleting the right child
                        parentNode.RightChild = swapNode;
                    }
                }
                
                if (swapNodeParent.LeftChild == swapNode)
                {
                    // If the node to swap was a left child
                    swapNodeParent.LeftChild = swapNode.RightChild;
                }
                else
                {
                    // If the node to swap was a right child
                    swapNodeParent.RightChild = swapNode.RightChild;
                }
                
                swapNode.LeftChild = nodeToDelete.LeftChild;
                swapNode.RightChild = nodeToDelete.RightChild;
                
                break;
        }
    }

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
     
        // Console.WriteLine("found:");
        // Console.WriteLine(node);
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