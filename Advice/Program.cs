using Advice.Services.Advices;
using Advice.Context;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddControllers();
    builder.Services.AddScoped<IAdviceService, AdviceService>();

}

// builder.Services.AddDbContext<ApplicationDBContext>(options =>
// options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}



