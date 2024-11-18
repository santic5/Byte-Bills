using Byte_BillsSolution.Collection.Interfaces;
using Byte_BillsSolution.Collection.Node;

namespace Byte_BillsSolution.Collection.ADT
{
    /// <summary>
    /// Logic of the Linked ADT for the resctricted use of Linked Collections.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    public class Linked<T> : ILinkedCollection<T> where T : IComparable<T>
    {
        #region Attributes
        protected LinkedNode<T> attFirst = default;
        protected LinkedNode<T> attLast = default;
        protected int attMaxCapacity = 100;
        protected int attLength = 0;
        #endregion

        #region Operations
        /// <summary>
        /// Restricted constructor.
        /// USE ONLY FOR DERIVED LINKED ADT CLASS.
        /// </summary>
        public Linked()
        {
            LinkedNode<T> attAux = default;
            for (int i = 0; i < attMaxCapacity; i++)
            {
                var newNode = new LinkedNode<T>(default);
                if (attFirst == default)
                {
                    attFirst = newNode;
                }
                else
                {
                    attAux.SetNext(newNode);
                }
                attAux = newNode;
            }
            attLast = attAux;
        }

        /// <summary>
        /// Restricted constructor.
        /// USE ONLY FOR DERIVED LINKED ADT CLASS.
        /// </summary>
        /// <param name="prmCapacity">Size of complete collection</param>
        public Linked(int prmCapacity)
        {
            attMaxCapacity = prmCapacity;
            LinkedNode<T> attAux = default;
            for (int i = 0; i < attMaxCapacity; i++)
            {
                var newNode = new LinkedNode<T>(default);
                if (attFirst == default)
                {
                    attFirst = newNode;
                }
                else
                {
                    attAux.SetNext(newNode);
                }
                attAux = newNode;
            }
            attLast = attAux;
        }

        /// <summary>
        /// Get the size of the collection. 
        /// If size = 0 : The collection is empty.
        /// </summary>
        /// <returns>Length of the colection</returns>
        public int GetLength() { return attLength; }

        /// <summary>
        /// Get the first item in Collection.
        /// </summary>
        /// <returns>First node.</returns>
        public LinkedNode<T> GetFirst()
        {
            return attFirst;
        }

        /// <summary>
        /// Get the last item in Collection.
        /// </summary>
        /// <returns>Last node.</returns>
        public LinkedNode<T> GetLast()
        {
            return attLast;
        }

        /// <summary>
        /// Parse nodes to array.
        /// </summary>
        /// <returns>Array of items.</returns>
        public T[] ToArray()
        {
            T[] attAux = new T[attLength];
            if(attLength == 0) { return attAux; }
            LinkedNode<T> attItem = attFirst;
            attAux[0] = attItem.GetItem();
            for (int i = 1; i < attLength && attAux[i] != null; i++)
            {
                attItem = attItem.GetNext();
                attAux[i] = attItem.GetItem();
            }
            return attAux;
        }

        /// <summary>
        /// Parse items to collections. This function create a node per item in the array.
        /// </summary>
        /// <param name="prmArray">Array to parse.</param>
        /// <returns>Boolean check if operation was sucess.</returns>
        public bool ToItems(T[] prmArray)
        {
            LinkedNode<T> attAux = attFirst;
            attLength = prmArray.Length;
            foreach (T attItem in prmArray)
            {
                attAux.SetItem(attItem);
                attAux = attAux.GetNext();
            }
            return true;
        }

        /// <summary>
        /// Insert the item in requested index.
        /// </summary>
        /// <param name="prmIdx">Index in collection to insert.</param>
        /// <param name="prmItem">Generic item to storage in node.</param>
        /// <param name="prmPriority">Item wished priority. If your collection have'nt priority, set the parameter in 1.</param>
        /// <returns>Boolean check if operation was sucess</returns>
        public bool InsertInto(int prmIdx, T prmItem, int prmPriority)
        {
            LinkedNode<T> attNext = new(prmItem, prmPriority);
            if (attLength == 0)
            {
                attFirst = attNext;
                attLast = attFirst;
                attLength++;
                return true;
            }
            attLength++;
            LinkedNode<T> attAux = attFirst;
            if (prmIdx == 0)
            {
                attNext.SetNext(attFirst);
                attFirst = attNext;
                return true;
            }
            for (int i = 1; i < prmIdx; i++)
            {
                attAux = attAux.GetNext();
            }
            attNext.SetNext(attAux.GetNext());
            attAux.SetNext(attNext);
            return true;
        }

        /// <summary>
        /// Modify the generic item in the requested index.
        /// </summary>
        /// <param name="prmIdx">Index to modify.</param>
        /// <param name="prmItem">Item to change.</param>
        /// <param name="prmPriority">Priority of the node. Use 1 for default priority.</param>
        /// <returns></returns>
        public bool ModifyAt(int prmIdx, T prmItem, int prmPriority)
        {
            if (attLength == 0)
            {
                return false;
            }
            if (prmIdx == 0)
            {
                if (attLast == attFirst)
                {
                    attLast.SetItem(prmItem);
                }
                attFirst.SetItem(prmItem);
                return true;
            }
            LinkedNode<T> attAux = attFirst;
            for (int i = 1; i < prmIdx; i++)
            {
                attAux = attAux.GetNext();
            }
            attAux.SetItem(prmItem);
            attAux.SetPriority(prmPriority);
            return true;
        }
        /// <summary>
        /// Remove an item in collection. 
        /// This function delete the link in the previous-node and it link to the next one.
        /// </summary>
        /// <param name="prmIdx">Index to remove</param>
        /// <param name="prmItem">Returns the item that was deleted</param>
        /// <returns></returns>
        public bool RemoveAt(int prmIdx, ref T prmItem)
        {
            if (attLength == 0)
            {
                prmItem = default;
                return false;
            }
            attLength--;
            if (prmIdx == 0)
            {
                prmItem = attFirst.GetItem();
                attFirst = attFirst.GetNext();
                return true;
            }
            LinkedNode<T> attAux = attFirst;
            for (int i = 1; i < prmIdx; i++)
            {
                attAux = attAux.GetNext();
            }
            prmItem = attAux.GetNext().GetItem();
            attAux.SetNext(attAux.GetNext().GetNext());
            return true;
        }
        /// <summary>
        /// Peek an item in collection.
        /// </summary>
        /// <param name="prmIdx">Index to peek.</param>
        /// <param name="prmItem">Returns the item.</param>
        /// <returns></returns>
        public bool RetrieveAt(int prmIdx, ref T prmItem)
        {
            if (attLength == 0)
            {
                prmItem = default;
                return false;
            }
            if (prmIdx == 0)
            {
                prmItem = attFirst.GetItem();
                return true;
            }
            LinkedNode<T> attAux = attFirst;
            for (int i = 1; i < prmIdx; i++)
            {
                attAux = attAux.GetNext();
            }
            prmItem = attAux.GetItem();
            return true;
        }

        /// <summary>
        /// Parse every generic item in collection into a string.
        /// </summary>
        /// <returns>String with all items</returns>
        public override string ToString()
        {
            string attString = "";
            LinkedNode<T> attAux = attFirst;
            for (int i = 0; i < attLength; i++)
            {
                attString = attString + attAux.GetItem().ToString() + " | Priority: "+ attAux.GetPriority() + "\n";
                attAux = attAux.GetNext();
            }
            return attString;
        }
        #endregion
    }
}
