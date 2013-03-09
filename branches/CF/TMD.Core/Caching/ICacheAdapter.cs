using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TMD.Core.Caching
{
    public interface ICacheAdapter
    {
        void AddItem<T>(string name, T value, Double minutes = 1440);
        T GetItem<T>(string name);
        T Resolve<R, T>(string name, R param, Func<R, T> methodCall);
        T Resolve<T>(string name, Func<T> methodCall);
        void SetItem<T>(string name, T value, Double minutes = 1440);
        T ResolveList<R, T>(string name, R param, Func<R, T> methodCall, Func<T, bool> validation);
    }
}
