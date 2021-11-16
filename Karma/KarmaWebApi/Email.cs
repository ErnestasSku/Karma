using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaWebApi
{
    public delegate void EmailActionCompletedHandler<T>(T value);
    public class Email<T>
    {
      
        public event EmailActionCompletedHandler<T> EmailActionCompleted;

        public virtual void OnEmailActionCompleted(T value)
        {
            EmailActionCompleted?.Invoke(value);
        }

    }
}
