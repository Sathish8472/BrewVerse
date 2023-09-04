using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewVerse.Abstractions.Dto
{
    public class ApiResponseDto<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public bool HasError => !string.IsNullOrEmpty(Error);
        public string Error { get; set; }
    }
}
