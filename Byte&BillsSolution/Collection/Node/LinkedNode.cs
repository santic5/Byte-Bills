using Byte_BillsSolution.Collection.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Byte_BillsSolution.Collection.Node
{
    public class LinkedNode<T> : SimpleNode<T>, ILinkedNode<T> where T : IComparable<T>
    {
        #region Attributes
        private int attPriority = 1;
        private LinkedNode<T> attNext = default;
        #endregion

        #region Operations
        public LinkedNode(T prmItem) : base(prmItem) { }
        public LinkedNode(T prmItem, int prmPriority) : base(prmItem) { attPriority = prmPriority; }
        public LinkedNode<T> GetNext()
        {
            return attNext;
        }
        public void SetNext(LinkedNode<T> prmNext)
        {
            attNext = prmNext;
        }
        public int GetPriority()
        {
            return attPriority;
        }
        public void SetPriority(int priority)
        {
            attPriority = priority;
        }
        #endregion
    }
}
