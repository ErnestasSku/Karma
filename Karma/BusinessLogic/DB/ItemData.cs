using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Utils;

namespace BusinessLogic
{
    /// <summary>
    /// Thinking: It might not make sense for ItemData to be a singletone. Since there may be a lot of data, 
    /// unless some kind of limit is ensured, so it doesn't consume too much memory. For UserProfile being a static class
    /// it probably makes sense.
    /// 
    /// Friend told me about reflections. We could probably use that when we learn how to work with DB
    /// </summary>
    /// We can add IEnumerable here
    public class ItemData : DataInteface<Item>, IEnumerable<Item>
    {
        private static ItemData instance = null;

        public List<Item> ItemList;

        private ItemData()
        {
            lock (this)
            {
                ItemList = new List<Item>();
            }
        }

        static public ItemData GetData()
        {
            if (instance == null)
                instance = new ItemData();

            return instance;
        }

        /// <summary>
        /// TODO: Loads data 
        /// </summary>
        public void LoadData()
        {

        }

        /// <summary>
        /// Thinking: Might be needed? To clear all current data and load it again
        /// </summary>
        public void ReloadData()
        {

        }


        /// <summary>
        /// TODO: Adds data to the list.
        /// </summary>
        public void AddData(Item data)
        {
            ItemList.Add(data);
        }

        /// <summary>
        /// Removes data.
        /// </summary>
        public void RemoveData(Item data)
        {
            bool removed = ItemList.Remove(data);
            
            if (!removed)
            {
                Logger.Error("Could not remove specified data");
            }
        
        }

        /// <summary>
        /// Removes data at a certain index.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveDataAt(int index)
        {
            
        }

        /// <summary>
        ///  TODO:
        /// </summary>
        /// <param name="flag"></param>
        /// <returns>A sorted list by a specific flag</returns>
        public List<Item> Sort(int flag)
        {
            return ItemList;
        }


        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)ItemList).GetEnumerator();
        }

        IEnumerator<Item> IEnumerable<Item>.GetEnumerator()
        {
            return ((IEnumerable<Item>)ItemList).GetEnumerator();
        }
    }
}
