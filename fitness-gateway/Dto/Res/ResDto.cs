using fitness_gateway.Model;

namespace fitness_gateway.Dto.Res
{
    public class ResDto<T>
    {
        public string status { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
