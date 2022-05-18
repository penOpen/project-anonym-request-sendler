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
        
        //finds file linked to ticket and return class js_file
        public async Task<js_file> Get_File(int id_file)
        {
            var file_info = new js_file();
            file_info = await _context.FindAsync<js_file>(id_file);
            
            return file_info;
        }
        
    }
}