using System;
using System.Collections.Generic;
using static Backend.Item;

namespace Backend.Utils
{
    /// <summary>
    /// Item utilities class.
    /// </summary>
    public static class ItemUtilities
    {
        /// <summary>
        /// Extends a list of items to be able to sort them.
        /// Note: method extensions need to be defined in a static class, it might be or might not be
        /// logical to create a extenstions.cs class with all extended methods.
        /// Future: Optimize sorting.
        /// <param name="list">Extended list</param>
        /// <param name="flag">Determins what is the </param>
        /// <param name="descendingOrder">Whether items should be in ascending or descending order</param>
        /// <returns></returns>
        public static List<Item> SortItems(this List<Item> list, SortType flag, bool descendingOrder = false)
        {
            list.Sort((x, y) =>
            {
                int comp = flag switch
                {
                    SortType.Name => x.Name.CompareTo(y.Name),
                    SortType.Date => x.Date.CompareTo(y.Date),
                    _ => throw new ArgumentException(message: "Invalid sorting arguments"),
                };

                if (descendingOrder)
                    comp *= -1;
                return comp;

            });
            return list;
        }
        public static SortType GetSortType(int selected)
        {
            switch (selected)
            {
                case < 2:
                    return Item.SortType.Name;
                default:
                    return Item.SortType.Date;
            }
        }
    }
}
