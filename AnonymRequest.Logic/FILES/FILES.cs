namespace AnonymRequest.Logic.FILES
{
    public class FILES : IFILES
    {
        private readonly Context _context;

        public FILES(Context context)
        {
            _context = context;
        }

        public async Task<int> Push_File(js_file file )
        {
            
            var new_file = new Files {Name = file.name, url = file.code};
            _context.Add(new_file);
            var id = new_file.Id;
            await _context.SaveChangesAsync();

            return id;
        }
        
    }
}