using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class TaggedQueryCommandInterceptor: DbCommandInterceptor
    {
        public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
        {
            //var sqlText = command.CommandText;
            //if (!sqlText.ToUpper().StartsWith("INSERT") || !sqlText.ToUpper().StartsWith("UPDATE"))
            //    MasterSlaveManager.SwitchToSlave(command);
            return base.ScalarExecuting(command, eventData, result);
        }
        public override ValueTask<object?> ScalarExecutedAsync(DbCommand command, CommandExecutedEventData eventData, object? result, CancellationToken cancellationToken = default)
        {
            //var sqlText = command.CommandText;
            //if (!sqlText.ToUpper().StartsWith("INSERT") || !sqlText.ToUpper().StartsWith("UPDATE"))
            //    MasterSlaveManager.SwitchToSlave(command);
            return base.ScalarExecutedAsync(command, eventData, result, cancellationToken);
        }
        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            var sqlText = command.CommandText;
            //if (!sqlText.ToUpper().StartsWith("INSERT") || !sqlText.ToUpper().StartsWith("UPDATE"))
            //    MasterSlaveManager.SwitchToSlave(command);
            return result;
        }
        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            //var sqlText = command.CommandText;
            //if (!sqlText.ToUpper().StartsWith("INSERT") || !sqlText.ToUpper().StartsWith("UPDATE"))
            //    MasterSlaveManager.SwitchToSlave(command);
            return new ValueTask<InterceptionResult<DbDataReader>>(result);
        }
        public override int NonQueryExecuted(DbCommand command, CommandExecutedEventData eventData, int result)
        {
            //MasterSlaveManager.SwitchToMaster(command);
            return base.NonQueryExecuted(command, eventData, result);
        }
        public override ValueTask<int> NonQueryExecutedAsync(DbCommand command, CommandExecutedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            //MasterSlaveManager.SwitchToMaster(command);
            return base.NonQueryExecutedAsync(command, eventData, result, cancellationToken);
        }

    }
}
