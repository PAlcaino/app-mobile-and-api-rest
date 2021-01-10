using System;
namespace api_rest_debts.Models
{
    public class ServiceResponse<T>
    {
        /// <summary>
        /// Indicates if the call was successfull
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gives a friendly message of the call from the service
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Indicates an error if any
        /// </summary>
        public Error Error { get; set; }

        /// <summary>
        /// Response Data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Successful Constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public ServiceResponse(T data, string message = null)
        {
            this.Message = message;
            this.Data = data;
            this.Success = true;
        }

        /// <summary>
        /// Unsuccessful Constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public ServiceResponse(Error error)
        {
            this.Success = false;
            this.Error = error;
        }
    }

    public class ServiceResponse
    {
        /// <summary>
        /// Indicates if the call was successfull
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gives a friendly message of the call from the service
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Indicates an error if any
        /// </summary>
        public Error Error { get; set; }

        /// <summary>
        /// Successful Constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public ServiceResponse(string message = null)
        {
            this.Message = message;
            this.Success = true;
        }

        /// <summary>
        /// Unsuccessful Constructor
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public ServiceResponse(Error error)
        {
            this.Success = false;
            this.Error = error;
        }
    }
}
