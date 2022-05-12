namespace AnonymRequest.Logic.Requests
{
    public interface IRequest
    {
        public Task Create(string[] pool);
        public Task Get_Request();
    }
}