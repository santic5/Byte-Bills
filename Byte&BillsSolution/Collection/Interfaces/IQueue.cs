namespace Byte_BillsSolution.Collection.Interfaces
{
    internal interface IQueue<T> where T : IComparable<T>
    {
        bool Enqueue(T prmItem, int prmPriority);
        bool Dequeue(ref T prmItem);
        bool Peek(ref T prmItem);
    }
}
