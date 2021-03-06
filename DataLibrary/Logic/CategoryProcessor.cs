﻿using CookBookBLL.DataAccess;
using CookBookBLL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CookBookBLL.Logic
{
    public class CategoryProcessor : Processor
    {
        private SqlDataAccess sqlDataAccess;
        public CategoryProcessor(SqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
            defaultStoredProceduresPrefix = "Categories";
        }
        public List<CategoryDTO> GetAll()
        {
            return sqlDataAccess.Load<CategoryDTO>(GetDefaultStoredProcedureName());
        }
        public CategoryDTO Get(int id)
        {
            var parameter = new
            {
                Id = id
            };
            return sqlDataAccess.Load<CategoryDTO>(GetDefaultStoredProcedureName(), parameter).FirstOrDefault();
        }
        public int Create(CategoryDTO category)
        {
            return sqlDataAccess.Save(GetDefaultStoredProcedureName(), category );
        }
        public int Update(CategoryDTO category)
        {
            return sqlDataAccess.Save(GetDefaultStoredProcedureName(), category );
        }
        public int Delete(int id)
        {
            var parameter = new
            {
                Id = id
            };
            //sqlDataAccess.DeleteData("IngredientsCategories_DeleteByCategories", parameter );
            return sqlDataAccess.Delete(GetDefaultStoredProcedureName(), parameter );
        }
    }
}
