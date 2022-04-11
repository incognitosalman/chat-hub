using Infrastructure.ExternalServices.Hubs;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SignalR using API",
        Description = "An ASP.NET Core Web API for implementing SignalR",
        TermsOfService = new Uri("https://github.com/salman-develop"),
        Contact = new OpenApiContact
        {
            Name = "Salman Malik",
            Url = new Uri("https://github.com/salman-develop")
        },
        License = new OpenApiLicense
        {
            Name = "License",
            Url = new Uri("https://github.com/salman-develop")
        }
    });


    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
    foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
    {
        if (!assembly.IsDynamic)
        {
            string xmlFile = $"{assembly.GetName().Name}.xml";
            string xmlPath = Path.Combine(baseDirectory, xmlFile);
            if (File.Exists(xmlPath))
            {
                options.IncludeXmlComments(xmlPath);
            }
        }
    }
});

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = String.Empty;
        options.DocumentTitle = "SignalR Implementation";
        options.DocExpansion(DocExpansion.None);
        options.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/chathub");

app.Run();
