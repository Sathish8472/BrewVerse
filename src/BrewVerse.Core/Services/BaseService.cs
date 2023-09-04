using BrewVerse.Abstractions.Dto;

namespace BrewVerse.Core.Services
{
    public abstract class BaseService
    {
        public static ApiResponseDto<T> GetSuccessResponse<T>(T data)
        {
            return new ApiResponseDto<T>
            {
                Data = data,
                StatusCode = 200,
            };
        }

        public static ApiResponseDto<T> GetErrorResponse<T>(string error, int statusCode = 500)
        {
            return new ApiResponseDto<T>
            {
                StatusCode = statusCode,
                Error = error
            };
        }
    }
}
