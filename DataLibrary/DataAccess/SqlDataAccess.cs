﻿using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Configuration;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Data.SqlClient;

namespace DataLibrary.DataAccess
{
    public class SqlDataAccess
    {
        private IConfiguration configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetConnectionString(string connectionName = "CookBookDB")
        {
            return configuration.GetConnectionString(connectionName);
        }
        public List<T> LoadData<T>(string sql,object parameter=null)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Query<T>(sql, parameter).ToList();
            }
        }
        public List<Tout> LoadData<Tin1,Tin2,Tout>(string sql,Func<Tin1,Tin2,Tout> mapping, object parameter = null)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                var data= connection.Query<Tin1,Tin2,Tout>(sql,mapping, parameter, splitOn: "CategoryList").ToList();
                return data;
            }
        }
        public  int SaveData<T>(string sql, T data)
        {
            using (IDbConnection connection = new SqlConnection(GetConnectionString()))
            {
                return connection.Execute(sql, data);
            }
        }
    }
}
