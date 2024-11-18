using Byte_BillsSolution.Collection.Node;

namespace Byte_BillsSolution.Collection.Interfaces
{
    internal interface ILinkedNode<T> where T : IComparable<T>
    {
        LinkedNode<T> GetNext();
        void SetNext(LinkedNode<T> prmNext);
    }
}
