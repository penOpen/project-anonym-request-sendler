using AnonymRequest.Logic;

namespace AnonymRequest.Models
{
    public class CreateRequest
    {
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public Logic.File?[] Files { get; set; }

        public CreateRequest(string type, string name, string description, Logic.File?[] files)
        {
            Type = type;
            Name = name;
            Description = description;
            Files = files; //tut!
        }
    }

    public class FindRequest
    {
        public string? Gid { get; set; }
        public FindRequest(string gid)
        {
           Gid = gid;
        }
    }

    public class ViewRequest
    {
        public string? Gid { get; set; }
        public string? Token { get; set; }
        public ViewRequest(string gid, string token)
        {
            Gid = gid;
            Token = token;
        }
    }

    public class LoginRequest
    {
        public string? Token {get; set;}

        public LoginRequest(string token)
        {
            Token = token;
        }
    }

    public class CommentRequest
    {
        public string? Text { get; set; }
        public Logic.File?[] Files { get; set; }
        public bool IsLogged { get; set; }
        public int Ticket_id { get; set; }

        public CommentRequest(string? text, Logic.File?[] files, bool isLogged, int ticket_id)
        {
            Text = text;
            Files = files;
            IsLogged = isLogged;
            Ticket_id = ticket_id;
        }
    }
}
