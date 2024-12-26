using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMentor.DemoEF.CodeFirst.Data.Interceptors
{
    public class ReadExampleInterceptor : DbCommandInterceptor
    {
        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            Console.WriteLine("============ HERE STARTS ============");
            return base.ReaderExecuting(command, eventData, result);
        }

        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            Console.WriteLine("============ HERE FINISH ============");
            return base.ReaderExecuted(command, eventData, result);
        }
    }
}
