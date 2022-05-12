namespace AnonymRequest.Logic.Users;

public class UserLogic : IUser
{
    private readonly Context _context;


    public async Task  Create_User()
    {
        var new_token = System.Guid.NewGuid().ToString() ;
        var user = new User {Token = new_token};

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

    }

    public async Task Find_User(string Token)
    {
      var user = await _context.Users.FindAsync(Token);
    }
}


/*public class UserLogic : IUser
{
    private readonly Context _context;

    public async Task Create(string token)
    {
        var user = new User {Token = token};

        _context.Users.Add(user);

        await _context.SaveChangesAsync();
    }

    public async Task Delete(int Id)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == Id);
        if (user != null)
        {
            _context.Users.Remove(user);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<IList<User>> GetAll() => await _context.Users.ToListAsync();

}*/


