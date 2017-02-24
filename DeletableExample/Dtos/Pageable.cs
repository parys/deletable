﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeletableExample
{
    public class PageableData<T> where T : class
    {
        protected int ItemPerPageDefault = 15;
        public IEnumerable<T> List { get; set; }
        public int PageNo { get; set; }
        public int TotalItems { get; set; }
        public int ItemPerPage { get; set; }

        public PageableData(IEnumerable<T> list, int page, int totalItems = 1, int itemPerPage = 0)
        {
            if (itemPerPage == 0)
            {
                ItemPerPage = ItemPerPageDefault;
            }
            //      ItemPerPage = itemPerPage;
            PageNo = page;
            TotalItems = totalItems;//(int)decimal.Remainder(TotalItems, itemPerPage) == 0 ? TotalItems / itemPerPage : TotalItems / itemPerPage + 1;
            List = list;
        }
    }
}
