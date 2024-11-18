using Byte_BillsSolution.Collection.Node;

namespace Byte_BillsSolution.Collection.Interfaces
{
    internal interface ILinkedCollection<T> where T : IComparable<T>
    {
        LinkedNode<T> GetFirst();
        LinkedNode<T> GetLast();
    }
}
