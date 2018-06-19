using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.Extensions.Microsoft.AspNetCore.Mvc
{
    public static class MapperExtensions
    {
        public static OkObjectResult Ok<T>(this IMapper mapper, object value)
        {
            var result = Mapper.Map<T>(value);
            return new OkObjectResult(result);
        }
    }
}
