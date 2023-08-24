using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using Trakk.WebApi.DatabaseModels.Models;

namespace Trakk.WebApi.DatabaseModels.Helpers
{
    public static class SqlExtensions
    {


        public static List<T> RawSqlQuery<T>(this Database database, string query, Func<DbDataReader, T> map)
        {
            using var context = new TrakkDbContext();
            using var command = context.Database.GetDbConnection().CreateCommand();
            command.CommandText = query;
            command.CommandType = CommandType.Text;

            context.Database.OpenConnection();

            using var result = command.ExecuteReader();
            var entities = new List<T>();

            while (result.Read())
            {
                entities.Add(map(result));
            }

            return entities;
        }
    }
}