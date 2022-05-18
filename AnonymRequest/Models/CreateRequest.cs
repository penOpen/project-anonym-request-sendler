using AnonymRequest.Logic;

namespace AnonymRequest.Models
{
    public class CreateRequest
    {
        public string? type { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }

        public File?[] files;

        public CreateRequest(string _type, string _name, string _desc, File?[] array)
        {
            type = _type;
            name = _name;
            description = _desc;
            files = array; //tut!
        }
        
    }
    public class File
    {
        public string? name {get; set;}
        public string? code {get; set;}

        public File(string _name, string _code)
        {
            name = _name;
            code = _code;
        }
    }
}
