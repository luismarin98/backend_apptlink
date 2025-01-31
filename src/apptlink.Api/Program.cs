using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using apptlink.Infraestructure;
using apptlink.Infraestructure.Configuracion;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddServicesCollection(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = General.NombreApi, Version = "v1" });
});

// Configure Data Protection
var dataProtectionBuilder = builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"/root/.aspnet/DataProtection-Keys"));

string? encryptionKey = Environment.GetEnvironmentVariable("ENCRYPTION_KEY");
if (!string.IsNullOrEmpty(encryptionKey))
{
    X509Certificate2? cert = new X509Certificate2(Convert.FromBase64String(encryptionKey));
    dataProtectionBuilder.ProtectKeysWithCertificate(cert);
}

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
/* builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader();
    });
}); */

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", General.NombreApi + "-" + General.TipoApi + " v1");
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseRouting();
app.UseCors("MyCorsPolicy");
app.Run();