﻿using CoreL.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        IDataResult<List<Admin>> GetAll();
        IDataResult<List<Admin>> GetBlogByAdmin(int id);
    }
}
