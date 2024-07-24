using fitness_gateway.Model;

namespace fitness_gateway.Dto.Res
{
    public class ResAllDto<T>
    {
        public string status { get; set; }
        public string message { get; set; }
        public ICollection<T> data { get; set; }
    }
}
