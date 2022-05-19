namespace AnonymRequest.Logic.MOD
{
    public interface IMOD
    {
         public  Task<Mod?> Find_Moderator(string key);
    }
}