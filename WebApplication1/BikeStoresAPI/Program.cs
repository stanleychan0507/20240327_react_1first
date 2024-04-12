using BikeStoresApplication.Model;
using BikeStoresApplication.Service;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddScoped<BikeStoresContext>();
builder.Services.AddScoped<GenerateResult>();
builder.Services.AddScoped<GenerateReport>();
builder.Services.AddScoped<CustomerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
var url = builder.Configuration.GetSection("frontend_url");
Console.WriteLine(url);

builder.Services.AddCors(options =>
{
    var frontEndURL = configuration.GetValue<string>("frontend_url");

    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontEndURL).AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
