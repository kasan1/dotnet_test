using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Agro.Shared.Logic.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Agro.Shared.Logic.Common.ActionFilters
{
    public class TransactionFilter : IAsyncActionFilter
    {
        private readonly DbTransaction _dbTransaction;

        public TransactionFilter(DbTransaction dbTransaction)
        {
            _dbTransaction = dbTransaction;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var connection = _dbTransaction.Connection;
            if (connection.State != ConnectionState.Open)
                throw new NotSupportedException("The provided connection was not open!");

            var executedContext = await next.Invoke();
            if (executedContext.Exception == null || executedContext.Exception is RestException { CommitTransaction: true })
            {
                await _dbTransaction.CommitAsync();
            } else
            {
                await _dbTransaction.RollbackAsync();
            }
        }
    }
}
