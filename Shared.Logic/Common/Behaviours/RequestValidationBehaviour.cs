using Agro.Shared.Logic.Common.Exceptions;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Shared.Logic.Common.Behaviours
{
    /// <summary>
    /// Adds request validation additional behaviour
    /// </summary>
    /// <typeparam name="TRequest">Request type</typeparam>
    /// <typeparam name="TResponse">Response type</typeparam>
    public class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        #region Private fields

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="validators">List of <see cref="IValidator"/></param>
        /// <param name="stringLocalizer">String localizer interface for <see cref="SharedResource"/></param>
        public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        #endregion

        #region Public functions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request">Request object of type TRequest</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="next">Request handler delegate</param>
        /// <returns></returns>
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);

            var errors = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .GroupBy(error => error.PropertyName)
                .ToDictionary(errorsGroup => errorsGroup.Key, errorsGroup => errorsGroup.ToList().Select(ve => ve.ErrorMessage).ToArray());

            if (errors.Any())
                throw new RestException(HttpStatusCode.BadRequest, "Произошла ошибка. Пожалуйста проверьте введенные данные", errors);

            return next();
        }

        #endregion
    }
}
