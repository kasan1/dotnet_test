using System;
using System.Collections.Generic;
using System.Net;

namespace Agro.Shared.Logic.Common.Exceptions
{
    /// <summary>
    /// Exception used for rest operation failures
    /// </summary>
    public class RestException : Exception
    {
        #region Public properties

        /// <summary>
        /// HTTP status code 
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Collection of errors by key-value
        /// </summary>
        public IDictionary<string, string[]> Errors { get; set; }

        /// <summary>
        /// Flag to indicate weather should commit database changes or not
        /// </summary>
        public bool CommitTransaction { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpStatusCode">HTTP status code</param>
        public RestException(HttpStatusCode httpStatusCode, bool commitTransaction = false) : base()
        {
            StatusCode = httpStatusCode;
            Errors = new Dictionary<string, string[]>();
            CommitTransaction = commitTransaction;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpStatusCode">HTTP status code</param>
        /// <param name="message">Message text</param>
        public RestException(HttpStatusCode httpStatusCode, string message, bool commitTransaction = false) : base(message)
        {
            StatusCode = httpStatusCode;
            Errors = new Dictionary<string, string[]>();
            CommitTransaction = commitTransaction;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpStatusCode">HTTP status code</param>
        /// <param name="message">Message text</param>
        /// <param name="errors">Collection of errors</param>
        public RestException(HttpStatusCode httpStatusCode, string message, Dictionary<string, string[]> errors, bool commitTransaction = false) : base(message)
        {
            StatusCode = httpStatusCode;
            Errors = errors;
            CommitTransaction = commitTransaction;
        }

        public static Dictionary<string, string[]> GenerateErrorForKey(string key, string value) => new Dictionary<string, string[]> { { key, new string[] { value } } };
        public static Dictionary<string, string[]> GenerateErrorsForKey(string key, string[] values) => new Dictionary<string, string[]> { { key, values } };

        #endregion
    }
}
