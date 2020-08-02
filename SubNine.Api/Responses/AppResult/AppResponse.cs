

namespace SubNine.Api.Responses.AppResponse
{
    public static class AppResponse
    {
        public static SuccessResponse Success(object data) => new SuccessResponse(data);
        // public static ErrorResponse<T> Error(T errors) => new ErrorResponse<T>(errors);
    }
}