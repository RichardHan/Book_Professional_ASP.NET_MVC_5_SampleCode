namespace System.Web.Http {
    public abstract class ApiController : IHttpController, IDisposable {
        // Properties

        public HttpConfiguration Configuration { get; set; }
        public HttpControllerContext ControllerContext { get; set; }
        public ModelStateDictionary ModelState { get; }
        public HttpRequestMessage Request { get; set; }
        public HttpRequestContext RequestContext { get; set; }
        public UrlHelper Url { get; set; }
        public IPrincipal User { get; }
        // Request execution
        public virtual Task<HttpResponseMessage>
            ExecuteAsync(
                HttpControllerContext controllerContext,
                CancellationToken cancellationToken);

        protected virtual void
            Initialize(
                HttpControllerContext controllerContext);

        // Action results

        protected virtual BadRequestResult
            BadRequest();
        protected virtual InvalidModelStateResult
            BadRequest(
                ModelStateDictionary modelState);
        protected virtual BadRequestErrorMessageResult
            BadRequest(
                string message);

        protected virtual ConflictResult
            Conflict();

        protected virtual NegotiatedContentResult<T>
            Content<T>(
                HttpStatusCode statusCode,
                T value);
        protected FormattedContentResult<T>
            Content<T>(
                HttpStatusCode statusCode,
                T value,
                MediaTypeFormatter formatter);
        protected FormattedContentResult<T>
            Content<T>(
                HttpStatusCode statusCode,
                T value,
                MediaTypeFormatter formatter,
                string mediaType);
        protected virtual FormattedContentResult<T>
            Content<T>(
                HttpStatusCode statusCode,
                T value,
                MediaTypeFormatter formatter,
                MediaTypeHeaderValue mediaType);

        protected CreatedNegotiatedContentResult<T>
            Created<T>(
                string location,
                T content);
        protected virtual CreatedNegotiatedContentResult<T>
            Created<T>(
                Uri location,
                T content);

        protected CreatedAtRouteNegotiatedContentResult<T>
            CreatedAtRoute<T>(
                string routeName,
                object routeValues,
                T content);
        protected virtual CreatedAtRouteNegotiatedContentResult<T>
            CreatedAtRoute<T>(
                string routeName,
                IDictionary<string, object> routeValues,
                T content);

        protected virtual InternalServerErrorResult
            InternalServerError();
        protected virtual ExceptionResult
            InternalServerError(
                Exception exception);

        protected JsonResult<T>
            Json<T>(
                T content);
        protected JsonResult<T>
            Json<T>(
                T content,
                JsonSerializerSettings serializerSettings);
        protected virtual JsonResult<T>
            Json<T>(
                T content,
                JsonSerializerSettings serializerSettings,
                Encoding encoding);

        protected virtual NotFoundResult
            NotFound();

        protected virtual OkResult
            Ok();
        protected virtual OkNegotiatedContentResult<T>
            Ok<T>(
                T content);

        protected virtual RedirectResult
            Redirect(
                string location);
        protected virtual RedirectResult
            Redirect(
                Uri location);

        protected virtual RedirectToRouteResult
            RedirectToRoute(
                string routeName,
                IDictionary<string, object> routeValues);
        protected RedirectToRouteResult
            RedirectToRoute(
                string routeName,
                object routeValues);

        protected virtual ResponseMessageResult
            ResponseMessage(
                HttpResponseMessage response);

        protected virtual StatusCodeResult
            StatusCode(
                HttpStatusCode status);

        protected UnauthorizedResult
            Unauthorized(
                params AuthenticationHeaderValue[] challenges);
        protected virtual UnauthorizedResult
            Unauthorized(
                IEnumerable<AuthenticationHeaderValue> challenges);
    }
}
