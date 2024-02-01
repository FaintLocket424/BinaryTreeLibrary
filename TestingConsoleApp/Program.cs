using BinaryTreeLibrary;

BinarySearchTree tree = new();

tree.Insert(10);
tree.Insert(20);
tree.Insert(15);
tree.Insert(9);
tree.Insert(4);

Console.Write("Preorder: ");
foreach (Node node in tree.InOrder())
{
    Console.Write($"{node.Data}, ");
}
Console.Write('\n');

Console.Write("In Order: ");
foreach (Node node in tree.PreOrder())
{
    Console.Write($"{node.Data}, ");
}
Console.Write('\n');

Console.Write("Postorder: ");
foreach (Node node in tree.PostOrder())
{
    Console.Write($"{node.Data}, ");
}
Console.Write('\n');