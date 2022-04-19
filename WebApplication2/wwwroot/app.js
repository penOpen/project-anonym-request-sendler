services.AddSingleton < IHttpContextAccessor, HttpContextAccessor > ();
services.AddReact();
services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName).AddChakraCore();
app.UseReact(config => { });
namespace WebApplication2.wwwroot
{
    public class app
    {
    }
}