using UserManager.Business.IoC;
using UserManager.Data.IoC;
using UserManager.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRepositories();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureDbContext();

builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureFluentValidation();
builder.Services.AddServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();