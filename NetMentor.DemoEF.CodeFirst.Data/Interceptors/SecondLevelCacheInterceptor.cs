using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Interceptors
{
    public class SecondLevelCacheInterceptor :DbCommandInterceptor
    {
        private readonly IMemoryCache memoryCache;

        public SecondLevelCacheInterceptor(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }


        public override async ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, 
                                                                                         CommandEventData eventData, 
                                                                                         InterceptionResult<DbDataReader> result, 
                                                                                         CancellationToken cancellationToken = default)
        {
            string key = command.CommandText + 
                         string.Join(",", command.Parameters.Cast<DbParameter>().Select(p => p.Value));

            if (memoryCache.TryGetValue(key, out List<Dictionary<string,object>>? cacheEntry))
            {
                DataTable dtCache = new DataTable();
                if (cacheEntry is not null && cacheEntry.Any())
                {
                    Console.WriteLine("read from cache");

                    foreach (var pair in cacheEntry.First())
                    {
                        dtCache.Columns.Add(pair.Key,
                            pair.Value is not null && pair.Value?.GetType() != typeof(DBNull)
                            ? pair.Value.GetType()
                            : typeof(object)
                            );
                    }

                    foreach (var rw in cacheEntry)
                    {
                        dtCache.Rows.Add(rw.Values.ToArray());
                    }

                    DataTableReader reader = dtCache.CreateDataReader();
                    Console.WriteLine("=== End read from cache ===");

                    return InterceptionResult<DbDataReader>.SuppressWithResult(reader);
                }
            }
            
            return result;
        }

        public override async ValueTask<DbDataReader> ReaderExecutedAsync(DbCommand command, 
                                                                          CommandExecutedEventData eventData, 
                                                                          DbDataReader result, 
                                                                          CancellationToken cancellationToken = default)
        {
            string key = command.CommandText
                         + string.Join(",", command.Parameters.Cast<DbParameter>().Select(p => p.Value));

            List<Dictionary<string, object>> resultList = new List<Dictionary<string, object>>();
            Dictionary<string, object> dict;

            if (result.HasRows)
            {
                while (await result.ReadAsync(cancellationToken))
                {
                    dict = new Dictionary<string, object>();
                    for (int i = 0; i < result.FieldCount; i++)
                    {
                        dict.TryAdd(result.GetName(i), result.GetValue(i));
                    }                
                    resultList.Add(dict);
                }

                if (resultList.Any())
                {
                    memoryCache.Set(key, resultList);
                }
            }

            await result.CloseAsync();

            var dtCache = new DataTable();
            if (resultList.Any())
            {
                foreach (var pair in resultList.First())
                {
                    dtCache.Columns.Add(pair.Key,
                                        pair.Value is not null && pair.Value?.GetType() != typeof(DBNull)
                                        ? pair.Value.GetType()
                                        : typeof(object)
                        );
                }

                foreach (var rw in resultList)
                {
                    dtCache.Rows.Add(rw.Values.ToArray());
                }
            }

            return dtCache.CreateDataReader();
        }
    }
}
