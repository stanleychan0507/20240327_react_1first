using WebApplication1.Method;
using WebApplication1.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

AddServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void AddServices(WebApplicationBuilder webApplicationBuilder)
{
    webApplicationBuilder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    webApplicationBuilder.Services.AddEndpointsApiExplorer();
    webApplicationBuilder.Services.AddSwaggerGen();
    webApplicationBuilder.Services.AddScoped<BikeStoresContext>();
    webApplicationBuilder.Services.AddScoped<GenerateResult>();
    webApplicationBuilder.Services.AddScoped<GenerateReport>();
}