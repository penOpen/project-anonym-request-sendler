namespace AnonymRequest.Logic
{
    public class js_parsed
    {

        public string? type;
        public string? name;
        public string? description;
        public string? js_name;
        public string? js_code;
        //public js_file files;

        //public js_parsed(string t, string n, string d, string fm, string fs)
        //{
        //    type = t;
        //    name = n;
        //    description = d;
        //    js_name = fm;
        //    js_code = fs;
        //    //files = f;
        //}
    }

    public class js_file
    {
        public string name;
        public string code;
        //public js_file(string n, string c)
        //{
        //    name = n;
        //    code = c;
        //}
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