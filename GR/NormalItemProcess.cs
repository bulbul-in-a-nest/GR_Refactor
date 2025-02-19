﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR
{
    public class NormalItemProcess : ProcessInventory
    {
        public override void UpdateItemInventory(Item item)
        {
            if (--item.SellIn < 0)
                item.Quality = item.Quality - 2;
            else
                item.Quality = item.Quality - 1;

            if (item.Quality < 0)
                item.Quality = 0;
        }
    }
}