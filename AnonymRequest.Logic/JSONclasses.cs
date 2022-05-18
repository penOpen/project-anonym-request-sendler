namespace AnonymRequest.Logic
{
    public class js_parsed
    {

        public string? type;
        public string? name;
        public string? description;

        public js_parsed(string t, string n, string d)
        {
            type = t;
            name = n;
            description = d;
        }
    }

    public class js_file
    {
        public string name;
        public string code;
        public js_file()
        {

        }
        public js_file(string n, string c)
        {
            name = n;
            code = c;
        }
    }

    public class js_find
    {
        public Guid master_token;
    }

    public class js_convert {

        public int Id;
        public int comment;//comment id in Comments
        public int files; // files name and code path in Files
        public string name;
        public string description;

        public string status;
        
    }
}