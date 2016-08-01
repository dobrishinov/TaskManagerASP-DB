using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTaskManagerEfDb.ViewModels
{
    public class BaseListVM<T> where T:class
    {
        public List<T> Items { get; set; }
    }
}