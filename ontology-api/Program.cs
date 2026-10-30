public class Program
{
    public static void Main(String[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.UseHttpsRedirection();
        app.Run();
    }
}