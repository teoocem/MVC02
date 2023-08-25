﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IGenericOperations<T> where T : class
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        List<T> GetAll();

        T GetById(int id);
    }
}
