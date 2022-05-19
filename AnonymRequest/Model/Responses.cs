using System.Text.Json;

namespace AnonymRequest.Models
{
    public abstract class Responses
    {

    }

    public class CreateResponse:Responses
    {
        public string token { get; set; }
        public string guid { get; set; }
        public CreateResponse(string Token, string G)
        {
            token = Token;
            guid = G;
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize<CreateResponse>(this);
        }
    }


    public class FindResponse
    {
        public string guid { get; set; }
        public bool ok { get; set; }
        public string token { get; set; }
        public FindResponse(string _guid, bool _ok, string _token)
        {
            ok = _ok;
            guid = _guid;
            token = _token;
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize<FindResponse>(this);
        }
    }

    public class ViewResponse
    {
        public bool ok { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public Logic.File?[] files { get; set; }
        public string status { get; set; }
        public Moder? moderator { get; set; }
        public Comment?[] comments { get; set; }

        public ViewResponse(bool Ok, string Name, string Description, Logic.File?[] Files, string Status, Moder Mod, Comment?[] Comments)
        {
            ok = Ok;
            name = Name;
            description = Description;
            files = Files;
            status = Status;
            moderator = Mod;
            comments = Comments;
        }
        public override string ToString()
        {
            return JsonSerializer.Serialize<ViewResponse>(this);
        }
    }

    public class Moder
    {
        public Logic.File avatar { get; set; }
        public string name { set; get; }

        public Moder(Logic.File Ava, string Name)
        {
            avatar = Ava;
            name = Name;
        }

    }

    public class Comment
    {
        public int id { get; set; }
        public bool isMod { get; set; }
        public string text { set; get; }
        public Logic.File?[] files { get; set; }

        public Comment(int Id, bool IsMod, string Text, Logic.File?[] Files)
        {
            id = Id;
            isMod = IsMod;
            text = Text;
            files = Files;
        }
    }
}
