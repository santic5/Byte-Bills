namespace Byte_BillsSolution.Collection.Interfaces
{
    internal interface INode<T> where T : IComparable<T>
    {
        T GetItem();
    }
}
