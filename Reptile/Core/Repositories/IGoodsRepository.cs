﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core;

namespace Core.Repositories
{
    public interface IGoodsRepository:IQueryable<Goods>,ICommand<Goods>
    {
    }
}
