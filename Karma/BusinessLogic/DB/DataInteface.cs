using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    interface DataInteface<T>
    {
        //Thinking about using an interface, since both ItemData and UserData might need the same methods (Might ne unneccessary)
        public void LoadData();
        public void AddData(T data);
        public void RemoveData(T data);

        public void RemoveDataAt(int index);
        
    }
}
