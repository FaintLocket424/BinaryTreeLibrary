using BinaryTreeLibrary;

BinarySearchTree tree = new();

tree.Insert(8);
tree.Insert(3);
tree.Insert(1);
tree.Insert(6);
tree.Insert(7);
// tree.Insert(10);
// tree.Insert(14);
// tree.Insert(13);

Console.Write("Preorder: ");
foreach (Node node in tree.PreOrder())
{
    Console.Write($"{node.Data}, ");
}
Console.Write('\n');

Console.Write("In Order: ");
foreach (Node node in tree.InOrder())
{
    Console.Write($"{node.Data}, ");
    // Console.WriteLine(node);
}
Console.Write('\n');

Console.Write("Postorder: ");
foreach (Node node in tree.PostOrder())
{
    Console.Write($"{node.Data}, ");
}
Console.Write('\n');
Console.Write('\n');

var searchData = 3;
Console.WriteLine($"Searching for {searchData}");
(Node? nodeFound, Node? nodeParent) = tree.Search(searchData);
Console.WriteLine(nodeFound);
Console.WriteLine($"Node Parent:\n{nodeParent}");
Console.Write('\n');

var toDelete = 8;
Console.WriteLine($"{toDelete} deleted");
tree.Remove(toDelete);
Console.Write("In Order: ");
foreach (Node node in tree.InOrder())
{
    Console.WriteLine(node);
    // Console.Write($"{node.Data}, ");
}
Console.Write('\n');