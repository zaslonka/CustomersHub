﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using CustomersHub.Core.Contracts;
using CustomersHub.Core.Models;

namespace CustomersHub.DataAccess.LocalMemory
{
    public class LocalMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        public LocalMemoryRepository()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;

            if (items == null)
            {
                items = new List<T>();
            }
        }

        public void Commit()
        {
            cache[className] = items;
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public T Find(string Id)
        {
            T t = items.Find(i => i.Id == Id);
            if (t != null)
            {
                return t;
            }
            else
            {
                throw new Exception(className + " Not found");
            }
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }
        
    }
}
