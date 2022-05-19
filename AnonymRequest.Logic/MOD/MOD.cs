namespace AnonymRequest.Logic.MOD
{
    public class MOD
    {
        private readonly Context _context;

        public MOD(Context context)
        {
            _context = context;
        }

        public async Task<Mod> Find_Moderator(string key)
        {
            var found_mod =  await _context.Mods.OrderBy(p => p.token == key).FirstOrDefaultAsync();
            return found_mod;

        }

    }
}