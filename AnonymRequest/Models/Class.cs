using AnonymRequest.Logic;

namespace AnonymRequest.Models
{
    public class CreateRequest
    {
        public string? type { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? js_name { get; set; }
        public string? js_code { get; set; }
    }
}
