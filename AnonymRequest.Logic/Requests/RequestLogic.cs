namespace AnonymRequest.Logic.Requests
{
    public class RequestLogic : IRequest
    {
        private readonly Context _context;

        public async Task  Create(string[] pool) //pool: instation, Header and text
        {
        //    var request = new Request {Header = pool[1], Text = pool[2], Instantion = pool[0], StatusId = 0 }; // status: 0 - created, 1 - wait, 2- completed
        //    //_context.Requests.Add(request);
        //    await _context.SaveChangesAsync();
        }

        public async Task Get_Request()
        {
            
        }
    }
}