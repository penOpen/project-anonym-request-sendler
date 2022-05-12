using System.Text.Json;
using AnonymRequest;
namespace AnonymRequest.Logic.Users;

public class UserLogic : IUser
{
    private readonly Context _context;
    public UserLogic(Context context)
    {
        _context = context;
    }

    public Task Get => throw new NotImplementedException();

    public async Task Create()
    {

        var user = new User {Token = System.Guid.NewGuid().ToString()};

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

    public async Task FindUser(string Token) 
    {
        var user = _context.Users.Find(Token);
    }
}


