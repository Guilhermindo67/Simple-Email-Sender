using EmailSender.Interface;
using EmailSender.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IEmailService, EmailService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // MAPEAR O ENDPOINT OPENAPI (Faltava este passo)
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
