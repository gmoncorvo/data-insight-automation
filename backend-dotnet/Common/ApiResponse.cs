namespace backend_dotnet.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public object? Pagination { get; set; }

        public static ApiResponse<T> SuccessResponse(T data, object? pagination = null)
        {
            return new ApiResponse<T>
            {
                Success = true,
                Data = data,
                Message = null,
                Pagination = pagination
            };
        }

        public static ApiResponse<T> ErrorResponse(string message)
        {
            return new ApiResponse<T>
            {
                Success = false,
                Data = default,
                Message = message,
                Pagination = null
            };
        }
    }
}