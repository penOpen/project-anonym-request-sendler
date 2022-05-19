using AnonymRequest.Logic;

namespace AnonymRequest.Models
{
    public class CreateRequest
    {
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public File?[] Files { get; set; }

        public CreateRequest(string type, string name, string description, File?[] files)
        {
            Type = type;
            Name = name;
            Description = description;
            Files = files; //tut!
        }
        
    }
    public class File
    {
        public string? Name {get; set;}
        public string? Code {get; set;}

        public File(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }

    public class CreateResponse
    {
        public string token { get; set;}
        public string guid { get; set;}
        public CreateResponse(string Token, string G)
        {
            token = Token; 
            guid = G;
        }
    }
}
