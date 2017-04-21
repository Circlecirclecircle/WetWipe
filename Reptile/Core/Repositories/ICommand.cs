using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface ICommand<T>
    {
        void Add(T model);

        void Save(T model);

        void Remove(T model);
    }
}
