using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.LocalData
{
    /// <summary>
    /// TODO:
    /// </summary>
    /// This should be almost identical to ItemData, since this will be held in actual memory.
    /// We could do something like it saves 3 pages of items in it's memory, and retrieves more in a seperate thread
    /// this way, when user changes pages, it will look like it had no load time
    class CachedItemData
    {
    }
}
