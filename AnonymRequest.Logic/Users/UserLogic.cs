namespace AnonymRequest.Logic.Users;

public class UserLogic : IUser
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

}


