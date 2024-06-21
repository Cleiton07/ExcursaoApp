using ExcursaoApp.Api.Filters;
using ExcursaoApp.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc(opt =>
{
    opt.EnableEndpointRouting = false;
    opt.Filters.Add<ExceptionFilter>();
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExcursaoApp();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.StartExcursaoApp();
app.Run();