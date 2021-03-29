using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Todo.Core.Handlers;
using Todo.Core.Repositories;
using Todo.Infra;
using Todo.Infra.Repositories;

namespace Todo.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});

            builder.Services.AddDbContext<TodoDataContext>(
                x => x.UseInMemoryDatabase("todos")
            );
            builder.Services.AddTransient<ITodoRepository, TodoRepository>();
            builder.Services.AddTransient<CreateTodoHandler>();
            builder.Services.AddTransient<MarkAsDoneHandler>();

            await builder.Build().RunAsync();
        }
    }
}