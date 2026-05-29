using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorKit
{
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
        void Reset();
    }
}
