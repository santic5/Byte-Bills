using Byte_BillsSolution.Collection.ADT;
using Byte_BillsSolution.Collection.Interfaces;
using Byte_BillsSolution.Collection.Node;

namespace Byte_BillsSolution.Collection.Linked
{
    public class LinkedPriorityQueue<T> : Linked<T>, IQueue<T> where T : IComparable<T>
    {
        /// <summary>
        /// Enqueue a item in the collection using the param prmPriority as priority of the collection.
        /// If the priority is major than the x item in collection. The item will be put in the x-1 index. 
        /// If the priority is equals than the x item in collection. The item will be put in the x+1 index.
        /// </summary>
        /// <param name="prmItem">Generic item to storage</param>
        /// <param name="prmPriority">Priority of the item</param>
        /// <returns>Boolean check if the operation was sucess</returns>
        public bool Enqueue(T prmItem, int prmPriority)
        {
            LinkedNode<T> attAux = attFirst;
            int i;
            for (i = 0; i < attLength; i++)
            {
                if (prmPriority <= attAux.GetPriority())
                {
                    attAux = attAux.GetNext();
                    continue;
                }
                break;
            }
            return InsertInto(i, prmItem, prmPriority);
        }

        /// <summary>
        /// Dequeue the first item in the collection.
        /// </summary>
        /// <param name="prmItem">Ref of the item eliminated</param>
        /// <returns>Bollen check if the operation was sucess</returns>
        public bool Dequeue(ref T prmItem)
        {
            return RemoveAt(0, ref prmItem);
        }

        /// <summary>
        /// A view of the first item in collection
        /// </summary>
        /// <param name="prmItem">Ref of the first item</param>
        /// <returns>Boolean check if the operation was sucess</returns>
        public bool Peek(ref T prmItem)
        {
            return RetrieveAt(0, ref prmItem);
        }

        public bool IsEmpty()
        {
            return (attLength == 0);
        }
    }
}
