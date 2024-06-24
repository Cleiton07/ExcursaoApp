using ExcursaoApp.Api.Authentication;
using ExcursaoApp.Api.Filters;
using ExcursaoApp.IoC;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc(opt =>
{
    opt.EnableEndpointRouting = false;
    opt.Filters.Add<ExceptionFilter>();
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    const string SECURITY_SCHEME_ID = "jwtAuth";

    c.AddSecurityDefinition(SECURITY_SCHEME_ID, new OpenApiSecurityScheme
    {
        Description = @"
        Utilize a rota 'api/authentication' para gerar o token.

        Para as rotas que necessitam de autenticação, passe no header 'Authorization' o token gerado no formato: 'Bearer SEU_TOKEN'.

        Caso utilize o campo abaixo para colocar o token, não é necessário a palavra 'Bearer', passar direto o token.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = SECURITY_SCHEME_ID
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddExcursaoApp().AddApiAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.StartAuthentication();
app.MapControllers();

app.StartExcursaoApp();
app.Run();