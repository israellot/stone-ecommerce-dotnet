using System.Net;

namespace GatewayApiClient.Utility {

    /// <summary>
    /// Represents a http response.
    /// </summary>
    public class HttpResponse {

        /// <summary>
        /// Serialized response from the api.
        /// </summary>
        public string RawResponse { get; private set; }

        /// <summary>
        /// Http status code from the api.
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; private set; }

        public HttpResponse(string rawResponse, HttpStatusCode httpStatusCode) {

            this.RawResponse = rawResponse;
            this.HttpStatusCode = httpStatusCode;
        }
    }

    /// <summary>
    /// Represents a http response.
    /// </summary>
    /// <typeparam name="TResponse">Defines the response class</typeparam>
    public class HttpResponse<TResponse> : HttpResponse {

        /// <summary>
        /// The deserialized response from the api.
        /// </summary>
        public TResponse Response { get; private set; }

        public HttpResponse(TResponse response, string rawResponse, HttpStatusCode httpStatusCode)
            : base(rawResponse, httpStatusCode) {

            this.Response = response;
        }
    }

    /// <summary>
    /// Represents a http response.
    /// </summary>
    /// <typeparam name="TResponse">Defines the response class</typeparam>
    /// <typeparam name="TRequest">Defines the request class</typeparam>
    public class HttpResponse<TResponse, TRequest> : HttpResponse<TResponse> {

        /// <summary>
        /// The deserialized request sent to the api.
        /// </summary>
        public TRequest Request { get; private set; }

        /// <summary>
        /// The serialized request sent to the api.
        /// </summary>
        public string RawRequest { get; private set; }

        public HttpResponse(TRequest request, string rawRequest, TResponse response, string rawResponse, HttpStatusCode httpStatusCode)
            : base(response, rawResponse, httpStatusCode) {

            this.Request = request;
            this.RawRequest = rawRequest;
        }
    }
}
