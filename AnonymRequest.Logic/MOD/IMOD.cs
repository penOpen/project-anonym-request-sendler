namespace AnonymRequest.Logic.MOD
{
    public interface IMOD
    {
         public  Task<Mod?> Find_Moderator(string key);
        public Task<int> Get_Type_Of_Moderator(string key);
    }
}