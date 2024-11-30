using Microsoft.Extensions.Options;
using InfraSkillsPro.Data;
using InfraSkillsPro.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel server settings (optional)
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // Listen on port 5000
    options.ListenAnyIP(8080); // Listen on port 8080
    options.ListenAnyIP(80);   // Listen on port 80
});

// Add services to the container
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<MongoDbContext>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    return new MongoDbContext(settings.ConnectionString, settings.DatabaseName);
});
builder.Services.AddSingleton<IItemService, ItemService>(); // Register your service
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();

app.MapGet("/", () => "Welcome to InfraSkillsPro with MongoDB!");
app.MapControllers();

app.Run();
