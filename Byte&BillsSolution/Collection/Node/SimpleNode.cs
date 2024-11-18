using Byte_BillsSolution.Collection.Interfaces;

namespace Byte_BillsSolution.Collection.Node
{
    /// <summary>
    /// SimpleNode class is the default class of a Node. The use of this class is restricted only for the creation of linked node.
    /// </summary>
    /// <typeparam name="T">Generic type. This allow all data types for storage.</typeparam>
    public class SimpleNode<T> : INode<T> where T : IComparable<T>
    {
        #region Attributes
        internal T attItem;
        #endregion

        #region Operations
        /// <summary>
        /// Instance a default node
        /// </summary>
        /// <param name="prmItem">Object to storage</param>
        public SimpleNode(T prmItem)
        {
            attItem = prmItem;
        }
        /// <summary>
        /// Getter of item
        /// </summary>
        /// <returns>Generic object requested</returns>
        public T GetItem()
        {
            return attItem;
        }
        /// <summary>
        /// Setter of item
        /// </summary>
        /// <param name="prmItem">T object to storage</param>
        public void SetItem(T prmItem)
        {
            attItem = prmItem;
        }

        /// <summary>
        /// Check if node value is null
        /// </summary>
        /// <returns>Boolean check</returns>
        public bool IsEmpty()
        {
            return attItem == null;
        }
        #endregion
    }
}
