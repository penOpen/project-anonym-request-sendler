
namespace AnonymRequest.Logic.TICKETFILES
{
    public class TICKETFILES : ITICKETFILES
    {
        private readonly Context _context;

        public TICKETFILES(Context context)
        {
            _context = context;
        }

        public async Task Bind_Ticket_File(int id_file, int id_ticket)
        {
            var new_bind = new TicketFiles{file_id = id_file, ticketinfo_id = id_ticket };
            _context.Add(new_bind);
            await _context.SaveChangesAsync();
        }

        public async Task<File?[]> GetFilesByTicketInfoId(int ticketInfo_id)
        {
            var files = new List<File?>();
            var linkes = await _context.TicketFiles.Where(p => p.ticketinfo_id == ticketInfo_id).ToListAsync();
            foreach (var link in linkes)
            {
                var raw_file = await _context.Files.Where(p => p.Id == link.file_id).FirstOrDefaultAsync();
                var file = new File(raw_file.Name, raw_file.url);
                files.Add(file);
            }
            return files.ToArray();
        }
    }
}