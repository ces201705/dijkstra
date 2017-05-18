using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oceanic.DAL
{
    public interface IBaseRepository<T> where T : class
    {
    }

    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected Entities Context { get; set; }

        protected BaseRepository(Entities context)
        {
            Context = context;
        }
    }
}