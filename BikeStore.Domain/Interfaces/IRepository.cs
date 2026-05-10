using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Domain.Interfaces
{
    public interface IRepository
    {
        void Add(object entity);
        void Update(object entity);
        void Remove(object entity);
    }
}
